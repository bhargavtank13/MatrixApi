using Matrix.DBContext;
using Matrix.Entity;
using Matrix.Model.Customer;
using Matrix.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Repository.Class
{
    public class CustomerService : ICustomerService
    {
        private readonly MatrixDBContext _context;

        public CustomerService(MatrixDBContext context)
        {
            this._context = context;

        }
        public async Task<CustomerList> GetCustomers(int pageNumber, int pageSize)
        {

            var query = _context.Customers.AsQueryable().OrderByDescending(x => x.CreatedAt);
            var totalCount = await query.CountAsync();
            var customers = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new CustomerList
            {
                Customers = customers,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        public async Task<Customer> GetCustomerDetails(Guid customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            return customer;
        }
        public async Task AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateCustomer(Guid customerId, Customer customer)
        {
            var customerDetails = await GetCustomerDetails(customerId);
            if (customerDetails != null)
            {
                customerDetails.CustomerName = customer.CustomerName;
                customerDetails.CustomerEmail = customer.CustomerEmail;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteCustomer(Guid customerId)
        {

            var customerDetails = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customerDetails != null)
            {
                _context.Customers.Remove(customerDetails);
                await _context.SaveChangesAsync();
            }

        }

    }
}
