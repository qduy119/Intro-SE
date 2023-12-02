import { useParams } from "react-router-dom";
import axios from "axios";
import { categories } from "../../constants";

export default function CategoryPage() {
    const { id } = useParams();
    const category = categories.find((category) => category.id === +id) ?? [];

    return (
        <div className="px-4 py-8 min-h-[600px]">
            <div className="flex gap-5 items-center">
                <img
                    src={category.thumbnail}
                    alt="Category"
                    width="150"
                    height="150"
                    className="rounded-md"
                />
                <p>{category.description}</p>
            </div>
            <div className="mt-10">
                <p>List food of {category.name} category</p>
            </div>
        </div>
    );
}

export async function fetchCategoryById({ params, request }) {
    const { id } = params;
    const res = await axios.get(`/api/v1/categories/${id}`, {
        signal: request.signal,
    });
    if (res.status !== 200) {
        throw new Error("Fetching products by category failed");
    }
    const { products } = res.data;
    return products ?? [];
}
