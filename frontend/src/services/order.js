import { createApi } from "@reduxjs/toolkit/query/react";
import { axiosBaseQuery } from "../api/axiosBaseQuery";

const baseQuery = "https://localhost:7190";

const orderApi = createApi({
    reducerPath: "orderApi",
    baseQuery: axiosBaseQuery({
        baseUrl: baseQuery,
    }),
    endpoints: (builder) => ({
        addOrder: builder.mutation({
            query: (payload) => ({
                url: "/api/Order",
                method: "POST",
                body: payload,
            }),
        }),
    }),
});

export const { useAddOrderMutation } = orderApi;

export default orderApi;
