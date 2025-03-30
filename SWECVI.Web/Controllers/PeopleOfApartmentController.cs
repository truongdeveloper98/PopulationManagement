using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Services;

namespace SWECVI.Web.Controllers
{
    public class PeopleOfApartmentController : ControllerBase
    {
        private readonly IPeopeOfApartmentService _peopleOfApartmentService;
        private readonly IApartmentService _apartmentService;

        public PeopleOfApartmentController(IPeopeOfApartmentService peopleOfApartmentService, IApartmentService apartmentService)
        {
            _peopleOfApartmentService = peopleOfApartmentService;
            _apartmentService = apartmentService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/peopleOfApartment-management/peopleOfApartments")]
        public async Task<IActionResult> CreatePeopleOfApartment([FromBody] PeopleOfApartmentDto model)
        {
            try
            {
                var result = await _peopleOfApartmentService.CreatePeopleOfApartment(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/peopleOfApartment-management/peopleOfApartments/{id}")]
        public async Task<IActionResult> UpdatePeopleOfApartment(int id, [FromBody] PeopleOfApartmentDto model)
        {
            try
            {
                var result = await _peopleOfApartmentService.UpdatePeopleOfApartment(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/peopleOfApartment-management/peopleOfApartments/{id}")]
        public async Task<IActionResult> DeletePeopleOfApartment(int id)
        {
            try
            {
                var result = await _peopleOfApartmentService.DeletePeopleOfApartment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/peopleOfApartment-management/peopleOfApartments/{id}")]
        public async Task<IActionResult> GetPeopleOfApartmentById(int id)
        {
            try
            {
                var result = await _peopleOfApartmentService.GetPeopleOfApartmentById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/peopleOfApartment-management/peopleOfApartments")]
        public async Task<IActionResult> GetPeopleOfApartments([FromQuery] PagedRequestDto model)
        {
            try
            {
                var result = await _peopleOfApartmentService.GetAllPeopleOfApartment(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/peopleOfApartment-management/apartmentsForSelection")]
        public async Task<IActionResult> GetApartmentsForSelection()
        {
            try
            {
                var result = await _apartmentService.GetApartmentsForSelection();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
