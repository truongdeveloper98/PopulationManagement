 
import { store } from 'stores';
import {
  townshipsSuccess, failed, requested, succeed,
} from 'stores/reducers/township.reducer';
import API from './api';

export const getTownshipRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.townships(params);
    if (response.data) {
      dispatch(townshipsSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};

export const deleteTownshipRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.deleteTownships(id);
    dispatch(succeed('Township deleted successfully'));
    if (callback) {
      callback();
    }
  } catch (error) {
    dispatch(failed(error?.response?.data));
  }
};
