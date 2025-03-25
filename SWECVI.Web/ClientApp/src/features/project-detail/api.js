import api from 'services/api';
import { project } from 'stores/reducers/project.reducer';

const apis = {
  project: (id) => `project-management/projects/${id}`,
  projects: 'project-management/projects',
  projectsForSelection: 'project-management/townshipsForSelection',
  managersForSelection: 'project-management/usersForSelection',
};

const API = {
  updateProject: (id, data) => api.put(apis.project(id), data),
  createProject: (data) => api.post(apis.projects, data),
  project: (id) => api.get(apis.project(id)),
  projectsForSelection: () => api.get(apis.projectsForSelection),
  managersForSelection: () => api.get(apis.managersForSelection),
};

export default API;
