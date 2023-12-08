import { useState } from "react";
import { useNavigate } from "react-router-dom";
import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import RemoveIcon from "@mui/icons-material/Remove";
import Search from "../../components/Search/Search";

export default function RevenuePage() {
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
                <div className="bg-primary-light w-[60px] h-[60px] rounded-full">
                    <img src="" alt="" />
                </div>
            </div>
            <div className="p-5">
                <h1 className="text-3xl font-bold text-gray-700 mb-1">REVENUE</h1>
                <div className="bg-primary-light w-[135px] h-[3px] rounded-[4px] mb-5" />
            </div>
            
        </>
    )
}
