import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import PAGES from 'navigation/pages';
// import { useSelector } from "react-redux";
// import { useJwt } from "react-jwt";
import { useSelector } from 'react-redux';
import { createCompanyRequest, getCompanyRequest, updateCompanyRequest } from '../services';

const useCompanyDetail = () => {
  const [company, setCompany] = useState(undefined);
  const navigate = useNavigate();
  const params = useParams();
  // const token = useSelector((state) => state.auth.token);
  // const { decodedToken } = useJwt(token);
  const [openBackdrop, setOpenBackdrop] = useState(false);
  const regionValue = useSelector((state) => state.company.region);

  useEffect(() => {
    if (params.id) {
      getCompanyRequest(params?.id, (data) => {
        setCompany(data);
      });
    }
  }, [params?.id]);

  const handleSubmitForm = async (data) => {
    setOpenBackdrop(true);
    if (params?.id) {
      await updateCompanyRequest(params.id, data, () => {
        navigate(PAGES.company);
      });
    } else {
      await createCompanyRequest(data, () => {
        navigate(PAGES.company);
      });
    }
    setOpenBackdrop(false);
  };
  const handleCancel = () => {
    navigate(PAGES.company);
  };

  return {
    company, handleCancel, handleSubmitForm, openBackdrop, regionValue,
  };
};

export default useCompanyDetail;
