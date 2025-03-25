import { store } from 'stores';
import { failed, requested, succeed, departmentSelectionSuccess } from 'stores/reducers/staff.reducer';
import API from './api';

export const updateStaffRequest = async (id, data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.updateStaff(id, data);
    dispatch(succeed('Staff updated successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const createStaffRequest = async (data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.createStaff(data);
    dispatch(succeed('Staff created successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getStaffRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.staff(id);
    if (response.data) {
      if (callback) callback(response.data);
    }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getDepartmentForSelection = async () => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.departmentsForSelection();
    if (response.data) {
          dispatch(departmentSelectionSuccess(response.data));
        }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};