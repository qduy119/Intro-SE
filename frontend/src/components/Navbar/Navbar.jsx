import { Link } from "react-router-dom";
import { Button } from '@mui/material';
import { useState } from "react";
import Header from "../Header/Header";


export default function Navbar() {
    const [showSearch, setShowSearch] = useState(false);
    return (
        <div className="border-b-2 py-2 px-3">
            <div className="flex items-center justify-between">
                <div className="inline">
                    <Link to="/" className="text-3xl font-bold text-primary">
                        hcmus@canteen
                    </Link>
                </div>
                <Header/>
                <div className="flex items-center sm:gap-x-0 md:gap-x-[6px] lg:gap-x-2">
                    <Button>
                        <Link to="/login" className="text-primary">Login</Link>
                    </Button>
                    <Button>
                        <Link to="/signup" className="text-primary">Sign up</Link>
                    </Button>
                </div>
            </div>
        </div>
    );
}
