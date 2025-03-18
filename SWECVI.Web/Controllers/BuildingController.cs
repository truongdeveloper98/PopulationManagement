using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/building-management/buildings")]
        public async Task<IActionResult> CreateBuilding([FromBody] BuildingDto model)
        {
            try
            {
                await _buildingService.CreateBuilding(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/building-management/buildings/{id}")]
        public async Task<IActionResult> UpdateBuilding(int id, [FromBody] BuildingDto model)
        {
            try
            {
                await _buildingService.UpdateBuilding(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/building/{id}")]
        public async Task<IActionResult> GetBuildingById(int id)
        {
            try
            {
                var result = await _buildingService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/building-management/buildings")]
        public async Task<IActionResult> GetAllBuildings([FromQuery] PagedRequestDto model)
        {
            try
            {
                var result = await _buildingService.GetBuildings(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/building-management/buildings/{id}")]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            try
            {
                var result = await _buildingService.DeleteBuilding(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

