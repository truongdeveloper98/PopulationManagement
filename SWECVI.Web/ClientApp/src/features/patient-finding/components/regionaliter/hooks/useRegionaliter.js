import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setPatientFindingValueInput } from 'stores/reducers/patient.reducer';

const useRegionaliter = (patientFindingBox, handleSave) => {
  const arrTab = [];
  patientFindingBox.forEach((item) => {
    if (!arrTab.includes(item.boxHeader)) {
      arrTab.push(item.boxHeader);
    }
  });
  const dispatch = useDispatch();
  const patientFindingValueInput = useSelector((state) => state.patient.patientFindingValueInput);

  const [segmentHeart, setSegmentHeart] = useState([]);
  const [tabIndex, setTabIndex] = useState(0);
  const midpoint = Math.ceil(segmentHeart.length / 2);
  const [arrVariable, setArrVariable] = useState([]);

  useEffect(() => {
    if (!patientFindingBox) {
      return;
    }
    setSegmentHeart(
      patientFindingBox
        .filter((item) => item.boxHeader === arrTab[tabIndex])
        .sort((a, b) => a.rowOrder - b.rowOrder),
    );
  }, [tabIndex]);

  useEffect(() => {
    setArrVariable(
      segmentHeart.filter((i) => i.boxHeader === arrTab[tabIndex]).map((j) => j.inputLabel),
    );
  }, [segmentHeart]);

  const handleTabChange = (index) => {
    setTabIndex(index);
  };

  const handleSelectChange = () => {};

  const handleClear = () => {
    const objSegmentHeart = {};
    for (let i = 0; i < segmentHeart.length; i++) {
      objSegmentHeart[arrVariable[i]] = {
        id: segmentHeart[i].id,
        value: '',
      };
    }
    const payload = {
      ...patientFindingValueInput,
      valueOnlyRadioButton: {
        ...patientFindingValueInput.valueOnlyRadioButton,
        Regionalitet: {
          ...patientFindingValueInput.valueOnlyRadioButton.Regionalitet,
          ...objSegmentHeart,
        },
      },
    };
    dispatch(setPatientFindingValueInput(payload));
    handleSave(payload);
  };

  const handleAllNormal = () => {
    const objSegmentHeart = {};
    for (let i = 0; i < segmentHeart.length; i++) {
      objSegmentHeart[arrVariable[i]] = {
        id: segmentHeart[i].id,
        value: 'Normal',
      };
    }
    const payload = {
      ...patientFindingValueInput,
      valueOnlyRadioButton: {
        ...patientFindingValueInput.valueOnlyRadioButton,
        Regionalitet: {
          ...patientFindingValueInput.valueOnlyRadioButton.Regionalitet,
          ...objSegmentHeart,
        },
      },
    };
    dispatch(setPatientFindingValueInput(payload));
    handleSave(payload);
  };

  return {
    handleTabChange,
    handleSelectChange,
    tabIndex,
    segmentHeart,
    midpoint,
    arrTab,
    handleClear,
    handleAllNormal,
  };
};

export default useRegionaliter;
