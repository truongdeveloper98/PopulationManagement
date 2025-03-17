using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Interfaces;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.Mapper;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITownShipRepository _townshipRepository;
        private readonly IUserRepository _userRepository;

        public ProjectService(IProjectRepository projectRepository, ITownShipRepository townshipRepository, IUserRepository userRepository)
        {
            _projectRepository = projectRepository;
            _townshipRepository = townshipRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateProject(ProjectDto model)
        {
            var township = _townshipRepository.FirstOrDefault(x => x.Name == model.TownShipId);
            var user = _userRepository.FirstOrDefault(x => x.FirstName == model.ManagerId);

            if (township == null)
            {
                throw new Exception("Can not find the township!");
            }
            else if (user == null) 
            {
                throw new Exception("Can not find the user!");    
            }

            var project = new Project()
            {
                ProjectId = model.ProjectId,
                Name = model.Name,
                TownShipId = township.Id,
                OperationId = model.OperationId,
                Description = model.Description,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                ManagerId = user.Id,
                DateLock = model.DateLock,
            };

            await _projectRepository.Add(project);

            return true;
        }

        public async Task<bool> DeleteProject(int id)
        {
            var project = await _projectRepository.Get(id);

            if (project == null)
            {
                throw new Exception($"Can not find the project with id = {id}");
            }

            await _projectRepository.Delete(project);

            return true;
        }

        public async Task<bool> UpdateProject(int id, ProjectDto model)
        {
            var project = await _projectRepository.Get(id);

            if (project == null)
            {
                throw new Exception($"Can not find the project with id = {id}");
            }

            var township = _townshipRepository.FirstOrDefault(x => x.Name == model.TownShipId);
            var user = _userRepository.FirstOrDefault(x => x.FullName == model.ManagerId);

            if (township == null)
            {
                throw new Exception("Can not find the township!");
            }
            else if (user == null)
            {
                throw new Exception("Can not find the user!");
            }


            project.ProjectId = model.ProjectId;
            project.Name = model.Name;
            project.TownShipId = township.Id;
            project.OperationId = model.OperationId;
            project.Description = model.Description;
            project.Address = model.Address;
            project.PhoneNumber = model.PhoneNumber;
            project.Email = model.Email;
            project.ManagerId = user.Id;
            project.DateLock = model.DateLock;

            await _projectRepository.Update(project);

            return true;
        }

        public async Task<ProjectDto> GetProjectById(int id)
        {
            var project = await _projectRepository.Get(id, "TownShip");

            if(project == null)
            {
                throw new Exception($"Can not find the project with id = {id}");
            }

            var result = new ProjectDto()
            {
                Id = project.Id,
                ProjectId = project.ProjectId,
                Name = project.Name,
                TownShipId = project.TownShip.Name,
                TownShipName = project.TownShip.Name,
                OperationId = project.OperationId,
                Description = project.Description,
                Address = project.Address,
                PhoneNumber = project.PhoneNumber,
                Email = project.Email,
                ManagerId = project.Manager.UserName,
                ManagerName = project.Manager.UserName ?? string.Empty,
                DateLock = project.DateLock,
            };

            return result;
        }

        public async Task<PagedResponseDto<ProjectDto>> GetAllProject(PagedRequestDto model)
        {
            Expression<Func<Project, bool>> filter = i => !i.IsDeleted;

            if(!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<Project, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                    (!string.IsNullOrEmpty(i.OperationId) &&
                                                                    i.OperationId.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _projectRepository.Count(filter);

            Expression<Func<Project, ProjectDto>> selector = i => new ProjectDto()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                OperationId = i.OperationId,
                Address = i.Address,
                Email = i.Email,
                ManagerId = i.Manager.UserName,
                ManagerName = i.Manager.UserName ?? string.Empty,
                PhoneNumber=i.PhoneNumber,
                ProjectId = i.ProjectId,
                TownShipId = i.TownShip.Name,
                TownShipName = i.TownShip.Name,
                DateLock = i.DateLock
            };

            var items = await _projectRepository
                .QueryAndSelectAsync(
                    selector: selector,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<ProjectDto>()
            {
                Page = model.CurrentPage,
                Limit = model.PageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double) model.PageSize),
                Items = items.ToList()
            };
        }
    }
}
