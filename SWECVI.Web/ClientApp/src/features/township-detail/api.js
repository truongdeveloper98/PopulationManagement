import api from 'services/api';

const apis = {
  township: (id) => `township-management/townships/${id}`,
  townships: `township-management/townships`,
  townshipsForSelection: 'township-management/companiesForSelection',
};

const API = {
  updateTownship: (id, data) => api.put(apis.township(id), data),
  createTownship: (data) => api.post(apis.townships, data),
  township: (id) => api.get(apis.township(id)),
  townshipsForSelection: () => api.get(apis.townshipsForSelection),
};

export default API;
