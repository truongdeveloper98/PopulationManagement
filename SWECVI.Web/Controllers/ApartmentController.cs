using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Services;

namespace SWECVI.Web.Controllers
{
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/apartment-management/apartments")]
        public async Task<IActionResult> CreateApartment([FromBody] ApartmentDto model)
        {
            try
            {
                var result = await _apartmentService.CreateApartment(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/apartment-management/apartments/{id}")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            try
            {
                var result = await _apartmentService.DeleteApartment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/apartment-management/apartments/{id}")]
        public async Task<IActionResult> UpdateApartment(int id, [FromBody] ApartmentDto model)
        {
            try
            {
                await _apartmentService.UpdateApartment(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/apartment-management/apartments/{id}")]
        public async Task<IActionResult> GetApartmentById(int id)
        {
            try
            {
                var result = await _apartmentService.GetApartmentById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/apartment-management/apartments")]
        public async Task<IActionResult> GetAllApartments([FromQuery] PagedRequestDto model)
        {
            try
            {
                var result = await _apartmentService.GetAllApartments(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
