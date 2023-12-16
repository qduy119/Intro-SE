import { createSlice } from "@reduxjs/toolkit";
import getItemsInOrder from "./getItemsInOrder";

const initialState = {
    items: null,
};

const orderSlice = createSlice({
    name: "order",
    initialState,
    reducers: {
        resetOrder: (state) => {
            state.items = null;
        },
    },
    extraReducers: (builder) => {
        builder.addCase(getItemsInOrder.fulfilled, (state, action) => {
            state.items = action.payload.data;
        });
    },
});

const { reducer, actions } = orderSlice;

export const { resetOrder } = actions;
export default reducer;
