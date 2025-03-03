/* eslint-disable react/no-unstable-nested-components */
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useSelector } from 'react-redux';
import { createColumnHelper } from '@tanstack/react-table';
import { useTranslation } from 'react-i18next';
import { Box, Button } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import useJob from './hooks/useJob';
import { getJobRequest } from './services';

const columnHelper = createColumnHelper();

export default function Job() {
  const {
    agRef, onCreateJob, handleEditJob, handleDeleteJob,
  } = useJob();
  const { t } = useTranslation();
  const jobs = useSelector((state) => state.job.jobs);
  const columns = [
    columnHelper.accessor('id', {
      id: 'id', 
      header: 'Id',
    }), 
    columnHelper.accessor('name', {
      id: 'name',
      header: 'Name',
    }),
    columnHelper.accessor('description', {
      id: 'description',
      header: 'Description',
    }),
    columnHelper.accessor('', {
      id: 'edit',
      header: () => 'Edit',
      maxSize: 20,
      cell: ({ row }) => (
        <Box>
          <Button
            onClick={() => handleEditJob(row.original.id)}
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
        entity={jobs || []}
        onFetching={getJobRequest}
        onCreate={onCreateJob}
        onDelete={handleDeleteJob}
        entityName={t('Job')}
        isExpand={false}
      />
    </BaseLayout>
  );
}
