/* eslint-disable no-unused-vars */
import BaseLayout from 'components/Customized/BaseLayout';
import { useMaterialUIController } from 'context';
import { Formik } from 'formik';
import React from 'react';
import { useTranslation } from 'react-i18next';
import * as Yup from 'yup';
import {
  Backdrop, Card, CircularProgress, Grid, FormControlLabel, Switch
} from '@mui/material';
import MDButton from 'components/MDButton';
import MDBox from 'components/MDBox';
import MDTypography from 'components/MDTypography';
import { useParams } from 'react-router-dom';
import FormField from 'components/Customized/FormFiled';
import Selector from 'components/Customized/Selector';
import useDepartmentDetail from './hooks/useDepartmentDetail';
import { useSelector } from 'react-redux';

const departmentSchema = Yup.object().shape({
  name: Yup.string().required('Required'),
  // description: Yup.string().required("Required"),
  departmentId: Yup.string().required('Required'),
  phoneNumber: Yup.string().required('Required'),
  email: Yup.string().required('Required'),
  managerName: Yup.string().required('Required'),
  isStatus: Yup.string().required('Required'),
  isCommentStatus: Yup.string().required('Required'),
  isNotifyStatus: Yup.string().required('Required'),
  isReceiveJobStatus: Yup.string().required('Required'),
});

export default function DepartmentDetail() {
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;
  const { t } = useTranslation();
  const params = useParams();
  const {
    department, handleCancel, handleSubmitForm, openBackdrop,
  } = useDepartmentDetail();

  const managers = useSelector((state) => state.department.managerSelections) || [];
  return (
    <BaseLayout>
      <Formik
        enableReinitialize
        initialValues={{
          name: department?.name,
          departmentId: department?.departmentId,
          phoneNumber: department?.phoneNumber,
          email: department?.email,
          managerId: department?.managerId,
          managerName: department?.managerName,
          isStatus: department?.isStatus,
          isCommentStatus: department?.isCommentStatus,
          isNotifyStatus: department?.isNotifyStatus,
          isReceiveJobStatus: department?.isReceiveJobStatus
        }}
        // validationSchema={departmentSchema}
        onSubmit={(values) => {
          const {
            name, departmentId, phoneNumber, email, address, managerId, managerName, isStatus, isCommentStatus, isNotifyStatus, isReceiveJobStatus
          } = values;
          const data =
          {
            ...values,
          };
          const res = {
            ...data,
            managerId: managers.find((item) => item.fullName === data.managerName)?.id,
          }
          handleSubmitForm(res);
        }}
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
                    {params?.id ? t('EditDepartment') : t('CreateDepartment')}
                  </MDTypography>
                </MDBox>
                <MDBox component="form" pb={3} px={3}>
                  <Grid container spacing={1}>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.name}
                        name="name"
                        label="Department Name"
                        placeholder="Department Name"
                        onChange={handleChange}
                        error={errors.name}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                        value={values.departmentId}
                        name="departmentId"
                        label="DepartmentId"
                        placeholder="DepartmentId"
                        onChange={handleChange}
                        error={errors.departmentId}
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
                    <Grid item xs={12} sm={6}>
                      <FormControlLabel
                        label="Is CommentStatus"
                        control={(
                          <Switch
                            checked={values.isCommentStatus}
                            onChange={(e) => setFieldValue('isCommentStatus', e.target.checked)}
                            color="primary"
                            name="isCommentStatus"
                          />
                        )}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormControlLabel
                        label="Is NotifyStatus"
                        control={(
                          <Switch
                            checked={values.isNotifyStatus}
                            onChange={(e) => setFieldValue('isNotifyStatus', e.target.checked)}
                            color="primary"
                            name="isNotifyStatus"
                          />
                        )}
                      />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormControlLabel
                        label="Is ReceiveJobStatus"
                        control={(
                          <Switch
                            checked={values.isReceiveJobStatus}
                            onChange={(e) => setFieldValue('isReceiveJobStatus', e.target.checked)}
                            color="primary"
                            name="isReceiveJobStatus"
                          />
                        )}
                      />
                    </Grid>
                    {/* <Grid item xs={12} sm={6}>
                      <Selector
                        label="Hospital"
                        options={hospitalSuperAdmin.map((item) => item.name)}
                        value={values.hospital}
                        onChange={(value) => setFieldValue("hospital", value)}
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
