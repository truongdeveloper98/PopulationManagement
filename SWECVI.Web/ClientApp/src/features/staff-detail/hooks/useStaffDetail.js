import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import PAGES from 'navigation/pages';
// import { useSelector } from "react-redux";
// import { useJwt } from "react-jwt";
import { useSelector } from 'react-redux';
import { createStaffRequest, getStaffRequest, updateStaffRequest, getDepartmentForSelection } from '../services';

const useStaffDetail = () => {
  const [staff, setStaff] = useState(undefined);
  const navigate = useNavigate();
  const params = useParams();
  // const token = useSelector((state) => state.auth.token);
  // const { decodedToken } = useJwt(token);
  const [openBackdrop, setOpenBackdrop] = useState(false);
  const regionValue = useSelector((state) => state.staff.region);

  useEffect(() => {
    if (params.id) {
      getStaffRequest(params?.id, (data) => {
        setStaff(data);
      });
    }
  }, [params?.id]);

    useEffect(() => {
      getDepartmentForSelection();
      }, []);

  const handleSubmitForm = async (data) => {
    setOpenBackdrop(true);
    if (params?.id) {
      await updateStaffRequest(params.id, data, () => {
        navigate(PAGES.staff);
      });
    } else {
      await createStaffRequest(data, () => {
        navigate(PAGES.staff);
      });
    }
    setOpenBackdrop(false);
  };
  const handleCancel = () => {
    navigate(PAGES.staff);
  };

  return {
    staff, handleCancel, handleSubmitForm, openBackdrop, regionValue,
  };
};

export default useStaffDetail;
