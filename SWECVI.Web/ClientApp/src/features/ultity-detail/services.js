import { store } from 'stores';
import { failed, requested, succeed } from 'stores/reducers/ultity.reducer';
import API from './api';

export const updateUltityRequest = async (id, data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.updateUltity(id, data);
    dispatch(succeed('Ultity updated successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const createUltityRequest = async (data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.createUltity(data);
    dispatch(succeed('Ultity created successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getUltityRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.ultity(id);
    if (response.data) {
      if (callback) callback(response.data);
    }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

