import api from 'services/api';

const apis = {
  manufacturerDicom: (id) => `reference-management/manufacturerDicom/${id}`,
  manufacturerDicoms: 'reference-management/manufacturerDicom',
};

const API = {
  updateManufacturerDicom: (id, data) => api.put(apis.manufacturerDicom(id), data),
  createManufacturerDicom: (data) => api.post(apis.manufacturerDicoms, data),
  manufacturerDicom: (id) => api.get(apis.manufacturerDicom(id)),
};

export default API;
