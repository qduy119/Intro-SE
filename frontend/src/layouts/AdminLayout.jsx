import { Outlet } from "react-router-dom";
import { useSelector } from "react-redux";
import Sidebar from "../components/Sidebar/Sidebar";
import UserMask from "../components/User/UserMask";
import AuthErrorPage from "../pages/customer/AuthErrorPage";

export default function AdminLayout() {
    const user = useSelector((state) => state.auth.user);

    return user?.role === "Admin" ? (
        <div className="max-w-[1440px] mx-auto">
            <Sidebar />
            <div className="ml-[200px] py-2 px-5 bg-slate-50">
                <div className="flex justify-end pb-2 border-b-2 border-primary-light">
                    <UserMask />
                </div>
                <Outlet />
            </div>
        </div>
    ) : (
        <AuthErrorPage />
    );
}
