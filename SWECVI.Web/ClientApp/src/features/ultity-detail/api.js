import api from 'services/api';
import { ultitys } from 'stores/reducers/ultity.reducer';

const apis = {
  ultity: (id) => `ultity-management/ultitys/${id}`,
  ultitys: 'ultity-management/ultitys',
};

const API = {
  updateUltity: (id, data) => api.put(apis.ultity(id), data),
  createUltity: (data) => api.post(apis.ultitys, data),
  ultity: (id) => api.get(apis.ultity(id)),
};

export default API;
