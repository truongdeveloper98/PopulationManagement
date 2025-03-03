import PAGES from 'navigation/pages';
import { useNavigate } from 'react-router-dom';
import { useRef } from 'react';
import { deleteCompanyRequest } from '../services';

const useCompany = () => {
  const navigate = useNavigate();
  const agRef = useRef(null);

  const onCreateCompany = () => {
    navigate(PAGES.newCompany);
  };

  const handleEditCompany = (id) => {
    navigate(`${PAGES.editCompany}/${id}`);
  };

  const handleDeleteCompany = (id, cb) => {
    if (!id) return;
    deleteCompanyRequest(id, cb);
  };

  return {
    agRef, onCreateCompany, handleEditCompany, handleDeleteCompany,
  };
};

export default useCompany;
