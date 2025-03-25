 
import { store } from 'stores';
import {
  staffsSuccess, failed, requested, succeed,
} from 'stores/reducers/staff.reducer';
import API from './api';

export const getStaffRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.staffs(params);
    if (response.data) {
      dispatch(staffsSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};

export const deleteStaffRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.deleteStaffs(id);
    dispatch(succeed('Staff deleted successfully'));
    if (callback) {
      callback();
    }
  } catch (error) {
    dispatch(failed(error?.response?.data));
  }
};
