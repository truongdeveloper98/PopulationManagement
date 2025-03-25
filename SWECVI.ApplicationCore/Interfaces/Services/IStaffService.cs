using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IStaffService
    {
        Task<bool> CreateStaff(StaffDto model);
        Task<bool> DeleteStaff(int id);
        Task<bool> UpdateStaff(int id, StaffDto model);
        Task<StaffDto> GetStaffById(int id);
        Task<PagedResponseDto<StaffDto>> GetAllStaffs(PagedRequestDto model);
    }
}
