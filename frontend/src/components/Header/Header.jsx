import { useState } from "react";
import { useNavigate } from "react-router-dom";

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
                <div className="h-[42px] py-2 px-5 rounded-l-full border-solid border-[1px] border-gray-300 focus-within:border-primary">
                    <label htmlFor="search" className="hidden"></label>
                    <input
                        id="search"
                        type="text"
                        placeholder="Search..."
                        className="border-none outline-none w-[300px]"
                        value={searchString}
                        onChange={(e) => setSearchString(e.target.value)}
                    />
                </div>
                <button
                    type="submit"
                    className="h-[42px] rounded-r-full border-l-0 border-solid border-[1px] py-[7px] px-4 border-gray-300 bg-gray-100 hover:bg-gray-200"
                >
                    <SearchIcon />
                </button>
            </form>
            
        </div>
    );
}
