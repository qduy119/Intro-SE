import { Link } from "react-router-dom";

export default function SignupPage() {
    return (
        <form className="flex h-[100vh] w-full gap-y-4">
        <div className="flex flex-col w-[35%] mt-[50px] p-4 pl-[80px]">
            <p className="text-center text-3xl font-bold text-blue-800">
                hcmus@canteen
            </p>
            <h2 className="text-center text-2xl font-bold pt-5 sm:pt-12">
            Create a new account
            </h2>
            <p className="text-center text-gray-600 text-[12px] mt-2">
            To use hcmuscanteen, Please enter your details
            </p>
            <div className="flex flex-col gap-5 w-full mt-4 ">
                <div className="flex flex-col">
                    <label className="mb-1" htmlFor="phone">Number</label>
                    <input className="w-[100%] border-none outline-none px-3 py-2 rounded-[4px] bg-gray-200" type="number" id="phone" placeholder="Your phone number" />
                </div>
                <div className="flex flex-col">
                    <label className="mb-1" htmlFor="name">Name</label>
                    <input className="w-[100%] border-none outline-none px-3 py-2 rounded-[4px] bg-gray-200" type="text" id="password" placeholder="Your Full Name" />
                </div>
                <div className="flex flex-col">
                    <label className="mb-1" htmlFor="password">Password</label>
                    <input className="w-[100%] border-none outline-none px-3 py-2 rounded-[4px] bg-gray-200" type="password" id="password" placeholder="Your Password" />
                </div>

                <button className="max-w-full rounded-[4px] border-none outline-non text-white font-bold text-xl bg-blue-800 hover:bg-blue-800/95 py-2">
                    Signup
                </button>
            </div>

            <p className="text-small-regular text-light-2 text-center mt-2">
                Already have an account?
                <Link
                    to="/signup"
                    className="text-blue-500 font-semibold ml-1 hover:underline">
                    Log in
                </Link>
            </p>
        </div>
        <div className="w-[65%]">
            <img src="" alt="" />
        </div>
    </form>
    );
}
