import { useSelector } from 'react-redux';

const useInputRadioGroup = () => {
  const patientFindingValueInput = useSelector((state) => state.patient.patientFindingValueInput);

  const getClassnameColor = (type) => {
    switch (type) {
      case 'Normal':
        return 'green';
      case 'Hypokinesi':
        return 'orange';
      case 'Akinesi':
        return 'red';
      case 'Aneurysm':
        return 'blue';
      case 'Dyskinesi':
        return 'gray';
      case 'Ej tolkningsbart':
        return 'purple';
      default:
        return 'blue';
    }
  };
  return { getClassnameColor, patientFindingValueInput };
};

export default useInputRadioGroup;
