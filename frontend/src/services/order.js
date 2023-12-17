import { createApi } from "@reduxjs/toolkit/query/react";
import { axiosBaseQuery } from "../api/axiosBaseQuery";

const baseQuery = "https://localhost:7190";

const orderApi = createApi({
    reducerPath: "orderApi",
    baseQuery: axiosBaseQuery({
        baseUrl: baseQuery,
    }),
    endpoints: (builder) => ({
        getOrder: builder.query({
            query: (payload) => ({
                url: `/api/Order/${payload.orderId}`,
                method: "GET",
            }),
        }),
        getAllOrder: builder.query({
            query: (payload) => ({
                url: `/api/Order?userId=${payload.userId}&page=${payload.page}&per_page=${payload.per_page}`,
                method: "GET",
            }),
        }),
        addOrder: builder.mutation({
            query: (payload) => ({
                url: "/api/Order",
                method: "POST",
                body: payload,
            }),
        }),
        modifyOrder: builder.mutation({
            query: (payload) => ({
                url: "/api/Order",
                method: "PUT",
                body: payload,
            }),
        }),
        deleteOrder: builder.mutation({
            query: (payload) => ({
                url: `/api/Order/${payload.id}`,
                method: "DELETE",
            }),
        }),
    }),
});

export const {
    useGetOrderQuery,
    useLazyGetAllOrderQuery,
    useAddOrderMutation,
    useModifyOrderMutation,
    useDeleteOrderMutation,
} = orderApi;

export default orderApi;
