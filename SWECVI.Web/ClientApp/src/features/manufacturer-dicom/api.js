import api from 'services/api';

const apis = {
  manufacturerDicom: 'reference-management/references',
};

const API = {
  manufacturerDicom: (params) => api.get(apis.manufacturerDicom, { params }),
};

export default API;
