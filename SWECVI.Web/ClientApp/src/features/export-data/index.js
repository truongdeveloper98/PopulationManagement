/* eslint-disable react/no-unstable-nested-components */
import { createColumnHelper } from '@tanstack/react-table';
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import { useTranslation } from 'react-i18next';
// import { useSelector } from "react-redux";
import useExportData from './hooks/useExportData';
import { exportData as mockExportData } from './mockData';
import { downloadExportDataRequest, getExportDataRequest } from './services';

const columnHelper = createColumnHelper();

export default function ExportData() {
  const { agGref } = useExportData();
  const { t } = useTranslation();
  // const exportData = useSelector((state) => state.exportData.exportData);
  const exportData = mockExportData;

  const columns = [
    columnHelper.accessor('id', {
      id: 'id',
      header: 'Id',
    }),
    columnHelper.accessor('studyRef', {
      id: 'studyRef',
      header: 'Study Ref',
    }),
    columnHelper.accessor('typeOfData', {
      id: 'typeOfData',
      header: 'Type Of Data',
    }),
    columnHelper.accessor('mainParameterCV', {
      id: 'mainParameterCV',
      header: 'Main Parameter CV',
    }),
    columnHelper.accessor('mainParameterCSD', {
      id: 'mainParameterCSD',
      header: 'Main Parameter CSD',
    }),
    columnHelper.accessor('mainParameterCM', {
      id: 'mainParameterCM',
      header: 'Main Parameter CM',
    }),
    columnHelper.accessor('findingSite', {
      id: 'findingSite',
      header: 'Finding Site',
    }),
    columnHelper.accessor('imageView', {
      id: 'imageView',
      header: 'Image View',
    }),
    columnHelper.accessor('imageMode', {
      id: 'imageMode',
      header: 'Image Mode',
    }),
    columnHelper.accessor('cardiacCyclePoint', {
      id: 'cardiacCyclePoint',
      header: 'Cardiac Cycle Point',
    }),
    columnHelper.accessor('respiratoryCyclePoint', {
      id: 'respiratoryCyclePoint',
      header: 'Respiratory Cycle Point',
    }),
    columnHelper.accessor('directionOfFlow', {
      id: 'directionOfFlow',
      header: 'Direction Of Flow',
    }),
    columnHelper.accessor('measurementMethod', {
      id: 'measurementMethod',
      header: 'Measurement Method',
    }),
    columnHelper.accessor('measurementUnit', {
      id: 'measurementUnit',
      header: 'Measurement Unit',
    }),
    columnHelper.accessor('resultValue', {
      id: 'resultValue',
      header: 'Result Value',
    }),
    columnHelper.accessor('derivation', {
      id: 'derivation',
      header: 'Derivation',
    }),
    columnHelper.accessor('selectionStatus', {
      id: 'selectionStatus',
      header: 'Selection Status',
    }),
    columnHelper.accessor('observationCV', {
      id: 'observationCV',
      header: 'Observation CV',
    }),
    columnHelper.accessor('observationCSD', {
      id: 'observationCSD',
      header: 'Observation CSD',
    }),
    columnHelper.accessor('observationCM', {
      id: 'observationCM',
      header: 'Observation CM',
    }),
    columnHelper.accessor('observationSetCV', {
      id: 'observationSetCV',
      header: 'Observation Set CV',
    }),
    columnHelper.accessor('observationSetCSD', {
      id: 'observationSetCSD',
      header: 'Observation Set CSD',
    }),
    columnHelper.accessor('observationSetCM', {
      id: 'observationSetCM',
      header: 'Observation Set CM',
    }),
    columnHelper.accessor('assessmentCV', {
      id: 'assessmentCV',
      header: 'Assessment CV',
    }),
    columnHelper.accessor('assessmentCSD', {
      id: 'assessmentCSD',
      header: 'Assessment CSD',
    }),
    columnHelper.accessor('assessmentCM', {
      id: 'assessmentCM',
      header: 'Assessment CM',
    }),
    columnHelper.accessor('assessmentTypeCV', {
      id: 'assessmentTypeCV',
      header: 'Assessment Type CV',
    }),
    columnHelper.accessor('assessmentTypeCSD', {
      id: 'assessmentTypeCSD',
      header: 'Assessment Type CSD',
    }),
    columnHelper.accessor('assessmentSetCV', {
      id: 'assessmentSetCV',
      header: 'Assessment Set CV',
    }),
    columnHelper.accessor('assessmentSetCSD', {
      id: 'assessmentSetCSD',
      header: 'Assessment Set CSD',
    }),
    columnHelper.accessor('assessmentSetCM', {
      id: 'assessmentSetCM',
      header: 'Assessment Set CM',
    }),
    columnHelper.accessor('iCDMainCode', {
      id: 'iCDMainCode',
      header: 'ICD Main Code',
    }),
    columnHelper.accessor('iCDSubCode', {
      id: 'iCDSubCode',
      header: 'ICD Sub Code',
    }),
    columnHelper.accessor('iCDCM', {
      id: 'iCDCM',
      header: 'ICD CM',
    }),
    columnHelper.accessor('createdAt', {
      id: 'createdAt',
      header: 'Created At',
    }),
  ];
  return (
    <BaseLayout>
      <TsGridTable
        ref={agGref}
        columns={columns}
        onFetching={getExportDataRequest}
        entity={exportData}
        entityName={t('ExportData')}
        isExpand={false}
        onExport={downloadExportDataRequest}
        searchDateRange
      />
    </BaseLayout>
  );
}
