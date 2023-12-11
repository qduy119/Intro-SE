import { useSearchParams } from "react-router-dom";
import FoodItem from "../../components/Food/FoodItem";

const foods = [
    {
        id: 2,
        name: "Big Mac",
        description:
            "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...",
        price: 899,
        discount: 17.94,
        stock: 34,
        thumbnail:
            "https://www.themealdb.com/images/media/meals/urzj1d1587670726.jpg",
        images: [
            "https://www.themealdb.com/images/media/meals/wvpsxx1468256321.jpg",
            "https://www.themealdb.com/images/media/meals/rwuyqx1511383174.jpg",
            "https://www.themealdb.com/images/media/meals/58oia61564916529.jpg",
            "https://www.themealdb.com/images/media/meals/1525872624.jpg",
            "https://www.themealdb.com/images/media/meals/uwxusv1487344500.jpg",
        ],
    },
    {
        id: 8,
        name: "Beef Asado",
        description:
            "Style and speed. Stand out on HD video calls backed by Studio Mics. Capture ideas on the vibrant touchscreen.",
        price: 1499,
        discount: 10.23,
        stock: 68,
        thumbnail:
            "https://www.themealdb.com/images/media/meals/pkopc31683207947.jpg",
        images: [
            "https://www.themealdb.com/images/media/meals/wvpsxx1468256321.jpg",
            "https://www.themealdb.com/images/media/meals/urzj1d1587670726.jpg",
            "https://www.themealdb.com/images/media/meals/rwuyqx1511383174.jpg",
            "https://www.themealdb.com/images/media/meals/58oia61564916529.jpg",
            "https://www.themealdb.com/images/media/meals/1525872624.jpg",
        ],
    },
    {
        id: 9,
        name: "Beef Wellington",
        description:
            "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty",
        price: 1099,
        discount: 11.83,
        stock: 96,
        thumbnail:
            "https://www.themealdb.com/images/media/meals/vvpprx1487325699.jpg",
        images: [
            "https://www.themealdb.com/images/media/meals/wvpsxx1468256321.jpg",
            "https://www.themealdb.com/images/media/meals/urzj1d1587670726.jpg",
            "https://www.themealdb.com/images/media/meals/rwuyqx1511383174.jpg",
            "https://www.themealdb.com/images/media/meals/58oia61564916529.jpg",
            "https://www.themealdb.com/images/media/meals/1525872624.jpg",
        ],
    },
];

export default function SearchPage() {
    const [searchParams] = useSearchParams();

    return (
        <div className="min-h-[600px] px-4 py-8">
            <h1 className="font-semibold text-3xl mb-2">
                All search for{" "}
                <span className="font-bold">{searchParams.get("query")}</span>
            </h1>
            <div className="w-[13.5rem] h-[4px] rounded-md bg-primary-light mb-6" />
            <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 gap-5">
                {foods.map((food, index) => (
                    <FoodItem key={index} food={food} />
                ))}
            </div>
        </div>
    );
}
