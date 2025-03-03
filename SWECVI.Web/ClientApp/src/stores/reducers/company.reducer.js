import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  companies: {
    items: [],
    limit: undefined,
    page: undefined,
    totalItems: undefined,
    totalPages: undefined,
  },
  isLoading: false,
  error: undefined,
  success: undefined,
};

const companiesSlice = createSlice({
  name: 'company',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    companiesSuccess: (state, action) => {
      state.isLoading = false;
      state.companies = action.payload;
    },
    failed: (state, action) => {
      state.isLoading = false;
      state.error = action.payload;
    },
    succeed: (state, action) => {
      state.isLoading = false;
      state.success = action.payload;
    },
    reinitialize: (state) => {
      state.error = undefined;
      state.success = undefined;
    },
  },
});

export const {
  requested, failed, succeed, companiesSuccess, reinitialize,companies
} = companiesSlice.actions;
export default companiesSlice.reducer;
