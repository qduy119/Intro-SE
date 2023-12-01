import CategoryItem from "./CategoryItem";
import { categories } from "../../constants";

export default function CategoryList() {
    return (
        <div className="mb-10">
            <div>
                <h1 className="font-semibold text-3xl mb-2">Category</h1>
                <div className="w-[8rem] h-[4px] rounded-md bg-primary-light mb-4" />
            </div>
            <ul className="flex flex-wrap gap-x-12 gap-y-5">
                {categories.map((category, index) => (
                    <CategoryItem key={index} category={category} />
                ))}
            </ul>
        </div>
    );
}
