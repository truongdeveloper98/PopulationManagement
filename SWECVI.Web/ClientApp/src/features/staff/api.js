import api from 'services/api';

const apis = {
  staffs: 'staff-management/staffs',
  deleteStaffs: (id) => `staff-management/staffs/${id}`,
  updateStaffs: (id) => `staff-management/staffs/${id}`,
};

const API = {
  staffs: (params) => api.get(apis.staffs, { params }),
  deleteStaffs: (id) => api.delete(apis.deleteStaffs(id)),
  updateStaffs:  (id) => api.put(apis.updateStaffs(id)),
};

export default API;
