/* eslint-disable react/no-unstable-nested-components */
import { createColumnHelper } from '@tanstack/react-table';
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useTranslation } from 'react-i18next';
import { Box, Button } from '@mui/material';
// import { useSelector } from "react-redux";
import EditIcon from '@mui/icons-material/Edit';
import useManufacturerDicom from './hooks/useManufacturerDicom';
import { getManufacturerDicomRequest } from './services';
import { manufacturerData } from './mockData';

const columnHelper = createColumnHelper();

export default function ManufacturerDicom() {
  const { agGref, onCreateManufacturerDicom, handleEditManufacturerDicom } = useManufacturerDicom();
  const { t } = useTranslation();
  // const manufacturerDicom = useSelector((state) => state.manufacturerDicom.manufacturerDicom);
  const manufacturerDicom = manufacturerData;

  const columns = [
    columnHelper.accessor('id', {
      id: 'id',
      header: 'Id',
    }),
    columnHelper.accessor('providerId', {
      id: 'providerId',
      header: 'Provider Id',
    }),
    columnHelper.accessor('providerParameterId', {
      id: 'providerParameterId',
      header: 'Provider Parameter Id',
    }),
    columnHelper.accessor('providerParameterShortName', {
      id: 'providerParameterShortName',
      header: 'Provider Parameter Short Name',
    }),
    columnHelper.accessor('measurementCSD', {
      id: 'measurementCSD',
      header: 'Measurement CSD',
    }),
    columnHelper.accessor('measurementCV', {
      id: 'measurementCV',
      header: 'Measurement CV',
    }),
    columnHelper.accessor('measurementCM', {
      id: 'measurementCM',
      header: 'Measurement CM',
    }),
    columnHelper.accessor('', {
      id: 'action',
      header: () => null,
      cell: ({ row }) => (
        <Box style={{ textAlign: 'right' }}>
          <Button
            onClick={() => handleEditManufacturerDicom(row.original.id)}
            className="icon-delete"
            color="info"
            icon={<EditIcon />}
          >
            <EditIcon />
          </Button>
        </Box>
      ),
    }),
  ];
  return (
    <BaseLayout>
      <TsGridTable
        ref={agGref}
        columns={columns}
        onCreate={onCreateManufacturerDicom}
        onFetching={getManufacturerDicomRequest}
        entity={manufacturerDicom}
        entityName={t('ManufacturerDicom')}
        isExpand={false}
      />
    </BaseLayout>
  );
}
