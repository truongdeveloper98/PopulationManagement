using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Services;

namespace SWECVI.Web.Controllers
{
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _service;

        public ServiceController(IServiceService service)
        {   
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/service-management/services")]
        public async Task<IActionResult> CreateService([FromBody] ServiceDto model)
        {
            try
            {
                var result = await _service.CreateService(model);
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
        [Route("api/service-management/services/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] ServiceDto model)
        {
            try
            {
                var result = await _service.UpdateService(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/service-management/services/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            try
            {
                var result = await _service.DeleteService(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/service-management/services/{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            try
            {
                var result = await _service.GetServiceById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/service-management/services")]
        public async Task<IActionResult> GetServices([FromQuery] PagedRequestDto model)
        {
            try
            {
                var result = await _service.GetAllServices(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
