import React from 'react';
import App from 'App';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';

import './styles/ag-grid.css';
import './styles/ag-theme-alpine.css';

import { Grid } from 'ag-grid-community';
import 'custom-styles.css';
import AgGridReact, { AgPromise } from 'ag-grid-react';

// ClientApp/src/index.js or ClientApp/src/App.js
import './setLicense';

// Soft UI Context Provider
import { StyledEngineProvider } from '@mui/material/styles';
import { AppProviders } from './AppProviders';
import './i18n';

const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <BrowserRouter>
    <AppProviders>
      <StyledEngineProvider injectFirst>
        <App />
      </StyledEngineProvider>
    </AppProviders>
  </BrowserRouter>,
);
