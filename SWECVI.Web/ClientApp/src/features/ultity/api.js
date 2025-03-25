import api from 'services/api';

const apis = {
  ultitys: 'ultity-management/ultitys',
  deleteUltitys: (id) => `ultity-management/ultitys/${id}`,
  updateUltitys: (id) => `ultity-management/ultitys/${id}`,
};

const API = {
  ultitys: (params) => api.get(apis.ultitys, { params }),
  deletUltitys: (id) => api.delete(apis.deleteUltitys(id)),
  updateUltitys:  (id) => api.put(apis.deleteUltitys(id)),
};

export default API;
