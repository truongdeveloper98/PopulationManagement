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
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public async Task<bool> CreateStaff(StaffDto model)
        {
            var staff = new StaffUser()
            {
                Name = model.Name,
                StaffCode = model.StaffCode,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Position = model.Position,
                NationalId = model.NationalId,
                Address = model.Address,
                DepartmentId = model.DepartmentId,
            };

            await _staffRepository.Add(staff);

            return true;
        }

        public async Task<bool> DeleteStaff(int id)
        {
            var staff = await _staffRepository.Get(x => x.Id == id);

            if (staff == null)
            {
                throw new Exception($"Can not find the staff with id = {id}");
            }

            await _staffRepository.Delete(staff);

            return true;
        }

        public async Task<PagedResponseDto<StaffDto>> GetAllStaffs(PagedRequestDto model)
        {
            Expression<Func<StaffUser, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<StaffUser, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                     (!string.IsNullOrEmpty(i.StaffCode) &&
                                                                     i.StaffCode.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _staffRepository.Count(filter);

            Expression<Func<StaffUser, StaffDto>> selectorExpression = i => new StaffDto()
            {
                Id = i.Id,
                StaffCode = i.StaffCode,
                Name = i.Name,
                PhoneNumber = i.PhoneNumber,
                Email = i.Email,
                DepartmentId = i.DepartmentId,
                DepartmentName = i.Department.Name,
                Position = i.Position,
                NationalId = i.NationalId,
                Address = i.Address
            };

            var items = await _staffRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<StaffDto>
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<StaffDto> GetStaffById(int id)
        {
            var staff = await _staffRepository.Get(x => x.Id == id, "Department");

            if (staff == null)
            {
                throw new Exception($"Can not find the staff with id = {id}");
            }

            var result = new StaffDto()
            {
                Id = id,
                Name = staff.Name,
                StaffCode = staff.StaffCode,
                PhoneNumber = staff.PhoneNumber,
                Email = staff.Email,
                NationalId = staff.NationalId,
                Address = staff.Address,
                Position = staff.Position,
                DepartmentId = staff.DepartmentId,
                DepartmentName = staff.Department.Name
            };

            return result;
        }

        public async Task<bool> UpdateStaff(int id, StaffDto model)
        {
            var staff = await _staffRepository.Get(x => x.Id == id);

            if (staff == null)
            {
                throw new Exception($"Can not find the staff with id = {id}");
            }

            staff.StaffCode = model.StaffCode;
            staff.Name = model.Name;
            staff.PhoneNumber = model.PhoneNumber;
            staff.Email = model.Email;
            staff.NationalId = model.NationalId;
            staff.Address = model.Address;
            staff.Position = model.Position;
            staff.DepartmentId = model.DepartmentId;

            await _staffRepository.Update(staff);

            return true;
        }
    }
}
