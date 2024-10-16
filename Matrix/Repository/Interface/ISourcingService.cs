using Matrix.Entity;

namespace Matrix.Repository.Interface
{
    public interface ISourcingService
    {
        Task<IEnumerable<Sourcing>> GetSourcings();
        Task<Sourcing> GetSourcingById(Guid sourcingId);
        Task addSoucing(Sourcing sourcing);
        Task updateSoucing(Guid sourcingId,Sourcing sourcing);
        Task deleteSoucing(Guid sourcingId);
        
    }
}
