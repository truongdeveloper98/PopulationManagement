import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import PAGES from 'navigation/pages';
// import { useSelector } from "react-redux";
// import { useJwt } from "react-jwt";
import { useSelector } from 'react-redux';
import { createPeopleOfApartmentRequest, getPeopleOfApartmentRequest, updatePeopleOfApartmentRequest } from '../services';

const usePeopleOfApartmentDetail = () => {
  const [peopleOfApartment, setPeopleOfApartment] = useState(undefined);
  const navigate = useNavigate();
  const params = useParams();
  // const token = useSelector((state) => state.auth.token);
  // const { decodedToken } = useJwt(token);
  const [openBackdrop, setOpenBackdrop] = useState(false);
  const regionValue = useSelector((state) => state.peopleOfApartment.region);

  useEffect(() => {
    if (params.id) {
      getPeopleOfApartmentRequest(params?.id, (data) => {
        setPeopleOfApartment(data);
      });
    }
  }, [params?.id]);

  const handleSubmitForm = async (data) => {

    console.log(123, data);
    setOpenBackdrop(true);
    if (params?.id) {
      await updatePeopleOfApartmentRequest(params.id, data, () => {
        navigate(PAGES.PeopleOfApartment);
      });
    } else {
      await createPeopleOfApartmentRequest(data, () => {
        navigate(PAGES.peopleOfApartment);
      });
    }
    setOpenBackdrop(false);
  };
  const handleCancel = () => {
    navigate(PAGES.peopleOfApartment);
  };

  return {
    peopleOfApartment, handleCancel, handleSubmitForm, openBackdrop, regionValue, valueExport, setValueExport
  };
};

export default usePeopleOfApartmentDetail;
