import {
  Box, Card, Grid, TextField,
} from '@mui/material';
import { useSelector } from 'react-redux';
import BaseLayout from 'components/Customized/BaseLayout';
import EditButton from 'components/Customized/EditButton';
import EditIcon from '@mui/icons-material/Edit';
import PeriodFiltersCard from 'components/Customized/PeriodFilter';
import SyncIcon from '@mui/icons-material/Sync';
import MDButton from 'components/MDButton';
import TsGridTable from 'components/Customized/TsGridTable';
import { createColumnHelper } from '@tanstack/react-table';
import { useTranslation } from 'react-i18next';
import Selector from 'components/Customized/Selector';
import usePatients from './hooks/usePatients';
import { getPatientsRequest } from './services';
import 'custom-styles.css';

const columnHelper = createColumnHelper();

// const columnDefs = [
//   {
//     field: "patientId",
//     headerName: "Patient ID",
//     cellRenderer: "agGroupCellRenderer",
//   },
//   {
//     field: "patientName",
//     headerName: "Patient's Name",
//   },
//   { field: "noOfExam", headerName: "No of exam", sortable: false },
// ];

function Patients() {
  const patients = useSelector((state) => state.patient.patients);
  const isLoading = useSelector((state) => state.common.isLoading);

  const {
    agRef,

    // funcs
    // handleSelectPatient,
    valueExport,
    setValueExport,
    handleOpenExamDetail,
    handleForceSyncPatients,
    // setIsExport,
    handleSave,
    // paging
  } = usePatients();

  const { t } = useTranslation();

  const columns = [
    columnHelper.accessor('patientId', {
      id: 'patientId',
      header: 'Id',
    }),
    columnHelper.accessor('ssn', {
      id: 'ssn',
      header: 'SSN',
    }),
    columnHelper.accessor('firstName', {
      id: 'firstName',
      header: 'First Name',
    }),
    columnHelper.accessor('lastName', {
      id: 'lastName',
      header: 'Last Name',
    }),
    columnHelper.accessor('noOfExam', {
      id: 'noOfExam',
      header: 'No of exam',
    }),
    columnHelper.accessor('delete', {
      id: 'delete',
      header: null,
      cell: ({ row }) => (
        <Box sx={{ display: 'flex', justifyContent: 'flex-end' }}>
          <EditButton
            className="icon-delete"
            color="info"
            icon={<EditIcon />}
            onClick={() => handleOpenExamDetail(
              row.original?.hospitalId ? row.original.hospitalId : 0,
              row.original.studyId,
            )}
          />
        </Box>
      ),
    }),
  ];

  // const detailGridOptions = {
  //   columnDefs: [
  //     {
  //       field: "id",
  //       headerName: "Exam ID",
  //       cellRenderer: "agGroupCellRenderer",
  //     },
  //     { field: "date", headerName: "Exam Date" },
  //     { field: "time", headerName: "Exam Time" },
  //     { field: "department" },
  //     { field: "reportType" },
  //     { field: "accessionNumber" },
  //     {
  //       field: "",
  //       cellRenderer: EditButton,
  //       cellRendererParams: {
  //         onClick: handleOpenExamDetail,
  //       },
  //       cellStyle: { justifyContent: "center" },
  //       maxWidth: 80,
  //     },
  //   ],
  //   defaultColDef,
  // };

  return (
    <BaseLayout>
      <Grid container spacing={1}>
        <Grid item xs={12} display="flex" gap={3}>
          <MDButton
            color="info"
            startIcon={!isLoading && <SyncIcon />}
            onClick={handleForceSyncPatients}
            variant="contained"
            disabled={isLoading}
          >
            {t('ForceSync')}
          </MDButton>
          {/* <MDButton
            color="info"
            startIcon={!isLoading && <SyncIcon />}
            onClick={() => setIsExport(!isExport)}
            variant="contained"
            disabled={isLoading}
          >
            {t("Export")}
          </MDButton> */}
        </Grid>
        {true && (
          <Grid item xs={12}>
            <Card style={{ padding: '20px' }}>
              <Grid container spacing={3}>
                <Grid item xs={3}>
                  <TextField
                    type="date"
                    fullWidth
                    label="Start Date"
                    InputLabelProps={{ shrink: true }}
                    onChange={(e) => setValueExport({ ...valueExport, startDate: e.target.value })}
                  />
                </Grid>
                <Grid item xs={3}>
                  <div>
                    <TextField
                      type="date"
                      fullWidth
                      label="End Date"
                      InputLabelProps={{ shrink: true }}
                      onChange={(e) => setValueExport({ ...valueExport, endDate: e.target.value })}
                    />
                  </div>
                </Grid>
                <Grid item xs={3}>
                  <div>
                    <Selector
                      options={patients.items.map((item) => item.patientName)}
                      onChange={(value) => setValueExport({
                        ...valueExport,
                        patient: patients.items.find((item) => item.patientName === value),
                      })}
                      label="Patients"
                      InputLabelProps={{ shrink: true }}
                    />
                  </div>
                </Grid>
                <Grid item xs={3} display="flex" alignItems="flex-end" justifyContent="flex-end">
                  <MDButton
                    color="info"
                    onClick={handleSave}
                    variant="contained"
                    disabled={isLoading}
                  >
                    {t('Save')}
                  </MDButton>
                </Grid>
              </Grid>
            </Card>
          </Grid>
        )}

        <Grid item xs={12}>
          <PeriodFiltersCard />
        </Grid>
        <Grid item xs={12}>
          {/* <AgGridTable
            ref={agRef}
            entity={patients}
            onFetching={getPatientsRequest}
            columnDefs={columnDefs}
            onDelete={handleDeletePatient}
            detailCellRendererParams={{
              detailGridOptions,
              getDetailRowData: (params) => {
                handleSelectPatient(params.data, (result) => {
                  params.successCallback(result);
                });
              },
            }}
            entityName="Patient"
          /> */}
          {patients && (
            <TsGridTable
              ref={agRef}
              entity={patients}
              columns={columns}
              onFetching={getPatientsRequest}
              entityName="Patient"
            />
          )}
        </Grid>
      </Grid>
    </BaseLayout>
  );
}
export default Patients;
