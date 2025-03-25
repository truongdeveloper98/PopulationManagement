import api from 'services/api';
import { staff } from 'stores/reducers/staff.reducer';

const apis = {
  staff: (id) => `staff-management/staffs/${id}`,
  staffs: 'staff-management/staffs',
  departmentsForSelection: 'staff-management/departmentsForSelection',
};

const API = {
  updateStaff: (id, data) => api.put(apis.staff(id), data),
  createStaff: (data) => api.post(apis.staffs, data),
  staff: (id) => api.get(apis.staff(id)),
  departmentsForSelection: () => api.get(apis.departmentsForSelection),
};

export default API;
