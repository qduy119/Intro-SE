import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import ArrowBackIosNewIcon from "@mui/icons-material/ArrowBackIosNew";
import PersonIcon from "@mui/icons-material/Person";
import OrderItem from "../../components/Order/OrderItem";
import { useDeleteSeatReservationMutation } from "../../services/seat";
import { useModifyOrderMutation } from "../../services/order";
import { useModifyPaymentMutation } from "../../services/payment";
import getItemsInOrder from "../../features/order/getItemsInOrder";
import Toast from "../../components/Toast/Toast";

export default function OrderPage() {
    const order = useSelector((state) => state.order.items);
    const dispatch = useDispatch();
    const user = useSelector((state) => state.auth.user);
    const [cancelOrder, { isSuccess: cancelOrderSuccess }] =
        useModifyOrderMutation();
    const [cancelPayment, { isSuccess: cancelPaymentSuccess }] =
        useModifyPaymentMutation();
    const [updateOrder, { isSuccess: updateOrderSuccess }] =
        useModifyOrderMutation();
    const [updatePayment, { isSuccess: updatePaymentSuccess }] =
        useModifyPaymentMutation();
    const [returnSeat, { isSuccess: returnSeatSuccess }] =
        useDeleteSeatReservationMutation();

    function handleReturnTable(seatNumber) {
        returnSeat({ seatNumber });
    }
    function handleCancelOrder({ order, payment }) {
        cancelOrder({ ...order, status: "Canceled" });
        cancelPayment({ ...payment, status: "Canceled" });
    }
    function handlePayOrder({ order, payment }) {
        updateOrder({ ...order, status: "Success" });
        updatePayment({
            ...payment,
            status: "Success",
            paymentDate: new Date(),
        });
    }

    useEffect(() => {
        if (returnSeatSuccess) {
            toast.success("Return table successfully !", {
                position: toast.POSITION.BOTTOM_RIGHT,
            });
            dispatch(getItemsInOrder({ userId: user.id }));
        }
    }, [returnSeatSuccess, dispatch, user?.id]);
    useEffect(() => {
        if (cancelOrderSuccess && cancelPaymentSuccess) {
            toast.success("Cancel order successfully !", {
                position: toast.POSITION.BOTTOM_RIGHT,
            });
            dispatch(getItemsInOrder({ userId: user.id }));
        }
    }, [cancelOrderSuccess, cancelPaymentSuccess, dispatch, user?.id]);
    useEffect(() => {
        if (updateOrderSuccess && updatePaymentSuccess) {
            toast.success("Pay order successfully !", {
                position: toast.POSITION.BOTTOM_RIGHT,
            });
            dispatch(getItemsInOrder({ userId: user.id }));
        }
    }, [updateOrderSuccess, updatePaymentSuccess, dispatch, user?.id]);

    return (
        <div className="min-h-[600px] px-5 py-8">
            <Link to="/" className="hover:underline text-primary">
                <ArrowBackIosNewIcon />
                BACK TO HOME PAGE
            </Link>
            <div className="rounded-lg mt-4 min-h-[500px]">
                <div className="flex items-center px-3 py-2 gap-1">
                    <PersonIcon />
                    MY ORDER
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
                                    Order ID
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Order Date
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Payment Method
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Total Price
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Seat Number
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Status
                                </th>
                                <th scope="col" className="px-6 py-4">
                                    Action
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            {order.map((item, index) => (
                                <OrderItem
                                    key={index}
                                    item={item}
                                    onReturnTable={handleReturnTable}
                                    onCancelOrder={handleCancelOrder}
                                    onPayOrder={handlePayOrder}
                                    t={index + 1}
                                />
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
            <Toast />
        </div>
    );
}
