import api from 'services/api';

const apis = {
  companies: 'company-management/companies',
  deleteCompanies: (id) => `company-management/companies/${id}`,
  updateCompanies: (id) => `company-management/companies/${id}`,
};

const API = {
  companies: (params) => api.get(apis.companies, { params }),
  deleteCompaies: (id) => api.delete(apis.deleteCompanies(id)),
  updateCompanies:  (id) => api.put(apis.updateCompanies(id)),
};

export default API;
