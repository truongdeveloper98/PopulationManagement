import PAGES from 'navigation/pages';
import { useNavigate } from 'react-router-dom';
import { useRef } from 'react';
import { deleteUltityRequest } from '../services';

const useUltity = () => {
  const navigate = useNavigate();
  const agRef = useRef(null);

  const onCreateUltity = () => {
    navigate(PAGES.newUltity);
  };

  const handleEditUltity = (id) => {
    navigate(`${PAGES.editUltity}/${id}`);
  };

  const handleDeleteUltity = (id, cb) => {
    if (!id) return;
    deleteUltityRequest(id, cb);
  };

  return {
    agRef, onCreateUltity, handleEditUltity, handleDeleteUltity,
  };
};

export default useUltity;
