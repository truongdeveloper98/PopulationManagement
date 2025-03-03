using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface ITownShipService
    {
        Task<bool> CreateTownShip(TownShipDto model);
        Task<bool> UpdateTownShip(int id, TownShipDto model);
        Task<bool> DeleteTownShip(int id);
        Task<TownShipDto> GetTownShipById(int id);
        Task<PagedResponseDto<TownShipDto>> GetTownShips(PagedRequestDto model);
    }
}
