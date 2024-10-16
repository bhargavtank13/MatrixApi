using Matrix.DBContext;
using Matrix.Entity;
using Matrix.Model.RegionalSaleDirector;
using Matrix.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Repository.Class
{

    public class RegionalSaleDirectorService : IRegionalSaleDirectorService
    {
        private readonly MatrixDBContext _context;

        public RegionalSaleDirectorService(MatrixDBContext context)
        {
            this._context = context;
        }
        public async Task<RegionalSalesDirectorList> GetRegionalSaleDirectors(int pageNumber, int pageSize)
        {
            var quey = _context.RegionalSaleDirectors.AsQueryable().OrderByDescending(x => x.CreatedAt);
            var totalCount = await quey.CountAsync();
            var regionalSaleDirectors = await quey.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new RegionalSalesDirectorList { 
                RegionalSaleDirectors = regionalSaleDirectors, 
                TotalCount = totalCount,
                PageNumber = pageNumber, 
                PageSize = pageSize
           };

        }
        public async Task<RegionalSaleDirector> GetRegionalSaleDirector(Guid regionalSaleDirectorId)
        {
            var regionalSalesDirector = await _context.RegionalSaleDirectors.FirstOrDefaultAsync(x => x.RegionalSaleDirectorId == regionalSaleDirectorId);
            return regionalSalesDirector;
        }
        public async Task AddRegionalSaleDirector(RegionalSaleDirector regionalSaleDirector)
        {
            _context.RegionalSaleDirectors.Add(regionalSaleDirector);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRegionalSaleDirector(Guid regionalSaleDirectorId, RegionalSaleDirector regionalSaleDirector)
        {
            var regionalSalesDirectorDetail = await _context.RegionalSaleDirectors.FirstOrDefaultAsync(x => x.RegionalSaleDirectorId == regionalSaleDirectorId);
            if (regionalSalesDirectorDetail != null)
            {
                regionalSalesDirectorDetail.RegionalSaleDirectorName = regionalSaleDirector.RegionalSaleDirectorName;
                regionalSalesDirectorDetail.RegionalSaleDirectorEmail = regionalSaleDirector.RegionalSaleDirectorEmail;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteRegionalSaleDirector(Guid regionalSaleDirectorId)
        {
            var regionalSalesDirector = await _context.RegionalSaleDirectors.FirstOrDefaultAsync(x => x.RegionalSaleDirectorId == regionalSaleDirectorId);
            if (regionalSalesDirector != null)
            {
                _context.RegionalSaleDirectors.Remove(regionalSalesDirector);
                await _context.SaveChangesAsync();
            }
        }
    }
}
