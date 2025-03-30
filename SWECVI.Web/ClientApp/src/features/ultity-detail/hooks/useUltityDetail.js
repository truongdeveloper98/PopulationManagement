import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import PAGES from 'navigation/pages';
// import { useSelector } from "react-redux";
// import { useJwt } from "react-jwt";
import { useSelector } from 'react-redux';
import { createUltityRequest, getUltityRequest, updateUltityRequest } from '../services';

const useUltityDetail = () => {
  const [ultity, setUltity] = useState(undefined);
  const navigate = useNavigate();
  const params = useParams();
  // const token = useSelector((state) => state.auth.token);
  // const { decodedToken } = useJwt(token);
  const [openBackdrop, setOpenBackdrop] = useState(false);
  const regionValue = useSelector((state) => state.ultity.region);
  const [valueExport, setValueExport] = useState({ startDate: '', endDate: '', ultity: null });

  useEffect(() => {
    if (params.id) {
      getUltityRequest(params?.id, (data) => {
        setUltity(data);
      });
    }
  }, [params?.id]);

  const handleSubmitForm = async (data) => {

    console.log(123, data);
    setOpenBackdrop(true);
    if (params?.id) {
      await updateUltityRequest(params.id, data, () => {
        navigate(PAGES.ultity);
      });
    } else {
      await createUltityRequest(data, () => {
        navigate(PAGES.ultity);
      });
    }
    setOpenBackdrop(false);
  };
  const handleCancel = () => {
    navigate(PAGES.ultity);
  };

  return {
    ultity, handleCancel, handleSubmitForm, openBackdrop, regionValue, valueExport, setValueExport
  };
};

export default useUltityDetail;
