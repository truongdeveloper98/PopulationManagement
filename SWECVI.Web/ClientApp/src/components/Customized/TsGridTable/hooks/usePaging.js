import { useMemo, useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setPageSize } from 'stores/reducers/common.reducer';

const usePaging = (entity = undefined, onFetching = undefined) => {
  const [textSearch, setTextSearch] = useState(undefined);
  const [dateRange, setDateRange] = useState(undefined);
  const [sortColumnName, setSortColumnName] = useState(undefined);
  const [sortColumnDirection, setSortColumnDirection] = useState(undefined);
  const pageSize = useSelector((state) => state.common.pageSize);
  const period = useSelector((state) => state.common.period);
  const dispatch = useDispatch();

  const [gridApi, setGridApi] = useState(null);

  const [pageOptions, setPageOptions] = useState([]);
  const [currentPage, setCurrentPage] = useState(0);

  const updatePageOptions = () => setPageOptions(() => {
    const pageOptionArr = [];
    const totalPage = entity?.totalPages;
    if (totalPage) {
      for (let i = 0; i < totalPage; i++) {
        pageOptionArr.push(i);
      }
    }
    return pageOptionArr;
  });

  const setEntriesPerPage = (value) => {
    updatePageOptions();
    dispatch(setPageSize(value));
  };

  const handleInputPagination = ({ target: { value } }) => (value > pageOptions.length || value < 0 ? setCurrentPage(0) : setCurrentPage(Number(value)));

  const handleInputPaginationValue = ({ target: value }) => setCurrentPage(Number(value.value - 1));

  const sortingOrder = useMemo(() => ['desc', 'asc', null], []);

  const previousPage = () => {
    onFetching({
      pageSize,
      currentPage: (entity?.page ?? 0) - 1,
      textSearch,
      period,
      sortColumnName,
      sortColumnDirection,
    });
  };

  const gotoPage = (option) => {
    onFetching({
      pageSize,
      currentPage: option,
      textSearch,
      period,
      sortColumnName,
      sortColumnDirection,
    });
  };

  const fetchData = () => {
    onFetching({
      pageSize,
      currentPage,
      textSearch,
      period,
      sortColumnName,
      sortColumnDirection,
      fromDate: dateRange ? dateRange[0] : undefined,
      toDate: dateRange ? dateRange[1] : undefined,
    });
  };

  useEffect(() => {
    fetchData();
  }, [textSearch, period, pageSize, currentPage, sortColumnName, sortColumnDirection, dateRange]);

  useEffect(() => {
    updatePageOptions();
  }, [entity?.totalPages]);

  const nextPage = () => {
    onFetching({
      pageSize,
      currentPage: (entity?.page ?? 0) + 1,
      textSearch,
      period,
      sortColumnName,
      sortColumnDirection,
    });
  };

  const onGridReady = (params) => {
    setGridApi(params.api);
  };

  const shrinkRows = (id) => {
    if (!id) return;
    gridApi?.forEachNode((node) => {
      if (id === node.id) {
        return;
      }
      node.expanded = false;
    });
    gridApi?.onGroupExpandedOrCollapsed();
  };

  const handleSortChanged = (e) => {
    const gridColumns = e?.columnApi?.columnModel?.gridColumns;
    const sortColumn = gridColumns.filter((x) => !!x.sort);
    if (sortColumn.length > 0) {
      setSortColumnName(sortColumn[0].colId);
      setSortColumnDirection(sortColumn[0].sort);
    } else {
      setSortColumnName(undefined);
      setSortColumnDirection(undefined);
    }
  };

  const handleDateRangeChange = (value) => {
    if (value.length === 2) {
      setDateRange(value);
    }
  };

  return {
    // states
    textSearch,
    period,
    pageOptions,
    sortingOrder,
    dateRange,

    // funcs
    setTextSearch,
    onGridReady,
    shrinkRows,
    handleDateRangeChange,

    // paging
    handleInputPagination,
    handleInputPaginationValue,
    previousPage,
    gotoPage,
    nextPage,
    setEntriesPerPage,
    handleSortChanged,

    fetchData,
  };
};
export default usePaging;
