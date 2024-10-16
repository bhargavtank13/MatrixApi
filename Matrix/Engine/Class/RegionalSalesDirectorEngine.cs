using AutoMapper;
using Matrix.Engine.Interface;
using Matrix.Entity;
using Matrix.Model.RegionalSaleDirector;
using Matrix.Repository.Interface;

namespace Matrix.Engine.Class
{
    public class RegionalSalesDirectorEngine : IRegionalSaleDirectorEngine
    {
        private readonly IRegionalSaleDirectorService _regionalSaleDirectorService;
        private readonly IMapper _mapper;

        public RegionalSalesDirectorEngine(IRegionalSaleDirectorService regionalSaleDirectorService, IMapper mapper)
        {
            this._regionalSaleDirectorService = regionalSaleDirectorService;
            this._mapper = mapper;
        }
        public async Task<RegionalSalesDirectorList> GetRegionalSaleDirectors(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;
           return await _regionalSaleDirectorService.GetRegionalSaleDirectors(pageNumber, pageSize);
        }
        public async Task<RegionalSaleDirector> GetRegionalSaleDirector(Guid regionalSaleDirectorId)
        {
            if (regionalSaleDirectorId == Guid.Empty)
            {
                throw new ArgumentException("Invalid customer ID provided.");
            }
            var regionalSalesDirector = await _regionalSaleDirectorService.GetRegionalSaleDirector(regionalSaleDirectorId);
            return regionalSalesDirector;
        }
        public async Task AddRegionalSaleDirector(RegionalSaleDirectorDto regionalSaleDirectorDto)
        {
            if (regionalSaleDirectorDto == null)
            {
                throw new ArgumentNullException("Invalid details provided.");
            }
            if (string.IsNullOrWhiteSpace(regionalSaleDirectorDto.RegionalSaleDirectorName))
            {
                throw new ArgumentException("Regional Sales Director Name is required.");
            }
            if (string.IsNullOrWhiteSpace(regionalSaleDirectorDto.RegionalSaleDirectorEmail))
            {
                throw new ArgumentException("Regional Sales Director Email is required.");
            }
            var regionalSalesDirector = _mapper.Map<RegionalSaleDirector>(regionalSaleDirectorDto);
            await _regionalSaleDirectorService.AddRegionalSaleDirector(regionalSalesDirector);
        }
        public async Task UpdateRegionalSaleDirector(Guid regionalSaleDirectorId, RegionalSaleDirectorDto regionalSaleDirectorDto)
        {
            if (regionalSaleDirectorId == Guid.Empty)
            {
                throw new ArgumentException("Invalid Regional Sale Director Id  provided.");
            }
            if (regionalSaleDirectorDto == null)
            {
                throw new ArgumentNullException("Invalid details provided.");
            }
            if (string.IsNullOrWhiteSpace(regionalSaleDirectorDto.RegionalSaleDirectorName))
            {
                throw new ArgumentException("Regional Sales Director Name is required.");
            }
            if (string.IsNullOrWhiteSpace(regionalSaleDirectorDto.RegionalSaleDirectorEmail))
            {
                throw new ArgumentException("Regional Sales Director Email is required.");
            }
            if (!IsValidEmail(regionalSaleDirectorDto.RegionalSaleDirectorEmail))
            {
                throw new ArgumentException("Customer email format is invalid.");
            }
            var regionalSalesDirector = _mapper.Map<RegionalSaleDirector>(regionalSaleDirectorDto);
            await _regionalSaleDirectorService.UpdateRegionalSaleDirector(regionalSaleDirectorId, regionalSalesDirector);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public async Task DeleteRegionalSaleDirector(Guid regionalSaleDirectorId)
        {
            if (regionalSaleDirectorId == Guid.Empty)
            {
                throw new ArgumentNullException("Invalid Regional Sales Director Id.");
            }
            await _regionalSaleDirectorService.DeleteRegionalSaleDirector(regionalSaleDirectorId);
        }

    }
}
