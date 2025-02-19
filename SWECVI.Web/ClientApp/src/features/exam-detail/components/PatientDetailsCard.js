/* eslint-disable no-console */
import {
  Card, FormControlLabel, Switch, Tab, Tabs, styled,
} from '@mui/material';
import MDBox from 'components/MDBox';
import MDTypography from 'components/MDTypography';
import { useEffect, useState } from 'react';
import Selector from 'components/Customized/Selector';
import { CheckCircle } from '@mui/icons-material';
import Grid from '@mui/material/Grid';
import Edittor from 'components/Edittor/Edittor';
import MDButton from 'components/MDButton';
import './styles.css';
import { getExamReportByExamIdRequest, updatePatientDetailsRequest } from '../services';
import useExam from '../hooks/useExam';

const AntTabs = styled(Tabs)(() => ({
  '& .MuiTabs-indicator': {
    borderBottom: '2px solid #3498db',
    boxShadow: 'none',
    borderRadius: 0,
  },
  borderRadius: 0,
  height: 60,
  padding: 0,
}));

function PatientDetails({ patientDetails }) {
  const [editorValue, setEditorValue] = useState('');
  const [statusValue, setStatusValue] = useState('');
  const [statusEnd, setStatusEnd] = useState('');
  const [isViewSupress, setViewSupressValue] = useState(false);
  const [version, setVersion] = useState(-1);
  const { params } = useExam();

  const status = [
    { value: 0, Status: 'Report started' },
    { value: 1, Status: 'Report preliminary' },
    { value: 2, Status: 'Report finalized' },
  ];

  useEffect(() => {
    if (patientDetails) {
      for (let i = 0; i < patientDetails.length; i++) {
        if (patientDetails[i].isCurrent) {
          setVersion(i);
          setEditorValue(
            isViewSupress
              ? patientDetails[i]?.contentReport
              : patientDetails[i]?.contentWithoutSupress,
          );
          setStatusValue(patientDetails[i]?.status);
          break;
        }
      }

      for (let i = 0; i < patientDetails.length; i++) {
        if (patientDetails[i]?.status === 'Report finalized') {
          setStatusEnd('Report finalized');
          break;
        } else {
          setStatusEnd('');
        }
      }
    }
  }, [patientDetails]);

  useEffect(() => {
    const patientDetail = patientDetails?.find((item, index) => index === version);
    setEditorValue(
      isViewSupress ? patientDetail?.contentReport : patientDetail?.contentWithoutSupress,
    );
    setStatusValue(patientDetail?.status);
  }, [version]);

  const handleSubmit = async () => {
    if (!patientDetails) {
      return;
    }
    const studyId = params?.id;
    const value = editorValue?.replace(/\t/g, '&nbsp;&nbsp;&nbsp;&nbsp;');

    let statusRequest = 0;
    if (statusValue === 'Report preliminary') {
      statusRequest = 1;
    } else if (statusValue === 'Report finalized') {
      statusRequest = 2;
    }

    updatePatientDetailsRequest(
      studyId,
      { contentReport: value, status: statusRequest },
      getExamReportByExamIdRequest(params?.hospitalId, params?.id),
    );
  };

  const handleChange = (e) => {
    if (e.target !== undefined) {
      const { value } = e.target;
      setEditorValue(value);
    } else {
      setEditorValue(e);
    }
  };

  const handleCopy = async () => {
    let contentCopy = '';
    for (let i = 0; i < patientDetails.length; i++) {
      if (patientDetails[i]?.status === 'Report finalized') {
        contentCopy = patientDetails[i]?.contentReport;
        break;
      }
    }
    await navigator.clipboard.writeText(contentCopy);
  };

  const checkViewSupress = (e) => {
    setViewSupressValue(e);
    if (!patientDetails) {
      return;
    }
    if (e) {
      handleChange(patientDetails[version].contentReport);
    } else {
      handleChange(patientDetails[version].contentWithoutSupress);
    }
  };

  return (
    <>
      <Card>
        <MDBox p={2} display="flex" justifyContent="space-between">
          <MDTypography xs={6} variant="h6" fontWeight="medium">
            Patient Details
          </MDTypography>
          <Grid item textAlign="right">
            <Grid container spacing={1}>
              <Grid item>
                <MDButton onClick={handleSubmit} variant="gradient" color="info" spacing={1}>
                  Save
                </MDButton>
              </Grid>
              <Grid item>
                <MDButton
                  onClick={handleCopy}
                  variant="gradient"
                  color="info"
                  disabled={statusEnd !== 'Report finalized'}
                >
                  Copy
                </MDButton>
              </Grid>
            </Grid>
          </Grid>
        </MDBox>
        <MDBox p={1} display="flex" justifyContent="flex-start">
          <Grid item xs={6} textAlign="left">
            <FormControlLabel
              label="To toggle this information"
              control={(
                <Switch
                  checked={isViewSupress}
                  onChange={(e) => checkViewSupress(e.target.checked)}
                  color="primary"
                  name="viewToSupress"
                />
              )}
              // labelPlacement="start"
            />
          </Grid>
        </MDBox>
        <MDBox p={2} pt={0} height="100%" overflow="auto">
          <AntTabs
            value={version}
            onChange={(e, i) => setVersion(i)}
            variant="scrollable"
            scrollButtons={false}
            aria-label="scrollable auto tabs example"
          >
            {patientDetails?.map((item) => (item.status === 'Report finalized' ? (
              <Tab
                key={item.id}
                label={`${item.status} (${item.date})`}
                icon={item.isCurrent && <CheckCircle />}
                className="tab-active"
                iconPosition="end"
              />
            ) : (
              <Tab
                key={item.id}
                icon={item.isCurrent && <CheckCircle />}
                label={`${item.status} (${item.date})`}
              />
            )))}
          </AntTabs>
          <Grid item xs={4} sm={4} spacing={1}>
            <Selector
              disableClearable
              label="Select Status"
              options={status?.map((item) => item.Status)}
              key={statusValue}
              defaultValue={statusValue}
              value={statusValue}
              disabled={statusEnd === 'Report finalized'}
              onChange={(value) => setStatusValue(value)}
            />
          </Grid>
          <Edittor
            onChange={handleChange}
            value={editorValue}
            readOnly={statusEnd === 'Report finalized'}
          />
        </MDBox>
      </Card>
      {/* {patientDetails && !patientDetails[version]?.contentReport && (
        <Backdrop sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }} open>
          <CircularProgress color="inherit" />
        </Backdrop>
      )} */}
    </>
  );
}

export default PatientDetails;
