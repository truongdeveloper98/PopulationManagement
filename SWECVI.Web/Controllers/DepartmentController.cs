using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IUserService _userService;

        public DepartmentController(IDepartmentService departmentService, IUserService userService)
        {
            _departmentService = departmentService;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/department-management/departments")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDto model)
        {
            try
            {
                var result = await _departmentService.CreateDepartment(model);
                return Ok();
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                Console.WriteLine($"Lỗi: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Chi tiết lỗi: {ex.InnerException.Message}");
                }

                throw;
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/department-management/departments/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id,[FromBody] DepartmentDto model)
        {
            try
            {
                var result = await _departmentService.UpdateDepartment(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/department-management/departments/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                var result = await _departmentService.DeleteDepartment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/department-management/departments/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                var result = await _departmentService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/department-management/departments")]
        public async Task<IActionResult> GetAllDepartmens([FromQuery]PagedRequestDto model)
        {
            try
            {
                var result = await _departmentService.GetAllDepartments(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/department-management/usersForSelection")]
        public async Task<IActionResult> GetUsersForSelection()
        {
            try
            {
                var result = await _userService.GetUserForSelection();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
