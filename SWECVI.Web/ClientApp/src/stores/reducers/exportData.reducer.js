import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  export: {
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

const exportSlice = createSlice({
  name: 'export',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    exportDataSuccess: (state, action) => {
      state.isLoading = false;
      state.export = action.payload;
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
  requested, failed, succeed, exportDataSuccess, reinitialize,
} = exportSlice.actions;
export default exportSlice.reducer;
