import { createApi } from "@reduxjs/toolkit/query/react";
import { axiosBaseQuery } from "../api/axiosBaseQuery";

const baseQuery = "https://localhost:7190";

const privateAuthApi = createApi({
    reducerPath: "privateAuthApi",
    baseQuery: axiosBaseQuery({
        baseUrl: baseQuery,
    }),
    endpoints: (builder) => ({
        logout: builder.mutation({
            query: () => ({
                url: "/logout",
                method: "GET",
                options: {
                    withCredentials: true,
                },
            }),
        }),
    }),
});

export const { useLogoutMutation } = privateAuthApi;
export default privateAuthApi;
