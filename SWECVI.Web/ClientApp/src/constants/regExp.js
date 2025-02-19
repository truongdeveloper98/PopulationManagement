const REG_EXP = {
  phone:
    /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/,
  hospitalName: /^[a-zA-Z0-9\s]+$/,
};
export default REG_EXP;
