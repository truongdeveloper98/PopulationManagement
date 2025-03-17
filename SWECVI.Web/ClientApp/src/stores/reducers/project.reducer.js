import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  projects: {
    items: [],
    limit: undefined,
    page: undefined,
    totalItems: undefined,
    totalPages: undefined,
  },
  isLoading: false,
  error: undefined,
  success: undefined,
  projectSelections : []
};

const projectsSlice = createSlice({
  name: 'project',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    projectsSuccess: (state, action) => {
      state.isLoading = false;
      state.projects = action.payload;
    },
    projectSelectionSuccess: (state, action) => {
      state.isLoading = false;
      state.projectSelections = action.payload;
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
  requested, failed, succeed, projectsSuccess, reinitialize, projects, projectSelectionSuccess, projectSelections
} = projectsSlice.actions;
export default projectsSlice.reducer;
