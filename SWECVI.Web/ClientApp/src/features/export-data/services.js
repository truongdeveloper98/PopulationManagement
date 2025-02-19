import { store } from 'stores';
import { exportDataSuccess, failed, requested } from 'stores/reducers/exportData.reducer';
import API from './api';

export const getExportDataRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.exportData(params);
     
    console.log(response);
    if (response.data) {
      dispatch(exportDataSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};

export const downloadExportDataRequest = async () => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.exportData();
     
    console.log(response);
    if (response.data) {
      dispatch(exportDataSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};
