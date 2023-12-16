import { createAsyncThunk } from "@reduxjs/toolkit";
import createAxiosInstance from "../../api/axios";

const getItemsInOrder = createAsyncThunk(
    "order/getItems",
    async (payload, thunkAPI) => {
        try {
            const { userId } = payload;
            const privateAxios = createAxiosInstance();
            const res = await privateAxios.get(
                `/api/Order?userId=${userId}`,
                {
                    signal: thunkAPI.signal,
                }
            );
            return res.data;
        } catch (error) {
            const { data } = error.response;
            throw new Error(data);
        }
    }
);

export default getItemsInOrder;
