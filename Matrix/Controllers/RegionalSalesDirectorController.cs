
using Matrix.Engine.Interface;
using Matrix.Entity;
using Matrix.Model.RegionalSaleDirector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Matrix.Controllers
{
    [ApiController]
    [Route("api/regionalSalesDirector")]
    public class RegionalSalesDirectorController : Controller
    {
        private readonly IRegionalSaleDirectorEngine _regionalSaleDirectorEngine;
        private readonly IMemoryCache _memoryCache;

        public RegionalSalesDirectorController(IRegionalSaleDirectorEngine regionalSaleDirectorEngine,IMemoryCache memoryCache)
        {
            this._regionalSaleDirectorEngine = regionalSaleDirectorEngine;
            this._memoryCache = memoryCache;
        }
        private static readonly List<string> _cachedKeys = new List<string>();
        private void InvalidateAllCustomerCaches()
        {
           
            foreach (var key in _cachedKeys)
            {
                _memoryCache.Remove(key);
            }
            _cachedKeys.Clear();
        }

        [HttpGet]
        public async Task<ActionResult<RegionalSalesDirectorList>> GetRegionalSalesDirectors([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var cacheKey = $"RegionalSalesDirector{pageNumber}_{pageSize}";
                var cacheData = _memoryCache.Get<RegionalSalesDirectorList>(cacheKey);

                if (cacheData != null)
                {
                    return Ok(cacheData);
                }
                cacheData = await _regionalSaleDirectorEngine.GetRegionalSaleDirectors(pageNumber, pageSize);

                if (cacheData == null || !cacheData.RegionalSaleDirectors.Any())
                {
                    return NotFound("No regional sales director found.");
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

        [HttpGet("{regionalSalesDirectorId}")]
        public async Task<IActionResult> GetRegionalSalesDirector(Guid regionalSalesDirectorId)
        {
            try
            {
                var regionalSalesDirector = await _regionalSaleDirectorEngine.GetRegionalSaleDirector(regionalSalesDirectorId);
                if (regionalSalesDirector == null)
                {
                    return BadRequest("Regional Sales Director not found.");
                }
                return Ok(regionalSalesDirector);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionalSalesDirector(RegionalSaleDirectorDto regionalSaleDirectorDto)
        {            
            if (regionalSaleDirectorDto == null)
            {
                return BadRequest("Invalid details provided.");
            }
            try
            {
                await _regionalSaleDirectorEngine.AddRegionalSaleDirector(regionalSaleDirectorDto);
                InvalidateAllCustomerCaches();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        [HttpPatch("{regionalSalesDirectorId}")]
        public async Task<IActionResult> UpdateRegionalSalesDirector(Guid regionalSalesDirectorId,RegionalSaleDirectorDto regionalSaleDirectorDto)
        {
            if (regionalSaleDirectorDto == null)
            {
                return BadRequest("Invalid details provided.");
            }
            try
            {
                await _regionalSaleDirectorEngine.UpdateRegionalSaleDirector(regionalSalesDirectorId,regionalSaleDirectorDto);
                InvalidateAllCustomerCaches();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{regionalSalesDirectorId}")]
        public async Task<IActionResult> DeleteRegionalSalesDirector(Guid regionalSalesDirectorId)
        {
            if (regionalSalesDirectorId == Guid.Empty)
            {
                return BadRequest("Invalid Regional Sales Director Id provided.");
            }
            try 
            {
               await _regionalSaleDirectorEngine.DeleteRegionalSaleDirector(regionalSalesDirectorId);
                InvalidateAllCustomerCaches();
                return Ok();

            } 
            catch (Exception ex) { return StatusCode(500, ex); }
        }



    }
}    