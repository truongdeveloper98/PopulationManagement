import { store } from 'stores';
import { failed, requested, succeed } from 'stores/reducers/projectInformation.reducer';
import API from './api';

export const updateProjectInformationRequest = async (id, data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.updateProjectInformation(id, data);
    dispatch(succeed('ProjectInformation updated successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const createProjectInformationRequest = async (data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.createProjectInformation(data);
    console.log(data);
    dispatch(succeed('ProjectInformation created successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getProjectInformationRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.projectInformation(id);
    if (response.data) {
      if (callback) callback(response.data);
    }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};
