import api from 'services/api';
import { jobs } from 'stores/reducers/job.reducer';

const apis = {
  job: (id) => `job-management/jobs/${id}`,
  jobs: 'job-management/jobs',
};

const API = {
  updateJob: (id, data) => api.put(apis.job(id), data),
  createJob: (data) => api.post(apis.jobs, data),
  job: (id) => api.get(apis.job(id)),
};

export default API;
