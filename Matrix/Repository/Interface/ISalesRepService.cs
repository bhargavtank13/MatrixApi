using Matrix.Entity;

namespace Matrix.Repository.Interface
{
    public interface ISalesRepService
    {
        Task<IEnumerable<SalesRep>> GetSalesReps();
        Task<SalesRep> GetSalesRep(Guid salesRepId);
        Task<IEnumerable<SalesRep>> GetSalesRepByRegionalSalesDirector(Guid regionalSalesDirectorId);
        Task AddSalesRep(SalesRep salesRep);
        Task UpdateSalesRep(Guid salesRepId,SalesRep salesRep);
        Task DeleteSalesRep(Guid salesRepId);

    }
}
