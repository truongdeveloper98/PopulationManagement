import api from 'services/api';

const apis = {
  exportPatient: 'patient-management/patients',
};

const API = {
  exportPatient: (data) => api.post(apis.exportPatient, data, {
    responseType: 'arraybuffer',
  }),
};

export default API;
