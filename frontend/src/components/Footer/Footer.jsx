import { Link } from "react-router-dom";

export default function Footer() {
    return (
        <footer className="px-3 w-full bg-primary">
            <div className="flex items-center justify-between py-3 px-2">
                <Link to="/" className="text-3xl font-bold text-white">
                    hcmus@canteen
                </Link>

                <div className="flex items-center gap-x-2 text-white font-thin">
                    <a href="/" className="underline">
                        Private policy
                    </a>
                    <a href="/" className="underline">
                        terms
                    </a>
                </div>
            </div>
        </footer>
    )
}
