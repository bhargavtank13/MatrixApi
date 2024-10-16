using Matrix.Entity;
using Matrix.Model.SalesRep;

namespace Matrix.Engine.Interface
{
    public interface ISalesRepEngine
    {
        Task<IEnumerable<SalesRep>> GetSalesReps();
        Task<SalesRep> GetSalesRep(Guid salesRepId);
        Task<IEnumerable<SalesRep>> GetSalesRepByRegionalSalesDirector(Guid regionalSalesDirectorId);
        Task AddSalesRep(SalesRepDto salesRepDto);
        Task UpdateSalesRep(Guid salesRepId, SalesRepDto salesRepDto);
        Task DeleteSalesRep(Guid salesRepId);


    }
}
