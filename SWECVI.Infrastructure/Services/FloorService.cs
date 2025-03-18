using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Infrastructure.Services
{
    public class FloorService : IFloorService
    {
        private readonly IFloorRepository _floorRepository;
        private readonly IBuildingRepository _buildingRepository;

        public FloorService(IFloorRepository floorRepository, IBuildingRepository buildingRepository)
        {  
           _floorRepository = floorRepository;
            _buildingRepository = buildingRepository;
        }

        public async Task<bool> CreateFloor(FloorDto model)
        {
            var building = _buildingRepository.FirstOrDefault(x => x.Name == model.BuildingName);

            if (building == null) 
            {
                throw new Exception("Building not found");
            }

            var floor = new FloorInformation()
            {
                Name = model.Name,
                BuildingId = building.Id,
                FloorId = model.FloorId
            };

            await _floorRepository.Add(floor);

            return true;
        }

        public async Task<bool> DeleteFloor(int id)
        {
            var floor = await _floorRepository.Get(id);

            if(floor == null)
            {
                throw new Exception($"Can not find the floor with id = {id}");
            }

            await _floorRepository.Delete(floor);

            return true;
        }

        public async Task<PagedResponseDto<FloorDto>> GetAllFloors(PagedRequestDto model)
        {
            Expression<Func<FloorInformation, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<FloorInformation, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) &&
                                                                              (!string.IsNullOrEmpty(i.FloorId)) ||
                                                                              i.FloorId.Contains(model.TextSearch);
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            Expression<Func<FloorInformation, FloorDto>> selector = x => new FloorDto()
            {
                Id = x.Id,
                Name = x.Name,
                BuildingId = x.BuildingInformation.Id,
                BuildingName = x.BuildingInformation.Name,
                FloorId = x.FloorId
            };

            var totalItems = await _floorRepository.Count(filter);

            var items = await _floorRepository
                .QueryAndSelectAsync
                (
                    selector: selector,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<FloorDto>
            {
                Page = model.CurrentPage,
                Limit = model.PageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double) model.PageSize),
                Items =  items.ToList()
            };

        }

        public async Task<FloorDto> GetFloorById(int id)
        {
            var floor = await _floorRepository.Get(id, "BuildingInformation");

            if (floor == null)
            {
                throw new Exception($"Can not find the floor with id = {id}");
            }

            var result = new FloorDto()
            {
                Id = id,
                Name = floor.Name,
                BuildingId = floor.BuildingInformation.Id,
                BuildingName = floor.BuildingInformation.Name,
                FloorId = floor.FloorId,
            };

            return result;
        }

        public async Task<bool> UpdateFloor(int id, FloorDto model)
        {
            var floor = await _floorRepository.Get(id);

            if (floor == null)
            {
                throw new Exception($"Can not find the floor with id = {id}");
            }

            var building = _buildingRepository.FirstOrDefault(x => x.Name == model.BuildingName);

            if(building == null)
            {
                throw new Exception("Building not found!");
            }

            floor.Name = model.Name;
            floor.FloorId = model.FloorId;
            floor.BuildingId = building.Id;

            await _floorRepository.Update(floor);

            return true;
        }
    }
}
