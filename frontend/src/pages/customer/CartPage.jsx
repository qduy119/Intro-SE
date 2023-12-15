import { Link, useNavigate } from "react-router-dom";
import ArrowBackIosNewIcon from "@mui/icons-material/ArrowBackIosNew";
import PersonIcon from "@mui/icons-material/Person";
import { useDispatch, useSelector } from "react-redux";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { useDeleteCartItemsMutation } from "../../services/cart";
import { useModifyProductMutation } from "../../services/product";
import getItemsInCart from "../../features/cart/getItemsInCart";
import CartItem from "../../components/Cart/CartItem";
import Toast from "../../components/Toast/Toast";
import { formatPrice } from "../../utils";

export default function CartPage() {
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const user = useSelector((state) => state.auth.user);
    const cartItems = useSelector((state) => state.cart.items);
    const [deleteCartItem, { isSuccess }] = useDeleteCartItemsMutation();
    const [updateItem] = useModifyProductMutation();
    const [select, setSelect] = useState(() => {
        return cartItems?.reduce((result, item) => {
            result[item.id] = false;
            return result;
        }, {});
    });
    const getData = {
        count: Object.values(select)?.reduce((count, item) => {
            if (item) {
                count++;
            }
            return count;
        }, 0),
        total: cartItems?.reduce((total, item) => {
            if (select[item.id]) {
                total += item.quantity * item.item.price;
            }
            return total;
        }, 0),
    };

    function handleSelect(e) {
        setSelect((prev) => {
            const temp = { ...prev };
            temp[e.target.value] = !temp[e.target.value];
            return temp;
        });
    }
    function handleDeleteCartItem(cart) {
        const { item, ...cartItem } = cart;
        setSelect((prev) => {
            const temp = { ...prev };
            delete temp[cartItem.id];
            return temp;
        });
        deleteCartItem({ id: cartItem.id });
        updateItem({ ...item, stock: item.stock + cartItem.quantity });
    }
    function handleCheckout() {
        const items = cartItems.reduce((result, item) => {
            if (select[item.id]) {
                result.push(item);
            }
            return result;
        }, []);
        navigate("/checkout", { state: { items } });
    }

    useEffect(() => {
        if (isSuccess) {
            dispatch(getItemsInCart({ userId: user.id }));
            toast.success("Delete successfully !", {
                position: toast.POSITION.BOTTOM_RIGHT,
            });
        }
    }, [isSuccess, dispatch, user]);

    return (
        <div className="w-full p-5 md:p-10">
            <Link to="/" className="px-3 py-4 hover:underline text-primary">
                <ArrowBackIosNewIcon />
                BACK TO HOME PAGE
            </Link>
            <div className="rounded-lg mt-4 min-h-[500px]">
                <div className="flex items-center px-3 py-2">
                    <PersonIcon />
                    USERS MEAL
                </div>
                <div className="z-[1000] w-full h-[1px] bg-black/20" />
                <div className="p-5 overflow-x-scroll">
                    <table className="min-w-full text-center table-auto">
                        <thead className="border-b font-medium dark:border-neutral-500">
                            <tr>
                                <th scope="col" className="px-6 py-4">
                                    #
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Name
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Thumbnail
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Quantity
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Price
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Action
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {cartItems.map((item, index) => (
                                <CartItem
                                    isChecked={select[item.id]}
                                    key={index}
                                    cart={item}
                                    onSetSelect={handleSelect}
                                    onDeleteCartItem={handleDeleteCartItem}
                                />
                            ))}
                        </tbody>
                    </table>
                </div>
                <div className="mt-2 flex justify-between px-5">
                    <div>
                        <p>
                            Select:{" "}
                            <span className="font-semibold">
                                {getData.count}
                            </span>
                        </p>
                        <p>
                            Total:{" "}
                            <span className="font-semibold">
                                {formatPrice(getData.total)}
                            </span>{" "}
                            $
                        </p>
                    </div>
                    <button
                        type="button"
                        onClick={() => handleCheckout()}
                        className="text-white text-lg bg-primary-light hover:bg-primary-light/90 transition font-semibold rounded-md px-4 py-2"
                    >
                        CHECKOUT
                    </button>
                </div>
            </div>
            <Toast />
        </div>
    );
}
