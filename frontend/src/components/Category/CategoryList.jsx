import CategoryItem from "./CategoryItem";
import { categories } from "../../constants";

export default function CategoryList() {
    return (
        <div className="mb-10">
            <h1 className="font-semibold text-3xl mb-4">Category</h1>
            <ul className="flex flex-wrap gap-x-12 gap-y-5">
                {categories.map((category, index) => (
                    <CategoryItem key={index} category={category} />
                ))}
            </ul>
        </div>
    );
}
