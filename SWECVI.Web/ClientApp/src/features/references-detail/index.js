/* eslint-disable no-unused-vars */
import {
  Backdrop,
  Card,
  CircularProgress,
  Grid,
  FormControlLabel,
  FormGroup,
  Switch,
} from '@mui/material';
import BaseLayout from 'components/Customized/BaseLayout';
import MDBox from 'components/MDBox';
import MDButton from 'components/MDButton';
import { useMaterialUIController } from 'context';
import { Formik } from 'formik';
import React from 'react';
import { useTranslation } from 'react-i18next';
import { useParams } from 'react-router-dom';
import MDTypography from 'components/MDTypography';
import FormField from 'components/Customized/FormFiled';
import * as Yup from 'yup';
import Selector from 'components/Customized/Selector';
import { useSelector } from 'react-redux';
import useReferencesDetail from './hooks/useReferencesDetail';

// const referencesSchema = Yup.object().shape({
//   parameterNameLogic: Yup.string().required("Required"),
//   displayUnit: Yup.string(),
//   departmentName: Yup.string(),
//   ageFrom: Yup.number(),
//   ageTo: Yup.number(),
//   referenceLow: Yup.number(),
//   referenceMin: Yup.number(),
//   referenceMax: Yup.number(),
//   normalRangeLower: Yup.number(),
//   normalRangeUpper: Yup.number(),
//   mildlyAbnormalRangeLower: Yup.number(),
//   mildlyAbnormalRangeUpper: Yup.number(),
//   moderatelyAbnormalRangeLower: Yup.number(),
//   moderatelyAbnormalRangeUpper: Yup.number(),
//   severelyAbnormalRangeMoreThan: Yup.number(),
//   severelyAbnormalRangeLessThan: Yup.number(),
//   gender: Yup.number(),
// });

const genders = [
  { name: 'Male', value: 1 },
  { name: 'Female', value: 2 },
  { name: 'Unknown', value: 3 },
];

export default function ReferencesDetail() {
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;
  const { t } = useTranslation();
  const params = useParams();
  const departments = useSelector((state) => state.department.departments);

  const {
    references, handleCancel, handleSubmitForm, openBackdrop,
  } = useReferencesDetail();
  return (
    <BaseLayout>
      <Formik
        enableReinitialize
        initialValues={{
          parameterId: references?.parameterId,
          parameterNameLogic: references?.parameterNameLogic,
          displayUnit: references?.displayUnit,
          departmentName: references?.departmentName,
          normalRangeLower: references?.normalRangeLower,
          normalRangeUpper: references?.normalRangeUpper,
          mildlyAbnormalRangeLower: references?.mildlyAbnormalRangeLower,
          mildlyAbnormalRangeUpper: references?.mildlyAbnormalRangeUpper,
          moderatelyAbnormalRangeLower: references?.moderatelyAbnormalRangeLower,
          moderatelyAbnormalRangeUpper: references?.moderatelyAbnormalRangeUpper,
          severelyAbnormalRangeMoreThan: references?.severelyAbnormalRangeMoreThan,
          severelyAbnormalRangeLessThan: references?.severelyAbnormalRangeLessThan,
          genderName: references?.genderName,
          isIndex: references?.isIndex,
          primaryReference: references?.primaryReference,
          fistAuthor: references?.fistAuthor,
          comment: references?.comment,
        }}
        // validationSchema={referencesSchema}
        onSubmit={(values) => {
          handleSubmitForm({
            ...values,
            depaermentId: departments.items.find((item) => item.name === values.departmentName)?.id,
            gender: genders.find((item) => item.name === values.genderName)?.value,
          });
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
                    {params?.id ? t('EditReferences') : t('CreateReferences')}
                  </MDTypography>
                </MDBox>
                <MDBox component="form" pb={3} px={3}>
                  <Grid container spacing={1}>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.parameterId}
                name="parameterId"
                label="Parameter Id"
                placeholder="Parameter Id"
                onChange={handleChange}
                error={errors.parameterId}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.parameterNameLogic}
                name="parameterNameLogic"
                label="Parameter Name Logic"
                placeholder="Parameter Name Logic"
                onChange={handleChange}
                error={errors.parameterNameLogic}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.displayUnit}
                name="displayUnit"
                label="Display Unit"
                placeholder="Display Unit"
                onChange={handleChange}
                error={errors.displayUnit}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.normalRangeLower}
                type="number"
                name="normalRangeLower"
                label="Normal Range Lower"
                placeholder="Normal Range Lower"
                onChange={handleChange}
                error={errors.normalRangeLower}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.normalRangeUpper}
                type="number"
                name="normalRangeUpper"
                label="Normal Range Upper"
                placeholder="Normal Range Upper"
                onChange={handleChange}
                error={errors.normalRangeUpper}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.mildlyAbnormalRangeLower}
                type="number"
                name="mildlyAbnormalRangeLower"
                label="Mildly Abnormal Range Lower"
                placeholder="Mildly Abnormal Range Lower"
                onChange={handleChange}
                error={errors.mildlyAbnormalRangeLower}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.mildlyAbnormalRangeUpper}
                type="number"
                name="mildlyAbnormalRangeUpper"
                label="Mildly Abnormal Range Upper"
                placeholder="Mildly Abnormal Range Upper"
                onChange={handleChange}
                error={errors.mildlyAbnormalRangeUpper}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.moderatelyAbnormalRangeLower}
                type="number"
                name="moderatelyAbnormalRangeLower"
                label="Moderately Abnormal Range Lower"
                placeholder="Moderately Abnormal Range Lower"
                onChange={handleChange}
                error={errors.moderatelyAbnormalRangeLower}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.moderatelyAbnormalRangeUpper}
                type="number"
                name="moderatelyAbnormalRangeUpper"
                label="Moderately Abnormal Range Upper"
                placeholder="Moderately Abnormal Range Upper"
                onChange={handleChange}
                error={errors.moderatelyAbnormalRangeUpper}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.severelyAbnormalRangeMoreThan}
                type="number"
                name="severelyAbnormalRangeMoreThan"
                label="Severely Abnormal Range More Than"
                placeholder="Severely Abnormal Range More Than"
                onChange={handleChange}
                error={errors.severelyAbnormalRangeMoreThan}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.severelyAbnormalRangeLessThan}
                type="number"
                name="severelyAbnormalRangeLessThan"
                label="Severely Abnormal Range Less Than"
                placeholder="Severely Abnormal Range Less Than"
                onChange={handleChange}
                error={errors.severelyAbnormalRangeLessThan}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.primaryReference}
                name="primaryReference"
                label="Primary Reference"
                placeholder="Primary Reference"
                onChange={handleChange}
                error={errors.primaryReference}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.fistAuthor}
                name="fistAuthor"
                label="Fist Author"
                placeholder="Fist Author"
                onChange={handleChange}
                error={errors.fistAuthor}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormField
                value={values.comment}
                name="comment"
                label="Comment"
                placeholder="Comment"
                onChange={handleChange}
                error={errors.comment}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <Selector
                disableClearable
                key={values?.departmentName}
                defaultValue={values?.departmentName}
                value={values?.departmentName}
                label="Department Name"
                options={departments.items.map((item) => item.name)}
                onChange={(value) => setFieldValue(
                  'departmentName',
                  departments.items.find((item) => item.name === value).name,
                )}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <Selector
                disableClearable
                key={values?.genderName}
                defaultValue={values?.genderName}
                label="Gender"
                onChange={(value) => setFieldValue(
                  'genderName',
                  genders.find((item) => item.name === value).name,
                )}
                options={genders.map((item) => item.name)}
                value={values?.genderName}
              />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                      <FormControlLabel
                label="Is Index"
                control={(
                  <Switch
                            checked={values.isIndex}
                            onChange={(e) => setFieldValue('isIndex', e.target.checked)}
                            color="primary"
                            name="isIndex"
                          />
                        )}
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
