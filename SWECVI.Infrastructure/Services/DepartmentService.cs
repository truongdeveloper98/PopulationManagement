using System.Linq.Expressions;
using NPOI.SS.Formula.Functions;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.ViewModels;
using SWECVI.Infrastructure.Repositories;

namespace SWECVI.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> CreateDepartment(DepartmentDto model)
        {
            var department = new Department()
            {
                Name = model.Name,
                DepartmentId = model.DepartmentId,
                Description = model.Description,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                ManagerId = model.ManagerId,
                IsStatus = model.IsStatus,
                IsCommentStatus = model.IsCommentStatus,
                IsNotifyStatus = model.IsNotifyStatus,
                IsReceiveJobStatus = model.IsReceiveJobStatus
            };

            await _departmentRepository.Add(department);

            return true;
        }

        public async Task<bool> UpdateDepartment(int id, DepartmentDto model)
        {
            var department = await _departmentRepository.Get(x => x.Id == id);

            if (department == null)
            {
                throw new Exception($"Can not find the department with id = {id}");
            }

            department.Name = model.Name;
            department.DepartmentId = model.DepartmentId;
            department.Description = model.Description;
            department.Email = model.Email;
            department.PhoneNumber = model.PhoneNumber;
            department.IsStatus = model.IsStatus;
            department.IsCommentStatus = model.IsCommentStatus;
            department.IsReceiveJobStatus = model.IsReceiveJobStatus;
            department.IsNotifyStatus = model.IsNotifyStatus;
            department.ManagerId = model.ManagerId; 

            await _departmentRepository.Update(department);

            return true;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.Get(x => x.Id == id);

            if (department == null)
            {
                throw new Exception($"Can not find the Department with id = {id}");
            }

            await _departmentRepository.Delete(department);

            return true;
        }

        public async Task<DepartmentDto> GetById(int id)
        {
            var department = await _departmentRepository.Get(x => x.Id == id, "DepartmentManager");

            if (department == null)
            {
                throw new Exception($"Can not find the department with id = {id}");
            }

            var result = new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                DepartmentId = department.DepartmentId,
                Description = department.Description,
                PhoneNumber = department.PhoneNumber,
                Email = department.Email,
                ManagerId = department.ManagerId,
                ManagerName = department.DepartmentManager == null ? string.Empty : department.DepartmentManager.UserName,
                IsStatus = department.IsStatus,
                IsNotifyStatus = department.IsNotifyStatus,
                IsReceiveJobStatus = department.IsReceiveJobStatus,
                IsCommentStatus = department.IsCommentStatus,
            };

            return result;
        }

        public async Task<PagedResponseDto<DepartmentDto>> GetAllDepartments(PagedRequestDto model)
        {
            Expression<Func<Department, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<Department, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                (!string.IsNullOrEmpty(i.DepartmentId) &&
                                                                  i.DepartmentId.Contains(model.TextSearch));

                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _departmentRepository.Count(filter);

            Expression<Func<Department, DepartmentDto>> selectorExpression = i => new DepartmentDto()
            {
                Id = i.Id,
                Name = i.Name,
                DepartmentId = i.DepartmentId,
                Description = i.Description,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber,
                IsReceiveJobStatus = i.IsReceiveJobStatus,
                IsNotifyStatus = i.IsNotifyStatus,
                IsCommentStatus = i.IsCommentStatus,
                IsStatus = i.IsStatus,
                ManagerId = i.ManagerId,
                ManagerName = i.DepartmentManager.UserName ?? string.Empty,
            };

            var items = await _departmentRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    page: model.CurrentPage,
                    pageSize: model.PageSize
                );

            return new PagedResponseDto<DepartmentDto>()
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<List<DepartmentDto>> GetDepartmentsForSelection()
        {
            var department = await _departmentRepository.QueryAndSelectAsync(selector: x => new DepartmentDto()
            {
                Id = x.Id,
                Name = x.Name,
            });

            return department.ToList();
        }

    }
}
