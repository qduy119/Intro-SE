import { createAsyncThunk } from "@reduxjs/toolkit";
import createAxiosInstance from "../../api/axios";

const logout = createAsyncThunk("auth/logout", async (_, thunkAPI) => {
    try {
        const privateAxios = createAxiosInstance();
        const res = await privateAxios.get("/logout", {
            signal: thunkAPI.signal,
            withCredentials: true,
        });
        return res.data;
    } catch (error) {
        const { data } = error.response;
        throw new Error(data);
    }
});

export default logout;
