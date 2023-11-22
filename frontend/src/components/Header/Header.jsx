import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";

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
        <div className="flex justify-end gap-2 border-b-2 py-4">
            <form action="/" onSubmit={(e) => handleSubmit(e)}>
                <label htmlFor="search" className="hidden"></label>
                <input
                    id="search"
                    type="text"
                    placeholder="Search..."
                    className="border outline-none"
                    value={searchString}
                    onChange={(e) => setSearchString(e.target.value)}
                />
                <button type="submit" className="bg-slate-300">
                    Search
                </button>
            </form>
            <p>
                <Link to="/cart">Cart</Link>
            </p>
        </div>
    );
}
