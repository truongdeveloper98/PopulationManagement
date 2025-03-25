using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Services;

namespace SWECVI.Web.Controllers
{
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IDepartmentService _departmentService;

        public StaffController(IStaffService staffService, IDepartmentService departmentService)
        {
            _staffService = staffService;
            _departmentService = departmentService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/staff-management/staffs")]
        public async Task<IActionResult> CreateStaff([FromBody] StaffDto model)
        {
            try
            {
                var result = await _staffService.CreateStaff(model);
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
        [Route("api/staff-management/staffs/{id}")]
        public async Task<IActionResult> UpdateStaff(int id, [FromBody] StaffDto model)
        {
            try
            {
                var result = await _staffService.UpdateStaff(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/staff-management/staffs/{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            try
            {
                var result = await _staffService.DeleteStaff(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/staff-management/staffs/{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            try
            {
                var result = await _staffService.GetStaffById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/staff-management/staffs")]
        public async Task<IActionResult> GetStaffs([FromQuery]PagedRequestDto model)
        {
            try
            {
                var result = await _staffService.GetAllStaffs(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/staff-management/departmentsForSelection")]
        public async Task<IActionResult> GetDepartmentsForSelection()
        {
            try
            {
                var result = await _departmentService.GetDepartmentsForSelection();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
