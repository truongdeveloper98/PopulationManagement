import PAGES from 'navigation/pages';
import { useNavigate } from 'react-router-dom';
import { useRef } from 'react';
import { deleteTownshipRequest } from '../services';

const useTownship = () => {
  const navigate = useNavigate();
  const agRef = useRef(null);

  const onCreateTownship = () => {
    navigate(PAGES.newTownship);
  };

  const handleEditTownship = (id) => {
    navigate(`${PAGES.editTownship}/${id}`);
  };

  const handleDeleteTownship = (id, cb) => {
    if (!id) return;
    deleteTownshipRequest(id, cb);
  };

  return {
    agRef, onCreateTownship, handleEditTownship, handleDeleteTownship,
  };
};

export default useTownship;
