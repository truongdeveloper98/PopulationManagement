import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import PAGES from 'navigation/pages';
// import { useSelector } from "react-redux";
// import { useJwt } from "react-jwt";
import { useSelector } from 'react-redux';
import { createProjectRequest, getProjectRequest, updateProjectRequest, getProjectsForSelection, getManagerForSelection } from '../services';

const useProjectDetail = () => {
  const [project, setProject] = useState(undefined);
  const navigate = useNavigate();
  const params = useParams();
  // const token = useSelector((state) => state.auth.token);
  // const { decodedToken } = useJwt(token);
  const [openBackdrop, setOpenBackdrop] = useState(false);
  const regionValue = useSelector((state) => state.project.region);

  useEffect(() => {
    if (params.id) {
      getProjectRequest(params?.id, (data) => {
        setProject(data);
      });
    }
  }, [params?.id]);

    useEffect(() => {
      getProjectsForSelection();
      getManagerForSelection();
      }, []);

  const handleSubmitForm = async (data) => {
    setOpenBackdrop(true);
    if (params?.id) {
      await updateProjectRequest(params.id, data, () => {
        navigate(PAGES.project);
      });
    } else {
      await createProjectRequest(data, () => {
        navigate(PAGES.project);
      });
    }
    setOpenBackdrop(false);
  };
  const handleCancel = () => {
    navigate(PAGES.project);
  };

  return {
    project, handleCancel, handleSubmitForm, openBackdrop, regionValue,
  };
};

export default useProjectDetail;
