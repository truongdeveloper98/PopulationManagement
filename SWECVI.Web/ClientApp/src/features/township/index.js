/* eslint-disable react/no-unstable-nested-components */
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useSelector } from 'react-redux';
import { createColumnHelper } from '@tanstack/react-table';
import { useTranslation } from 'react-i18next';
import { Box, Button } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import useTownship from './hooks/useTownship';
import { getTownshipRequest } from './services';

const columnHelper = createColumnHelper();

export default function Township() {
  const {
    agRef, onCreateTownship, handleEditTownship, handleDeleteTownship,
  } = useTownship();
  const { t } = useTranslation();
  const townships = useSelector((state) => state.township.townships);
  const columns = [
    columnHelper.accessor('id', {
      id: 'id', 
      header: 'Id',
    }), 
    columnHelper.accessor('townShipId', {
      id: 'townShipId',
      header: 'TownshipId',
    }),
    columnHelper.accessor('name', {
      id: 'name',
      header: 'Name',
    }),
    columnHelper.accessor('companyName', {
      id: 'companyName',
      header: 'CompanyName',
    }),
    columnHelper.accessor('', {
      id: 'edit',
      header: () => 'Edit',
      maxSize: 20,
      cell: ({ row }) => (
        <Box>
          <Button
            onClick={() => handleEditTownship(row.original.id)}
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
        ref={agRef}
        columns={columns}
        entity={townships || []}
        onFetching={getTownshipRequest}
        onCreate={onCreateTownship}
        onDelete={handleDeleteTownship}
        entityName={t('Township')}
        isExpand={false}
      />
    </BaseLayout>
  );
}
