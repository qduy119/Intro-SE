import { Link } from "react-router-dom";
import { bg } from "../../assets";

export default function SignupPage() {
    return (
        <div
            className="relative h-screen w-full bg-contain"
            style={{ backgroundImage: `url(${bg})` }}
        >
            <form className="absolute top-[50%] left-[50%] translate-x-[-50%] translate-y-[-50%] bg-white px-8 py-6 rounded-md shadow-lg w-[60%] max-w-md">
                <p className="text-center text-3xl font-bold text-primary">
                    <Link to="/">hcmus@canteen</Link>
                </p>
                <h2 className="text-center text-2xl font-bold pt-5 sm:pt-12 text-primary-dark">
                    Create a new account
                </h2>
                <p className="text-center text-gray-600 text-[12px] mt-2">
                    To use hcmuscanteen, please enter your details
                </p>
                <div className="flex flex-col gap-y-3 w-full mt-4">
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
                        <label className="mb-1" htmlFor="name">
                            Name
                        </label>
                        <input
                            className="w-[100%] border-none outline-none px-3 py-2 rounded-[4px] bg-gray-200"
                            type="text"
                            id="name"
                            placeholder="Your Full Name"
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
                    <div className="flex flex-col">
                        <label className="mb-1" htmlFor="confirm-password">
                            Confirm Password
                        </label>
                        <input
                            className="w-[100%] border-none outline-none px-3 py-2 rounded-[4px] bg-gray-200"
                            type="confirm-password"
                            id="confirm-password"
                            placeholder="Your Password Confirmation"
                        />
                    </div>
                    <button className="mt-5 max-w-full rounded-[4px] border-none outline-non text-white font-bold text-xl bg-primary hover:bg-primary-dark py-2">
                        Sign up
                    </button>
                </div>

                <p className="text-small-regular text-light-2 text-center mt-2">
                    Already have an account?
                    <Link
                        to="/login"
                        className="text-primary-light font-semibold ml-1 hover:underline"
                    >
                        Log in
                    </Link>
                </p>
            </form>
        </div>
    );
}
