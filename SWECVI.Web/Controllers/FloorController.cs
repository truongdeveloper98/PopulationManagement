using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Services;

namespace SWECVI.Web.Controllers
{
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;

        public FloorController(IFloorService floorService)
        {
            _floorService = floorService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/floor-management/floors")]
        public async Task<IActionResult> CreateFloor([FromBody]FloorDto model)
        {
            try
            {
                var result = await _floorService.CreateFloor(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/floor-management/floors/{id}")]
        public async Task<IActionResult> DeleteFloor(int id)
        {
            try
            {
                var result = await _floorService.DeleteFloor(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/floor-management/floors/{id}")]
        public async Task<IActionResult> UpdateFloor(int id, [FromBody] FloorDto model)
        {
            try
            {
                await _floorService.UpdateFloor(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/floor-management/floors/{id}")]
        public async Task<IActionResult> GetFloorById(int id)
        {
            try
            {
                var result = await _floorService.GetFloorById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/floor-management/floors")]
        public async Task<IActionResult> GetAllFloors([FromQuery] PagedRequestDto model)
        {
            try
            {
                var result = await _floorService.GetAllFloors(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
