using AutoMapper;
using Matrix.Entity;
using Matrix.Model.SalesRep;

namespace Matrix.Mapping
{
    public class SalesRepMapping : Profile
    {
        public SalesRepMapping()
        {
            CreateMap<SalesRepDto,SalesRep>().ReverseMap();
            CreateMap<SalesRepListDto,SalesRep>().ReverseMap();
        }
    }
}
