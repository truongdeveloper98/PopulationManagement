using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Entities.Building_Resident;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Repositories;

namespace SWECVI.Infrastructure.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<bool> CreateService(ServiceDto model)
        {
            var service = new Service()
            {
                Name = model.Name,
                ServiceCode = model.ServiceCode,
                TypeOfObject = model.TypeOfObject,
                TypeOfService = model.TypeOfService,
                Description = model.Description,
                Cycle = model.Cycle,
                FirstDate = model.FirstDate,
                PayDate = model.PayDate,
                StartPriceCaculationMethod = model.StartPriceCaculationMethod,
                EndPriceCaculationMethod= model.EndPriceCaculationMethod,
                ApplyFrom = model.ApplyFrom,
                SwitchDay = model.SwitchDay,
            };

            await _serviceRepository.Add(service);

            return true;
        }

        public async Task<bool> DeleteService(int id)
        {
            var service = await _serviceRepository.Get(x => x.Id == id);

            if (service == null)
            {
                throw new Exception($"Can not find service with id = {id}");
            }

            await _serviceRepository.Delete(service);

            return true;
        }

        public async Task<PagedResponseDto<ServiceDto>> GetAllServices(PagedRequestDto model)
        {
            Expression<Func<Service, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<Service, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                     (!string.IsNullOrEmpty(i.ServiceCode) &&
                                                                     i.ServiceCode.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _serviceRepository.Count(filter);

            Expression<Func<Service, ServiceDto>> selectorExpression = i => new ServiceDto()
            {
                Id = i.Id,
                ServiceCode = i.ServiceCode,
                Name = i.Name,
                TypeOfObject = i.TypeOfObject,
                TypeOfService = i.TypeOfService,
                Description = i.Description,
                Cycle = i.Cycle,
                FirstDate = i.FirstDate,
                PayDate = i.PayDate,
                StartPriceCaculationMethod = i.StartPriceCaculationMethod,
                EndPriceCaculationMethod = i.EndPriceCaculationMethod,
                ApplyFrom = i.ApplyFrom,
                SwitchDay = i.SwitchDay,
            };

            var items = await _serviceRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<ServiceDto>
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<ServiceDto> GetServiceById(int id)
        {
            var service = await _serviceRepository.Get(x => x.Id == id);

            if (service == null)
            {
                throw new Exception($"Can not find the service with id = {id}");
            }

            var result = new ServiceDto()
            {
                Id = id,
                Name = service.Name,
                ServiceCode = service.ServiceCode,
                TypeOfObject = service.TypeOfObject,
                TypeOfService = service.TypeOfService,
                Description = service.Description,
                Cycle = service.Cycle,
                FirstDate = service.FirstDate,
                PayDate = service.PayDate,
                StartPriceCaculationMethod = service.StartPriceCaculationMethod,
                EndPriceCaculationMethod = service.EndPriceCaculationMethod,
                ApplyFrom = service.ApplyFrom,
                SwitchDay = service.SwitchDay,
            };

            return result;
        }

        public async Task<bool> UpdateService(int id, ServiceDto model)
        {
            var service = await _serviceRepository.Get(x => x.Id == id);

            if (service == null)
            {
                throw new Exception($"Can not find service with id = {id}");
            }

            service.Name = model.Name;
            service.ServiceCode = model.ServiceCode;
            service.TypeOfObject = model.TypeOfObject;
            service.TypeOfObject = model.TypeOfObject;
            service.Description = model.Description;
            service.Cycle = model.Cycle;
            service.FirstDate = model.FirstDate;
            service.PayDate = model.PayDate;
            service.StartPriceCaculationMethod = model.StartPriceCaculationMethod;
            service.EndPriceCaculationMethod= model.EndPriceCaculationMethod;
            service.ApplyFrom = model.ApplyFrom;
            service.SwitchDay = model.SwitchDay;

            await _serviceRepository.Update(service);

            return true;
        }
    }
}
