import React from 'react';
import DeleteIcon from '@mui/icons-material/Delete';
import CellButton from 'components/Customized/CellButton';

function DeleteButton({
  data, confirmTitle, onClick, className,
}) {
  return (
    <CellButton
      color="error"
      className={className}
      title={<DeleteIcon />}
      confirmTitle={confirmTitle}
      onClick={() => {
        onClick(data);
      }}
    />
  );
}

export default DeleteButton;
