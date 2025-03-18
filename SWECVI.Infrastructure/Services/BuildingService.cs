using System.Linq.Expressions;
using NPOI.SS.Formula.Functions;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Repositories;

namespace SWECVI.Infrastructure.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }
        public async Task<bool> CreateBuilding(BuildingDto model)
        {
            var building = new BuildingInformation()
            {
                Name = model.Name,
                BuildingId = model.BuildingId,
                Status = model.Status
            };

            await _buildingRepository.Add(building);

            return true;
        }

        public async Task<bool> DeleteBuilding(int id)
        {
            var building = await _buildingRepository.Get(id);

            if (building == null)
            {
                throw new Exception($"Can not find the building with id = {id}");
            }

            await _buildingRepository.Delete(building);

            return true;
        }

        public async Task<PagedResponseDto<BuildingDto>> GetBuildings(PagedRequestDto model)
        {
            Expression<Func<BuildingInformation, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<BuildingInformation, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                (!string.IsNullOrEmpty(i.BuildingId) &&
                                                                  i.BuildingId.Contains(model.TextSearch));

                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _buildingRepository.Count(filter);

            Expression<Func<BuildingInformation, BuildingDto>> selectorExpression = i => new BuildingDto()
            {
                Id = i.Id,
                Name = i.Name,
                BuildingId = i.BuildingId,
                Status = i.Status,
            };

            var items = await _buildingRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    page: model.CurrentPage,
                    pageSize: model.PageSize
                );

            return new PagedResponseDto<BuildingDto>()
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<bool> UpdateBuilding(int id, BuildingDto model)
        {
            var building = await _buildingRepository.Get(id);

            if (building == null)
            {
                throw new Exception($"Can not find the building with id = {id}");
            }

            building.Name = model.Name;
            building.BuildingId = model.BuildingId;
            building.Status = model.Status;

            await _buildingRepository.Update(building);

            return true;
        }

        public async Task<BuildingDto> GetById(int id)
        {
            var building = await _buildingRepository.Get(id);

            if (building == null)
            {
                throw new Exception($"Can not find the building with id = {id}");
            }

            var result = new BuildingDto()
            {
                Id = building.Id,
                Name = building.Name,
                BuildingId = building.BuildingId,
                Status = building.Status,
            };

            return result;
        }

        public async Task<List<BuildingForSelectionDto>> GetBuildingForSelection()
        {
            var building = await _buildingRepository.QueryAndSelectAsync(selector: x => new BuildingForSelectionDto()
            {
                Id = x.Id,
                Name = x.Name,
            });

            return building.ToList();
        }
    }
}
