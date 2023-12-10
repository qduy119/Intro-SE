import { useState } from "react";
import { useNavigate } from "react-router-dom";
import AddIcon from "@mui/icons-material/Add";
import DeleteIcon from "@mui/icons-material/Delete";
import Search from "../../components/Search/Search";
import UserMask from "../../components/User/UserMask";

export default function OrderPage() {
    const [searchString, setSearchString] = useState("");
    const navigate = useNavigate();

    function handleSubmit(e) {
        e.preventDefault();
        if (searchString) {
            navigate(`/search?query=${searchString}`);
        }
    }
    return (
        <>
            <div className="flex pb-2 border-b-2 border-primary-light">
                <div className="flex flex-1 items-center justify-center">
                    <Search
                        search={searchString}
                        onSetSearch={setSearchString}
                        onSubmit={handleSubmit}
                    />
                </div>
                <UserMask
                    imageUrl={
                        "https://res.cloudinary.com/dlzyiprib/image/upload/v1694617729/e-commerces/user/kumz90hy8ufomdgof8ik.jpg"
                    }
                />
            </div>
            <div className="p-5">
                <h1 className="text-3xl font-bold text-gray-700 mb-1">ORDER</h1>
                <div className="bg-primary-light w-[100px] h-[3px] rounded-[4px] mb-5" />
                <button className="mb-10 flex items-center gap-x-2 text-white text-xl font-semibold uppercase rounded-md px-4 py-3 bg-primary transition duration-150 hover:bg-primary-light">
                    add order
                    <AddIcon />
                </button>
                <div className="p-4">
                    <div className="bg-gray-300 rounded-[4px] flex w-full items-center mb-5 justify-between py-2 px-4">
                        <h3 className="font-medium text-xl w-[17%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Avatar
                        </h3>
                        <h3 className="font-medium text-xl w-[15%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Name
                        </h3>
                        <h3 className="font-medium text-xl w-[15%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Order Date
                        </h3>
                        <h3 className="font-medium text-xl w-[15%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Total Price
                        </h3>
                        <h3 className="font-medium text-xl w-[12%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Status
                        </h3>
                        <div className="w-[5%]" />
                    </div>

                    <div className="flex items-center rounded-[4px] justify-between w-full bg-gray-300 p-4 mb-5">
                        <div className="w-[170px] h-[170px] rounded-[4px] bg-gray-500">
                            <img src="" alt="" />
                        </div>
                        <p className="py-2 px-5 rounded-[4px] text-xs font-medium text-center text-white bg-gray-500">
                            DUY CHUT
                        </p>
                        <p className="py-2 px-5 rounded-[4px] text-xs font-medium text-center text-white bg-gray-500">
                            DUY CHUT
                        </p>
                        <p className="py-2 px-5 rounded-[4px] text-xs font-medium text-center text-white bg-gray-500">
                            DUY CHUT
                        </p>
                        <p className="py-2 px-5 rounded-[4px] text-xs font-medium text-center text-white bg-gray-500">
                            DUY CHUT
                        </p>
                        <DeleteIcon className="cursor-pointer w-4 h-4 text-xl" />
                    </div>

                    <div className="flex items-center rounded-[4px] justify-between w-full bg-gray-300 p-4 mb-5">
                        <div className="w-[170px] h-[170px] rounded-[4px] bg-gray-500">
                            <img src="" alt="" />
                        </div>
                        <p className="py-2 px-5 rounded-[4px] text-xs font-medium text-center text-white bg-gray-500">
                            DUY CHUT
                        </p>
                        <p className="py-2 px-5 rounded-[4px] text-xs font-medium text-center text-white bg-gray-500">
                            DUY CHUT
                        </p>
                        <p className="py-2 px-5 rounded-[4px] text-xs font-medium text-center text-white bg-gray-500">
                            DUY CHUT
                        </p>
                        <p className="py-2 px-5 rounded-[4px] text-xs font-medium text-center text-white bg-gray-500">
                            DUY CHUT
                        </p>
                        <DeleteIcon className="cursor-pointer w-4 h-4 text-xl" />
                    </div>
                </div>
            </div>
        </>
    );
}
