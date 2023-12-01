import { useState } from "react";
import { useNavigate } from "react-router-dom";
import CloseIcon from '@mui/icons-material/Close';
import SearchIcon from "@mui/icons-material/Search";
import AddIcon from '@mui/icons-material/Add';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import RemoveIcon from "@mui/icons-material/Remove";

export default function CategoryPage() {
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
            <div className="flex mb-3 items-center justify-between">
                <form
                    action="/"
                    onSubmit={(e) => handleSubmit(e)}
                    className="flex items-center ml-[300px]"
                >
                    <div className="flex items-center h-[42px] py-2 pl-5 pr-2 rounded-l-full border-solid border-[1px] border-gray-300 focus-within:border-primary focus-within:shadow-primary-light">
                        <label htmlFor="search" className="hidden"></label>
                        <input
                            id="search"
                            type="text"
                            placeholder="Search..."
                            className="border-none outline-none w-[350px] bg-transparent"
                            value={searchString}
                            onChange={(e) => setSearchString(e.target.value)}
                        />
                        {searchString ? (
                            <button className=" p-1 rounded-full bg-gray-200 opacity-100" onClick={() => setSearchString("")}>
                                <CloseIcon className="w-2 h-2" />
                            </button>
                        ) : (
                            <button className=" p-1 rounded-full bg-gray-200 opacity-0" onClick={() => setSearchString("")}>
                                <CloseIcon className="w-2 h-2" />
                            </button>
                        )}
                    </div>
                    <button
                        type="submit"
                        className="h-[42px] rounded-r-full border-l-0 border-solid border-[1px] py-[7px] px-4 border-gray-300 bg-gray-100 hover:bg-gray-20"
                        onClick={(e) => handleSubmit(e)}
                    >
                        <SearchIcon />
                    </button>
                </form>
                <div className="bg-primary-light w-[60px] h-[60px] rounded-full">
                    <img src="" alt="" />
                </div>


            </div>
            <div className="bg-primary-light w-full h-[2px] rounded-[4px]" />
            <div className="py-3 px-5">
                <h1 className="text-3xl font-bold text-gray-700 mb-1">MENU</h1>
                <div className="bg-primary-light w-[90px] h-[3px] rounded-[4px] mb-5" />
                <button className="mb-10 flex items-center gap-x-2 text-white text-xl font-semibold uppercase rounded-md px-4 py-3 bg-primary transition duration-150 hover:bg-primary-light">
                    add menu
                    <AddIcon />
                </button>
                <div>
                <div className="flex items-center justify-between p-3 rounded-sm bg-gray-200 w-[80%] mb-4">
                        <div className="flex items-center gap-x-6">
                            <div className="bg-gray-300 rounded-md w-[6rem] h-[6rem]">
                                <img src="" alt="" />
                            </div>
                            <div className="flex flex-col justify-between gap-y-3">
                                <h2 className="p-2 bg-gray-300 rounded-sm text-center">Menu Name</h2>
                                <p className="p-2 bg-gray-300 rounded-sm text-center">Menu Description</p>
                            </div>
                        </div>

                        <div className="flex items-center gap-x-8 mr-3">
                            <div className="flex items-center gap-x-4 mt-1">
                                <button className="border-none outline-none rounded-md p-1 bg-gray-400 hover:bg-gray-300">
                                    <RemoveIcon />
                                </button>
                                <p className="text-lg font-semibold">
                                    1
                                </p>
                                <button className="border-none outline-none rounded-md p-1 bg-gray-400 hover:bg-gray-300">
                                    <AddIcon />
                                </button>
                            </div>
                            <div className="flex items-center gap-x-3">
                                <EditIcon className="cursor-pointer" />
                                <DeleteIcon className="cursor-pointer" />
                            </div>
                        </div>
                    </div>

                    <div className="flex items-center justify-between p-3 rounded-sm bg-gray-200 w-[80%] mb-4">
                        <div className="flex items-center gap-x-6">
                            <div className="bg-gray-300 rounded-md w-[6rem] h-[6rem]">
                                <img src="" alt="" />
                            </div>
                            <div className="flex flex-col justify-between gap-y-3">
                                <h2 className="p-2 bg-gray-300 rounded-sm text-center">Menu Name</h2>
                                <p className="p-2 bg-gray-300 rounded-sm text-center">Menu Description</p>
                            </div>
                        </div>

                        <div className="flex items-center gap-x-8 mr-3">
                            <div className="flex items-center gap-x-4 mt-1">
                                <button className="border-none outline-none rounded-md p-1 bg-gray-400 hover:bg-gray-300">
                                    <RemoveIcon />
                                </button>
                                <p className="text-lg font-semibold">
                                    1
                                </p>
                                <button className="border-none outline-none rounded-md p-1 bg-gray-400 hover:bg-gray-300">
                                    <AddIcon />
                                </button>
                            </div>
                            <div className="flex items-center gap-x-3">
                                <EditIcon className="cursor-pointer" />
                                <DeleteIcon className="cursor-pointer" />
                            </div>
                        </div>
                    </div>

                    <div className="flex items-center justify-between p-3 rounded-sm bg-gray-200 w-[80%] mb-4">
                        <div className="flex items-center gap-x-6">
                            <div className="bg-gray-300 rounded-md w-[6rem] h-[6rem]">
                                <img src="" alt="" />
                            </div>
                            <div className="flex flex-col justify-between gap-y-3">
                                <h2 className="p-2 bg-gray-300 rounded-sm text-center">Menu Name</h2>
                                <p className="p-2 bg-gray-300 rounded-sm text-center">Menu Description</p>
                            </div>
                        </div>

                        <div className="flex items-center gap-x-8 mr-3">
                            <div className="flex items-center gap-x-4 mt-1">
                                <button className="border-none outline-none rounded-md p-1 bg-gray-400 hover:bg-gray-300">
                                    <RemoveIcon />
                                </button>
                                <p className="text-lg font-semibold">
                                    1
                                </p>
                                <button className="border-none outline-none rounded-md p-1 bg-gray-400 hover:bg-gray-300">
                                    <AddIcon />
                                </button>
                            </div>
                            <div className="flex items-center gap-x-3">
                                <EditIcon className="cursor-pointer" />
                                <DeleteIcon className="cursor-pointer" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}
