import { Box } from '@mui/material';

export default function TabItem({ name, active }) {
  return (
    <Box
      sx={{
        px: 3,
        py: 1,
        fontSize: '1rem',
        lineHeight: 'normal',
        borderRadius: 2,
        backgroundColor: active ? '#2881eb' : 'transparent',
        color: active ? '#fff' : '#000',
        border: '1px solid #ccc',
        transition: 'all .3s linear',
      }}
    >
      {name}
    </Box>
  );
}
