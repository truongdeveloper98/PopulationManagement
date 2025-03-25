import { store } from 'stores';
import { failed, requested, succeed, projectSelectionSuccess, managerSelectionSuccess } from 'stores/reducers/project.reducer';
import API from './api';

export const updateProjectRequest = async (id, data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.updateProject(id, data);
    dispatch(succeed('Project updated successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const createProjectRequest = async (data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.createProject(data);
    dispatch(succeed('Project created successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getProjectRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.project(id);
    if (response.data) {
      if (callback) callback(response.data);
    }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getProjectsForSelection = async () => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.projectsForSelection();
    if (response.data) {
          dispatch(projectSelectionSuccess(response.data));
        }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getManagerForSelection = async () => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.managersForSelection();
    if (response.data) {
          dispatch(managerSelectionSuccess(response.data));
        }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};