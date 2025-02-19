import PAGES from 'navigation/pages';
import { useRef } from 'react';
import { useNavigate } from 'react-router-dom';

const useFindingStructure = () => {
  const navigate = useNavigate();
  const agRef = useRef();

  const onCreateFinding = () => {
    navigate(PAGES.newFinding);
  };

  const handleEditFidings = async (id) => {
    navigate(`${PAGES.editFinding}/${id}`);
  };

  return { agRef, onCreateFinding, handleEditFidings };
};

export default useFindingStructure;
