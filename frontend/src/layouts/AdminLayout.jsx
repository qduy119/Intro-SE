import { Outlet } from "react-router-dom";
import Sidebar from "../components/Sidebar/Sidebar";

export default function AdminLayout() {
    return (
        <div className="flex">
            <Sidebar />
            <div className="flex-1 py-2 px-5">
                <Outlet />
            </div>
        </div>
    );
}
