/**
=========================================================
* Otis Admin PRO - v2.0.1
=========================================================

* Product Page: https://material-ui.com/store/items/otis-admin-pro-material-dashboard-react/
* Copyright 2022 Creative Tim (https://www.creative-tim.com)

Coded by www.creative-tim.com

 =========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
*/

// Otis Admin PRO React helper functions
import pxToRem from 'assets/theme-dark/functions/pxToRem';

// Otis Admin PRO React base styles
import colors from 'assets/theme-dark/base/colors';
import boxShadows from 'assets/theme-dark/base/boxShadows';
import borders from 'assets/theme-dark/base/borders';

const { transparent } = colors;
const { md } = boxShadows;
const { borderRadius } = borders;

export default {
  styleOverrides: {
    paper: {
      backgroundColor: transparent.main,
      boxShadow: md,
      padding: pxToRem(8),
      borderRadius: borderRadius.md,
    },
  },
};
