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
import useJobDetail from './hooks/useJobDetail';
import { namespace } from 'stylis';

const jobSchema = Yup.object().shape({
  name: Yup.string()
    .matches(REG_EXP.jobName, 'Job Name is not valid')
    .required('Required'),
  description: Yup.string().required("Required"),

});


function JobDetail() {
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;
  const { t } = useTranslation();
  const params = useParams();
  const {
    job, handleCancel, handleSubmitForm, openBackdrop, 
  } = useJobDetail();

  return (
    <BaseLayout>
      <Formik
        enableReinitialize
        initialValues={{
          name: job?.name,
          description: job?.description,
        }}
        validationSchema={jobSchema}
        onSubmit={(values) => {
          const {
            name, description,
          } = values;

          const data = 
            {
              ...values,
            };
          handleSubmitForm(data);
          //console.log(data);
        }}
        // validateOnChange={false}
      >
        {({
          values, errors, handleChange, handleSubmit, setFieldValue,
        }) => (
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
                    {params?.id ? t('EditJob') : t('CreateJob')}
                  </MDTypography>
                </MDBox>
                <MDBox component="form" pb={3} px={3}>
                  <Grid container spacing={1}>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.name}
                name="name"
                label="Job Name"
                placeholder="Job Name"
                onChange={handleChange}
                error={errors.name}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                    <FormField
                value={values.description}
                name="description"
                label="Job Description"
                placeholder="Job Description"
                onChange={handleChange}
                error={errors.description}
              />
                      {/* {errors?.region && <FormHelperText error>{errors?.region}</FormHelperText>} */}
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

export default JobDetail;
