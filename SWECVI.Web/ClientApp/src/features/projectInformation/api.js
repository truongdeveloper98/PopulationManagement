import api from 'services/api';

const apis = {
  projectInformations: 'projectInformation-management/projectInformations',
  deleteprojectInformations: (id) => `projectInformation-management/projectInformations/${id}`,
  updateprojectInformation: (id) => `projectInformation-management/projectInformations/${id}`,
};

const API = {
  projectInformations: (params) => api.get(apis.projectInformations, { params }),
  deleteProjectInformations: (id) => api.delete(apis.deleteInformation(id)),
  updateProjectInformation:  (id) => api.put(apis.updateInformation(id)),
};

export default API;
