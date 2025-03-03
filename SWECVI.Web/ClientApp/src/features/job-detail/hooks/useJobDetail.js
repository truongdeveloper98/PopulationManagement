import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import PAGES from 'navigation/pages';
// import { useSelector } from "react-redux";
// import { useJwt } from "react-jwt";
import { useSelector } from 'react-redux';
import { createJobRequest, getJobRequest, updateJobRequest } from '../services';

const useJobDetail = () => {
  const [job, setJob] = useState(undefined);
  const navigate = useNavigate();
  const params = useParams();
  // const token = useSelector((state) => state.auth.token);
  // const { decodedToken } = useJwt(token);
  const [openBackdrop, setOpenBackdrop] = useState(false);
  const regionValue = useSelector((state) => state.job.region);

  useEffect(() => {
    if (params.id) {
      getJobRequest(params?.id, (data) => {
        setJob(data);
      });
    }
  }, [params?.id]);

  const handleSubmitForm = async (data) => {
    setOpenBackdrop(true);
    if (params?.id) {
      await updateJobRequest(params.id, data, () => {
        navigate(PAGES.job);
      });
    } else {
      await createJobRequest(data, () => {
        navigate(PAGES.job);
      });
    }
    setOpenBackdrop(false);
  };
  const handleCancel = () => {
    navigate(PAGES.job);
  };

  return {
    job, handleCancel, handleSubmitForm, openBackdrop, regionValue,
  };
};

export default useJobDetail;
