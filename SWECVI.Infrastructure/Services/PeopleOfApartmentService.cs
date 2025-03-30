using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PasswordGenerator;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Entities.Building_Resident;
using SWECVI.ApplicationCore.Interfaces;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Repositories;

namespace SWECVI.Infrastructure.Services
{
    public class PeopleOfApartmentService : IPeopeOfApartmentService
    {
        private readonly IPeopleOfApartmentRepository _peopleOfApartmentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IUserService _userService;

        public PeopleOfApartmentService(IPeopleOfApartmentRepository personRepository, IUserRepository userRepository
            , IApartmentRepository apartmentRepository, IUserService userService)
        {
            _peopleOfApartmentRepository = personRepository;
            _userRepository = userRepository;
            _apartmentRepository = apartmentRepository;
            _userService = userService;
        }
        public async Task<bool> CreatePeopleOfApartment(PeopleOfApartmentDto model)
        {
            var user = _userRepository.FirstOrDefault(x => x.Id == model.AppUserId);

            if (user == null)
            {
              user =  await _userService.CreateUser(new UserInformationDto()
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            PhoneNumber = model.PhoneNumberUser,
                            Email = model.EmailUser,
                            Roles = new string[]{ "User"},
                            Password = "Admin@123",
                            IsActive = true
                        });
            }

            var apartment = _apartmentRepository.FirstOrDefault(x => x.Id == model.ApartmentId);

            if (apartment == null)
            {
                throw new Exception("Apartment not found");
            }

            var people = new PeopleOfApartment()
            {
                AppUserId = user.Id,
                Name = user.FullName,
                NationalId = model.NationalId,
                Dob = model.Dob,
                Gender = model.Gender,
                Relationship = model.Relationship,
                ApartmentId = apartment.Id,
            };
            await _peopleOfApartmentRepository.Add(people);

            return true;
        }

        public async Task<bool> DeletePeopleOfApartment(int id)
        {
            var peopleOfApartment = await _peopleOfApartmentRepository.Get(x => x.Id == id);

            if (peopleOfApartment == null)
            {
                throw new Exception($"Can not find the peopleOfApartment with id = {id}");
            }

            await _peopleOfApartmentRepository.Delete(peopleOfApartment);

            return true;
        }

        public async Task<PagedResponseDto<PeopleOfApartmentDto>> GetAllPeopleOfApartment(PagedRequestDto model)
        {
            Expression<Func<PeopleOfApartment, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<PeopleOfApartment, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                    (!string.IsNullOrEmpty(i.Name) &&
                                                                    i.NationalId.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _peopleOfApartmentRepository.Count(filter);

            Expression<Func<PeopleOfApartment, PeopleOfApartmentDto>> selector = i => new PeopleOfApartmentDto()
            {
                Id = i.Id,
                FirstName = i.AppUser.FirstName,
                LastName = i.AppUser.LastName,
                AppUserId = i.AppUser.Id,
                EmailUser = i.AppUser.EmailUser,
                PhoneNumberUser = i.AppUser.PhoneNumberUser,
                NationalId = i.NationalId,
                Dob = i.Dob,
                Gender = i.Gender,
                ApartmentId = i.ApartmentId,
                ApartmentName = i.Apartment.Name,
                Relationship = i.Relationship,
            };

            var items = await _peopleOfApartmentRepository
                .QueryAndSelectAsync(
                    selector: selector,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<PeopleOfApartmentDto>()
            {
                Page = model.CurrentPage,
                Limit = model.PageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<PeopleOfApartmentDto> GetPeopleOfApartmentById(int id)
        {
            var peopleOfApartment = await _peopleOfApartmentRepository.Get(x => x.Id == id, "Apartment,AppUser");

            if (peopleOfApartment == null)
            {
                throw new Exception($"Can not find the peopleOfApartment with id = {id}");
            }

            var result = new PeopleOfApartmentDto()
            {
                Id = peopleOfApartment.Id,
                FirstName = peopleOfApartment.AppUser.FirstName,
                LastName = peopleOfApartment.AppUser.LastName,
                AppUserId = peopleOfApartment.AppUser.Id,
                PhoneNumberUser = peopleOfApartment.AppUser.PhoneNumberUser,
                EmailUser = peopleOfApartment.AppUser.EmailUser,
                NationalId = peopleOfApartment.NationalId,
                Dob = peopleOfApartment.Dob,
                Gender = peopleOfApartment.Gender,
                ApartmentId = peopleOfApartment.ApartmentId,
                ApartmentName = peopleOfApartment.Apartment.Name,
                Relationship = peopleOfApartment.Relationship,
            };

            return result;
        }

        public async Task<bool> UpdatePeopleOfApartment(int id, PeopleOfApartmentDto model)
        {
            var peopleOfApartment = await _peopleOfApartmentRepository.Get(x => x.Id == id);

            if (peopleOfApartment == null)
            {
                throw new Exception($"Can not find the peopleOfApartment with id = {id}");
            }

            var user = _userRepository.FirstOrDefault(x => x.FirstName == model.FirstName);

            if (user == null)
            {
                throw new Exception("Can not find the user!");
            }

            var apartment = _apartmentRepository.FirstOrDefault(x => x.Id == model.ApartmentId);

            if (apartment == null)
            {
                throw new Exception("Apartment not found");
            }

            peopleOfApartment.NationalId = model.NationalId;
            peopleOfApartment.AppUserId = user.Id;
            peopleOfApartment.Name = user.FullName;
            peopleOfApartment.Dob = model.Dob;
            peopleOfApartment.Gender = model.Gender;
            peopleOfApartment.Relationship = model.Relationship;
            peopleOfApartment.ApartmentId = apartment.Id;

            await _peopleOfApartmentRepository.Update(peopleOfApartment);

            return true;
        }
    }
}
