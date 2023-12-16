import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import AddIcon from "@mui/icons-material/Add";
import RemoveIcon from "@mui/icons-material/Remove";
import DeleteIcon from "@mui/icons-material/Delete";
import { IconButton } from "@mui/material";
import { useModifyProductMutation } from "../../services/product";
import { useModifyCartItemsMutation } from "../../services/cart";
import getItemsInCart from "../../features/cart/getItemsInCart";
import { formatPrice } from "../../utils";

export default function CartItem({
    isChecked,
    cart,
    onSetSelect,
    onDeleteCartItem,
}) {
    const dispatch = useDispatch();
    const user = useSelector((state) => state.auth.user);
    const [updateItem] = useModifyProductMutation();
    const [updateCartItem, { isSuccess }] = useModifyCartItemsMutation();

    function handleModify(type = -1) {
        const { item, ...cartItem } = cart;
        if (type === -1) {
            if (cartItem.quantity > 1) {
                updateCartItem({
                    ...cartItem,
                    quantity: cartItem.quantity - 1,
                });
                updateItem({ ...item, stock: item.stock + 1 });
            }
        } else {
            if (item.stock >= 1) {
                updateCartItem({
                    ...cartItem,
                    quantity: cartItem.quantity + 1,
                });
                updateItem({ ...item, stock: item.stock - 1 });
            }
        }
    }

    useEffect(() => {
        if (isSuccess) {
            dispatch(getItemsInCart({ userId: user.id }));
        }
    }, [isSuccess, dispatch, user.id]);

    return (
        <tr className="border-b border-primary-dark">
            <td className="whitespace-nowrap px-6 py-4 font-medium">
                <label htmlFor="check" className="hidden"></label>
                <input
                    type="checkbox"
                    name="check"
                    id="check"
                    checked={isChecked}
                    value={cart.id}
                    onChange={(e) => onSetSelect(e)}
                />
            </td>
            <td className="whitespace-nowrap px-6 py-4 flex justify-center">
                <div
                    className="w-[50px] h-[50px] bg-center bg-cover rounded-md"
                    style={{
                        backgroundImage: `url(${cart.item.thumbnail})`,
                    }}
                />
            </td>
            <td className="whitespace-nowrap px-6 py-4">{cart.item.name}</td>
            <td className="whitespace-nowrap px-6 py-4">
                <IconButton onClick={() => handleModify()}>
                    <RemoveIcon />
                </IconButton>
                <label htmlFor="quantity" className="hidden"></label>
                <input
                    type="number"
                    id="quantity"
                    name="quantity"
                    min={1}
                    max={cart.item.stock}
                    value={cart.quantity}
                    className="border border-gray-200 text-center w-[50px] rounded-sm"
                    disabled
                />
                <IconButton onClick={() => handleModify(1)}>
                    <AddIcon />
                </IconButton>
            </td>
            <td className="whitespace-nowrap px-6 py-4">
                {formatPrice(cart.item.price * cart.quantity)} $
            </td>
            <td className="whitespace-nowrap px-6 py-4">
                <IconButton onClick={() => onDeleteCartItem(cart)}>
                    <DeleteIcon />
                </IconButton>
            </td>
        </tr>
    );
}
