import { store } from 'stores';
import { failed, requested, succeed } from 'stores/reducers/peopleOfApartment.reducer';
import API from './api';

export const updatePeopleOfApartmentRequest = async (id, data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.updatePeopleOfApartment(id, data);
    dispatch(succeed('PeopleOfApartment updated successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const createPeopleOfApartmentRequest = async (data, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    await API.createPeopleOfApartment(data);
    dispatch(succeed('PeopleOfApartment created successfully'));
    if (callback) callback();
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

export const getPeopleOfApartmentRequest = async (id, callback) => {
  const { dispatch } = store;
  try {
    dispatch(requested());
    const response = await API.peopleOfApartment(id);
    if (response.data) {
      if (callback) callback(response.data);
    }
  } catch (error) {
    dispatch(failed(error.response?.data));
  }
};

