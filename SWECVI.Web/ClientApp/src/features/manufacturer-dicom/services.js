import { store } from 'stores';
import {
  failed,
  manufacturerDicomSuccess,
  requested,
} from 'stores/reducers/manufacturerDicom.reducer';
import API from './api';

export const getManufacturerDicomRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.manufacturerDicom(params);
     
    console.log(response);
    if (response.data) {
      dispatch(manufacturerDicomSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};
