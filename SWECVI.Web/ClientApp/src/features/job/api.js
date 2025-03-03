import api from 'services/api';

const apis = {
  jobs: 'job-management/jobs',
  deleteJobs: (id) => `job-management/jobs/${id}`,
  updateJob: (id) => `job-management/jobs/${id}`,
};

const API = {
  jobs: (params) => api.get(apis.jobs, { params }),
  deleteJobs: (id) => api.delete(apis.deleteJob(id)),
  updateJob:  (id) => api.put(apis.updateJob(id)),
};

export default API;
