import PAGES from 'navigation/pages';
import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import {
  createManufacturerDicomRequest,
  getManufacturerDicomRequest,
  updateManufacturerDicomRequest,
} from '../services';

const useManufacturerDicomDetail = () => {
  const [manufacturerDicom, setManufacturerDicom] = useState(undefined);
  const navigate = useNavigate();
  const params = useParams();
  const [openBackdrop, setOpenBackdrop] = useState(false);

  useEffect(() => {
    if (params.id) {
      getManufacturerDicomRequest(params?.id, (data) => {
        setManufacturerDicom(data);
      });
    }
  }, [params?.id]);

  const handleCancel = () => {
    navigate(PAGES.manufacturerDicom);
  };

  const handleSubmitForm = async (data) => {
    setOpenBackdrop(true);
    if (params?.id) {
      await updateManufacturerDicomRequest(params.id, data, () => {
        navigate(PAGES.manufacturerDicom);
      });
    } else {
      await createManufacturerDicomRequest(data, () => {
        navigate(PAGES.manufacturerDicom);
      });
    }
    setOpenBackdrop(false);
  };

  return {
    handleCancel, manufacturerDicom, handleSubmitForm, openBackdrop,
  };
};

export default useManufacturerDicomDetail;
