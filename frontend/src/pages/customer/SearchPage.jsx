import { useSearchParams } from "react-router-dom";

export default function SearchPage() {
    const [searchParams] = useSearchParams();

    return (
        <div>
            <p>Result for: {searchParams.get("query")}</p>
            <h1 className="text-2xl">SearchPage</h1>
        </div>
    );
}
