import { useState } from "react";
import { useNavigate } from "react-router-dom";
import CloseIcon from '@mui/icons-material/Close';
import SearchIcon from "@mui/icons-material/Search";

export default function Header() {
    const [searchString, setSearchString] = useState("");
    const navigate = useNavigate();

    function handleSubmit(e) {
        e.preventDefault();
        if (searchString) {
            navigate(`/search?query=${searchString}`);
        }
    }
    return (
        <div className="flex justify-end gap-2 py-4 items-center">
            <form
                action="/"
                onSubmit={(e) => handleSubmit(e)}
                className="flex items-center "
            >
                <div className="flex items-center h-[42px] py-2 pl-5 pr-2 rounded-l-full border-solid border-[1px] border-gray-300 focus-within:border-primary focus-within:shadow-primary-light">
                    <label htmlFor="search" className="hidden"></label>
                    <input
                        id="search"
                        type="text"
                        placeholder="Search..."
                        className="border-none outline-none w-[300px] bg-transparent"
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

        </div>
    );
}
