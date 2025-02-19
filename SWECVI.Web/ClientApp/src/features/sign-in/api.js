import api from 'services/api';

const apis = {
  login: 'auth/login',
};

const API = {
  login: (email, password) => {
    return api.post(
      apis.login,
      { email, password },
      { headers: { ...api.defaults.headers } },
    );
  },
};

export default API;
