 
import { store } from 'stores';
import {
  jobsSuccess, failed, requested, succeed,
} from 'stores/reducers/job.reducer';
import API from './api';

export const getJobRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.jobs(params);
    if (response.data) {
      dispatch(jobsSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};

export const deleteJobRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.deleteJobs(id);
    dispatch(succeed('Job deleted successfully'));
    if (callback) {
      callback();
    }
  } catch (error) {
    dispatch(failed(error?.response?.data));
  }
};
