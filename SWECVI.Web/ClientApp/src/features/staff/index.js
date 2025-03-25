/* eslint-disable react/no-unstable-nested-components */
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useSelector } from 'react-redux';
import { createColumnHelper } from '@tanstack/react-table';
import { useTranslation } from 'react-i18next';
import { Box, Button } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import useStaff from './hooks/useStaff';
import { getStaffRequest } from './services';
import { staff } from 'stores/reducers/staff.reducer';

const columnHelper = createColumnHelper();

export default function Staff() {
  const {
    agRef, onCreateStaff, handleEditStaff, handleDeleteStaff,
  } = useStaff();
  const { t } = useTranslation();
  const staffs = useSelector((state) => state.staff.staffs);
  const columns = [
    columnHelper.accessor('id', {
      id: 'id', 
      header: 'Id',
    }), 
    columnHelper.accessor('name', {
      id: 'name',
      header: 'name',
    }),
    columnHelper.accessor('staffId', {
      id: 'staffId',
      header: 'staffId',
    }),
    columnHelper.accessor('email', {
      id: 'email', 
      header: 'email',
    }),
    columnHelper.accessor('phoneNumber', {
      id: 'phoneNumber', 
      header: 'PhoneNumber',
    }),
    columnHelper.accessor('position', {
      id: 'position', 
      header: 'position',
    }),
    columnHelper.accessor('nationalId', {
      id: 'nationalId', 
      header: 'nationalId',
    }),
    columnHelper.accessor('address', {
      id: 'address', 
      header: 'address',
    }),
    columnHelper.accessor('address', {
      id: 'address', 
      header: 'address',
    }),
    columnHelper.accessor('departmentName', {
      id: 'departmentName',
      header: 'departmentName',
    }),
    columnHelper.accessor('', {
      id: 'edit',
      header: () => 'Edit',
      maxSize: 20,
      cell: ({ row }) => (
        <Box>
          <Button
            onClick={() => handleEditStaff(row.original.id)}
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
        entity={staffs || []}
        onFetching={getStaffRequest}
        onCreate={onCreateStaff}
        onDelete={handleDeleteStaff}
        entityName={t('Staff')}
        isExpand={false}
      />
    </BaseLayout>
  );
}
