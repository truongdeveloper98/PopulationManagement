import { getDepartmentRequest } from 'features/department/services';
import PAGES from 'navigation/pages';
import { useEffect, useRef } from 'react';
import { useNavigate } from 'react-router-dom';

const useManufacturerDicom = () => {
  const navigate = useNavigate();
  const agRef = useRef();

  useEffect(() => {
    getDepartmentRequest();
  }, []);

  const onCreateManufacturerDicom = () => {
    navigate(PAGES.newManufacturerDicom);
  };

  const handleEditManufacturerDicom = async (id) => {
    navigate(`${PAGES.editManufacturerDicom}/${id}`);
  };

  return { agRef, onCreateManufacturerDicom, handleEditManufacturerDicom };
};

export default useManufacturerDicom;
