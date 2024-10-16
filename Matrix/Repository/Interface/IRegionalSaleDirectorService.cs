using Matrix.Entity;
using Matrix.Model.RegionalSaleDirector;

namespace Matrix.Repository.Interface
{
    public interface IRegionalSaleDirectorService
    {
        Task<RegionalSalesDirectorList> GetRegionalSaleDirectors(int pageNumber, int pageSize);
        Task<RegionalSaleDirector> GetRegionalSaleDirector(Guid regionalSaleDirectorId);
        Task AddRegionalSaleDirector(RegionalSaleDirector regionalSaleDirector);
        Task UpdateRegionalSaleDirector(Guid regionalSaleDirectorId,RegionalSaleDirector regionalSaleDirector);
        Task DeleteRegionalSaleDirector(Guid regionalSaleDirectorId);
    }
}
