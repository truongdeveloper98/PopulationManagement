import { store } from 'stores';
import { failed, requested, succeed, townshipSelectionSuccess } from 'stores/reducers/township.reducer';
import API from './api';

export const updateTownshipRequest = async (id, data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.updateTownship(id, data);
    dispatch(succeed('Township updated successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const createTownshipRequest = async (data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.createTownship(data);
    dispatch(succeed('Township created successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getTownshipRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.township(id);
    if (response.data) {
      if (callback) callback(response.data);
    }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getTownshipForSelection = async () => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.townshipsForSelection();
    if (response.data) {
          dispatch(townshipSelectionSuccess(response.data));
        }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};
