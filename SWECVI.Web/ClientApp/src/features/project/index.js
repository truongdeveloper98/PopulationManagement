/* eslint-disable react/no-unstable-nested-components */
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useSelector } from 'react-redux';
import { createColumnHelper } from '@tanstack/react-table';
import { useTranslation } from 'react-i18next';
import { Box, Button } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import useProject from './hooks/useProject';
import { getProjectRequest } from './services';
import { projects } from 'stores/reducers/project.reducer';

const columnHelper = createColumnHelper();

export default function Project() {
  const {
    agRef, onCreateProject, handleEditProject, handleDeleteProject,
  } = useProject();
  const { t } = useTranslation();
  const projects = useSelector((state) => state.project.projects);
  const columns = [
    columnHelper.accessor('id', {
      id: 'id', 
      header: 'Id',
    }), 
    columnHelper.accessor('townShipName', {
      id: 'townShipName',
      header: 'TownshipName',
    }),
    columnHelper.accessor('name', {
      id: 'name',
      header: 'Name',
    }),
    columnHelper.accessor('address', {
      id: 'address', 
      header: 'Address',
    }),
    columnHelper.accessor('phoneNumber', {
      id: 'phoneNumber', 
      header: 'PhoneNumber',
    }),
    columnHelper.accessor('description', {
      id: 'description', 
      header: 'Description',
    }),
    columnHelper.accessor('managerName', {
      id: 'managerName',
      header: 'ManagerName',
    }),
    columnHelper.accessor('', {
      id: 'edit',
      header: () => 'Edit',
      maxSize: 20,
      cell: ({ row }) => (
        <Box>
          <Button
            onClick={() => handleEditProject(row.original.id)}
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
        entity={projects || []}
        onFetching={getProjectRequest}
        onCreate={onCreateProject}
        onDelete={handleDeleteProject}
        entityName={t('Project')}
        isExpand={false}
      />
    </BaseLayout>
  );
}
