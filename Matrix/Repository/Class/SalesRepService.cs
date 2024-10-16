using Matrix.DBContext;
using Matrix.Entity;
using Matrix.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Repository.Class
{
    public class SalesRepService : ISalesRepService
    {
        private readonly MatrixDBContext _context;

        public SalesRepService(MatrixDBContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<SalesRep>> GetSalesReps()
        {
            var salesReps = await _context.SalesReps.Include(x => x.RegionalSaleDirector).OrderByDescending(x => x.CreatedAt).ToListAsync();
            return salesReps;
        }
        public async Task<SalesRep> GetSalesRep(Guid salesRepId)
        {
            var salesRep = await _context.SalesReps.Include(x => x.RegionalSaleDirector).FirstOrDefaultAsync(x => x.SalesRepId == salesRepId);
            return salesRep;
        }
        public async Task<IEnumerable<SalesRep>> GetSalesRepByRegionalSalesDirector(Guid regionalSalesDirectorId)
        {
            var salesReps = await _context.SalesReps.Where(x => x.RegionalSaleDirectorId == regionalSalesDirectorId).ToListAsync();
            return salesReps;
        }

        public async Task AddSalesRep(SalesRep salesRep)
        {
            _context.SalesReps.Add(salesRep);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateSalesRep(Guid salesRepId, SalesRep salesRep)
        {            
            var salesRepDetailTask = _context.SalesReps.FirstOrDefaultAsync(x => x.SalesRepId == salesRepId);
            var regionalSalesDirectorDetailTask = _context.RegionalSaleDirectors.FirstOrDefaultAsync(x => x.RegionalSaleDirectorId == salesRep.RegionalSaleDirectorId);
            await Task.WhenAll(salesRepDetailTask, regionalSalesDirectorDetailTask);
            var salesRepDetail = salesRepDetailTask.Result;
            var regionalSalesDirectorDetail = regionalSalesDirectorDetailTask.Result;
            if (salesRepDetail == null || regionalSalesDirectorDetail == null)
            {
                return;
            }
            salesRepDetail.SaleRepName = salesRep.SaleRepName;
            salesRepDetail.SaleRepEmail = salesRep.SaleRepEmail;
            salesRepDetail.RegionalSaleDirectorId = regionalSalesDirectorDetail.RegionalSaleDirectorId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSalesRep(Guid salesRepId)
        {
            var salesRepDetail = await _context.SalesReps.FirstOrDefaultAsync(x => x.SalesRepId == salesRepId);
            if (salesRepDetail != null)
            { 
                _context.SalesReps.Remove(salesRepDetail);
                await _context.SaveChangesAsync();
            }
        }

    }
}
