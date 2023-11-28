import { Link } from "react-router-dom";

export default function FoodItem({ food }) {
    return (
        <div className="rounded-md hover:-translate-y-3 transition-all duration-500 border-2 overflow-hidden shadow-slate-300 shadow-md">
            <div>
                <Link to={`/food/${food.id}`}>
                    <img
                        src={food.thumbnail}
                        alt="Thumbnail"
                        className="w-auto"
                    />
                </Link>
            </div>
            <div className="px-4 py-3">
                <p className="font-semibold text-xl text-end">{food.name}</p>
                <p className="text-end mt-2 text-primary font-bold">
                    <span className="text-red-600 font-semibold line-through mr-4">
                        {food.discount}%
                    </span>
                    {food.price}$
                </p>
                <p className="text-end mt-2 font-semibold">Stock: {food.stock}</p>
                <button></button>
            </div>
        </div>
    );
}
