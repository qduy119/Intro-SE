import axios from "axios";

export default async function getCategoryById({ params, request }) {
    const { id } = params;
    const res = await axios.get(`/api/Categories/${id}`, {
        signal: request.signal,
    });
    if (res.status !== 200) {
        throw new Error("Fetching category failed");
    }
    const { products } = res.data;
    return products ?? [];
}