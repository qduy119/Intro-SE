import { Outlet } from "react-router-dom";
import Sidebar from "../../components/Sidebar/Sidebar";

export default function AdminLayout() {
    return (
        <div className="flex">
            <Sidebar />
            <div className="flex-1 p-2 mr-[200px]">
                <Outlet />
            </div>
        </div>
    );
}
