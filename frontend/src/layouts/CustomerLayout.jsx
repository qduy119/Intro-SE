import { Outlet } from "react-router-dom";
import Navbar from "../components/Navbar/Navbar";
import Footer from "../components/Footer/Footer";

export default function CustomerLayout() {
    return (
        <div>
            <Navbar />
            <div className="mt-[100px]">
                <Outlet />
            </div>
            <Footer />
        </div>
    );
}
