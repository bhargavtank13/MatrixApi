using Matrix.DBContext;
using Matrix.Entity;
using Matrix.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Repository.Class
{
    public class SourcingService : ISourcingService
    {
        private readonly MatrixDBContext _context;

        public SourcingService(MatrixDBContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Sourcing>> GetSourcings()
        {
            return await _context.Sourcings.ToListAsync();
        }
        public async Task<Sourcing> GetSourcingById(Guid sourcingId)
        {
            return await _context.Sourcings.FirstOrDefaultAsync(x => x.SourcingID == sourcingId);
        }
        public async Task addSoucing(Sourcing sourcing)
        {
            _context.Sourcings.Add(sourcing);
            await _context.SaveChangesAsync();
        }
        public async Task updateSoucing(Guid sourcingId, Sourcing sourcing)
        {
            var sourcingPerson =  await _context.Sourcings.FirstOrDefaultAsync(x => x.SourcingID == sourcingId);
            if (sourcingPerson == null) 
            {
                return;                
            }
            sourcingPerson.SourcingName = sourcing.SourcingName;
            sourcingPerson.SourcingEmail = sourcing.SourcingEmail;
            await _context.SaveChangesAsync();

        }
        public async Task deleteSoucing(Guid sourcingId)
        {
            var sourcingPerson = await _context.Sourcings.FirstOrDefaultAsync(x => x.SourcingID == sourcingId);
            if (sourcingPerson == null)
            {
                return;
            }
            _context.Sourcings.Remove(sourcingPerson);
            await _context.SaveChangesAsync();
        }
    }
}
