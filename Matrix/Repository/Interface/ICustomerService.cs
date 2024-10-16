using Matrix.Entity;
using Matrix.Model.Customer;

namespace Matrix.Repository.Interface
{
    public interface ICustomerService
    {
        Task<CustomerList> GetCustomers(int pageNumber , int pageSize );
        Task<Customer> GetCustomerDetails(Guid customerId);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Guid customerId, Customer customer);
        Task DeleteCustomer(Guid customerId);

    }
}
