import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import PAGES from 'navigation/pages';
// import { useSelector } from "react-redux";
// import { useJwt } from "react-jwt";
import { useSelector } from 'react-redux';
import { createProjectInformationRequest, getProjectInformationRequest, updateProjectInformationRequest } from '../services';

const useProjectInformationDetail = () => {
  const [projectInformation, setProjectInformation] = useState(undefined);
  const navigate = useNavigate();
  const params = useParams();
  // const token = useSelector((state) => state.auth.token);
  // const { decodedToken } = useJwt(token);
  const [openBackdrop, setOpenBackdrop] = useState(false);
  const regionValue = useSelector((state) => state.projectInformation.region);

  useEffect(() => {
    if (params.id) {
      getProjectInformationRequest(params?.id, (data) => {
        setProjectInformation(data);
      });
    }
  }, [params?.id]);

  const handleSubmitForm = async (data) => {
    setOpenBackdrop(true);
    if (params?.id) {
      await updateProjectInformationRequest(params.id, data, () => {
        navigate(PAGES.projectInformation);
      });
    } else {
      await createProjectInformationRequest(data, () => {
        navigate(PAGES.projectInformation);
      });
    }
    setOpenBackdrop(false);
  };
  const handleCancel = () => {
    navigate(PAGES.projectInformation);
  };

  return {
    projectInformation, handleCancel, handleSubmitForm, openBackdrop, regionValue,
  };
};

export default useProjectInformationDetail;
