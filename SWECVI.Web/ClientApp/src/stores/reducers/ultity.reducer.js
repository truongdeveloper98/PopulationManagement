import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  ultitys: {
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

const ultitysSlice = createSlice({
  name: 'ultity',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    ultitysSuccess: (state, action) => {
      state.isLoading = false;
      state.ultitys = action.payload;
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
  requested, failed, succeed, ultitysSuccess, reinitialize, ultitys
} = ultitysSlice.actions;
export default ultitysSlice.reducer;
