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
using SWECVI.Infrastructure.Repositories;

namespace SWECVI.Infrastructure.Services
{
    public class UltityService : IUltityService
    {
        private readonly IUltityRepository _ultityRepository;

        public UltityService(IUltityRepository ultityRepository)
        {
            _ultityRepository = ultityRepository;
        }
        public async Task<bool> CreateUltity(UltityDto model)
        {
            var ultity = new Ultity()
            {
                Name = model.Name,
                UltityId = model.UltityId,
                Price = model.Price,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                UseTime = model.UseTime,
                OpenDate = model.OpenDate,
                Note = model.Note,
                Commitment = model.Commitment,
                IsStatus = model.IsStatus,
            };

            await _ultityRepository.Add(ultity);

            return true;
        }

        public async Task<bool> DeleteUltity(int id)
        {
            var ultity = await _ultityRepository.Get(x => x.Id == id);

            if (ultity == null)
            {
                throw new Exception($"Can not find the ultity with id = {id}");
            }

            await _ultityRepository.Delete(ultity);

            return true;
        }

        public async Task<PagedResponseDto<UltityDto>> GetAllUltitys(PagedRequestDto model)
        {
            Expression<Func<Ultity, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<Ultity, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                     (!string.IsNullOrEmpty(i.UltityId) &&
                                                                     i.UltityId.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _ultityRepository.Count(filter);

            Expression<Func<Ultity, UltityDto>> selectorExpression = i => new UltityDto()
            {
                Id = i.Id,
                UltityId = i.UltityId,
                Name = i.Name,
                Price = i.Price,
                StartTime = i.StartTime,
                EndTime = i.EndTime,
                UseTime = i.UseTime,
                OpenDate = i.OpenDate,
                Note = i.Note,
                Commitment = i.Commitment,
                IsStatus = i.IsStatus,
            };

            var items = await _ultityRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<UltityDto>
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<UltityDto> GetUltityById(int id)
        {
            var ultity = await _ultityRepository.Get(x => x.Id == id);

            if (ultity == null)
            {
                throw new Exception($"Can not find the ultity with id = {id}");
            }

            var result = new UltityDto()
            {
                Id = id,
                Name = ultity.Name,
                UltityId = ultity.UltityId,
                Price = ultity.Price,
                StartTime = ultity.StartTime,
                EndTime = ultity.EndTime,
                OpenDate = ultity.OpenDate,
                UseTime = ultity.UseTime,
                Note = ultity.Note,
                Commitment = ultity.Commitment,
                IsStatus = ultity.IsStatus,
            };

            return result;
        }

        public async Task<bool> UpdateUltity(int id, UltityDto model)
        {
            var ultity = await _ultityRepository.Get(x => x.Id == id);

            if (ultity == null)
            {
                throw new Exception($"Can not find the ultity with id = {id}");
            }

            ultity.Name = model.Name;
            ultity.UltityId = model.UltityId;
            ultity.Price = model.Price;
            ultity.StartTime = model.StartTime;
            ultity.EndTime = model.EndTime;
            ultity.UseTime = model.UseTime;
            ultity.OpenDate = model.OpenDate;
            ultity.Note = model.Note;
            ultity.Commitment = model.Commitment;
            ultity.IsStatus = model.IsStatus;

            await _ultityRepository.Update(ultity);

            return true;
        }
    }
}
