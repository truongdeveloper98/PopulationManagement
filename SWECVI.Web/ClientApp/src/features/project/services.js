 
import { store } from 'stores';
import {
  projectsSuccess, failed, requested, succeed,
} from 'stores/reducers/project.reducer';
import API from './api';

export const getProjectRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.projects(params);
    if (response.data) {
      dispatch(projectsSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};

export const deleteProjectRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.deleteProjects(id);
    dispatch(succeed('Project deleted successfully'));
    if (callback) {
      callback();
    }
  } catch (error) {
    dispatch(failed(error?.response?.data));
  }
};
