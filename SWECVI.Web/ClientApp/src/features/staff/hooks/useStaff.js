import PAGES from 'navigation/pages';
import { useNavigate } from 'react-router-dom';
import { useRef } from 'react';
import { deleteStaffRequest } from '../services';

const useStaff = () => {
  const navigate = useNavigate();
  const agRef = useRef(null);

  const onCreateStaff = () => {
    navigate(PAGES.newStaff);
  };

  const handleEditStaff = (id) => {
    navigate(`${PAGES.editStaff}/${id}`);
  };

  const handleDeleteStaff = (id, cb) => {
    if (!id) return;
    deleteStaffRequest(id, cb);
  };

  return {
    agRef, onCreateStaff, handleEditStaff, handleDeleteStaff,
  };
};

export default useStaff;
