using System.Linq.Expressions;
using NPOI.SS.Formula.Functions;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Infrastructure.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<bool> CreateJob(JobDto model)
        {
            var job = new Job()
            {
                Name = model.Name,
                Description = model.Description
            };

            await _jobRepository.Add(job);

            return true;
        }

        public async Task<bool> DeleteJob(int id)
        {
            var job = await _jobRepository.Get(id);

            if(job == null)
            {
                throw new Exception($"Can not find the job with id = {id}");
            }

            await _jobRepository.Delete(job);

            return true;
        }

        public async Task<JobDto> GetById(int id)
        {
            var job = await _jobRepository.Get(id);

            if (job == null)
            {
                throw new Exception($"Can not find the job with id = {id}");
            }

            var result = new JobDto()
            {
                Id = job.Id,
                Name = job.Name,
                Description = job.Description
            };

            return result;
        }

        public async Task<PagedResponseDto<JobDto>> GetJobs(PagedRequestDto model)
        {
            Expression<Func<Job, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<Job, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) || 
                                                                (!string.IsNullOrEmpty(i.Description) && 
                                                                  i.Description.Contains(model.TextSearch));

                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _jobRepository.Count(filter);

            Expression<Func<Job, JobDto>> selectorExpression = i => new JobDto()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
            };

            var items = await _jobRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    page: model.CurrentPage,
                    pageSize: model.PageSize
                );

            return new PagedResponseDto<JobDto>()
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<bool> UpdateJob(int id, JobDto model)
        {
            var job = await _jobRepository.Get(id);

            if (job == null)
            {
                throw new Exception($"Can not find the job with id = {id}");
            }

            job.Name = model.Name;
            job.Description = model.Description;

            await _jobRepository.Update(job);

            return true;
        }
    }
}
