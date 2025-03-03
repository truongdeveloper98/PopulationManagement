using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class TownShipController : ControllerBase
    {
        private readonly ITownShipService _townshipService;
        private readonly ICompanyService _companyService;

        public TownShipController(ITownShipService townshipService, ICompanyService companyService)
        {
            _townshipService = townshipService;
            _companyService = companyService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/township-management/townships")]
        public async Task<IActionResult> CreateTownShip([FromBody]TownShipDto model)
        {
            try
            {
                var result = await _townshipService.CreateTownShip(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/township-management/townships/{id}")]
        public async Task<IActionResult> UpdateTownShip(int id, [FromBody] TownShipDto model)
        {
            try
            {
                var result = await _townshipService.UpdateTownShip(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/township-management/townships/{id}")]
        public async Task<IActionResult> DeleteTownShip(int id)
        {
            try
            {
                var result = await _townshipService.DeleteTownShip(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/township-management/townships/{id}")]
        public async Task<IActionResult> GetTownShipById(int id)
        {
            try
            {
                var result = await _townshipService.GetTownShipById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/township-management/townships")]
        public async Task<IActionResult> GetTownShips(PagedRequestDto model)
        {
            try
            {
                var result = await _townshipService.GetTownShips(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/township-management/companiesForSelection")]
        public async Task<IActionResult> GetCompaniesForSelection()
        {
            try
            {
                var result = await _companyService.GetCompaniesForSelection();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
