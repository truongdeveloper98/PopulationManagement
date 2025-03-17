import api from 'services/api';
import { projectInformations } from 'stores/reducers/projectInformation.reducer';

const apis = {
  projectInformation: (id) => `projectInformation-management/projectInformations/${id}`,
  projectInformations: 'projectInformation-management/projectInformations',
};

const API = {
  updateProjectInformation: (id, data) => api.put(apis.projectInformation(id), data),
  createProjectInformation: (data) => api.post(apis.projectInformations, data),
  projectInformation: (id) => api.get(apis.projectInformation(id)),
};

export default API;
