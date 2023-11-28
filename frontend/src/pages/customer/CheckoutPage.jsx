import { Link, useNavigate } from "react-router-dom";
import ArrowBackIosNewIcon from "@mui/icons-material/ArrowBackIosNew";
import PaymentsIcon from "@mui/icons-material/Payments";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import CheckCircleOutlineIcon from "@mui/icons-material/CheckCircleOutline";
import AddCircleIcon from "@mui/icons-material/AddCircle";
import CheckCircleIcon from "@mui/icons-material/CheckCircle";
import WalletIcon from "@mui/icons-material/Wallet";
import CreditCardIcon from "@mui/icons-material/CreditCard";

export default function CheckoutPage() {
    const navigate = useNavigate();
    function handleCheckout() {
        // Do something
        navigate("/payment");
    }

    return (
        <div className="w-full px-10 md:px-20 py-5">
            <div className="mx-auto">
                <Link
                    to="../"
                    className="flex items-center px-3 py-4 hover:underline"
                >
                    <ArrowBackIosNewIcon />
                    BACK TO HOME PAGE
                </Link>
                <div className="bg-gray-200 rounded-lg">
                    <div className="flex items-center px-3 py-2">
                        <PaymentsIcon className="mr-2" />
                        CHECKOUT
                    </div>
                    <div className="z-[1000] w-full h-[1px] bg-black/20" />
                    <div className="py-5 px-10">
                        <div className="mb-3">
                            <h3 className="text-lg font-semibold uppercase">
                                User
                            </h3>
                            <div className="z-[1] cursor-pointer flex items-center justify-between mt-3 bg-gray-400 py-2 px-4 rounded-[4px]">
                                <div className="flex items-center gap-x-2">
                                    <CheckCircleOutlineIcon />
                                    <div>
                                        <h3>Username</h3>
                                        <p>+123456789</p>
                                    </div>
                                </div>
                                <div className="flex items-center gap-x-3">
                                    <EditIcon className="cursor-pointer z-10" />
                                    <DeleteIcon className="cursor-pointer z-10" />
                                </div>
                            </div>
                            <div className="cursor-pointer flex items-center gap-x-2 mt-2 bg-gray-400 py-2 px-4 rounded-[4px]">
                                <AddCircleIcon />
                                <p className="uppercase text-lg">
                                    add other{"'"}s information
                                </p>
                            </div>
                        </div>
                    </div>
                    <div className="z-[1000] w-full h-[1px] bg-black/20" />
                    <div className="mb-3 py-3 px-10">
                        <h3 className="text-lg font-semibold uppercase">
                            Time order
                        </h3>
                    </div>
                    <div className="z-[1000] w-full h-[1px] bg-black/20" />
                    <div className="py-3 px-10">
                        <h3 className="text-lg font-semibold uppercase">
                            PAYMENT METHODS
                        </h3>
                        <div className="cursor-pointer flex items-center gap-x-3 mt-2 bg-gray-400 py-2 px-4 rounded-[4px]">
                            <CheckCircleOutlineIcon />
                            <p className="uppercase text-lg flex items-center gap-x-1">
                                {" "}
                                <WalletIcon /> MOMO WALLET
                            </p>
                        </div>
                        <div className="cursor-pointer flex items-center gap-x-3 mt-2 bg-gray-400 py-2 px-4 rounded-[4px]">
                            <CheckCircleIcon />
                            <p className="uppercase text-lg flex items-center gap-x-1">
                                {" "}
                                <CreditCardIcon /> ATM
                            </p>
                        </div>
                        <button
                            className="mt-10 mb-3 uppercase font-bold text-xl text-center py-[10px] bg-primary hover:bg-primary-dark w-full rounded-[4px] text-white"
                            onClick={handleCheckout}
                        >
                            CHECKOUT
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
}
