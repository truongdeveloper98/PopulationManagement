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
import useUltityDetail from './hooks/useUltityDetail';
import { useSelector } from 'react-redux';
import { position } from 'stylis';

const ultitySchema = Yup.object().shape({
  name: Yup.string()
    .matches(REG_EXP.UltityName, 'Ultity Name is not valid')
    .required('Required'),
  ultityId: Yup.string().required("Required"),
  price: Yup.string().required("Required"),
  startTime: Yup.string().required("Required"),
  endTime: Yup.string().required("Required"),
  useTime: Yup.string().required("Required"),
  openDate: Yup.string().required("Required"),
  note: Yup.string().required("Required"),
  commitment: Yup.string().required("Required"),
  isStatus: Yup.string().required("Required"),
});


function UltityDetail() {
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;
  const { t } = useTranslation();
  const params = useParams();
  const {
    ultity, handleCancel, handleSubmitForm, openBackdrop
  } = useUltityDetail();

  return (
    <BaseLayout>
      <Formik
        enableReinitialize
        initialValues={{
          name: ultity?.name,
          ultityId: ultity?.ultity,
          price: ultity?.price,
          startTime: ultity?.startTime,
          endTime: ultity?.endTime,
          useTime: ultity?.useTime,
          openDate: ultity?.openDate,
          note: ultity?.note,
          commitment: ultity?.commitment,
          isStatus: ultity?.isStatus,

        }}
        validationSchema={ultitySchema}
        onSubmit={(values) => {
          const {
            name, ultityId, price, address, startTime, endTime, useTime, openDate, note, commitment, isStatus
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
                    {params?.id ? 'EditUltity' : 'CreateUltity'}
                  </MDTypography>
                </MDBox>
                <MDBox component="form" pb={3} px={3}>
                  <Grid container spacing={1}>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.name}
                        name="name"
                        label="Ultity Name"
                        placeholder="Ultity Name"
                        onChange={handleChange}
                        error={errors.name}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.ultityId}
                        name="ultityId"
                        label="ultityId"
                        placeholder="ultityId "
                        onChange={handleChange}
                        error={errors.ultityId}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.price}
                        name="price"
                        label="price"
                        placeholder="price"
                        onChange={handleChange}
                        error={errors.price}
                      />
                    </Grid>
                    {/* <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.startTime}
                        name="startTime"
                        label="startTime"
                        placeholder="startTime"
                        onChange={handleChange}
                        error={errors.startTime}
                      />
                    </Grid> */}
                    <Grid item xs={3}>
                      <div>
                        <TextField
                          type="time"
                          fullWidth
                          name='startTime'
                          label="Start Time"
                          value={values.startTime}
                          InputLabelProps={{ shrink: true }}
                          onChange={handleChange}
                        />
                      </div>
                    </Grid>
                    {/* <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.endTime}
                        name="endTime"
                        label="endTime"
                        placeholder="endTime"
                        onChange={handleChange}
                        error={errors.endTime}
                      />
                    </Grid> */}
                    <Grid item xs={3}>
                      <div>
                        <TextField
                          type="time"
                          name='endTime'
                          fullWidth
                          label="End Time"
                          value={values.endTime}
                          InputLabelProps={{ shrink: true }}
                          onChange={handleChange}
                        />
                      </div>
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.useTime}
                        name="useTime"
                        label="useTime"
                        placeholder="useTime"
                        onChange={handleChange}
                        error={errors.useTime}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.openDate}
                        name="openDate"
                        label="openDate"
                        placeholder="openDate"
                        onChange={handleChange}
                        error={errors.openDate}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.note}
                        name="note"
                        label="note"
                        placeholder="note"
                        onChange={handleChange}
                        error={errors.note}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.commitment}
                        name="commitment"
                        label="commitment"
                        placeholder="commitment"
                        onChange={handleChange}
                        error={errors.commitment}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormControlLabel
                        label="Is Status"
                        control={(
                          <Switch
                            checked={values.isStatus}
                            onChange={(e) => setFieldValue('isStatus', e.target.checked)}
                            color="primary"
                            name="isStatus"
                          />
                        )}
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

export default UltityDetail;
