using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Services;

namespace SWECVI.Web.Controllers
{
    public class UltityController : ControllerBase
    {
        private readonly IUltityService _ultityService;

        public UltityController(IUltityService ultityService)
        {
            _ultityService = ultityService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/ultity-management/ultitys")]
        public async Task<IActionResult> CreateUltity([FromBody] UltityDto model)
        {
            try
            {
                var result = await _ultityService.CreateUltity(model);
                return Ok();
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                Console.WriteLine($"Lỗi khi cập nhật cơ sở dữ liệu: {ex.InnerException?.Message}");
                throw;
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/ultity-management/ultitys/{id}")]
        public async Task<IActionResult> UpdateUltity(int id, [FromBody] UltityDto model)
        {
            try
            {
                var result = await _ultityService.UpdateUltity(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/ultity-management/ultitys/{id}")]
        public async Task<IActionResult> DeleteUltity(int id)
        {
            try
            {
                var result = await _ultityService.DeleteUltity(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ultity-management/ultitys/{id}")]
        public async Task<IActionResult> GetUltityById(int id)
        {
            try
            {
                var result = await _ultityService.GetUltityById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/ultity-management/ultitys")]
        public async Task<IActionResult> GetUltitys([FromQuery] PagedRequestDto model)
        {
            try
            {
                var result = await _ultityService.GetAllUltitys(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
