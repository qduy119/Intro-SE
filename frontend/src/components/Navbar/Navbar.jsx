import { Link } from "react-router-dom";

export default function Navbar() {
    return (
        <div className="border-b-2">
            <ul className="list-none">
                <li className="inline">
                    <Link to="/" className="text-2xl">
                        LOGO
                    </Link>
                </li>
                <li className="float-right">
                    <Link to="/login">Login</Link>
                </li>
                <li className="mr-4 float-right">
                    <Link to="/signup">Sign up</Link>
                </li>
            </ul>
        </div>
    );
}
