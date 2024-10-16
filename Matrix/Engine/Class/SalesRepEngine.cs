using AutoMapper;
using Matrix.Engine.Interface;
using Matrix.Entity;
using Matrix.Model.SalesRep;
using Matrix.Repository.Interface;

namespace Matrix.Engine.Class
{
    public class SalesRepEngine : ISalesRepEngine
    {
        private readonly ISalesRepService _salesRepService;
        private readonly IMapper _mapper;

        public SalesRepEngine(ISalesRepService salesRepService, IMapper mapper)
        {
            this._salesRepService = salesRepService;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<SalesRep>> GetSalesReps()
        {
            var salesRep = await _salesRepService.GetSalesReps();
            if (salesRep == null || !salesRep.Any())
            {
                return Enumerable.Empty<SalesRep>();
            }
            return salesRep;
        }
        public async Task<SalesRep> GetSalesRep(Guid salesRepId)
        {
            if (salesRepId == Guid.Empty)
            {
                throw new ArgumentNullException("Invalid Sales Rep ID provided.");
            }
            return await _salesRepService.GetSalesRep(salesRepId);
        }
        public async Task<IEnumerable<SalesRep>> GetSalesRepByRegionalSalesDirector(Guid regionalSalesDirectorId)
        {
            if (regionalSalesDirectorId == Guid.Empty)
            {
                throw new ArgumentNullException("Invalid Regional Sales Director Id provided.");
            }
            return await _salesRepService.GetSalesRepByRegionalSalesDirector(regionalSalesDirectorId);
        }
        public async Task AddSalesRep(SalesRepDto salesRepDto)
        {
            if (salesRepDto == null)
            {
                throw new ArgumentException("Invalid details provided.");
            }
            if (string.IsNullOrWhiteSpace(salesRepDto.SaleRepName))
            {
                throw new ArgumentException("Sales Rep name is required.");
            }
            if (string.IsNullOrWhiteSpace(salesRepDto.SaleRepEmail))
            {
                throw new ArgumentException("Sales Rep email is required.");
            }
            var salesRep = _mapper.Map<SalesRep>(salesRepDto);
            await _salesRepService.AddSalesRep(salesRep);
        }
        public async Task UpdateSalesRep(Guid salesRepId, SalesRepDto salesRepDto)
        {
            if (salesRepId == Guid.Empty)
            {
                throw new ArgumentNullException("Invalid Sales Rep ID provided.");
            }
            if (salesRepDto == null)
            {
                throw new ArgumentException("Invalid details provided.");
            }
            if (string.IsNullOrWhiteSpace(salesRepDto.SaleRepName))
            {
                throw new ArgumentException("Sales Rep name is required.");
            }
            if (string.IsNullOrWhiteSpace(salesRepDto.SaleRepEmail))
            {
                throw new ArgumentException("Sales Rep email is required.");
            }
            var salesRep = _mapper.Map<SalesRep>(salesRepDto);
            await _salesRepService.UpdateSalesRep(salesRepId, salesRep);
        }
        public async Task DeleteSalesRep(Guid salesRepId)
        {
            if (salesRepId == Guid.Empty)
            {
                throw new ArgumentNullException("Invalid Sales Rep ID provided.");
            }
            await _salesRepService.DeleteSalesRep(salesRepId);
        }
    }
}
