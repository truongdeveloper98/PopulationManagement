import api from 'services/api';

const apis = {
  exportData: 'export-management/exports',
};

const API = {
  exportData: (params) => api.get(apis.exportData, { params }),
};

export default API;
