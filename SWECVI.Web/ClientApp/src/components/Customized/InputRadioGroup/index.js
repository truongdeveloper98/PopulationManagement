import { Box, Grid, Typography } from '@mui/material';
import useInputRadioGroup from './hooks/useInputRadioGroup';
import styles from './styles.module.css';

export default function InputRadioGroup({
  id, label, options, onChange, tabName,
}) {
  const { getClassnameColor, patientFindingValueInput } = useInputRadioGroup();
  return (
    <Box sx={{ display: 'flex', alignItems: 'center', width: '100%' }}>
      <Grid container>
        <Grid item xs={12} xl={5}>
          <Typography sx={{ pb: '6px', width: '150px' }}>{label}</Typography>
        </Grid>

        <Grid item xs={12} xl={7}>
          <Box sx={{ display: 'flex' }}>
            {options?.map((option) => (
              <div
                className={styles.radioWrapper}
                style={{
                  border: `1px solid ${getClassnameColor(option)}`,
                }}
                onClick={() => onChange(id, label, option, tabName)}
              >
                <div
                  style={{
                    backgroundColor: getClassnameColor(option),
                    width: '100%',
                    height: '100%',
                    borderRadius: '50%',
                  }}
                  className={
                    patientFindingValueInput.valueOnlyRadioButton[tabName]
                      ? patientFindingValueInput.valueOnlyRadioButton[tabName][label]?.id === id
                        && patientFindingValueInput.valueOnlyRadioButton[tabName][label]?.value
                          === option
                        ? styles.active
                        : styles.inactive
                      : styles.inactive
                  }
                />
              </div>
            ))}
          </Box>
        </Grid>
      </Grid>
    </Box>
  );
}
