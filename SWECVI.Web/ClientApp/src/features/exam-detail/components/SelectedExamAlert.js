import React from 'react';
import MDBox from 'components/MDBox';
import { Box } from '@mui/material';

import MDAlert from 'components/MDAlert';
// import moment from "moment";
import MDTypography from 'components/MDTypography';

function SelectedExamAlert({ data }) {
  return data ? (
    <MDBox display="flex">
      <MDAlert>
        <MDTypography variant="body2" color="white" fontWeight="regular">
          SELECTED PATIENT:
          {' '}
          {data?.patientName}
          ,
          {data.ssn === undefined || data.ssn === '' ? 'No data' : data.ssn}
        </MDTypography>
      </MDAlert>
      <Box sx={{ m: 1 }} />
      <MDAlert>
        <MDTypography variant="body2" color="white" fontWeight="regular">
          SELECTED EXAM:
          {' '}
          {data.examDate === undefined || data.examDate === '' ? 'No data' : data.examDate}
        </MDTypography>
      </MDAlert>
    </MDBox>
  ) : null;
}
export default SelectedExamAlert;
