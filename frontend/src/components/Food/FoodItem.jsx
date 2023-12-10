import { Link } from "react-router-dom";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import ShoppingBagOutlinedIcon from "@mui/icons-material/ShoppingBagOutlined";

export default function FoodItem({ food }) {
    return (
        <div className="rounded-md hover:-translate-y-3 transition-all duration-500 border-2 overflow-hidden shadow-md">
            <div>
                <Link to={`/food/${food.id}`}>
                    <img
                        src={food.thumbnail}
                        alt="Thumbnail"
                        className="w-auto"
                    />
                </Link>
                <div className="px-4 py-3 ">
                    <Link to={`/food/${food.id}`}>
                        <p className="font-semibold text-xl text-center">
                            {food.name}
                        </p>
                    </Link>
                    <p className="text-center mt-2 text-primary font-bold">
                        <span className="text-red-600 font-semibold line-through mr-4">
                            {food.discount}%
                        </span>
                        {food.price}$
                    </p>
                    <p className="text-center mt-2 font-semibold">
                        Stock: {food.stock}
                    </p>
                </div>
            </div>
            <div className="px-4 py-3 ">
                <div className="flex items-center justify-center gap-x-2 flex-wrap">
                    <button className="py-2 px-4 rounded-[4px] mt-2 border-2 border-primary-light text-primary uppercase font-semibold text-md">
                        BUY{" "}
                        <span>
                            <ShoppingBagOutlinedIcon />
                        </span>
                    </button>
                    <button className="py-2 px-4 rounded-[4px] mt-2 border-2 border-primary-light text-primary uppercase font-semibold text-md">
                        ADD TO CART{" "}
                        <span>
                            <AddShoppingCartIcon />
                        </span>
                    </button>
                </div>
            </div>
        </div>
    );
}
