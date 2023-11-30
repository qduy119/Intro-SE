import { Link, NavLink } from "react-router-dom";

export default function Sidebar() {
    return (
        <div className="bg-primary w-[200px] h-screen">
            <div className="flex justify-center py-10">
                <Link to="/admin" className="text-3xl font-bold text-white">
                    ADMIN
                </Link>
            </div>
            <ul className="flex flex-col items-center gap-8 uppercase text-xl font-semibold text-white">
                <li>
                    <NavLink
                        to="dashboard"
                        className={({ isActive }) =>
                            isActive ? "text-black" : ""
                        }
                    >
                        Dashboard
                    </NavLink>
                </li>
                <li>
                    <NavLink
                        to="category"
                        className={({ isActive }) =>
                            isActive ? "text-black" : ""
                        }
                    >
                        Category
                    </NavLink>
                </li>
                <li>
                    <NavLink
                        to="menu"
                        className={({ isActive }) =>
                            isActive ? "text-black" : ""
                        }
                    >
                        Menu
                    </NavLink>
                </li>
                <li>
                    <NavLink
                        to="order"
                        className={({ isActive }) =>
                            isActive ? "text-black" : ""
                        }
                    >
                        Order
                    </NavLink>
                </li>
                <li>
                    <NavLink
                        to="customer"
                        className={({ isActive }) =>
                            isActive ? "text-black" : ""
                        }
                    >
                        Customer
                    </NavLink>
                </li>
                <li>
                    <NavLink
                        to="revenue"
                        className={({ isActive }) =>
                            isActive ? "text-black" : ""
                        }
                    >
                        Revenue
                    </NavLink>
                </li>
            </ul>
        </div>
    );
}
