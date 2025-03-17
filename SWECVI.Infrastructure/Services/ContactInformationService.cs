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
    public class ContactInformationService : IContactInformationService
    {
        private readonly IContactInformationRepository _contactInformationRepository;
        public ContactInformationService(IContactInformationRepository contactInformationRepository)
        {
            _contactInformationRepository = contactInformationRepository;
        }
        public async Task<bool> Create(ContactInformationDto model)
        {

            var contactInformation = new ContactInformation()
            {
                TownName = model.TownName,
                Address = model.Address,
                Email = model.Email,
                AddressForPay = model.AddressForPay,
                DepartmentId = model.DepartmentId,
                PhoneNumber = model.PhoneNumber,
                Introduce = model.Introduce,
                DateLock = model.DateLock,
            };

            await _contactInformationRepository.Add(contactInformation);

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var contactInformatin = await _contactInformationRepository.Get(id);

            if(contactInformatin == null)
            {
                throw new Exception($"Can not find contact with id = {id}");
            }

            await _contactInformationRepository.Delete(contactInformatin);

            return true;
        }

        public async Task<PagedResponseDto<ContactInformationDto>> GetAllContact(PagedRequestDto model)
        {
            Expression<Func<ContactInformation, bool>> filter = i => !i.IsDeleted;

            if(!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<ContactInformation, bool>> searchFilter = i => i.TownName.Contains(model.TextSearch) &&
                                                                               (!string.IsNullOrEmpty(i.Address) ||
                                                                               i.Address.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _contactInformationRepository.Count(filter);

            Expression<Func<ContactInformation, ContactInformationDto>> selector = i => new ContactInformationDto()
            {
                TownName = i.TownName,
                Address = i.Address,
                AddressForPay = i.AddressForPay,
                DateLock = i.DateLock,
                DepartmentId = i.Department.Id,
                DerpartmentName = i.Department.Name,
                Email = i.Email,
                Id = i.Id,
                Introduce = i.Introduce,
                PhoneNumber = i.PhoneNumber
            };

            var items = await _contactInformationRepository
                .QueryAndSelectAsync(
                    selector: selector,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<ContactInformationDto>()
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<ContactInformationDto> GetContactById(int id)
        {
            var contactInformation = await _contactInformationRepository.Get(id);

            if (contactInformation == null)
            {
                throw new Exception($"Can not find contact with id = {id}");
            }

            var result = new ContactInformationDto()
            {
                TownName = contactInformation.TownName,
                DepartmentId= contactInformation.Department.Id,
                Introduce= contactInformation.Introduce,
                DateLock= contactInformation.DateLock,
                Address = contactInformation.Address,
                AddressForPay= contactInformation.AddressForPay,
                Email = contactInformation.Email,
                Id= contactInformation.Id,
                PhoneNumber= contactInformation.PhoneNumber,
                DerpartmentName = contactInformation.Department.Name
            };

            return result;
        }

        public async Task<bool> Update(int id, ContactInformationDto model)
        {
            var contactInformation = await _contactInformationRepository.Get(id);

            if (contactInformation == null)
            {
                throw new Exception($"Can not find contact with id = {id}");
            }

            contactInformation.TownName = model.TownName;
            contactInformation.Address = model.Address;
            contactInformation.PhoneNumber = model.PhoneNumber;
            contactInformation.AddressForPay = model.AddressForPay;
            contactInformation.Email = model.Email;
            contactInformation.DateLock = model.DateLock;
            contactInformation.Introduce = model.Introduce;
            contactInformation.DepartmentId = model.DepartmentId;

            await _contactInformationRepository.Update(contactInformation);

            return true;
        }
    }
}
