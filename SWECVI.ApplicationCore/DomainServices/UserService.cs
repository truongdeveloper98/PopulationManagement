using Microsoft.AspNetCore.Identity;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.ApplicationCore.Interfaces;
using SWECVI.ApplicationCore.Mapper;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Interfaces.Services;

namespace SWECVI.ApplicationCore.DomainServices
{
    public class UserService : IUserService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IUserRepository _userRepo;
        private readonly UserManager<AppUser> _userManager;

        public UserService(RoleManager<AppRole> roleManager, IUserRepository userRepo, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userRepo = userRepo;
            _userManager = userManager;
        }
        public async Task CreateUser(UserInformationDto userInformationDto)
        {
            if (string.IsNullOrEmpty(userInformationDto.Password))
            {
                throw new Exception($"Password is required");
            }

            if (userInformationDto.Roles == null || userInformationDto.Roles.Length == 0)
            {
                throw new Exception("Roles is required");
            }

            if (_userManager.FindByEmailAsync(userInformationDto.Email).Result != null)
            {
                throw new Exception("Duplicate Email");
            }

            var email = new EmailAddressAttribute();
            
            if (!email.IsValid(userInformationDto.Email))
            {
                throw new Exception("Invalid email");
            }

            AppUser appUser = userInformationDto.MapToAppUser();

            var result = await _userManager.CreateAsync(appUser, userInformationDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(appUser, userInformationDto.Roles);
                User user = userInformationDto.MapToUser();
                user.Identity = appUser;

                user.IdentityId = appUser.Id;
                
                await _userRepo.Add(user);
                
                return;
            }

            string errorMessages = "";

            foreach (var it in result.Errors)
            {
                errorMessages += it.Description + "\n";
            }

            throw new Exception(errorMessages);
            
        }

        public async Task UpdateUser(int id, UserInformationDto userModel)
        {
            var user = await _userRepo.Get(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (userModel.Roles == null)
            {
                throw new Exception("User has not contain role");
            }

            var appUser = await _userManager.FindByIdAsync(user.IdentityId.ToString());

            if (appUser == null)
            {
                throw new Exception("User not found");
            }

            if (!string.IsNullOrEmpty(userModel.Email) && userModel.Email != appUser.Email)
            {
                var emailExisted = await _userRepo.Get(u => u.Identity.Email != null &&
                                                            u.Identity.Email.ToUpper() == userModel.Email.ToUpper(),
                                                       "Identity");
                {
                    if (emailExisted != null)
                    {
                        throw new Exception("Email already exists");
                    }
                    appUser.Email = userModel.Email;
                    appUser.UserName = userModel.Email;
                }
            }

            if (!string.IsNullOrEmpty(userModel.FirstName) && userModel.FirstName != user.FirstName)
            {
                user.FirstName = userModel.FirstName;
                user.FullName = user.FirstName + " " + user.LastName;
            }

            if (!string.IsNullOrEmpty(userModel.LastName) && userModel.LastName != user.LastName)
            {
                user.LastName = userModel.LastName;
                user.FullName = user.FirstName + " " + user.LastName;
            }

            if (!string.IsNullOrEmpty(userModel.PhoneNumber) && userModel.PhoneNumber != appUser.PhoneNumber)
            {
                appUser.PhoneNumber = userModel.PhoneNumber;
            }

            if (userModel.Roles.Length > 0)
            {
                foreach (var role in userModel.Roles)
                {
                    var roleExisted = await _roleManager.RoleExistsAsync(role);
                    if (roleExisted)
                    {
                        var roles = await _userManager.GetRolesAsync(user.Identity);
                        if (!roles.SequenceEqual(userModel.Roles))
                        {
                            await _userManager.RemoveFromRolesAsync(appUser, roles);
                            await _userManager.AddToRolesAsync(appUser, userModel.Roles);
                        }
                    }
                }
            }

            var result = await _userManager.UpdateAsync(appUser);

            if (result.Succeeded)
            {
                await _userRepo.Update(user);

                return;
            }

            string errorMessages = "";

            foreach (var it in result.Errors)
            {
                errorMessages += it.Description + "\n";
            }

            throw new InvalidOperationException(errorMessages);
            
        }

        public async Task ActiveUser(int id)
        {
            var user = await _userRepo.Get(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.IsActive = true;
            await _userRepo.Update(user);
        }

        public async Task InactiveUser(int id)
        {
            var user = await _userRepo.Get(id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.IsActive = false;

            await _userRepo.Update(user);
        }

        public async Task<PagedResponseDto<UserInformationDto>> GetUsers(int currentPage, int pageSize, string? sortColumnDirection, string? sortColumnName, string? textSearch)
        {
            Expression<Func<User, bool>> filter = i => i.IsActive;

            if (!string.IsNullOrEmpty(textSearch))
            {
                Expression<Func<User, bool>> searchFilter = i => i.FullName.Contains(textSearch) ||  i.FirstName.Contains(textSearch) ||
                    i.LastName.Contains(textSearch) ||
                    (i.Identity.Email != null &&
                     i.Identity.Email.Contains(textSearch));

                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            Expression<Func<User, UserInformationDto>> selectorExpression = user => new UserInformationDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = user.IsActive,
                Email = user.Identity.Email ?? string.Empty,
                PhoneNumber = user.Identity.PhoneNumber ?? string.Empty,
                AppUser = user.Identity
            };


            var totalItems = await _userRepo.Count(filter);

            var items = await _userRepo
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, sortColumnName ?? string.Empty, sortColumnDirection ?? string.Empty),
                    "Identity",
                    pageSize,
                    page: currentPage
                );

            foreach (var item in items)
            {
                if (item.AppUser != null)
                {
                    item.Role = string.Join(',', await _userManager.GetRolesAsync(item.AppUser));
                }
            }

            return new PagedResponseDto<UserInformationDto>()
            {
                Page = currentPage,
                Limit = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                Items = (List<UserInformationDto>)items
            };
        }

        public async Task<UserInformationDto> GetUserById(int id)
        {
            var user = await _userRepo.Get(id, includeProperties: "Identity");

            if (user == null)
            {
                throw new Exception("User not found");
            }

            UserInformationDto userModel = new UserInformationDto();

            AppUser? appUser = await _userManager.FindByIdAsync(user.IdentityId.ToString());

            if(appUser == null)
            {
                throw new Exception("User not found");
            }

            userModel = user.MapToUserInformationDto();

          
            var roles = await _userManager.GetRolesAsync(appUser);
            if (roles != null)
            {
                userModel.Roles = new List<string>(roles).ToArray();
            }

            return userModel;
        }

        public async Task<string?> GetDoctorName(string userName)
        {
            var user = await _userRepo.Get(x => x.Identity.Email == userName, includeProperties: "Identity");

            return user?.FirstName + " " + user?.LastName;
        }
    }
}