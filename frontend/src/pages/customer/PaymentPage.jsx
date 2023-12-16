import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link, useLocation, useNavigate } from "react-router-dom";
import ArrowBackIosNewIcon from "@mui/icons-material/ArrowBackIosNew";
import {
    useGetPaymentQuery,
    useModifyPaymentMutation,
} from "../../services/payment";
import PaymentBox from "../../components/Payment/PaymentBox";
import Toast from "../../components/Toast/Toast";
import { useGetOrderQuery, useModifyOrderMutation } from "../../services/order";
import { toast } from "react-toastify";
import getItemsInOrder from "../../features/order/getItemsInOrder";

export default function PaymentPage() {
    const location = useLocation();
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const user = useSelector((state) => state.auth.user);
    const { orderId } = location.state.payload;
    const { data: payment } = useGetPaymentQuery({ orderId });
    const { data: order } = useGetOrderQuery({ orderId });
    const [modifyPayment, { isSuccess: modifyPaymentSuccess }] =
        useModifyPaymentMutation();
    const [modifyOrder, { isSuccess: modifyOrderSuccess }] =
        useModifyOrderMutation();

    function handlePay() {
        modifyPayment({
            ...payment.data[0],
            status: "Success",
            paymentDate: new Date(),
        });
        modifyOrder({ ...order, status: "Success" });
    }
    function handlePayLater() {
        navigate("/");
    }

    useEffect(() => {
        if (modifyOrderSuccess && modifyPaymentSuccess) {
            dispatch(getItemsInOrder({ userId: user.id }));
            toast.success("Pay successfully !", {
                position: toast.POSITION.BOTTOM_RIGHT,
            });
            setTimeout(() => {
                navigate("/order");
            }, 2000);
        }
    }, [
        modifyOrderSuccess,
        modifyPaymentSuccess,
        navigate,
        dispatch,
        user?.id,
    ]);

    return (
        <div className="min-h-[600px] px-5 py-8">
            <Link to="/" className="hover:underline text-primary">
                <ArrowBackIosNewIcon />
                BACK TO HOME PAGE
            </Link>
            <PaymentBox
                method={payment?.data[0]?.paymentMethod}
                amount={payment?.data[0]?.amount}
                onPay={handlePay}
                onPayLater={handlePayLater}
            />
            <Toast />
        </div>
    );
}
