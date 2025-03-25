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
import useProjectDetail from './hooks/useProjectDetail';
import { useSelector } from 'react-redux';

const projectSchema = Yup.object().shape({
  name: Yup.string()
    .matches(REG_EXP.projectName, 'project Name is not valid')
    .required('Required'),
  projectId: Yup.string().required("Required"),
  operationId: Yup.string().required("Required"),
  address: Yup.string().required("Required"),
  phoneNumber: Yup.string().required("Required"),
  email: Yup.string().required("Required"),
  townshipName: Yup.string().required("Required"),
  managerName: Yup.string().required("Required"),

});


function ProjectDetail() {
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;
  const { t } = useTranslation();
  const params = useParams();
  const {
    project, handleCancel, handleSubmitForm, openBackdrop,
  } = useProjectDetail();

  const projects = useSelector((state) => state.project.projectSelections) || [];
  const managers = useSelector((state) => state.project.managerSelections) || [];

  return (
    <BaseLayout>
      <Formik
        enableReinitialize
        initialValues={{
          name: project?.name,
          projectId: project?.projectId,
          operationId: project?.operationId,
          address: project?.address,
          phoneNumber: project?.phoneNumber,
          email: project?.email,
          townshipId: project?.townShipId,
          townshipName: project?.townShipName,
          managerId: project?.managerId,
          managerName: project?.managerName,

        }}
        validationSchema={projectSchema}
        onSubmit={(values) => {
          const {
            name, projectId, operationId, description, address, phoneNumber, email, townshipId, managerId, managerName, townshipName
          } = values;
          const data =
          {
            ...values,
          };

          const res = {
            ...data,
            townshipId: projects.find((item) => item.name === data.townshipName)?.id,
            managerId: managers.find((item) => item.fullName === data.managerName)?.id,
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
                    {params?.id ? 'EditProject' : 'CreateProject'}
                  </MDTypography>
                </MDBox>
                <MDBox component="form" pb={3} px={3}>
                  <Grid container spacing={1}>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.name}
                        name="name"
                        label="Project Name"
                        placeholder="Project Name"
                        onChange={handleChange}
                        error={errors.name}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.projectId}
                        name="projectId"
                        label="Project Id"
                        placeholder="Project ID"
                        onChange={handleChange}
                        error={errors.projectId}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.operationId}
                        name="operationId"
                        label="Operation Id"
                        placeholder="Operation ID"
                        onChange={handleChange}
                        error={errors.operationId}
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
                      <Selector
                        disableClearable
                        key={values?.managerName}
                        defaultValue={values?.managerName}
                        label="Manager"
                        onChange={(value) => setFieldValue(
                          'managerName',
                          managers.find((item) => item.fullName === value).fullName,
                        )}
                        options={managers.map((item) => item.fullName)}
                        value={values?.managerName}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <Selector
                        disableClearable
                        key={values?.townshipName}
                        defaultValue={values?.townshipName}
                        label="Township"
                        onChange={(value) => setFieldValue(
                          'townshipName',
                          projects.find((item) => item.name === value).name,
                        )}
                        options={projects.map((item) => item.name)}
                        value={values?.townshipName}
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

export default ProjectDetail;
