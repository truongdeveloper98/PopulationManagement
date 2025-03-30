import api from 'services/api';

const apis = {
  peoples: 'peopleOfApartment-management/peopleOfApartments',
  deletePeoples: (id) => `peopleOfApartment-management/peopleOfApartments/${id}`,
  updatePeoples: (id) => `peopleOfApartment-management/peopleOfApartments/${id}`,
};

const API = {
  peoples: (params) => api.get(apis.peoples, { params }),
  deletePeoples: (id) => api.delete(apis.deletePeoples(id)),
  updatePeoples:  (id) => api.put(apis.updatePeoples(id)),
};

export default API;
