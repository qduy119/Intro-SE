import {
    createBrowserRouter,
    Navigate,
    Outlet,
    RouterProvider,
} from "react-router-dom";

import CustomerLayout from "./layouts/customer/CustomerLayout";
import AdminLayout from "./layouts/admin/AdminLayout";
import HomePage from "./pages/customer/HomePage";
import CategoryPage from "./pages/customer/CategoryPage";
import FoodDetailPage from "./pages/customer/FoodDetailPage";
import CartPage from "./pages/customer/CartPage";
import OrderPage from "./pages/customer/OrderPage";
import SearchPage from "./pages/customer/SearchPage";
import PaymentPage from "./pages/customer/PaymentPage";
import LoginPage from "./pages/customer/LoginPage";
import SignupPage from "./pages/customer/SignupPage";
import ProfilePage from "./pages/customer/ProfilePage";
import CheckoutPage from "./pages/customer/CheckoutPage";
import DashboardPage from "./pages/admin/DashboardPage";
import AdminCategoryPage from "./pages/admin/CategoryPage";
import MenuPage from "./pages/admin/MenuPage";
import AdminOrderPage from "./pages/admin/OrderPage";
import CustomerPage from "./pages/admin/CustomerPage";
import RevenuePage from "./pages/admin/RevenuePage";

const router = createBrowserRouter([
    {
        path: "/",
        element: <Outlet />,
        children: [
            {
                path: "/",
                element: <CustomerLayout />,
                children: [
                    {
                        path: "/",
                        element: <HomePage />,
                    },
                    {
                        path: "category/:id",
                        element: <CategoryPage />,
                    },
                    {
                        path: "food/:id",
                        element: <FoodDetailPage />,
                    },
                    {
                        path: "cart",
                        element: <CartPage />,
                    },
                    {
                        path: "order",
                        element: <OrderPage />,
                    },
                    {
                        path: "payment",
                        element: <PaymentPage />,
                    },
                    {
                        path: "checkout",
                        element: <CheckoutPage />,
                    },
                    {
                        path: "search",
                        element: <SearchPage />,
                    },
                    {
                        path: "profile",
                        element: <ProfilePage />,
                    },
                ],
            },
            {
                path: "login",
                element: <LoginPage />,
            },
            {
                path: "signup",
                element: <SignupPage />,
            },
            {
                path: "admin",
                element: <AdminLayout />,
                children: [
                    {
                        path: "",
                        element: <Navigate replace to="dashboard" />,
                    },
                    {
                        path: "dashboard",
                        element: <DashboardPage />,
                    },
                    {
                        path: "category",
                        element: <AdminCategoryPage />,
                    },
                    {
                        path: "menu",
                        element: <MenuPage />,
                    },
                    {
                        path: "order",
                        element: <AdminOrderPage />,
                    },
                    {
                        path: "customer",
                        element: <CustomerPage />,
                    },
                    {
                        path: "revenue",
                        element: <RevenuePage />,
                    },
                ],
            },
        ],
    },
]);

function App() {
    return <RouterProvider router={router} />;
}

export default App;
