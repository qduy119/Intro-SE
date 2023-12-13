import { createSlice } from "@reduxjs/toolkit";
import logout from "./logout";

const initialState = {
    user: null,
    accessToken: null,
};

const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        loginSuccess: (state, action) => {
            state.user = action.payload.user;
            state.accessToken = action.payload.accessToken;
        },
        updateAccessToken: (state, action) => {
            state.accessToken = action.payload.newAccessToken;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(logout.fulfilled, (state) => {
                state.user = null;
                state.accessToken = null;
            })
    },
});

const { reducer, actions } = authSlice;

export const { loginSuccess, updateAccessToken } = actions;
export default reducer;
