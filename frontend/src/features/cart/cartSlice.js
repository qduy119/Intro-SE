import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    cart: null,
};

const cartSlice = createSlice({
    name: "cart",
    initialState,
    reducers: {},
    // extraReducers: (builder) => {
    //     builder.addCase();
    // },
});

const { reducer, actions } = cartSlice;

export default reducer;
