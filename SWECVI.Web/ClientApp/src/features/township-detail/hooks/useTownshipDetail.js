import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import PAGES from 'navigation/pages';
// import { useSelector } from "react-redux";
// import { useJwt } from "react-jwt";
import { createTownshipRequest, getTownshipRequest, updateTownshipRequest, getTownshipForSelection } from '../services';

const useTownshipDetail = () => {
  const [township, setTownship] = useState(undefined);
  const navigate = useNavigate();
  const params = useParams();
  // const token = useSelector((state) => state.auth.token);
  // const { decodedToken } = useJwt(token);
  const [openBackdrop, setOpenBackdrop] = useState(false);

  useEffect(() => {
    if (params.id) {
      getTownshipRequest(params?.id, (data) => {
        setTownship(data);
      });
    }
  }, [params?.id]);

  useEffect(() => {
    getTownshipForSelection();
    }, []);

  const handleSubmitForm = async (data) => {
    setOpenBackdrop(true);
    if (params?.id) {
      await updateTownshipRequest(params.id, data, () => {
        navigate(PAGES.township);
      });
    } else {
      await createTownshipRequest(data, () => {
        navigate(PAGES.township);
      });
    }
    setOpenBackdrop(false);
  };
  const handleCancel = () => {
    navigate(PAGES.township);
  };

  return {
    township, handleCancel, handleSubmitForm, openBackdrop
  };
};

export default useTownshipDetail;
