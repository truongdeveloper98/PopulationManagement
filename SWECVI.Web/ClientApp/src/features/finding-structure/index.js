/* eslint-disable react/no-unstable-nested-components */
/* eslint-disable no-unused-vars */
import {
  Box, Button, Card, FormControlLabel, FormGroup, Grid, Switch,
} from '@mui/material';
import { createColumnHelper } from '@tanstack/react-table';
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useTranslation } from 'react-i18next';
import { useSelector } from 'react-redux';
import EditIcon from '@mui/icons-material/Edit';
import { getFindingStructuresRequest } from './services';
import useFindingStructure from './hooks/useFindingStructure';

const columnHelper = createColumnHelper();

export default function FindingStructure() {
  const { t } = useTranslation();

  const { agRef, onCreateFinding, handleEditFidings } = useFindingStructure();
  const settings = useSelector((state) => state.findings.findings);

  const columns = [
    columnHelper.accessor('id', {
      id: 'id',
      header: 'Id',
    }),
    columnHelper.accessor('rowOrder', {
      id: 'rowOrder',
      header: 'RowOrder',
    }),
    columnHelper.accessor('tabName', {
      id: 'tabName',
      header: 'Tab Name',
    }),
    columnHelper.accessor('boxHeader', {
      id: 'boxHeader',
      header: 'Box Header',
    }),
    columnHelper.accessor('inputLabel', {
      id: 'inputLabel',
      header: 'Input Label',
    }),
    columnHelper.accessor('inputTypeName', {
      id: 'inputTypeName',
      header: 'Input Type',
    }),
    columnHelper.accessor('inputOptions', {
      id: 'iputOptions',
      header: 'Input Options',
    }),
    columnHelper.accessor('orderInReport', {
      id: 'orderInReport',
      header: 'Order In Report',
    }),
    columnHelper.accessor('', {
      id: 'action',
      header: () => null,
      cell: ({ row }) => (
        <Box style={{ textAlign: 'right' }}>
          <Button
            className="icon-delete"
            color="info"
            icon={<EditIcon />}
            onClick={() => handleEditFidings(row.original.id)}
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
        onFetching={getFindingStructuresRequest}
        onCreate={onCreateFinding}
        entity={settings}
        entityName="Finding-Structure"
        isExpand={false}
      />
    </BaseLayout>
  );
}
