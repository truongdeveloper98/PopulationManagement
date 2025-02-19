import React from 'react';
import CellButton from 'components/Customized/CellButton';

function EditButton({
  data, onClick, className, icon, color,
}) {
  return (
    <CellButton
      title={icon}
      className={className}
      color={color}
      onClick={() => {
        onClick(data);
      }}
    />
  );
}

export default EditButton;
