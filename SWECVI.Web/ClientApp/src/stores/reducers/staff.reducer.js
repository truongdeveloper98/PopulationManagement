import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  staffs: {
    items: [],
    limit: undefined,
    page: undefined,
    totalItems: undefined,
    totalPages: undefined,
  },
  isLoading: false,
  error: undefined,
  success: undefined,
  departmentSelections: []
};
const staffsSlice = createSlice({
  name: 'staff',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    staffsSuccess: (state, action) => {
      state.isLoading = false;
      state.staffs = action.payload;
    },
    departmentSelectionSuccess: (state, action) => {
      state.isLoading = false;
      state.departmentSelections = action.payload;
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
  requested, failed, succeed, staffsSuccess, reinitialize, staffs,
  departmentSelectionSuccess, departmentSelections
} = staffsSlice.actions;
export default staffsSlice.reducer;
