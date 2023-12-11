import FoodItem from "./FoodItem";

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
            "https://i.dummyjson.com/data/products/2/1.jpg",
            "https://i.dummyjson.com/data/products/2/2.jpg",
            "https://i.dummyjson.com/data/products/2/3.jpg",
            "https://i.dummyjson.com/data/products/2/thumbnail.jpg",
        ],
    },
    {
        id: 4,
        name: "Corba",
        description: "OPPO F19 is officially announced on April 2021.",
        price: 280,
        discount: 17.91,
        stock: 123,
        thumbnail:
            "https://www.themealdb.com/images/media/meals/58oia61564916529.jpg",
        images: [
            "https://i.dummyjson.com/data/products/4/1.jpg",
            "https://i.dummyjson.com/data/products/4/2.jpg",
            "https://i.dummyjson.com/data/products/4/3.jpg",
            "https://i.dummyjson.com/data/products/4/4.jpg",
            "https://i.dummyjson.com/data/products/4/thumbnail.jpg",
        ],
    },
    {
        id: 7,
        name: "Sushi",
        description:
            "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched",
        price: 1499,
        discount: 4.15,
        rating: 4.25,
        stock: 68,
        thumbnail:
            "https://www.themealdb.com/images/media/meals/g046bb1663960946.jpg",
        images: [
            "https://i.dummyjson.com/data/products/7/1.jpg",
            "https://i.dummyjson.com/data/products/7/2.jpg",
            "https://i.dummyjson.com/data/products/7/3.jpg",
            "https://i.dummyjson.com/data/products/7/thumbnail.jpg",
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
            "https://i.dummyjson.com/data/products/9/1.jpg",
            "https://i.dummyjson.com/data/products/9/2.png",
            "https://i.dummyjson.com/data/products/9/3.png",
            "https://i.dummyjson.com/data/products/9/4.jpg",
            "https://i.dummyjson.com/data/products/9/thumbnail.jpg",
        ],
    },
    {
        id: 10,
        name: "Jerk chicken with rice & peas",
        description:
            "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10",
        price: 1099,
        discount: 6.18,
        stock: 89,
        thumbnail:
            "https://www.themealdb.com/images/media/meals/tytyxu1515363282.jpg",
        images: [
            "https://i.dummyjson.com/data/products/10/1.jpg",
            "https://i.dummyjson.com/data/products/10/2.jpg",
            "https://i.dummyjson.com/data/products/10/3.jpg",
            "https://i.dummyjson.com/data/products/10/thumbnail.jpeg",
        ],
    },
];

export default function Food() {
    return (
        <div className="mb-10">
            <h1 className="font-semibold text-3xl mb-2">Best Seller</h1>
            <div className="w-[13.5rem] h-[4px] rounded-md bg-primary-light mb-6" />
            <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 gap-5">
                {foods.map((food, index) => (
                    <FoodItem key={index} food={food} />
                ))}
            </div>
        </div>
    );
}
