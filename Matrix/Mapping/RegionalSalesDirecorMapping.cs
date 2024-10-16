using AutoMapper;
using Matrix.Entity;
using Matrix.Model.RegionalSaleDirector;

namespace Matrix.Mapping
{
    public class RegionalSalesDirecorMapping : Profile
    {
        public RegionalSalesDirecorMapping()
        {
            CreateMap<RegionalSaleDirector,RegionalSaleDirectorDto>().ReverseMap();
        }
    }
}
