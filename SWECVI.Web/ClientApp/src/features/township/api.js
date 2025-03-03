import api from 'services/api';

const apis = {
  townships: 'township-management/townships',
  deleteTownships: (id) => `township-management/townships/${id}`,
  updateTownships: (id) => `township-management/townships/${id}`,
};

const API = {
  townships: (params) => api.get(apis.townships, { params }),
  deleteTownships: (id) => api.delete(apis.deleteTownships(id)),
  updateTownships:  (id) => api.put(apis.updateTownships(id)),
};

export default API;
