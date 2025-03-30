import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  peopleOfApartments: {
    items: [],
    limit: undefined,
    page: undefined,
    totalItems: undefined,
    totalPages: undefined,
  },
  isLoading: false,
  error: undefined,
  success: undefined,
  peopleOfApartmentSelections : []
};

const peopleOfApartmentsSlice = createSlice({
  name: 'peopleOfApartment',
  initialState,
  reducers: {
    // request
    requested: (state) => {
      state.isLoading = true;
      state.error = undefined;
    },
    peopleOfApartmentsSuccess: (state, action) => {
      state.isLoading = false;
      state.peopleOfApartments = action.payload;
    },
    // peopleOfApartmentSelectionSuccess: (state, action) => {
    //   state.isLoading = false;
    //   state.peopleOfApartmentSelections = action.payload;
    // },
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
  requested, failed, succeed, peopleOfApartmentsSuccess, reinitialize, peopleOfApartments, peopleOfApartmentSelections
} = peopleOfApartmentsSlice.actions;
export default peopleOfApartmentsSlice.reducer;
