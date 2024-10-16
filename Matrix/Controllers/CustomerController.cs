using Matrix.Engine.Interface;
using Matrix.Entity;
using Matrix.Model.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Matrix.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerEngine _customerEngine;
        private readonly IMemoryCache _memoryCache;

        public CustomerController(ICustomerEngine customerEngine,IMemoryCache memoryCache)
        {
            this._customerEngine = customerEngine;
            this._memoryCache = memoryCache;
        }
        private static readonly List<string> _cachedKeys = new List<string>();

        private void InvalidateAllCustomerCaches()
        {
            // Loop through and remove all cached keys related to customers
            foreach (var key in _cachedKeys)
            {
                _memoryCache.Remove(key);
            }

            // Clear the list after invalidation
            _cachedKeys.Clear();
        }
        [HttpGet]
        public async Task<ActionResult<CustomerList>> GetCustomers([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var cacheKey = $"Customer_{pageNumber}_{pageSize}";
                var cacheData = _memoryCache.Get<CustomerList>(cacheKey);

                if (cacheData != null)
                {
                    return Ok(cacheData);
                }

                cacheData = await _customerEngine.GetCustomers(pageNumber, pageSize);

                if (cacheData == null || !cacheData.Customers.Any())
                {
                    return NotFound("No customers found.");
                }

                var expirationTime = DateTimeOffset.Now.AddMinutes(5);
                _memoryCache.Set(cacheKey, cacheData, expirationTime);

                if (!_cachedKeys.Contains(cacheKey))
                {
                    _cachedKeys.Add(cacheKey);
                }

                return Ok(cacheData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerDetail(Guid customerId)
        {
            try 
            {
               var customer = await _customerEngine.GetCustomerDetails(customerId);
                if (customer == null)
                {
                    return BadRequest("Customer not found.");
                }
                return Ok(customer);
            } 
            catch(Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddUpdateCustomerDto addUpdateCustomerDto)
        {
            if (addUpdateCustomerDto == null)
            {
                return BadRequest("Invalid details provided.");
            }

            try
            {
                await _customerEngine.AddCustomer(addUpdateCustomerDto);
                InvalidateAllCustomerCaches();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPatch("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(Guid  customerId, AddUpdateCustomerDto addUpdateCustomer)
        {
            if (customerId == Guid.Empty) 
            { 
                return BadRequest("Invalid Customer Id provided."); 
            }
            if (addUpdateCustomer == null)
            {
                return BadRequest("Invalid details provided.");
            }

            try
            {
                await _customerEngine.UpdateCustomer(customerId, addUpdateCustomer);
                InvalidateAllCustomerCaches();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                return BadRequest("Invalid Customer Id provided.");
            }
            try
            {
                await _customerEngine.DeleteCustomer(customerId);
                InvalidateAllCustomerCaches();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
