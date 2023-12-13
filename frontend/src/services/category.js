import { createApi } from "@reduxjs/toolkit/query/react";
import { axiosBaseQuery } from "../api/axiosBaseQuery";

const baseQuery = "https://localhost:7190";

const categoryApi = createApi({
    reducerPath: "categoryApi",
    baseQuery: axiosBaseQuery({
        baseUrl: baseQuery,
    }),
    endpoints: (builder) => ({
        addCategory: builder.mutation({
            query: (payload) => ({
                url: "api/Categories",
                method: "POST",
                body: payload,
            }),
        }),
        modifyCategory: builder.mutation({
            query: (payload) => ({
                url: `api/Categories/${payload.id}`,
                method: "PUT",
                body: payload,
            }),
        }),
        deleteCategory: builder.mutation({
            query: ({ id }) => ({
                url: `api/Categories/${id}`,
                method: "DELETE",
            }),
        }),
    }),
});

export const {
    useAddCategoryMutation,
    useModifyCategoryMutation,
    useDeleteCategoryMutation,
} = categoryApi;

export default categoryApi;
