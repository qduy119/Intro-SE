import { createApi } from "@reduxjs/toolkit/query/react";
import { axiosBaseQuery } from "../api/axiosBaseQuery";

const baseQuery = "https://localhost:7190";

const paymentApi = createApi({
    reducerPath: "paymentApi",
    baseQuery: axiosBaseQuery({
        baseUrl: baseQuery,
    }),
    endpoints: (builder) => ({
        getPayments: builder.mutation({
            query: () => ({
                url: "api/Payment",
                method: "GET",
            }),
        }),
        addPayment: builder.mutation({
            query: (payload) => ({
                url: "api/Payment",
                method: "POST",
                body: payload,
            }),
        }),
    }),
});

export const { useGetSeatReservationMutation, useAddReviewsMutation } =
    paymentApi;

export default paymentApi;
