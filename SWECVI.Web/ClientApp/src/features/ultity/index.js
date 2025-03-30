/* eslint-disable react/no-unstable-nested-components */
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useSelector } from 'react-redux';
import { createColumnHelper } from '@tanstack/react-table';
import { useTranslation } from 'react-i18next';
import { Box, Button } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import useUltity from './hooks/useUltity';
import { getUltityRequest } from './services';
import { ultitys } from 'stores/reducers/ultity.reducer';

const columnHelper = createColumnHelper();

export default function Ultity() {
  const {
    agRef, onCreateUltity, handleEditUltity, handleDeleteUltity, 
  } = useUltity();
  const { t } = useTranslation();
  const ultitys = useSelector((state) => state.ultity.ultitys);
  const columns = [
    columnHelper.accessor('id', {
      id: 'id', 
      header: 'Id',
    }), 
    columnHelper.accessor('name', {
      id: 'name',
      header: 'name',
    }),
    columnHelper.accessor('ultityId', {
      id: 'ultityId',
      header: 'ultityId',
    }),
    columnHelper.accessor('price', {
      id: 'price', 
      header: 'price',
    }),
    columnHelper.accessor('startTime', {
      id: 'startTime', 
      header: 'startTime',
    }),
    columnHelper.accessor('endTime', {
      id: 'endTime', 
      header: 'endTime',
    }),
    columnHelper.accessor('useTime', {
      id: 'useTime', 
      header: 'useTime',
    }),
    columnHelper.accessor('openDate', {
      id: 'openDate', 
      header: 'openDate',
    }),
    columnHelper.accessor('note', {
      id: 'note', 
      header: 'note',
    }),
    columnHelper.accessor('commitment', {
      id: 'commitment',
      header: 'commitment',
    }),
    columnHelper.accessor('isStatus', {
      id: 'isStatus',
      header: 'isStatus',
    }),
    columnHelper.accessor('', {
      id: 'edit',
      header: () => 'Edit',
      maxSize: 20,
      cell: ({ row }) => (
        <Box>
          <Button
            onClick={() => handleEditUltity(row.original.id)}
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
        entity={ultitys || []}
        onFetching={getUltityRequest}
        onCreate={onCreateUltity}
        onDelete={handleDeleteUltity}
        entityName={t('Ultity')}
        isExpand={false}
      />
    </BaseLayout>
  );
}
