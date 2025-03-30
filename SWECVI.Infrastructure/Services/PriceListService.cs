using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities.Building_Resident;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Infrastructure.Services
{
    public class PriceListService : IPriceListService
    {
        private readonly IPriceListRepository _priceListRepository;
        private readonly IServiceRepository _serviceRepository;

        public PriceListService(IPriceListRepository priceListRepository, IServiceRepository serviceRepository)
        {
            _priceListRepository = priceListRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> CreatePriceList(PriceListDto model)
        {
            var service = _serviceRepository.FirstOrDefault(x => x.Id == model.ServiceId);

            if (service == null)
            {
                throw new Exception("Service not found");
            }

            var priceList = new PriceList()
            {
                Name = model.Name,
                PriceListCode = model.PriceListCode,
                ServiceId = service.Id,
                TypeOfFee = model.TypeOfFee,
                ApplyDate = model.ApplyDate,
                Price = model.Price,
            };

            await _priceListRepository.Add(priceList);

            return true;
        }

        public async Task<bool> DeletePriceList(int id)
        {
            var priceList = await _priceListRepository.Get(x => x.Id == id);

            if (priceList == null)
            {
                throw new Exception($"Can not find price list with id = {id}");
            }

            await _priceListRepository.Delete(priceList);

            return true;
        }

        public async Task<PagedResponseDto<PriceListDto>> GetAllPriceLists(PagedRequestDto model)
        {
            Expression<Func<PriceList, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<PriceList, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                     (!string.IsNullOrEmpty(i.PriceListCode) &&
                                                                     i.PriceListCode.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _priceListRepository.Count(filter);

            Expression<Func<PriceList, PriceListDto>> selectorExpression = i => new PriceListDto()
            {
                Id = i.Id,
                PriceListCode = i.PriceListCode,
                Name = i.Name,
                ServiceId = i.Service.Id,
                ServiceName = i.Service.Name,
                TypeOfFee = i.TypeOfFee,
                ApplyDate = i.ApplyDate,
                Price = i.Price,
            };

            var items = await _priceListRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<PriceListDto>
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<PriceListDto> GetPriceListById(int id)
        {
            var priceList = await _priceListRepository.Get(x => x.Id == id);

            if (priceList == null)
            {
                throw new Exception($"Can not find price list with id = {id}");
            }

            var result = new PriceListDto()
            {
                Id = id,
                Name = priceList.Name,
                PriceListCode = priceList.PriceListCode,
                ServiceId = priceList.Service.Id,
                ServiceName = priceList.Service.Name,
                TypeOfFee = priceList.TypeOfFee,
                ApplyDate = priceList.ApplyDate,
                Price = priceList.Price,
            };
            return result;
        }

        public async Task<bool> UpdatePriceList(int id, PriceListDto model)
        {
            var priceList = await _priceListRepository.Get(x => x.Id == id);

            if (priceList == null)
            {
                throw new Exception($"Can not find priceList with id = {id}");
            }

            var service = _serviceRepository.FirstOrDefault(x => x.Id == model.ServiceId);

            if (service == null)
            {
                throw new Exception($"Can not found service");
            }

            priceList.Name = model.Name;
            priceList.PriceListCode = model.PriceListCode;
            priceList.ServiceId = service.Id;
            priceList.TypeOfFee = model.TypeOfFee;
            priceList.ApplyDate = model.ApplyDate;
            priceList.Price = model.Price;

            await _priceListRepository.Update(priceList);

            return true;
        }
    }
}
