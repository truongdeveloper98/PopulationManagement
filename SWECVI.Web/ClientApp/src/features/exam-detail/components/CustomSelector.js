import React from 'react';
import TextField from '@mui/material/TextField';
import Stack from '@mui/material/Stack';
import Autocomplete from '@mui/material/Autocomplete';

function SelectorExam({
  onChange, options, property, ...rest
}) {
  return (
    <Stack sx={{ width: 300, margin: 'auto' }}>
      <Autocomplete
        componentsProps={{
          paper: {
            sx: {
              width: 350,
              margin: 'auto',
            },
          },
        }}
        id="Hello"
        getOptionLabel={(option) => String(property ? option[property] ?? option : option)}
        options={options}
        noOptionsText="No results"
        onChange={(e, value) => onChange(value)}
        renderInput={(params) => (
          <TextField
            {...params}
            label="Select Exam"
            sx={{
              '& .MuiOutlinedInput-root': {
                borderRadius: '50px',

                legend: {
                  marginLeft: '30px',
                },
              },
              '& .MuiAutocomplete-inputRoot': {
                paddingLeft: '20px !important',
                borderRadius: '50px',
              },
              '& .MuiInputLabel-outlined': {
                paddingLeft: '20px',
              },
              '& .MuiInputLabel-shrink': {
                marginLeft: '20px',
                paddingLeft: '10px',
                paddingRight: 0,
              },
            }}
          />
        )}
        {...rest}
      />
    </Stack>
  );
}

export default SelectorExam;
