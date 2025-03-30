 
import { store } from 'stores';
import {
  peopleOfApartmentsSuccess, failed, requested, succeed,
} from 'stores/reducers/peopleOfApartment.reducer';
import API from './api';

export const getPeopleOfApartmentRequest = async (params) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.peopleOfApartments(params);
    if (response.data) {
      dispatch(peopleOfApartmentsSuccess(response.data));
    }
  } catch (error) {
    dispatch(failed(error));
  }
};

export const deletePeopleOfApartmentRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.deletePeopleOfApartments(id);
    dispatch(succeed('PeopleOfApartment deleted successfully'));
    if (callback) {
      callback();
    }
  } catch (error) {
    dispatch(failed(error?.response?.data));
  }
};
