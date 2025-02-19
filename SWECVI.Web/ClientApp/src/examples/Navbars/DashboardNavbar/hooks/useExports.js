 
import { useRef, useState } from 'react';
import { exportPatientRequest } from '../services';

const useExports = () => {
  const agRef = useRef(null);
  const [startDateValue, setStartDateValue] = useState(undefined);
  const [endDateValue, setEndDateValue] = useState(undefined);
  const handleSave = async () => {
    await exportPatientRequest({
      startDate: startDateValue,
      endDate: endDateValue,
    });
  };

  return {
    agRef,
    startDateValue,
    setStartDateValue,
    endDateValue,
    setEndDateValue,
    handleSave,
  };
};
export default useExports;
