using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class ProjectInformationController : ControllerBase
    {
        private readonly IProjectInformationService _projectInformationService;

        public ProjectInformationController(IProjectInformationService projectInformationService)
        {
            _projectInformationService = projectInformationService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/projectInformation-management/projectInformations")]
        public async Task<IActionResult> CreateProjectInformation([FromBody]ProjectInformationDto model)
        {
            try
            {
                var result = await _projectInformationService.CreateProjecInformation(model);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/projectInformation-management/projectInformations/{id}")]
        public async Task<IActionResult> DeleteProjectInformation(int id)
        {
            try
            {
                var result = await _projectInformationService.DeleteProjecInformation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/projectInformation-management/projectInformations/{id}")]
        public async Task<IActionResult> GetProjectInformationById(int id)
        {
            try
            {
                var result = await _projectInformationService.GetProjectInformationById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/projectInformation-management/projectInformations")]
        public async Task<IActionResult> GetAllProjectInformation([FromQuery]PagedRequestDto model)
        {
            try
            {
                var result = await _projectInformationService.GetAllProjectInformation(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/projectInformation-management/projectInformations/{id}")]
        public async Task<IActionResult> UpdateProjectInformation(int id,[FromBody]ProjectInformationDto model)
        {
            try
            {
                var result = await _projectInformationService.UpdateProjectInformation(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
