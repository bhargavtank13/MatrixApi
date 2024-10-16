using Matrix.Entity;
using Matrix.Model.RegionalSaleDirector;

namespace Matrix.Engine.Interface
{
    public interface IRegionalSaleDirectorEngine
    {
        Task<RegionalSalesDirectorList> GetRegionalSaleDirectors(int pageNumber, int pageSize);
        Task<RegionalSaleDirector> GetRegionalSaleDirector(Guid regionalSaleDirectorId);
        Task AddRegionalSaleDirector(RegionalSaleDirectorDto regionalSaleDirectorDto);
        Task UpdateRegionalSaleDirector(Guid regionalSaleDirectorId, RegionalSaleDirectorDto regionalSaleDirectorDto);
        Task DeleteRegionalSaleDirector(Guid regionalSaleDirectorId);

    }
}
