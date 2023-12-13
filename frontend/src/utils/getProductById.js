import axios from "axios";

export default async function getProductById({ params, request }) {
    const { id } = params;
    const res = await axios.get(`/api/Items/${id}`, {
        signal: request.signal,
    });
    if (res.status !== 200) {
        throw new Error("Fetching product failed");
    }
    const { product } = res.data;
    return product ?? [];
}
