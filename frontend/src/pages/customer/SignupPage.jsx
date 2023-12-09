import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useRegisterMutation } from "../../services/auth";
import { bg } from "../../assets";

export default function SignupPage() {
    const navigate = useNavigate();
    const [credentials, setCredentials] = useState({});
    const [errors, setErrors] = useState(null);
    const [register, { data, isLoading, isSuccess, isError, error }] =
        useRegisterMutation();
    function handleChange(e) {
        setCredentials((prev) => ({ ...prev, [e.target.id]: e.target.value }));
    }
    function handleSubmit(e) {
        e.preventDefault();
        if (
            credentials.email === "" ||
            credentials.password === "" ||
            credentials.confirmPassword === ""
        ) {
            return;
        }
        let flag = 1;
        if (credentials.password !== credentials.confirmPassword) {
            setErrors((prev) => ({
                ...prev,
                confirmPassword: "Confirm Password is incorrect",
            }));
            flag = 0;
        }
        const regex = /^[\w-.]+@([\w-]+\.)+[\w-]{2,5}$/g;
        if (!regex.test(credentials.email)) {
            setErrors((prev) => ({
                ...prev,
                email: "Email is not valid",
            }));
            flag = 0;
        }
        if (!flag) return;
        setErrors(null);
        register({
            email: credentials.email,
            password: credentials.password,
        });
    }
    useEffect(() => {
        if (isSuccess) {
            setCredentials({});
            navigate("/login");
        }
        console.log(data);
    }, [isSuccess, data, navigate]);

    return (
        <div
            className="relative h-screen w-full bg-contain"
            style={{ backgroundImage: `url(${bg})` }}
        >
            <form
                action="/"
                method="post"
                onSubmit={(e) => handleSubmit(e)}
                className="absolute top-[50%] left-[50%] translate-x-[-50%] translate-y-[-50%] bg-white px-8 py-6 rounded-md shadow-lg w-[60%] max-w-md"
            >
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
                        <label className="mb-1" htmlFor="email">
                            Email
                        </label>
                        <input
                            className="w-[100%] border-none outline-none px-3 py-2 rounded-[4px] bg-gray-200"
                            type="text"
                            id="email"
                            placeholder="Your Email"
                            value={credentials.email ?? ""}
                            onChange={(e) => handleChange(e)}
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
                            value={credentials.password ?? ""}
                            onChange={(e) => handleChange(e)}
                        />
                    </div>
                    <div className="flex flex-col">
                        <label className="mb-1" htmlFor="confirm-password">
                            Confirm Password
                        </label>
                        <input
                            className="w-[100%] border-none outline-none px-3 py-2 rounded-[4px] bg-gray-200"
                            type="password"
                            id="confirmPassword"
                            placeholder="Your Confirm Password"
                            value={credentials.confirmPassword ?? ""}
                            onChange={(e) => handleChange(e)}
                        />
                    </div>
                    {errors
                        ? Object.values(errors).map((error, index) => (
                              <p
                                  key={index}
                                  className="mt-2 font-semibold text-red-600"
                              >
                                  {error}
                              </p>
                          ))
                        : null}
                    {isError ? (
                        <p className="mt-2 font-semibold text-red-600">
                            {error.message}
                        </p>
                    ) : null}
                    <button
                        type="submit"
                        className="flex justify-center items-center gap-2 mt-3 max-w-full rounded-[4px] border-none outline-non text-white font-bold text-xl bg-primary hover:bg-primary-dark py-2"
                    >
                        SIGN UP{" "}
                        <span className={`bar ${isLoading ? "" : "hidden"}`} />
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
