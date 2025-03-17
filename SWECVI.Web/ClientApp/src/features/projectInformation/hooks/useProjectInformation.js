import PAGES from 'navigation/pages';
import { useNavigate } from 'react-router-dom';
import { useRef } from 'react';
import { deleteProjectInformationRequest } from '../services';

const useProjectInformation = () => {
  const navigate = useNavigate();
  const agRef = useRef(null);

  const onCreateProjectInformation = () => {
    navigate(PAGES.newProjectInformation);
  };

  const handleEditProjectInformation = (id) => {
    navigate(`${PAGES.editProjectInformation}/${id}`);
  };

  const handleDeleteProjectInformation = (id, cb) => {
    if (!id) return;
    deleteProjectInformationRequest(id, cb);
  };

  return {
    agRef, onCreateProjectInformation, handleEditProjectInformation, handleDeleteProjectInformation,
  };
};

export default useProjectInformation;
