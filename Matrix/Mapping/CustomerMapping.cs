using AutoMapper;
using Matrix.Entity;
using Matrix.Model.Customer;

namespace Matrix.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer,AddUpdateCustomerDto>().ReverseMap();
        }
    }
}
