import PAGES from 'navigation/pages';
import { useNavigate } from 'react-router-dom';
import { useRef } from 'react';
import { deleteJobRequest } from '../services';

const useJob = () => {
  const navigate = useNavigate();
  const agRef = useRef(null);

  const onCreateJob = () => {
    navigate(PAGES.newJob);
  };

  const handleEditJob = (id) => {
    navigate(`${PAGES.editJob}/${id}`);
  };

  const handleDeleteJob = (id, cb) => {
    if (!id) return;
    deleteJobRequest(id, cb);
  };

  return {
    agRef, onCreateJob, handleEditJob, handleDeleteJob,
  };
};

export default useJob;
