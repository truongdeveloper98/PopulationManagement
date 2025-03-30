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
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }
        public async Task<bool> CreateApartment(ApartmentDto model)
        {
            var apartment = new Apartment()
            {
                Name = model.Name,
                ApartmentId = model.ApartmentId,
                FloorId = model.FloorId,
                ElectricId = model.ElectricId,
                WaterId = model.WaterId,
                Area = model.Area,
                NumberOfBedroom = model.NumberOfBedroom,
                CustomerId = model.CustomerId,
                Population = model.Population,
                Status = model.Status,
                Description = model.Description,
            };

            await _apartmentRepository.Add(apartment);

            return true;
        }

        public async Task<bool> DeleteApartment(int id)
        {
            var apartment = await _apartmentRepository.Get(x => x.Id == id);

            if (apartment == null)
            {
                throw new Exception($"Can not find the apartment with id = {id}");
            }

            await _apartmentRepository.Delete(apartment);

            return true;
        }

        public async Task<PagedResponseDto<ApartmentDto>> GetAllApartments(PagedRequestDto model)
        {
            Expression<Func<Apartment, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<Apartment, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                     (!string.IsNullOrEmpty(i.Name) &&
                                                                     i.ApartmentId.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _apartmentRepository.Count(filter);

            Expression<Func<Apartment, ApartmentDto>> selectorExpression = i => new ApartmentDto()
            {
                Id = i.Id,
                Name = i.Name,
                ApartmentId = i.ApartmentId,
                FloorId = i.FloorId,
                FloorName = i.FloorInformation.Name,
                ElectricId = i.ElectricId,
                WaterId = i.WaterId,
                Area = i.Area,
                NumberOfBedroom = i.NumberOfBedroom,
                CustomerId = i.CustomerId,
                CustomerName = i.Customer.UserName,
                Population = i.Population,
                Status = i.Status,
                Description = i.Description,
            };

            var items = await _apartmentRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<ApartmentDto>
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<ApartmentDto> GetApartmentById(int id)
        {
            var apartment = await _apartmentRepository.Get(x => x.Id == id, "FloorInformation,Customer");

            if (apartment == null)
            {
                throw new Exception($"Can not find the apartment with id = {id}");
            }

            var result = new ApartmentDto()
            {
                Id = id,
                Name = apartment.Name,
                ApartmentId = apartment.ApartmentId,
                FloorId = apartment.FloorId,
                FloorName = apartment.FloorInformation.Name,
                ElectricId = apartment.ElectricId,
                WaterId = apartment.WaterId,
                Area = apartment.Area,
                NumberOfBedroom = apartment.NumberOfBedroom,
                CustomerId = apartment.CustomerId,
                CustomerName = apartment.Customer.UserName,
                Population = apartment.Population,
                Status = apartment.Status,
                Description = apartment.Description,
            };

            return result;
        }

        public async Task<List<ApartmentDto>> GetApartmentsForSelection()
        {
            var apartment = await _apartmentRepository.QueryAndSelectAsync(selector: x => new ApartmentDto()
            {
                Id= x.Id,
                Name = x.Name,
            });

            return apartment.ToList();
        }

        public async Task<bool> UpdateApartment(int id, ApartmentDto model)
        {
            var apartment = await _apartmentRepository.Get(x => x.Id == id);

            if (apartment == null)
            {
                throw new Exception($"Can not find the apartment with id = {id}");
            }

            apartment.ApartmentId = model.ApartmentId;
            apartment.Name = model.Name;
            apartment.FloorId = model.FloorId;
            apartment.Area = model.Area;
            apartment.NumberOfBedroom = model.NumberOfBedroom;
            apartment.ElectricId = model.ElectricId;
            apartment.WaterId = model.WaterId;
            apartment.Population = model.Population;
            apartment.Status = model.Status;
            apartment.Description = model.Description;

            await _apartmentRepository.Update(apartment);

            return true;
        }
    }
}
