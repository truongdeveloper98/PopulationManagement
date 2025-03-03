 
import { store } from 'stores';
import {
  companiesSuccess, failed, requested, succeed,
} from 'stores/reducers/company.reducer';
import API from './api';

export const getCompanyRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.companies(params);
    if (response.data) {
      dispatch(companiesSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};

export const deleteCompanyRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.deleteCompanies(id);
    dispatch(succeed('Company deleted successfully'));
    if (callback) {
      callback();
    }
  } catch (error) {
    dispatch(failed(error?.response?.data));
  }
};
