/* eslint-disable react/no-unstable-nested-components */
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useSelector } from 'react-redux';
import { createColumnHelper } from '@tanstack/react-table';
import { useTranslation } from 'react-i18next';
import { Box, Button } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import useProjectInformation from './hooks/useProjectInformation';
import { getProjectInformationRequest } from './services';

const columnHelper = createColumnHelper();

export default function ProjectInformation() {
  const {
    agRef, onCreateProjectInformation, handleEditProjectInformation, handleDeleteProjectInformation,
  } = useProjectInformation();
  const { t } = useTranslation();
  const projectInformations = useSelector((state) => state.projectInformation.projectInformations);
  const columns = [
    columnHelper.accessor('id', {
      id: 'id', 
      header: 'Id',
    }), 
    columnHelper.accessor('content', {
      id: 'content',
      header: 'Content',
    }),
    columnHelper.accessor('quantity', {
      id: 'quantity',
      header: 'Quantity',
    }),
    columnHelper.accessor('note', {
      id: 'note',
      header: 'Note',
    }),
    columnHelper.accessor('', {
      id: 'edit',
      header: () => 'Edit',
      maxSize: 20,
      cell: ({ row }) => (
        <Box>
          <Button
            onClick={() => handleEditProjectInformation(row.original.id)}
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
        entity={projectInformations || []}
        onFetching={getProjectInformationRequest}
        onCreate={onCreateProjectInformation}
        onDelete={handleDeleteProjectInformation}
        entityName={t('ProjectInformation')}
        isExpand={false}
      />
    </BaseLayout>
  );
}
