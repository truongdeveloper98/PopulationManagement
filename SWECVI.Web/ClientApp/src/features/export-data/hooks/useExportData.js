import { getDepartmentRequest } from 'features/department/services';
import { useEffect, useRef } from 'react';

const useExportData = () => {
  const agRef = useRef();

  useEffect(() => {
    getDepartmentRequest();
  }, []);

  return { agRef };
};

export default useExportData;
