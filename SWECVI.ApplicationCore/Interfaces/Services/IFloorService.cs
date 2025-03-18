using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IFloorService
    {
        Task<bool> CreateFloor(FloorDto model);
        Task<bool> UpdateFloor(int id, FloorDto model);
        Task<bool> DeleteFloor(int id);
        Task<FloorDto> GetFloorById(int id);
        Task<PagedResponseDto<FloorDto>> GetAllFloors(PagedRequestDto model);
    }
}
