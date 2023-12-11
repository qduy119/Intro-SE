import { Outlet } from "react-router-dom";
import Sidebar from "../components/Sidebar/Sidebar";

export default function AdminLayout() {
    return (
        <div>
            <Sidebar />
            <div className="ml-[200px] py-2 px-5 bg-slate-50">
                <Outlet />
            </div>
        </div>
    );
}
