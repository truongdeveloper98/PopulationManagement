import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  projectInformations: {
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

const projectInformationsSlice = createSlice({
  name: 'projectInformation',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    projectInformationsSuccess: (state, action) => {
      state.isLoading = false;
      state.projectInformations = action.payload;
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
  requested, failed, succeed, projectInformationsSuccess, reinitialize,projectInformations
} = projectInformationsSlice.actions;
export default projectInformationsSlice.reducer;
