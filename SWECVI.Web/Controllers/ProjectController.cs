using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ITownShipService _townShipService;
        private readonly IUserService _userService;

        public ProjectController(IProjectService projectService, ITownShipService townShipService, IUserService userService)
        {
            _projectService = projectService;
            _townShipService = townShipService;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/project-management/projects")]
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
        [Route("api/project-management/projects/{id}")]
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
        [Route("api/project-management/projects/{id}")]
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
        [Route("api/project-management/projects/{id}")]
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

        [HttpGet]
        [AllowAnonymous]
        [Route("api/project-management/townshipsForSelection")]
        public async Task<IActionResult> GetTownshipsForSelection()
        {
            try
            {
                var result = await _townShipService.GetTownShipsForSelection();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/project-management/usersForSelection")]
        public async Task<IActionResult> GetUsersForSelection()
        {
            try
            {
                var user = await _userService.GetUserForSelection();
                return Ok(user);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
