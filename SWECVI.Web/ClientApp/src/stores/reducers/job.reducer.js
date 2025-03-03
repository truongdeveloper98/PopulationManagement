import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  jobs: {
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

const jobsSlice = createSlice({
  name: 'job',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    jobsSuccess: (state, action) => {
      state.isLoading = false;
      state.jobs = action.payload;
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
  requested, failed, succeed, jobsSuccess, reinitialize,jobs
} = jobsSlice.actions;
export default jobsSlice.reducer;
