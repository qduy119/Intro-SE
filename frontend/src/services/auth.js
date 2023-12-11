import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const baseQuery = "https://localhost:7190";

const authApi = createApi({
    reducerPath: "authApi",
    baseQuery: fetchBaseQuery({
        baseUrl: baseQuery,
    }),
    endpoints: (builder) => ({
        login: builder.mutation({
            query: (payload) => ({
                url: "/authenticate",
                method: "POST",
                credentials: "include",
                body: payload,
            }),
        }),
        register: builder.mutation({
            query: (payload) => ({
                url: "/register",
                method: "POST",
                body: payload,
            }),
        }),
        logout: builder.mutation({
            query: () => ({
                url: "/logout",
                method: "GET",
                credentials: "include",
            }),
        }),
    }),
});

export const { useLoginMutation, useRegisterMutation, useLogoutMutation } =
    authApi;
export default authApi;
