import { createContext, useContext, useReducer } from 'react';

// prop-types is a library for typechecking of props
import PropTypes from 'prop-types';

// The Soft UI Dashboard PRO Material main context
const MaterialUI = createContext();

// Setting custom name for the context which is visible on react dev tools
MaterialUI.displayName = 'MaterialUIContext';

// Otis Admin PRO React reducer
function reducer(state, action) {
  switch (action.type) {
    case 'MINI_SIDENAV': {
      return { ...state, miniSidenav: action.value };
    }
    case 'TRANSPARENT_SIDENAV': {
      return { ...state, transparentSidenav: action.value };
    }
    case 'WHITE_SIDENAV': {
      return { ...state, whiteSidenav: action.value };
    }
    case 'SIDENAV_COLOR': {
      return { ...state, sidenavColor: action.value };
    }
    case 'TRANSPARENT_NAVBAR': {
      return { ...state, transparentNavbar: action.value };
    }
    case 'FIXED_NAVBAR': {
      return { ...state, fixedNavbar: action.value };
    }
    case 'OPEN_CONFIGURATOR': {
      return { ...state, openConfigurator: action.value };
    }
    case 'DIRECTION': {
      return { ...state, direction: action.value };
    }
    case 'LAYOUT': {
      return { ...state, layout: action.value };
    }
    case 'DARKMODE': {
      return { ...state, darkMode: action.value };
    }
    case 'LANGUAGE': {
      return { ...state, language: action.value };
    }
    default: {
      throw new Error(`Unhandled action type: ${action.type}`);
    }
  }
}

// Otis Admin PRO React context provider
function MaterialUIControllerProvider({ children }) {
  const initialState = {
    miniSidenav: false,
    transparentSidenav: false,
    whiteSidenav: false,
    sidenavColor: 'info',
    transparentNavbar: true,
    fixedNavbar: true,
    openConfigurator: false,
    direction: 'ltr',
    layout: 'dashboard',
    darkMode: false,
    language: 'en',
  };

  const [controller, dispatch] = useReducer(reducer, initialState);
  const contextValue = [controller, dispatch];

  return <MaterialUI.Provider value={contextValue}>{children}</MaterialUI.Provider>;
}

// Otis Admin PRO React custom hook for using context
function useMaterialUIController() {
  const context = useContext(MaterialUI);

  if (!context) {
    throw new Error(
      'useMaterialUIController should be used inside the MaterialUIControllerProvider.',
    );
  }

  return context;
}

// Typechecking props for the MaterialUIControllerProvider
MaterialUIControllerProvider.propTypes = {
  children: PropTypes.node.isRequired,
};

// Context module functions
const setMiniSidenav = (dispatch, value) => dispatch({ type: 'MINI_SIDENAV', value });
const setTransparentSidenav = (dispatch, value) => dispatch({ type: 'TRANSPARENT_SIDENAV', value });
const setWhiteSidenav = (dispatch, value) => dispatch({ type: 'WHITE_SIDENAV', value });
const setSidenavColor = (dispatch, value) => dispatch({ type: 'SIDENAV_COLOR', value });
const setTransparentNavbar = (dispatch, value) => dispatch({ type: 'TRANSPARENT_NAVBAR', value });
const setFixedNavbar = (dispatch, value) => dispatch({ type: 'FIXED_NAVBAR', value });
const setOpenConfigurator = (dispatch, value) => dispatch({ type: 'OPEN_CONFIGURATOR', value });
const setDirection = (dispatch, value) => dispatch({ type: 'DIRECTION', value });
const setLayout = (dispatch, value) => dispatch({ type: 'LAYOUT', value });
const setDarkMode = (dispatch, value) => dispatch({ type: 'DARKMODE', value });
const setLanguage = (dispatch, value) => dispatch({ type: 'LANGUAGE', value });

export {
  MaterialUIControllerProvider,
  useMaterialUIController,
  setMiniSidenav,
  setTransparentSidenav,
  setWhiteSidenav,
  setSidenavColor,
  setTransparentNavbar,
  setFixedNavbar,
  setOpenConfigurator,
  setDirection,
  setLayout,
  setDarkMode,
  setLanguage,
};
