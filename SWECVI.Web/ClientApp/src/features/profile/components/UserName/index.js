import MDBox from 'components/MDBox';
import { useJwt } from 'react-jwt';
import { useSelector } from 'react-redux';
import { useMaterialUIController } from 'context';

function UserName() {
  const [controller] = useMaterialUIController();

  const { darkMode } = controller;

  const token = useSelector((state) => state.auth.token);

  const { decodedToken } = useJwt(token);

  const userName = decodedToken?.sub;

  return (
    <MDBox className={darkMode ? 'ag-theme-alpine-dark' : 'ag-theme-alpine'}>{userName}</MDBox>
  );
}

export default UserName;
