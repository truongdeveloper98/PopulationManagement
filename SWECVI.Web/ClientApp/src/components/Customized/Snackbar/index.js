import { useSelector, useDispatch } from 'react-redux';
import MDSnackbar from 'components/MDSnackbar';
import { reinitialize as userReinitialize } from 'stores/reducers/user.reducer';
import { reinitialize as hospitalReinitialize } from 'stores/reducers/hospital.reducer';
import { reinitialize as departmentReinitialize } from 'stores/reducers/department.reducer';
import { reinitialize as assessmentReinitialize } from 'stores/reducers/assessment.reducer';
import { reinitialize as referencesReinitialize } from 'stores/reducers/references.reducer';
import { reinitialize as manufacturerDicomReinitialize } from 'stores/reducers/manufacturerDicom.reducer';
import { reinitialize as exportDataReinitialize } from 'stores/reducers/exportData.reducer';
import { reinitialize as settingsReinitialize } from 'stores/reducers/settings.reducer';
import { reinitialize as patientReinitialize } from 'stores/reducers/patient.reducer';
import { reinitialize as sessionReinitialize } from 'stores/reducers/session.reducer';
import { reinitialize as authReinitialize } from 'stores/reducers/auth.reducer';
import { reinitialize as findingReinitialize } from 'stores/reducers/finding.reducer';
import { reinitialize as pythonReinitialize } from 'stores/reducers/python.reducer';
import { reinitialize as examReinitialize } from 'stores/reducers/exam.reducer';

export default function Snackbar() {
  const dispatch = useDispatch();

  const error = useSelector(
    (state) => state.user.error
      || state.hospital.error
      || state.department.error
      || state.assessment.error
      || state.references.error
      || state.manufacturerDicom.error
      || state.exportData.error
      || state.settings.error
      || state.auth.error
      || state.patient.error
      || state.session.error
      || state.python.error
      || state.findings.error
      || state.exam.error,
  );
  const success = useSelector(
    (state) => state.user.success
      || state.hospital.success
      || state.department.success
      || state.assessment.success
      || state.references.success
      || state.manufacturerDicom.success
      || state.exportData.success
      || state.settings.success
      || state.auth.success
      || state.patient.success
      || state.session.success
      || state.python.success
      || state.findings.success
      || state.exam.success,
  );

  const errorSnackbar = () => (
    <MDSnackbar
      color="error"
      icon="error"
      title="Error"
      content={error?.toString()}
      open={!!error}
      onClose={() => {
        dispatch(userReinitialize());
        dispatch(hospitalReinitialize());
        dispatch(departmentReinitialize());
        dispatch(assessmentReinitialize());
        dispatch(referencesReinitialize());
        dispatch(manufacturerDicomReinitialize());
        dispatch(exportDataReinitialize());
        dispatch(settingsReinitialize());
        dispatch(patientReinitialize());
        dispatch(sessionReinitialize());
        dispatch(authReinitialize());
        dispatch(findingReinitialize());
        dispatch(pythonReinitialize());
        dispatch(examReinitialize());
      }}
    />
  );

  const successSnackbar = () => (
    <MDSnackbar
      color="success"
      icon="done"
      title="Success"
      open={!!success}
      content={success}
      onClose={() => {
        dispatch(userReinitialize());
        dispatch(hospitalReinitialize());
        dispatch(departmentReinitialize());
        dispatch(assessmentReinitialize());
        dispatch(referencesReinitialize());
        dispatch(manufacturerDicomReinitialize());
        dispatch(exportDataReinitialize());
        dispatch(settingsReinitialize());
        dispatch(patientReinitialize());
        dispatch(sessionReinitialize());
        dispatch(authReinitialize());
        dispatch(findingReinitialize());
        dispatch(pythonReinitialize());
        dispatch(examReinitialize());
      }}
    />
  );

  return (
    <>
      {errorSnackbar()}
      {successSnackbar()}
    </>
  );
}
