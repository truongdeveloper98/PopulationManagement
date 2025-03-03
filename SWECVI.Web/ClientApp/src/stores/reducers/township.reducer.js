import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  townships: {
    items: [],
    limit: undefined,
    page: undefined,
    totalItems: undefined,
    totalPages: undefined,
  },
  isLoading: false,
  error: undefined,
  success: undefined,
  townshipSelections : []
};

const townshipsSlice = createSlice({
  name: 'township',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    townshipsSuccess: (state, action) => {
      state.isLoading = false;
      state.townships = action.payload;
    },
    townshipSelectionSuccess: (state, action) => {
      state.isLoading = false;
      state.townshipSelections = action.payload;
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
  requested, failed, succeed, townshipsSuccess, reinitialize, townships, townshipSelectionSuccess, townshipSelections
} = townshipsSlice.actions;
export default townshipsSlice.reducer;
