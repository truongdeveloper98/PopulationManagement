/* eslint-disable no-unused-vars */
import {
  Autocomplete,
  Backdrop,
  Card,
  CircularProgress,
  FormHelperText,
  Grid,
  FormControlLabel,
  Switch,
  TextField
} from '@mui/material';
import BaseLayout from 'components/Customized/BaseLayout';
import FormField from 'components/Customized/FormFiled';
import Selector from 'components/Customized/Selector';
import MDBox from 'components/MDBox';
import MDButton from 'components/MDButton';
import MDTypography from 'components/MDTypography';
import { useMaterialUIController } from 'context';
import { Formik } from 'formik';
import React, { useEffect, useState } from 'react';
import { useTranslation } from 'react-i18next';
import * as Yup from 'yup';
import { useParams } from 'react-router-dom';
import REG_EXP from 'constants/regExp';
import usePeopleOfApartmentDetail from './hooks/usePeopleOfApartmentDetail';
import { useSelector } from 'react-redux';
import { position } from 'stylis';

const peopleOfApartmentSchema = Yup.object().shape({
  firstName: Yup.string()
    .matches(REG_EXP.UltityName, ' Name is not valid')
    .required('Required'),
  lastName: Yup.string().required("Required"),
  phoneNumberUser: Yup.string().required("Required"),
  emailUser: Yup.string().required("Required"),
  nationalId: Yup.string().required("Required"),
  dob: Yup.string().required("Required"),
  gender: Yup.string().required("Required"),
  apartmentName: Yup.string().required("Required"),
  relationShip: Yup.string().required("Required"),
});


function PeopleOfApartmentDetail() {
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;
  const { t } = useTranslation();
  const params = useParams();
  const {
    peopleOfApartment, handleCancel, handleSubmitForm, openBackdrop
  } = usePeopleOfApartmentDetail();

  return (
    <BaseLayout>
      <Formik
        enableReinitialize
        initialValues={{
          firstName : peopleOfApartment?.firstName,
          lastName: peopleOfApartment.lastName,
          phoneNumberUser: peopleOfApartment?.phoneNumberUser,
          emailUser: peopleOfApartment?.emailUser,
          nationalId: peopleOfApartment?.nationalId,
          dob: peopleOfApartment?.dob,
          gender: peopleOfApartment?.dob,
          relationShip: peopleOfApartment?.relationShip,
          apartmentName: peopleOfApartment?.apartmentName,
        }}
        validationSchema={ultitySchema}
        onSubmit={(values) => {
          const {
            firstName, lastName, phoneNumberUser, emailUser, nationalId, dob, gender, relationShip, apartmentName
          } = values;
          const data =
          {
            ...values,
          };

          const res = {
            ...data,
          }

          handleSubmitForm(res);
          //console.log(data);
        }}
      // validateOnChange={false}
      >
        {({
          values, errors, handleChange, handleSubmit, setFieldValue,
        }) =>
        (
          <>
            <Grid item xs={12} md={5} sx={{ textAlign: 'right', paddingBottom: 1 }}>
              <MDButton
                onClick={handleCancel}
                variant="gradient"
                color="error"
                sx={{ marginRight: 1 }}
              >
                {t('Cancel')}
              </MDButton>
              <MDButton variant="gradient" color="info" onClick={handleSubmit}>
                {t('SaveChanged')}
              </MDButton>
            </Grid>
            <MDBox
              height="80vh"
              mb={2}
              className={darkMode ? 'ag-theme-alpine-dark' : 'ag-theme-alpine'}
            >
              <Card id="basic-info" sx={{ overflow: 'visible' }}>
                <MDBox p={3}>
                  <MDTypography variant="h5">
                    {params?.id ? 'EditPeopleOfApartment' : 'CreatePeopleOfApartment'}
                  </MDTypography>
                </MDBox>
                <MDBox component="form" pb={3} px={3}>
                  <Grid container spacing={1}>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.firstName}
                        name="firstName"
                        label="firstName"
                        placeholder="firstName"
                        onChange={handleChange}
                        error={errors.firstName}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.lastName}
                        name="lastName"
                        label="lastName"
                        placeholder="lastName "
                        onChange={handleChange}
                        error={errors.lastName}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.phoneNumberUser}
                        name="phoneNumberUser"
                        label="phoneNumberUser"
                        placeholder="phoneNumberUser"
                        onChange={handleChange}
                        error={errors.phoneNumberUser}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.dob}
                        name="dob"
                        label="dob"
                        placeholder="dob"
                        onChange={handleChange}
                        error={errors.dob}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.emailUser}
                        name="emailUser"
                        label="emailUser"
                        placeholder="emailUser"
                        onChange={handleChange}
                        error={errors.emailUser}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.gender}
                        name="gender"
                        label="gender"
                        placeholder="gender"
                        onChange={handleChange}
                        error={errors.gender}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.nationalId}
                        name="nationalId"
                        label="nationalId"
                        placeholder="nationalId"
                        onChange={handleChange}
                        error={errors.nationalId}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.apartmentName}
                        name="apartmentName"
                        label="apartmentName"
                        placeholder="apartmentName"
                        onChange={handleChange}
                        error={errors.apartmentName}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.relationShip}
                        name="relationShip"
                        label="relationShip"
                        placeholder="relationShip"
                        onChange={handleChange}
                        error={errors.relationShip}
                      />
                    </Grid>
                    {!params?.id && (
                      <Grid item xs={12} sm={6}>

                      </Grid>
                    )}
                    {/*
                    <Grid item xs={12}>
                      <Typography fontSize={14} color="#7b809a">
                        Description
                      </Typography>
                      <TextareaAutosize
                        aria-label="minimum height"
                        style={{
                          width: "100%",
                          borderRadius: "8px",
                          border: "1px solid #C7D0DD",
                          padding: "5px",
                        }}
                        minRows={3}
                        value={values.description}
                        name="description"
                        placeholder="Thompson"
                        onChange={handleChange}
                      />
                    </Grid> */}
                  </Grid>
                </MDBox>
              </Card>
            </MDBox>
          </>
        )}
      </Formik>
      <Backdrop
        sx={{ color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={openBackdrop}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </BaseLayout>
  );
}

export default PeopleOfApartmentDetail;
