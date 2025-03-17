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
    public class ProjectInformationService : IProjectInformationService
    {
        private readonly IProjectInformationRepository _projectInformationRepository;

        public ProjectInformationService(IProjectInformationRepository projectInformationRepository)
        {
            _projectInformationRepository = projectInformationRepository;
        }

        public async Task<bool> CreateProjecInformation(ProjectInformationDto model)
        {
            var projectInformation = new ProjectInformation()
            {
                Content = model.Content,
                Quantity = model.Quantity,
                Note = model.Note
            };

            await _projectInformationRepository.Add(projectInformation);

            return true;
        }

        public async Task<bool> DeleteProjecInformation(int id)
        {
            var projectInformation = await _projectInformationRepository.Get(id);

            if (projectInformation == null)
            {
                throw new Exception($"Can not find infor with id = {id}");
            }

            await _projectInformationRepository.Delete(projectInformation);

            return true;
        }

        public async Task<PagedResponseDto<ProjectInformationDto>> GetAllProjectInformation(PagedRequestDto model)
        {
            Expression<Func<ProjectInformation, bool>> filter = i => !i.IsDeleted;

            if(!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<ProjectInformation, bool>> searchFilter = i => i.Content.Contains(model.TextSearch) &&
                                                                                (!string.IsNullOrEmpty(i.Note) ||
                                                                                i.Note.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _projectInformationRepository.Count(filter);

            Expression<Func<ProjectInformation, ProjectInformationDto>> selector = i => new ProjectInformationDto()
            {
                Id = i.Id,
                Content = i.Content,
                Note = i.Note,
                Quantity = i.Quantity
            };

            var items = await _projectInformationRepository
                .QueryAndSelectAsync(
                    selector: selector,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<ProjectInformationDto>()
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<ProjectInformationDto> GetProjectInformationById(int id)
        {
            var projectInformation = await _projectInformationRepository.Get(id);

            if(projectInformation == null)
            {
                throw new Exception($"Can not find infor with id = {id}");
            }

            var result = new ProjectInformationDto()
            {
                Id = projectInformation.Id,
                Content = projectInformation.Content,
                Quantity = projectInformation.Quantity,
                Note = projectInformation.Note
            };

            return result;
        }

        public async Task<bool> UpdateProjectInformation(int id, ProjectInformationDto model)
        {
            var projectInformation = await _projectInformationRepository.Get(id);

            if(projectInformation == null)
            {
                throw new Exception($"Can not find infor with id = {id}");
            }

            projectInformation.Content = model.Content;
            projectInformation.Quantity = model.Quantity;
            projectInformation.Note = model.Note;

            await _projectInformationRepository.Update(projectInformation);

            return true;
        }
    }
}
