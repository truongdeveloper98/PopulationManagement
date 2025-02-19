 
import { store } from 'stores';
import { failed, succeed } from 'stores/reducers/patient.reducer';
import API from './api';

export const exportPatientRequest = async (data) => {
  const { dispatch } = store;
  try {
    await API.exportPatient(data)
      .then((res) => {
        const url = window.URL.createObjectURL(
          new Blob([res.data], {
            type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;',
          }),
        );
        const link = document.createElement('a');
        link.href = url;
        link.setAttribute('download', 'ParameterResult.xlsx');
        document.body.appendChild(link);
        link.click();
      })
      .catch((err) => dispatch(failed(err?.response?.data)));
    dispatch(succeed('Export patient data successfully'));
  } catch (error) {
    dispatch(failed(error?.response?.data));
  }
};
