import { store } from 'stores';
import { failed, requested, succeed } from 'stores/reducers/manufacturerDicom.reducer';
import API from './api';

export const updateManufacturerDicomRequest = async (id, data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    // await API.updateManufacturerDicom(id, data);
    dispatch(succeed('Manufacturer Dicom updated successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const createManufacturerDicomRequest = async (data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    // await API.createManufacturerDicom(data);
    dispatch(succeed('Manufacturer Dicom created successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getManufacturerDicomRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.manufacturerDicom(id);
    if (response.data) {
      if (callback) callback(response.data);
    }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};
