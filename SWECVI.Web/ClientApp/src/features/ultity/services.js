 
import { store } from 'stores';
import {
  ultitysSuccess, failed, requested, succeed,
} from 'stores/reducers/ultity.reducer';
import API from './api';

export const getUltityRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.ultitys(params);
    if (response.data) {
      dispatch(ultitysSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};

export const deleteUltityRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.deleteUltitys(id);
    dispatch(succeed('Ultity deleted successfully'));
    if (callback) {
      callback();
    }
  } catch (error) {
    dispatch(failed(error?.response?.data));
  }
};
