import { Link } from "react-router-dom";
import { Button } from "@mui/material";
import ShoppingCartOutlinedIcon from "@mui/icons-material/ShoppingCartOutlined";
import Header from "../Header/Header";

export default function Navbar() {
    return (
        <div className="border-b-[1px] py-4 px-3 w-full z-50 fixed top-0 left-0 flex items-center h-[100px] bg-white">
            <div className="flex-1 flex items-center justify-between">
                <div className="inline">
                    <Link to="/" className="text-3xl font-bold text-primary">
                        hcmus@canteen
                    </Link>
                </div>
                <Header />
                <div className="flex items-center sm:gap-x-0 md:gap-x-[6px] lg:gap-x-2">
                    <Button>
                        <Link to="/login" className="text-primary">
                            Login
                        </Link>
                    </Button>
                    <Button>
                        <Link to="/signup" className="text-primary">
                            Sign up
                        </Link>
                    </Button>
                    <p className="hidden">
                        <Link to="/cart">
                            <ShoppingCartOutlinedIcon />
                        </Link>
                    </p>
                </div>
            </div>
        </div>
    );
}
