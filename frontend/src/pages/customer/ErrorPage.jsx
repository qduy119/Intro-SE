import { useRouteError, useNavigate } from "react-router-dom";

export default function Error() {
    const error = useRouteError();
    const navigate = useNavigate();
    console.log(error);

    return (
        <section className="px-6 md:px-12 mt-[150px]">
            <div className="max-w-[1440px] mx-auto">
                <div className="p-4 bg-white rounded-md">
                    <p className="text-red-700 font-bold">{error.message} !</p>
                    <button
                        onClick={() => navigate(-1)}
                        className="bg-gray-400 rounded-md p-2 mt-2"
                    >
                        &larr; Go back
                    </button>
                </div>
            </div>
        </section>
    );
}
