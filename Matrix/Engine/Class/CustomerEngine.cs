using AutoMapper;
using Matrix.Engine.Interface;
using Matrix.Entity;
using Matrix.Model.Customer;
using Matrix.Repository.Interface;

namespace Matrix.Engine.Class
{
    public class CustomerEngine : ICustomerEngine
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerEngine(ICustomerService customerService, IMapper mapper)
        {
            this._customerService = customerService;
            this._mapper = mapper;
        }
        public async Task<CustomerList> GetCustomers(int pageNumber , int pageSize )
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            return await _customerService.GetCustomers(pageNumber, pageSize);
        }
        public async Task<Customer> GetCustomerDetails(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException("Invalid customer ID provided.");
            }

            var customer = await _customerService.GetCustomerDetails(customerId);

            return customer;
        }
        public async Task AddCustomer(AddUpdateCustomerDto addUpdateCustomer)
        {
            if (addUpdateCustomer == null)
            {
                throw new ArgumentException("Invalid details provided.");
            }

            if (string.IsNullOrWhiteSpace(addUpdateCustomer.CustomerName))
            {
                throw new ArgumentException("Customer name is required.");
            }

            if (string.IsNullOrWhiteSpace(addUpdateCustomer.CustomerEmail))
            {
                throw new ArgumentException("Customer email is required.");
            }
            var rand = new Random();
            var customer = _mapper.Map<AddUpdateCustomerDto,Customer>(addUpdateCustomer);
            customer.CustomerNumber = rand.Next(1000, 1000000);

            await _customerService.AddCustomer(customer);

        }
        public async Task UpdateCustomer(Guid customerId, AddUpdateCustomerDto addUpdateCustomer)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException("Invalid customer ID provided.");
            }

            if (addUpdateCustomer == null)
            {
                throw new ArgumentException("Invalid details provided.");
            }

            if (string.IsNullOrWhiteSpace(addUpdateCustomer.CustomerName))
            {
                throw new ArgumentException("Customer name is required.");
            }

            if (string.IsNullOrWhiteSpace(addUpdateCustomer.CustomerEmail))
            {
                throw new ArgumentException("Customer email is required.");
            }

            if (!IsValidEmail(addUpdateCustomer.CustomerEmail))
            {
                throw new ArgumentException("Customer email format is invalid.");
            }

            var customer = _mapper.Map<Customer>(addUpdateCustomer);
            await _customerService.UpdateCustomer(customerId, customer);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public async Task DeleteCustomer(Guid customerId)
        {
            if (customerId == Guid.Empty)
            {
                throw new ArgumentException("Invalid customer ID provided.");
            }
            await _customerService.DeleteCustomer(customerId);
        }

    }
}
