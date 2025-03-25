import api from 'services/api';

const apis = {
  department: (id) => `department-management/departments/${id}`,
  departments: 'department-management/departments',
  managersForSelection: 'department-management/usersForSelection',
};

const API = {
  updateDepartment: (id, data) => api.put(apis.department(id), data),
  createDepartment: (data) => api.post(apis.departments, data),
  department: (id) => api.get(apis.department(id)),
  managersForSelection: () => api.get(apis.managersForSelection),
};

export default API;
