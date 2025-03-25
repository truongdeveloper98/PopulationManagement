using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<bool> CreateDepartment(DepartmentDto model);
        Task<bool> UpdateDepartment(int id, DepartmentDto model);
        Task<bool> DeleteDepartment(int id);
        Task<DepartmentDto> GetById(int id);
        Task<PagedResponseDto<DepartmentDto>> GetAllDepartments(PagedRequestDto model);
        Task<List<DepartmentDto>> GetDepartmentsForSelection();
    }
}
