/* eslint-disable no-unused-vars */
import {
  Backdrop, Card, CircularProgress, Grid,
} from '@mui/material';
import BaseLayout from 'components/Customized/BaseLayout';
import FormField from 'components/Customized/FormFiled';
import MDBox from 'components/MDBox';
import MDButton from 'components/MDButton';
import MDTypography from 'components/MDTypography';
import { useMaterialUIController } from 'context';
import { Formik } from 'formik';
import { useTranslation } from 'react-i18next';
import { useSelector } from 'react-redux';
import { useParams } from 'react-router-dom';
import * as Yup from 'yup';
import useManufacturerDicomDetail from './hooks/useManufacturerDicomDetail';
import { manufacturerData } from './mockData';

const manufacturerDicomSchema = Yup.object().shape({
  providerId: Yup.string().required('Required'),
  providerParameterId: Yup.string().required('Required'),
  providerParameterShortName: Yup.string().required('Required'),
  measurementCSD: Yup.string().required('Required'),
  measurementCV: Yup.string().required('Required'),
  measurementCM: Yup.string().required('Required'),
});

export default function ManufacturerDicomDetail() {
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;
  const { t } = useTranslation();
  const params = useParams();
  const departments = useSelector((state) => state.department.departments);

  const { handleCancel, handleSubmitForm, openBackdrop } = useManufacturerDicomDetail();
  // Mock data
  const manufacturerDicom = manufacturerData;

  return (
    <BaseLayout>
      <Formik
        enableReinitialize
        initialValues={{
          providerId: manufacturerDicom?.providerId,
          providerParameterId: manufacturerDicom?.providerParameterId,
          providerParameterShortName: manufacturerDicom?.providerParameterShortName,
          measurementCSD: manufacturerDicom?.measurementCSD,
          measurementCV: manufacturerDicom?.measurementCV,
          measurementCM: manufacturerDicom?.measurementCM,
        }}
        validationSchema={manufacturerDicomSchema}
        onSubmit={(values) => {
          handleSubmitForm(values);
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
                    {params?.id ? t('EditManufacturerDicom') : t('CreateManufacturerDicom')}
                  </MDTypography>
                </MDBox>
                <MDBox component="form" pb={3} px={3}>
                  <Grid container spacing={1}>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.providerId}
                name="providerId"
                label="Provider Id"
                placeholder="Provider Id"
                onChange={handleChange}
                error={errors.providerId}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.providerParameterId}
                name="providerParameterId"
                label="Provider Parameter Id"
                placeholder="Provider Parameter Id"
                onChange={handleChange}
                error={errors.providerParameterId}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.providerParameterShortName}
                name="providerParameterShortName"
                label="Provider Parameter Short Name"
                placeholder="Provider Parameter Short Name"
                onChange={handleChange}
                error={errors.providerParameterShortName}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.measurementCSD}
                name="measurementCSD"
                label="Measurement CSD"
                placeholder="Measurement CSD"
                onChange={handleChange}
                error={errors.measurementCSD}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.measurementCV}
                name="measurementCV"
                label="Measurement CV"
                placeholder="Measurement CV"
                onChange={handleChange}
                error={errors.measurementCV}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.measurementCM}
                name="measurementCM"
                label="Measurement CM"
                placeholder="Measurement CM"
                onChange={handleChange}
                error={errors.measurementCM}
              />
                    </Grid>
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
