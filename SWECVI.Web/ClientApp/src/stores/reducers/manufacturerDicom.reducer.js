import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  manufacturerDicom: {
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

const manufacturerDicomSlice = createSlice({
  name: 'manufacturerDicom',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    manufacturerDicomSuccess: (state, action) => {
      state.isLoading = false;
      state.manufacturerDicom = action.payload;
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
  requested, failed, succeed, manufacturerDicomSuccess, reinitialize,
} = manufacturerDicomSlice.actions;
export default manufacturerDicomSlice.reducer;
