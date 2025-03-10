/* eslint-disable react/jsx-no-useless-fragment */
/* eslint-disable no-unused-expressions */
import {
  flexRender,
  getCoreRowModel,
  getExpandedRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  useReactTable,
} from '@tanstack/react-table';
import React, {
  forwardRef, useCallback, useImperativeHandle, useState,
} from 'react';
// import PropTypes from "prop-types";
// import { Box } from "@mui/material";
import {
  Box,
  Grid,
  Icon,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableRow,
  Typography,
} from '@mui/material';
import { FileDownload } from '@mui/icons-material';
import { useSelector } from 'react-redux';
import MDBox from 'components/MDBox';
import MDButton from 'components/MDButton';
import Pagination from 'components/Customized/Pagination2';
import SearchInput from 'components/Customized/SearchInput';
import { useTranslation } from 'react-i18next';
import DeleteIcon from '@mui/icons-material/Delete';
import KeyboardArrowRightIcon from '@mui/icons-material/KeyboardArrowRight';
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import MDDatePicker from 'components/MDDatePicker';
import { useMaterialUIController } from 'context';
import usePaging from './hooks/usePaging';
import PageSize from '../PageSize';
import SubTsGridTable from '../../../features/patients/SubComponent';
import EditButton from '../EditButton';
import styles from './styles.module.css';

const TsGridTable = forwardRef(
  (
    {
      entity,
      columns,
      onFetching,
      onCreate,
      onDelete,
      onExport,
      columnHides,
      entityName,
      subColumns,
      isExpand,
      tableClassName,
      searchDateRange = false,
    },
    ref,
  ) => {
    const [controller] = useMaterialUIController();
    const { darkMode } = controller;
    const [expanded, setExpanded] = useState({});
    const [columnVisibility, setColumnVisibility] = useState({ columnHides });
    const [sorting, setSorting] = useState([]);
    const [columnOrder, setColumnOrder] = useState(columns.map((column) => column.id));
    const pageSize = useSelector((state) => state.common.pageSize);

    const gridTable = useReactTable({
      columns,
      data: entity.items,
      state: {
        expanded, columnVisibility, sorting, columnOrder,
      },
      onColumnOrderChange: setColumnOrder,
      onSortingChange: setSorting,
      onColumnVisibilityChange: setColumnVisibility,
      getRowCanExpand: (row) => row.subRows || [],
      onExpandedChange: setExpanded,
      getCoreRowModel: getCoreRowModel(),
      getSortedRowModel: getSortedRowModel(),
      getExpandedRowModel: getExpandedRowModel(),
      getPaginationRowModel: getPaginationRowModel(),
      debugTable: true,
      debugHeaders: true,
      debugColumns: true,
    });

    const {
      // states
      textSearch,
      setTextSearch,
      dateRange,
      handleDateRangeChange,

      // paging
      previousPage,
      gotoPage,
      nextPage,
      setEntriesPerPage,

      fetchData,
    } = usePaging(entity, onFetching);

    const renderSubComponent = useCallback(
      (data) => <SubTsGridTable data={data} columns={subColumns} />,
      [],
    );

    useImperativeHandle(ref, () => ({
      fetchData: () => {
        fetchData();
      },
    }));

    const { t } = useTranslation();

    return (
      <Grid container spacing={1}>
        <Grid item xs={12} justifyContent="space-between" display="flex">
          <MDBox display="flex" alignItems="center">
            {'totalPages' in entity && (
              <>
                <PageSize
                  pageSize={pageSize}
                  onChange={(event, value) => {
                    setEntriesPerPage(value);
                  }}
                />
                <SearchInput label={t('Search')} value={textSearch} onChange={setTextSearch} />
                {searchDateRange && (
                  <div className={styles.dateRange}>
                    <MDDatePicker
                      options={{ mode: 'range' }}
                      value={dateRange}
                      onChange={handleDateRangeChange}
                      input={{
                        placeholder: 'Select date',
                      }}
                    />
                  </div>
                )}
              </>
            )}
          </MDBox>
          {onCreate && (
            <MDButton onClick={onCreate} variant="gradient" color="info">
              <Icon>add</Icon>
              {t('AddNew')}
              {' '}
              {entityName}
            </MDButton>
          )}
          {onExport && (
            <MDButton onClick={onExport} variant="gradient" color="info">
              <FileDownload />
              &nbsp;
              {' '}
              {t('ExportData')}
            </MDButton>
          )}
        </Grid>
        <Grid item xs={12}>
          {/* {gridTable.getAllLeafColumns().map((column) => (
            <div key={column.id} className="px-1">
              <label>
                <input
                  {...{
                    type: "checkbox",
                    checked: column.getIsVisible(),
                    onChange: column.getToggleVisibilityHandler(),
                  }}
                />
                {column.id}
              </label>
            </div>
          ))} */}
          <TableContainer className={tableClassName} sx={{ border: '1px solid #babfc7' }}>
            <Table stickyHeader aria-label="sticky table">
              <thead>
                {gridTable.getHeaderGroups().map((headerGroup) => (
                  <TableRow key={headerGroup.id}>
                    {headerGroup.headers.map((header) => (
                      <TableCell key={header.id} colSpan={header.colSpan}>
                        {header.isPlaceholder ? null : (
                          <Box
                            sx={{ cursor: 'pointer' }}
                            onClick={header.column.getToggleSortingHandler()}
                          >
                            <Typography
                              variant="body2"
                              fontWeight="bold"
                              color={darkMode ? '#FFF' : '#181d1f'}
                            >
                              {flexRender(header.column.columnDef.header, header.getContext())}
                              {{
                                asc: ' 🔼',
                                desc: ' 🔽',
                              }[header.column.getIsSorted()] ?? null}
                            </Typography>
                          </Box>
                        )}
                      </TableCell>
                    ))}
                  </TableRow>
                ))}
              </thead>
              <TableBody>
                {entity.items.length > 0 ? (
                  <>
                    {gridTable.getCoreRowModel().rows.map((row) => (
                      <>
                        <TableRow key={row.id} onClick={row.getToggleExpandedHandler()}>
                          {row.getVisibleCells().map((cell, index) => (
                            <TableCell
                              key={cell.id}
                              sx={{
                                borderTop: '1px solid #dde2eb',
                                borderBottom: '1px solid #dde2eb',
                                color: darkMode ? '#FFF' : '#242424',
                              }}
                            >
                              {index === 0 ? (
                                <>
                                  {row.getCanExpand() && (
                                    <Box sx={{ cursor: 'pointer' }}>
                                      {!isExpand ? (
                                        <span>
                                          {flexRender(
                                            cell.column.columnDef.cell,
                                            cell.getContext(),
                                          )}
                                        </span>
                                      ) : (
                                        <>
                                          {row.getIsExpanded() ? (
                                            <>
                                              <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                                <KeyboardArrowDownIcon />
                                                <span>
                                                  {flexRender(
                                                    cell.column.columnDef.cell,
                                                    cell.getContext(),
                                                  )}
                                                </span>
                                              </Box>
                                            </>
                                          ) : (
                                            <>
                                              <Box sx={{ display: 'flex', alignItems: 'center' }}>
                                                <KeyboardArrowRightIcon />
                                                <span>
                                                  {flexRender(
                                                    cell.column.columnDef.cell,
                                                    cell.getContext(),
                                                  )}
                                                </span>
                                              </Box>
                                            </>
                                          )}
                                        </>
                                      )}
                                    </Box>
                                  )}
                                </>
                              ) : (
                                <>{flexRender(cell.column.columnDef.cell, cell.getContext())}</>
                              )}
                            </TableCell>
                          ))}
                        </TableRow>
                        {subColumns && row.getIsExpanded() && (
                          <TableRow>
                            <TableCell
                              colSpan={row.getVisibleCells().length}
                              className="sub-component"
                            >
                              {renderSubComponent(row.original)}
                            </TableCell>
                          </TableRow>
                        )}
                      </>
                    ))}
                  </>
                ) : (
                  <TableRow>
                    <TableCell colSpan={gridTable.getAllColumns().length}>
                      <Box sx={{ display: 'flex', justifyContent: 'center' }}>
                        <Typography fontWeight={200} color="#181d1f" fontSize={14}>
                          {t('NoRowsToShow')}
                        </Typography>
                      </Box>
                    </TableCell>
                  </TableRow>
                )}
              </TableBody>
            </Table>
          </TableContainer>
        </Grid>
        <Grid item xs={12}>
          {/* <Pagination
            entity={entity}
            previousPage={previousPage}
            gotoPage={gotoPage}
            nextPage={nextPage}
            pageOptions={pageOptions}
            onChange={(handleInputPagination, handleInputPaginationValue)}
          /> */}
          <Pagination
            entity={entity}
            previousPage={previousPage}
            gotoPage={gotoPage}
            nextPage={nextPage}
          />
        </Grid>
      </Grid>
    );
  },
);

// TsGridTable.defaultProps = {
//   columns: [],
//   subColumns: [],
// };

// TsGridTable.propTypes = {
//   columns: PropTypes.array.isRequired(),
//   subColumns: PropTypes.array || undefined,
// };

export default TsGridTable;
