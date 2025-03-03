import api from 'services/api';
import { companies } from 'stores/reducers/company.reducer';

const apis = {
  company: (id) => `company-management/companies/${id}`,
  companies: `company-management/companies`,
};

const API = {
  updateCompany: (id, data) => api.put(apis.company(id), data),
  createCompany: (data) => api.post(apis.companies, data),
  company: (id) => api.get(apis.company(id)),
};

export default API;
