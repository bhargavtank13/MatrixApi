using Matrix.Entity;
using Matrix.Model.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Engine.Interface
{
    public interface ICustomerEngine
    {
        Task<CustomerList> GetCustomers(int pageNumber , int pageSize);
        Task<Customer> GetCustomerDetails(Guid customerId);
        Task AddCustomer(AddUpdateCustomerDto addUpdateCustomer);
        Task UpdateCustomer(Guid customerId, AddUpdateCustomerDto addUpdateCustomer);
        Task DeleteCustomer(Guid customerId);
    }
}
