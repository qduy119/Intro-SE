import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    items: null,
};

const orderSlice = createSlice({
    name: "order",
    initialState,
    reducers: {},
    // extraReducers: (builder) => {
    //     builder.addCase();
    // },
});

const { reducer, actions } = orderSlice;

export default reducer;
