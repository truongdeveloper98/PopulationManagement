import PAGES from 'navigation/pages';
import { useNavigate } from 'react-router-dom';
import { useRef } from 'react';
import { deletePeopleOfApartmentRequest } from '../services';

const usePeopleOfApartment = () => {
  const navigate = useNavigate();
  const agRef = useRef(null);

  const onCreatePeopleOfApartment = () => {
    navigate(PAGES.newPeopleOfApartment);
  };

  const handleEditPeopleOfApartment = (id) => {
    navigate(`${PAGES.editPeopleOfApartment}/${id}`);
  };

  const handleDeletePeopleOfApartment = (id, cb) => {
    if (!id) return;
    deletePeopleOfApartmentRequest(id, cb);
  };

  return {
    agRef, onCreatePeopleOfApartment, handleEditPeopleOfApartment, handleDeletePeopleOfApartment,
  };
};

export default usePeopleOfApartment;
