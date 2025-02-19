import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import PAGES from 'navigation/pages';
import { useSelector } from 'react-redux';
import { loginRequest } from '../services';

const useSignIn = () => {
  const navigate = useNavigate();
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const token = useSelector((state) => state.auth.token);

  const handleLogin = () => {
    loginRequest({ email, password });
  };

  useEffect(() => {
    if (token) {
      navigate(PAGES.patients);
    }
  }, [token]);

  return {
    state: {
      email,
      setEmail,
      password,
      setPassword,
    },

    function: {
      handleLogin,
    },
  };
};
export default useSignIn;
