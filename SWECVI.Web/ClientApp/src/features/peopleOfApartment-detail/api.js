import api from 'services/api';
import { peopleOfApartments } from 'stores/reducers/peopleOfApartment.reducer';

const apis = {
  peopleOfApartment: (id) => `peopleOfApartment-management/peopleOfApartments/${id}`,
  peopleOfApartments: 'peopleOfApartment-management/peopleOfApartments',
};

const API = {
  updatePeopleOfApartment: (id, data) => api.put(apis.peopleOfApartment(id), data),
  createPeopleOfApartment: (data) => api.post(apis.peopleOfApartments, data),
  peopleOfApartment: (id) => api.get(apis.peopleOfApartment(id)),
};

export default API;
