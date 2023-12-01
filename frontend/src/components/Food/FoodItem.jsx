import { Link } from "react-router-dom";

export default function FoodItem({ food }) {
    return (
        <div className="flex flex-col justify-between rounded-md hover:-translate-y-3 transition-all duration-500 border-2 overflow-hidden shadow-slate-300 shadow-md">
            <div>
                <Link to={`/food/${food.id}`}>
                    <img
                        src={food.thumbnail}
                        alt="Thumbnail"
                        className="w-auto"
                    />
                </Link>
                <div className="px-4 py-3 ">
                    <Link to={`/food/${food.id}`}><p className="font-semibold text-xl text-end">{food.name}</p></Link>
                    <p className="text-end mt-2 text-primary font-bold">
                        <span className="text-red-600 font-semibold line-through mr-4">
                            {food.discount}%
                        </span>
                        {food.price}$
                    </p>
                    <p className="text-end mt-2 font-semibold">Stock: {food.stock}</p>
                </div>
            </div>
            <div className="px-4 py-3 ">

                <div className="flex items-center justify-center gap-x-2 flex-wrap">
                    <button className="py-2 px-4 rounded-[4px] mt-2 bg-primary-light hover:bg-primary transition text-white uppercase font-semibold text-md">BUY</button>
                    <button className="py-2 px-4 rounded-[4px] mt-2 bg-primary-light hover:bg-primary transition text-white uppercase font-semibold text-md">ADD TO CART</button>
                </div>
            </div>
        </div>
    );
}
