import { Link, NavLink } from "react-router-dom";

const navigationLinks = [
  { to: "dashboard", label: "Dashboard" },
  { to: "category", label: "Category" },
  { to: "menu", label: "Menu" },
  { to: "order", label: "Order" },
  { to: "customer", label: "Customer" },
  { to: "revenue", label: "Revenue" },
];

export default function Sidebar() {
    return (
        <div className="bg-primary w-[200px] h-screen">
            <div className="flex justify-center py-10">
                <Link to="/admin" className="text-3xl font-bold text-white">
                    HCMUS
                </Link>
            </div>
            <div className="bg-white w-full h-[2px] rounded-sm" />
            <ul className="mt-10 flex flex-col items-center gap-8 uppercase text-xl font-semibold text-white">
                {navigationLinks.map(({ to, label }) => (
                    <li key={to}>
                        <NavLink
                            to={to}
                            className={({ isActive }) =>
                                isActive ? "text-primary-light bg-white px-4 py-2 rounded-[4px]" : ""
                            }
                        >
                            {label}
                        </NavLink>
                    </li>
                ))}
            </ul>
        </div>
    );
}
