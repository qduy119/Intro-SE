import { Link, useNavigate } from "react-router-dom";
import ArrowBackIosNewIcon from "@mui/icons-material/ArrowBackIosNew";
import PersonIcon from "@mui/icons-material/Person";
import CloseIcon from "@mui/icons-material/Close";
import AddIcon from "@mui/icons-material/Add";
import RemoveIcon from "@mui/icons-material/Remove";

export default function CartPage() {
    const navigate = useNavigate();
    function handleCart() {
        // Do something
        navigate("/checkout");
    }

    return (
        <div className="w-full px-5 md:px-10 py-5">
            <div className="mx-auto">
                <Link
                    to="/"
                    className="flex items-center px-3 py-4 hover:underline"
                >
                    <ArrowBackIosNewIcon />
                    BACK TO HOME PAGE
                </Link>
                <div className="bg-gray-200 rounded-lg">
                    <div className="flex items-center px-3 py-2">
                        <PersonIcon />
                        USERS MEAL
                    </div>
                    <div className="z-[1000] w-full h-[1px] bg-black/20" />
                    <div className="py-5 px-10">
                        <div className="flex items-start w-full bg-gray-400 mb-4">
                            <div className="relative w-[25%]">
                                <img
                                    src="https://www.themealdb.com/images/media/meals/tytyxu1515363282.jpg"
                                    className="w-full h-auto"
                                    alt=""
                                />
                                <button className="flex justify-center items-center w-[30px] h-[30px] rounded-full outline-none border-none bg-gray-300 opacity-60 hover:opacity-80 absolute top-1 left-1">
                                    <CloseIcon />
                                </button>
                            </div>
                            <div className="flex items-start justify-between px-4 py-2 w-3/4">
                                <h3 className="font-semibold text-lg uppercase">
                                    Jerk chicken with rice & peas
                                </h3>
                                <div className="flex flex-col items-end">
                                    <p>1099$</p>
                                    <div className="flex items-center gap-x-4 mt-1">
                                        <button className="border-none outline-none rounded-md p-1 bg-gray-200 hover:bg-gray-300">
                                            <RemoveIcon />
                                        </button>
                                        <p className="text-lg font-semibold">
                                            1
                                        </p>
                                        <button className="border-none outline-none rounded-md p-1 bg-gray-200 hover:bg-gray-300">
                                            <AddIcon />
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div className="flex items-start w-full bg-gray-400 mb-4">
                            <div className="relative w-[25%]">
                                <img
                                    src="https://www.themealdb.com/images/media/meals/vvpprx1487325699.jpg"
                                    className="w-full h-auto"
                                    alt=""
                                />
                                <button className="flex justify-center items-center w-[30px] h-[30px] rounded-full outline-none border-none bg-gray-300 opacity-60 hover:opacity-80 absolute top-1 left-1">
                                    <CloseIcon />
                                </button>
                            </div>
                            <div className="flex items-start justify-between px-4 py-2 w-3/4">
                                <h3 className="font-semibold text-lg uppercase">
                                    Beef Wellington
                                </h3>
                                <div className="flex flex-col items-end">
                                    <p>1099$</p>
                                    <div className="flex items-center gap-x-4 mt-1">
                                        <button className="border-none outline-none rounded-md p-1 bg-gray-200 hover:bg-gray-300">
                                            <RemoveIcon />
                                        </button>
                                        <p className="text-lg font-semibold">
                                            1
                                        </p>
                                        <button className="border-none outline-none rounded-md p-1 bg-gray-200 hover:bg-gray-300">
                                            <AddIcon />
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <button
                            className="mt-4 uppercase font-bold text-xl text-center py-[10px] bg-primary hover:bg-primary-dark w-full rounded-[4px] text-white transition-all"
                            onClick={handleCart}
                        >
                            CHECK OUT
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
}
