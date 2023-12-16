import { createApi } from "@reduxjs/toolkit/query/react";
import { axiosBaseQuery } from "../api/axiosBaseQuery";

const baseQuery = "https://localhost:7190";

const paymentApi = createApi({
    reducerPath: "paymentApi",
    baseQuery: axiosBaseQuery({
        baseUrl: baseQuery,
    }),
    endpoints: (builder) => ({
        getPayment: builder.query({
            query: ({ orderId }) => ({
                url: `/api/Payment?orderId=${orderId}`,
                method: "GET",
            }),
        }),
        addPayment: builder.mutation({
            query: (payload) => ({
                url: "/api/Payment",
                method: "POST",
                body: payload,
            }),
        }),
        modifyPayment: builder.mutation({
            query: (payload) => ({
                url: "/api/Payment",
                method: "PUT",
                body: payload,
            }),
        }),
    }),
});

export const {
    useGetPaymentQuery,
    useAddPaymentMutation,
    useModifyPaymentMutation,
} = paymentApi;

export default paymentApi;
