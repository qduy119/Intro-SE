import { createApi } from "@reduxjs/toolkit/query/react";
import { axiosBaseQuery } from "../api/axiosBaseQuery";

const baseQuery = "https://localhost:7190";

const seatApi = createApi({
    reducerPath: "seatApi",
    baseQuery: axiosBaseQuery({
        baseUrl: baseQuery,
    }),
    endpoints: (builder) => ({
        getSeatReservation: builder.mutation({
            query: () => ({
                url: "/api/SeatReservation",
                method: "GET",
            }),
        }),
        addSeatReservation: builder.mutation({
            query: (payload) => ({
                url: "/api/SeatReservation",
                method: "POST",
                body: payload,
            }),
        }),
    }),
});

export const { useGetSeatReservationMutation, useAddReviewsMutation } =
    seatApi;

export default seatApi;
