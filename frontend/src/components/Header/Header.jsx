import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Search from "../Search/Search";
import ShoppingCartOutlinedIcon from "@mui/icons-material/ShoppingCartOutlined";

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
        <div className="flex gap-2 py-2 items-center">
            <Search
                search={searchString}
                onSetSearch={setSearchString}
                onSubmit={handleSubmit}
            />
            <ShoppingCartOutlinedIcon
                sx={{ ":hover": { cursor: "pointer" } }}
                onClick={() => navigate("/cart")}
            />
        </div>
    );
}
