using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationService _contactInformationService;

        public ContactInformationController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/contactInformation-management/contactInformations")]
        public async Task<IActionResult> Create([FromBody]ContactInformationDto model)
        {
            try
            {
                var result = await _contactInformationService.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/contactInformation-management/contactInformations/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactInformationDto model)
        {
            try
            {
                var result = await _contactInformationService.Update(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/contactInformation-management/contactInformations/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _contactInformationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/contactInformation-management/contactInformations/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _contactInformationService.GetContactById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/contactInformation-management/contactInformations")]
        public async Task<IActionResult> GetAll([FromQuery]PagedRequestDto model)
        {
            try
            {
                var result = await _contactInformationService.GetAllContact(model);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
