/* eslint-disable react/no-unstable-nested-components */
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useSelector } from 'react-redux';
import { createColumnHelper } from '@tanstack/react-table';
import { useTranslation } from 'react-i18next';
import { Box, Button } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import useCompany from './hooks/useCompany';
import { getCompanyRequest } from './services';

const columnHelper = createColumnHelper();

export default function Company() {
  const {
    agRef, onCreateCompany, handleEditCompany, handleDeleteCompany,
  } = useCompany();
  const { t } = useTranslation();
  const companies = useSelector((state) => state.company.companies);
  const columns = [
    columnHelper.accessor('id', {
      id: 'id', 
      header: 'Id',
    }), 
    columnHelper.accessor('name', {
      id: 'name',
      header: 'Name',
    }),
    columnHelper.accessor('companyId', {
      id: 'companyId',
      header: 'CompanyId',
    }),
    columnHelper.accessor('', {
      id: 'edit',
      header: () => 'Edit',
      maxSize: 20,
      cell: ({ row }) => (
        <Box>
          <Button
            onClick={() => handleEditCompany(row.original.id)}
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
        entity={companies || []}
        onFetching={getCompanyRequest}
        onCreate={onCreateCompany}
        onDelete={handleDeleteCompany}
        entityName={t('Company')}
        isExpand={false}
      />
    </BaseLayout>
  );
}
