using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IBuildingService
    {
        Task<bool> CreateBuilding(BuildingDto model);
        Task<bool> UpdateBuilding(int id, BuildingDto model);
        Task<bool> DeleteBuilding(int id);
        Task<BuildingDto> GetById(int id);
        Task<PagedResponseDto<BuildingDto>> GetBuildings(PagedRequestDto model);
        Task<List<BuildingForSelectionDto>> GetBuildingForSelection();
    }
}
