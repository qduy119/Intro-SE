import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    user: null,
    accessToken: null,
};

const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        updateAccessToken: (state, action) => {
            state.accessToken = action.payload;
            localStorage.setItem("accessToken", state.accessToken);
        },
    },
    extraReducers: (builder) => {
        builder.addCase();
    },
});

const { reducer, actions } = authSlice;

export const { updateAccessToken } = actions;

export default reducer;
