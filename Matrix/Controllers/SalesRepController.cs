using Matrix.Engine.Interface;
using Matrix.Entity;
using Matrix.Model.SalesRep;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Controllers
{
    [ApiController]
    [Route("api/salesRep")]
    public class SalesRepController : Controller
    {
        private readonly ISalesRepEngine _salesRepEngine;

        public SalesRepController(ISalesRepEngine salesRepEngine)
        {
            this._salesRepEngine = salesRepEngine;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesRep>>> GetSalesReps()
        {
            return Ok(await _salesRepEngine.GetSalesReps());
        }

        [HttpGet("{salesRepId}")]
        public async Task<IActionResult> GetSalesRep(Guid salesRepId)
        {
            return Ok(await _salesRepEngine.GetSalesRep(salesRepId));
        }

        [HttpGet("{regionalSalesDirectorId}/SalesReps")]
        public async Task<ActionResult<IEnumerable<SalesRep>>> GetSalesRepByRegionalSalesDirector(Guid regionalSalesDirectorId)
        {
            return Ok(await _salesRepEngine.GetSalesRepByRegionalSalesDirector(regionalSalesDirectorId));
        }

        [HttpPost]
        public async Task<IActionResult> AddSalesRep(SalesRepDto salesRepDto)
        {
            try
            {
                await _salesRepEngine.AddSalesRep(salesRepDto);    
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        [HttpPatch("{salesRepId}")]
        public async Task<IActionResult> UpdateSalesRep(Guid salesRepId,SalesRepDto salesRepDto)
        {
            try
            {
                await _salesRepEngine.UpdateSalesRep(salesRepId, salesRepDto);
                return Ok();
            }
            catch(Exception ex)
            { return BadRequest(ex.Message); }
        }

        [HttpDelete("{salesRepId}")]
        public async Task<IActionResult> DeleteSalesRep(Guid salesRepId)
        {
            try 
            {
                await _salesRepEngine.DeleteSalesRep(salesRepId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}