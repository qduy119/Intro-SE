import { createSlice } from "@reduxjs/toolkit";
import getItemsInCart from "./getItemsInCart";

const initialState = {
    items: null,
};

const cartSlice = createSlice({
    name: "cart",
    initialState,
    reducers: {
        updateCart: (state, action) => {
            state.items = action.payload;
        },
        resetCart: (state) => {
            state.items = null;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(getItemsInCart.fulfilled, (state, action) => {
                state.items = action.payload.data;
            })
    },
});

const { reducer, actions } = cartSlice;

export const { updateCart, resetCart } = actions;
export default reducer;
