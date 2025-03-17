 
import { store } from 'stores';
import {
  projectInformationsSuccess, failed, requested, succeed,
} from 'stores/reducers/projectInformation.reducer';
import API from './api';

export const getProjectInformationRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.projectInformations(params);
    if (response.data) {
      dispatch(projectInformationsSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};

export const deleteProjectInformationRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.deleteProjectInformations(id);
    dispatch(succeed('Project Information deleted successfully'));
    if (callback) {
      callback();
    }
  } catch (error) {
    dispatch(failed(error?.response?.data));
  }
};
