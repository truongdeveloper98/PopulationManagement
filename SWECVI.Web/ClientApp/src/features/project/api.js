import api from 'services/api';

const apis = {
  projects: 'project-management/project',
  deleteProjects: (id) => `project-management/project/${id}`,
  updateProjects: (id) => `project-management/project/${id}`,
};

const API = {
  projects: (params) => api.get(apis.projects, { params }),
  deleteProjects: (id) => api.delete(apis.deleteProjects(id)),
  updateProjects:  (id) => api.put(apis.updateProjects(id)),
};

export default API;
