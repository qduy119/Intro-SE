import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link, useNavigate } from "react-router-dom";
import ShoppingBagIcon from "@mui/icons-material/ShoppingBag";
import VisibilityIcon from "@mui/icons-material/Visibility";
import { IconButton, Tooltip } from "@mui/material";
import { useAddCartItemsMutation } from "../../services/cart";
import { useModifyProductMutation } from "../../services/product";
import getItemsInCart from "../../features/cart/getItemsInCart";

export default function FoodItem({ food }) {
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const user = useSelector((state) => state.auth.user);
    const [addToCart, { data, isSuccess }] = useAddCartItemsMutation();
    const [updateProduct] = useModifyProductMutation();

    function handleBuyNow() {
        if (!user) {
            navigate("/login");
        } else {
            addToCart({ quantity: 1, itemId: food.id, userId: user.id });
            updateProduct({ ...food, stock: food.stock - 1 });
        }
    }
    
    useEffect(() => {
        if (isSuccess) {
            dispatch(getItemsInCart({ userId: user.id }));
            navigate("/checkout", {
                state: { items: [{ ...data, item: food }] },
            });
        }
    }, [isSuccess, dispatch, navigate, data, food, user?.id]);

    return (
        <>
            <div className="rounded-md hover:-translate-y-2 transition-all duration-500 border-2 overflow-hidden shadow-md">
                <div>
                    <Link to={`/food/${food.id}`}>
                        <img
                            src={food.thumbnail}
                            alt="Thumbnail"
                            className="w-auto"
                        />
                    </Link>
                    <div className="px-4 py-3 ">
                        <p className="font-semibold text-xl text-center">
                            {food.name}
                        </p>
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
                <div className="p-2 sm:p-4">
                    <div className="flex items-center justify-center gap-x-2 flex-wrap">
                        <span>
                            <Tooltip title="View detail">
                                <IconButton>
                                    <Link to={`/food/${food.id}`}>
                                        <VisibilityIcon className="hover:text-primary transition-all" />
                                    </Link>
                                </IconButton>
                            </Tooltip>
                        </span>
                        <span>
                            <Tooltip title="Buy now">
                                <IconButton onClick={() => handleBuyNow()}>
                                    <ShoppingBagIcon className="hover:text-primary transition-all" />
                                </IconButton>
                            </Tooltip>
                        </span>
                    </div>
                </div>
            </div>
        </>
    );
}
