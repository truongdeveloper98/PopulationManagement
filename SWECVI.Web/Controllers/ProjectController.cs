using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/project-management/project")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDto model)
        {
            try
            {
                var result = await _projectService.CreateProject(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/project-management/project/{id}")]
        public async Task<IActionResult> UpdateProject(int id,[FromBody] ProjectDto model)
        {
            try
            {
                var result = await _projectService.UpdateProject(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/project-management/project/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                var result = await _projectService.DeleteProject(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/project-management/project/{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            try
            {
                var result = await _projectService.GetProjectById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/project-management/project")]
        public async Task<IActionResult> GetAllProjects([FromQuery]PagedRequestDto model)
        {
            try
            {
                var result = await _projectService.GetAllProject(model);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
