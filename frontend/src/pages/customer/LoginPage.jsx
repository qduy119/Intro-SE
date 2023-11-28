import { Link } from "react-router-dom";
import { bg } from "../../assets";

export default function LoginPage() {
    return (
        <div
            className="relative h-screen w-full bg-contain"
            style={{ backgroundImage: `url(${bg})` }}
        >
            <form className="absolute top-[50%] left-[50%] translate-x-[-50%] translate-y-[-50%] flex gap-y-4 bg-white px-10 py-5 rounded-md">
                <div className="flex flex-col">
                    <p className="text-center text-3xl font-bold text-primary">
                        <Link to="/">hcmus@canteen</Link>
                    </p>
                    <h2 className="text-center text-2xl font-bold pt-5 sm:pt-12 text-primary-dark">
                        Log in to your account
                    </h2>
                    <p className="text-center text-gray-600 text-[12px] mt-2">
                        Welcome back! Please enter your details.
                    </p>
                    <div className="flex flex-col gap-5 w-full mt-4 ">
                        <div className="flex flex-col">
                            <label className="mb-1" htmlFor="phone">
                                Number
                            </label>
                            <input
                                className="w-[100%] border-none outline-none px-3 py-2 rounded-[4px] bg-gray-200"
                                type="text"
                                id="phone"
                                placeholder="Your phone number"
                            />
                        </div>
                        <div className="flex flex-col">
                            <label className="mb-1" htmlFor="password">
                                Password
                            </label>
                            <input
                                className="w-[100%] border-none outline-none px-3 py-2 rounded-[4px] bg-gray-200"
                                type="password"
                                id="password"
                                placeholder="Your Password"
                            />
                        </div>

                        <button className="max-w-full rounded-[4px] border-none outline-non text-white font-bold text-xl bg-primary hover:bg-primary-dark py-2">
                            Login
                        </button>
                    </div>

                    <p className="text-small-regular text-light-2 text-center mt-2">
                        Don&apos;t have an account yet?
                        <Link
                            to="/signup"
                            className="text-primary-light font-semibold ml-1 hover:underline"
                        >
                            Sign up
                        </Link>
                    </p>
                </div>
            </form>
        </div>
    );
}
