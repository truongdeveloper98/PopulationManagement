/* eslint-disable no-unused-vars */
import {
  Autocomplete,
  Backdrop,
  Card,
  CircularProgress,
  FormHelperText,
  Grid,
  TextField,
  TextareaAutosize,
  Typography,
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
import useStaffDetail from './hooks/useStaffDetail';
import { useSelector } from 'react-redux';
import { position } from 'stylis';

const staffSchema = Yup.object().shape({
  name: Yup.string()
    .matches(REG_EXP.staffName, 'Staff Name is not valid')
    .required('Required'),
  staffId: Yup.string().required("Required"),
  email: Yup.string().required("Required"),
  address: Yup.string().required("Required"),
  phoneNumber: Yup.string().required("Required"),
  position: Yup.string().required("Required"),
  nationalId: Yup.string().required("Required"),
  departmentName: Yup.string().required("Required"),

});


function StaffDetail() {
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;
  const { t } = useTranslation();
  const params = useParams();
  const {
    staff, handleCancel, handleSubmitForm, openBackdrop,
  } = useStaffDetail();

  const departments = useSelector((state) => state.staff.departmentSelections) || [];

  return (
    <BaseLayout>
      <Formik
        enableReinitialize
        initialValues={{
          name: staff?.name,
          staffId: staff?.staffId,
          position: staff?.position,
          address: staff?.address,
          phoneNumber: staff?.phoneNumber,
          email: staff?.email,
          nationalId: staff?.nationalId,
          departmentId: staff?.deaprtmentId,
          departmentName: staff?.departmentName,

        }}
        validationSchema={staffSchema}
        onSubmit={(values) => {
          const {
            name, staffId, position, address, phoneNumber, email, nationalId, departmentId, departmentName
          } = values;
          const data =
          {
            ...values,
          };

          const res = {
            ...data,
            departmentId: departments.find((item) => item.name === data.departmentName)?.id,
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
                    {params?.id ? 'EditStaff' : 'CreateStaff'}
                  </MDTypography>
                </MDBox>
                <MDBox component="form" pb={3} px={3}>
                  <Grid container spacing={1}>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.name}
                        name="name"
                        label="Staff Name"
                        placeholder="Staff Name"
                        onChange={handleChange}
                        error={errors.name}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.staffId}
                        name="staffId"
                        label="staffId"
                        placeholder="staffId "
                        onChange={handleChange}
                        error={errors.staffId}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.position}
                        name="position"
                        label="position"
                        placeholder="position"
                        onChange={handleChange}
                        error={errors.position}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.address}
                        name="address"
                        label="address"
                        placeholder="address"
                        onChange={handleChange}
                        error={errors.address}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.phoneNumber}
                        name="phoneNumber"
                        label="phoneNumber"
                        placeholder="phoneNumber"
                        onChange={handleChange}
                        error={errors.phoneNumber}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.email}
                        name="email"
                        label="email"
                        placeholder="email"
                        onChange={handleChange}
                        error={errors.email}
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
                      <Selector
                        disableClearable
                        key={values?.departmentName}
                        defaultValue={values?.departmentName}
                        label="Department"
                        onChange={(value) => setFieldValue(
                          'departmentName',
                          departments.find((item) => item.name === value).name,
                        )}
                        options={departments.map((item) => item.name)}
                        value={values?.name}
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

export default StaffDetail;
