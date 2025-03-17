import PAGES from 'navigation/pages';
import { useNavigate } from 'react-router-dom';
import { useRef } from 'react';
import { deleteProjectRequest } from '../services';

const useProject = () => {
  const navigate = useNavigate();
  const agRef = useRef(null);

  const onCreateProject = () => {
    navigate(PAGES.newProject);
  };

  const handleEditProject = (id) => {
    navigate(`${PAGES.editProject}/${id}`);
  };

  const handleDeleteProject = (id, cb) => {
    if (!id) return;
    deleteProjectRequest(id, cb);
  };

  return {
    agRef, onCreateProject, handleEditProject, handleDeleteProject,
  };
};

export default useProject;
