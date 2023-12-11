import { useState } from "react";
import { useNavigate } from "react-router-dom";
import DeleteIcon from "@mui/icons-material/Delete";
import AddIcon from "@mui/icons-material/Add";
import Search from "../../components/Search/Search";
import UserMask from "../../components/User/UserMask";

export default function CustomerPage() {
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
                <UserMask />
            </div>
            <div className="p-5">
                <h1 className="text-3xl font-bold text-gray-700 mb-1">
                    CUSTOMER
                </h1>
                <div className="bg-primary-light w-[165px] h-[3px] rounded-[4px] mb-5" />
                <button className="mb-10 flex items-center gap-x-2 text-white text-xl font-semibold uppercase rounded-md px-4 py-3 bg-primary transition duration-150 hover:bg-primary-light">
                    add customer
                    <AddIcon />
                </button>
                <div className="p-4">
                    <div className="bg-gray-300 rounded-[4px] flex w-full items-center mb-5 justify-between py-2 px-4">
                        <h3 className="font-medium text-xl w-[17%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Avatar
                        </h3>
                        <h3 className="font-medium text-xl w-[15%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Full Name
                        </h3>
                        <h3 className="font-medium text-xl w-[15%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Email
                        </h3>
                        <h3 className="font-medium text-xl w-[18%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Phone Number
                        </h3>
                        <h3 className="font-medium text-xl w-[12%] text-center text-white py-2 px-5 bg-gray-500 rounded-[4px]">
                            Role
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
