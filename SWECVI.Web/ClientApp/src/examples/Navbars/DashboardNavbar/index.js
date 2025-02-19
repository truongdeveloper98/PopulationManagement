import { useState, useEffect } from 'react';
import { NavLink, useLocation } from 'react-router-dom';
import PropTypes from 'prop-types';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Icon from '@mui/material/Icon';
import {
  Grid, TextField, Menu, MenuItem, Switch,
} from '@mui/material';
import MDBox from 'components/MDBox';
import Breadcrumbs from 'examples/Breadcrumbs';
import { LOGOUT } from 'constants/actionTypes';

import {
  navbar,
  navbarContainer,
  navbarRow,
  navbarIconButton,
  navbarDesktopMenu,
} from 'examples/Navbars/DashboardNavbar/styles';

import {
  useMaterialUIController,
  setTransparentNavbar,
  setMiniSidenav,
  setDarkMode,
  setLanguage,
} from 'context';
import { useTranslation } from 'react-i18next';
import { LANGUAGES } from 'constants/language';
import { useJwt } from 'react-jwt';
import { useSelector, useDispatch } from 'react-redux';
import LanguageIcon from '@mui/icons-material/Language';

import routes from 'navigation/privateRoutes';
import MDButton from 'components/MDButton';
import useExports from './hooks/useExports';

function DashboardNavbar({ absolute, light, isMini }) {
  const {
    handleSave,
    setStartDateValue,
    setEndDateValue,
    // paging
  } = useExports();

  const [navbarType, setNavbarType] = useState();
  const [controller, dispatch] = useMaterialUIController();
  const {
    miniSidenav, transparentNavbar, fixedNavbar, darkMode,
  } = controller;
  const route = useLocation().pathname.split('/').slice(1);

  const isHideFillter = !!useLocation().pathname.includes('references');

  const token = useSelector((state) => state.auth.token);

  const { decodedToken } = useJwt(token);

  const dispatchLogout = useDispatch();

  const handleLogout = () => {
    localStorage.removeItem('hospitalId');
    localStorage.removeItem('hospitalName');
    dispatchLogout({ type: LOGOUT });
  };

  const handleChangeSideBar = (event) => {
    if (event.target.innerWidth > 1200) {
      setMiniSidenav(dispatch, false);
    } else {
      setMiniSidenav(dispatch, true);
    }
  };

  // eslint-disable-next-line no-console
  const departmentName = decodedToken?.['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname'];

  const hospitalName = localStorage.getItem('hospitalName');

  useEffect(() => {
    if (fixedNavbar) {
      setNavbarType('sticky');
    } else {
      setNavbarType('static');
    }
    function handleTransparentNavbar() {
      setTransparentNavbar(dispatch, (fixedNavbar && window.scrollY === 0) || !fixedNavbar);
    }
    window.addEventListener('scroll', handleTransparentNavbar);
    window.addEventListener('resize', handleChangeSideBar);
    handleTransparentNavbar();
    return () => {
      window.removeEventListener('scroll', handleTransparentNavbar);
      window.removeEventListener('resize', handleChangeSideBar);
    };
  }, [dispatch, fixedNavbar]);

  const handleMiniSidenav = () => {
    setMiniSidenav(dispatch, !miniSidenav);
  };

  const handleDarkMode = () => setDarkMode(dispatch, !darkMode);

  // Styles for the navbar icons
  const iconsStyle = ({ palette: { dark, white, text }, functions: { rgba } }) => ({
    color: () => {
      let colorValue = light || darkMode ? white.main : dark.main;

      if (transparentNavbar && !light) {
        colorValue = darkMode ? rgba(text.main, 0.6) : text.main;
      }

      return colorValue;
    },
  });

  const { i18n } = useTranslation();

  const [anchorEl, setAnchorEl] = useState(null);

  const handleClick = (e) => {
    setAnchorEl(e.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const [anchorElAvatar, setAnchorElAvatar] = useState(null);

  const handleClickAvatar = (event) => {
    setAnchorElAvatar(event.currentTarget);
  };
  const handleCloseAvatar = () => {
    setAnchorElAvatar(null);
  };

  const handleChangeLanguage = (lng) => {
    i18n.changeLanguage(lng);
    setLanguage(dispatch, lng);
    handleClose();
  };
  return (
    <AppBar
      position={absolute ? 'absolute' : navbarType}
      color="inherit"
      sx={(theme) => navbar(theme, {
        transparentNavbar, absolute, light, darkMode,
      })}
    >
      <Toolbar sx={(theme) => navbarContainer(theme)} style={{ padding: 0 }}>
        <MDBox color="inherit" mb={{ xs: 1, md: 0 }} sx={(theme) => navbarRow(theme, { isMini })}>
          <IconButton sx={navbarDesktopMenu} onClick={handleMiniSidenav} size="small" disableRipple>
            <Icon fontSize="medium" sx={iconsStyle}>
              {miniSidenav ? 'menu_open' : 'menu'}
            </Icon>
          </IconButton>
        </MDBox>
        <MDBox className={darkMode ? 'ag-theme-alpine-dark' : 'ag-theme-alpine'}>
          Hospital :
          {' '}
          {hospitalName === undefined || hospitalName === '' ? 'N/A' : hospitalName}
          ,
          Department :
          {' '}
          {departmentName === undefined || departmentName === '' ? 'N/A' : departmentName}
        </MDBox>
        {isMini ? null : (
          <MDBox sx={(theme) => navbarRow(theme, { isMini })}>
            <MDBox />
            <MDBox color={light ? 'white' : 'inherit'}>
              <IconButton
                size="small"
                color="inherit"
                sx={navbarIconButton}
                variant="contained"
                onClick={handleClick}
              >
                <LanguageIcon />
              </IconButton>
              <Menu
                id="simple-menu"
                anchorEl={anchorEl}
                keepMounted
                open={Boolean(anchorEl)}
                onClose={handleClose}
              >
                {LANGUAGES.map((item) => (
                  <MenuItem
                    onClick={() => handleChangeLanguage(item.code)}
                    key={item.code}
                    value={item.code}
                  >
                    {item.label}
                  </MenuItem>
                ))}
              </Menu>
              <IconButton size="small" color="inherit" sx={navbarIconButton} variant="contained">
                <Icon color="inherit" sx={iconsStyle}>
                  {darkMode ? 'dark_mode' : 'wb_sunny'}
                </Icon>
                <Switch checked={darkMode} onChange={handleDarkMode} />
              </IconButton>

              {/* <select
                defaultValue={i18n.language}
                onChange={(e) => handleChangeLanguage(e.target.value)}
              >
                {LANGUAGES.map(({ code, label }) => (
                  <option key={code} value={code}>
                    {label}
                  </option>
                ))}
              </select> */}
              {/* <IconButton
                size="small"
                disableRipple
                color="inherit"
                sx={navbarMobileMenu}
                onClick={handleMiniSidenav}
              >
                <Icon sx={iconsStyle} fontSize="medium">
                  {miniSidenav ? "menu_open" : "menu"}
                </Icon>
              </IconButton> */}
              <IconButton
                size="small"
                color="inherit"
                sx={navbarIconButton}
                variant="contained"
                onClick={handleClickAvatar}
              >
                {routes.find((item) => item.type === 'collapse').icon}
              </IconButton>
              <Menu
                id="simple-menu"
                anchorEl={anchorElAvatar}
                keepMounted
                open={Boolean(anchorElAvatar)}
                onClose={handleCloseAvatar}
              >
                {routes
                  .find((item) => item.type === 'collapse')
                  .collapse.map((item) => {
                    if (item?.type === 'logout') {
                      return (
                        <MDButton type="button" onClick={handleLogout}>
                          Logout
                        </MDButton>
                      );
                    }
                    return (
                      <NavLink to={item?.route} key={item.key}>
                        <MenuItem>{item.name}</MenuItem>
                      </NavLink>
                    );
                  })}
              </Menu>
            </MDBox>
          </MDBox>
        )}
      </Toolbar>
      <MDBox
        style={{
          display: 'flex',
          'justify-content': 'space-between',
        }}
      >
        <Breadcrumbs icon="home" title={route[route.length - 1]} route={route} light={light} />
        {isHideFillter && (
          <Grid item textAlign="right">
            <Grid container spacing={!isHideFillter ? 1 : 0}>
              <Grid item xs={4}>
                <TextField
                  type="date"
                  fullWidth
                  label="Start Date"
                  InputLabelProps={{ shrink: true }}
                  onChange={(e) => setStartDateValue(e.target.value)}
                />
              </Grid>
              <Grid item xs={4}>
                <div>
                  <TextField
                    type="date"
                    fullWidth
                    label="End Date"
                    InputLabelProps={{ shrink: true }}
                    onChange={(e) => setEndDateValue(e.target.value)}
                  />
                </div>
              </Grid>

              <Grid item xs={4} alignItems="flex-end" justifyContent="flex-end">
                <MDButton color="info" onClick={handleSave} variant="contained">
                  Export Data
                </MDButton>
              </Grid>
            </Grid>
          </Grid>
        )}
      </MDBox>
    </AppBar>
  );
}

// Setting default values for the props of DashboardNavbar
DashboardNavbar.defaultProps = {
  absolute: false,
  light: false,
  isMini: false,
};

// Typechecking props for the DashboardNavbar
DashboardNavbar.propTypes = {
  absolute: PropTypes.bool,
  light: PropTypes.bool,
  isMini: PropTypes.bool,
};

export default DashboardNavbar;
