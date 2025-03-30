/* eslint-disable react/no-unstable-nested-components */
import BaseLayout from 'components/Customized/BaseLayout';
import TsGridTable from 'components/Customized/TsGridTable';
import React from 'react';
import { useSelector } from 'react-redux';
import { createColumnHelper } from '@tanstack/react-table';
import { useTranslation } from 'react-i18next';
import { Box, Button } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import usePeopleOfApartment from './hooks/usePeopleOfApartment';
import { getPeopleOfApartmentRequest } from './services';
import { peopleOfApartment } from 'stores/reducers/peopleOfApartment.reducer';

const columnHelper = createColumnHelper();

export default function PeopleOfApartment() {
  const {
    agRef, onCreatePeopleOfApartment, handleEditPeopleOfApartment, handleDeletePeopleOfApartment, 
  } = usePeopleOfApartment();
  const { t } = useTranslation();
  const peopleOfApartments = useSelector((state) => state.peopleOfApartment.peopleOfApartment);
  const columns = [
    columnHelper.accessor('id', {
      id: 'id', 
      header: 'Id',
    }), 
    columnHelper.accessor('firstName', {
      id: 'firstName',
      header: 'firstName',
    }),
    columnHelper.accessor('lastName', {
      id: 'lastName',
      header: 'lastName',
    }),
    columnHelper.accessor('email', {
      id: 'email', 
      header: 'email',
    }),
    columnHelper.accessor('phoneNumber', {
      id: 'phoneNumber', 
      header: 'phoneNumber',
    }),
    columnHelper.accessor('nationalId', {
      id: 'nationalId', 
      header: 'nationalId',
    }),
    columnHelper.accessor('dob', {
      id: 'dob', 
      header: 'dob',
    }),
    columnHelper.accessor('gender', {
      id: 'gender', 
      header: 'gender',
    }),
    columnHelper.accessor('apartmentName', {
      id: 'apartmentName', 
      header: 'apartmentName',
    }),
    columnHelper.accessor('relationship', {
      id: 'relationship',
      header: 'relationship',
    }),
    
    columnHelper.accessor('', {
      id: 'edit',
      header: () => 'Edit',
      maxSize: 20,
      cell: ({ row }) => (
        <Box>
          <Button
            onClick={() => handleEditPeopleOfApartment(row.original.id)}
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
        entity={peopleOfApartments || []}
        onFetching={getPeopleOfApartmentRequest}
        onCreate={onCreatePeopleOfApartment}
        onDelete={handleDeletePeopleOfApartment}
        entityName={t('peopleOfApartment')}
        isExpand={false}
      />
    </BaseLayout>
  );
}
