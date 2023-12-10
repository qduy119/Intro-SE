import FoodItem from "./FoodItem";

const foods = [
    {
        id: 1,
        name: "Teriyaki Chicken Casserole",
        description: "An apple mobile which is nothing like apple",
        price: 549,
        discount: 12.96,
        stock: 94,
        thumbnail: "https://www.themealdb.com/images/media/meals/wvpsxx1468256321.jpg",
        images: [
            "https://i.dummyjson.com/data/products/1/1.jpg",
            "https://i.dummyjson.com/data/products/1/2.jpg",
            "https://i.dummyjson.com/data/products/1/3.jpg",
            "https://i.dummyjson.com/data/products/1/4.jpg",
            "https://i.dummyjson.com/data/products/1/thumbnail.jpg",
        ],
    },
    {
        id: 2,
        name: "Big Mac",
        description:
            "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...",
        price: 899,
        discount: 17.94,
        stock: 34,
        thumbnail: "https://www.themealdb.com/images/media/meals/urzj1d1587670726.jpg",
        images: [
            "https://i.dummyjson.com/data/products/2/1.jpg",
            "https://i.dummyjson.com/data/products/2/2.jpg",
            "https://i.dummyjson.com/data/products/2/3.jpg",
            "https://i.dummyjson.com/data/products/2/thumbnail.jpg",
        ],
    },
    {
        id: 3,
        name: "Pencakes",
        description:
            "Samsung's new variant which goes beyond Galaxy to the Universe",
        price: 1249,
        discount: 15.46,
        stock: 36,
        thumbnail: "https://www.themealdb.com/images/media/meals/rwuyqx1511383174.jpg",
        images: ["https://i.dummyjson.com/data/products/3/1.jpg"],
    },
    {
        id: 4,
        name: "Corba",
        description: "OPPO F19 is officially announced on April 2021.",
        price: 280,
        discount: 17.91,
        stock: 123,
        thumbnail: "https://www.themealdb.com/images/media/meals/58oia61564916529.jpg",
        images: [
            "https://i.dummyjson.com/data/products/4/1.jpg",
            "https://i.dummyjson.com/data/products/4/2.jpg",
            "https://i.dummyjson.com/data/products/4/3.jpg",
            "https://i.dummyjson.com/data/products/4/4.jpg",
            "https://i.dummyjson.com/data/products/4/thumbnail.jpg",
        ],
    },
    {
        id: 5,
        name: "Kung Pao Chicken",
        description:
            "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.",
        price: 499,
        discount: 10.58,
        stock: 32,
        thumbnail: "https://www.themealdb.com/images/media/meals/1525872624.jpg",
        images: [
            "https://i.dummyjson.com/data/products/5/1.jpg",
            "https://i.dummyjson.com/data/products/5/2.jpg",
            "https://i.dummyjson.com/data/products/5/3.jpg",
        ],
    },
    {
        id: 6,
        name: "Masala Fish",
        description:
            "MacBook Pro 2021 with mini-LED display may launch between September, November",
        price: 1749,
        discount: 11.02,
        stock: 83,
        thumbnail: "https://www.themealdb.com/images/media/meals/uwxusv1487344500.jpg",
        images: [
            "https://i.dummyjson.com/data/products/6/1.png",
            "https://i.dummyjson.com/data/products/6/2.jpg",
            "https://i.dummyjson.com/data/products/6/3.png",
            "https://i.dummyjson.com/data/products/6/4.jpg",
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
        thumbnail: "https://www.themealdb.com/images/media/meals/g046bb1663960946.jpg",
        images: [
            "https://i.dummyjson.com/data/products/7/1.jpg",
            "https://i.dummyjson.com/data/products/7/2.jpg",
            "https://i.dummyjson.com/data/products/7/3.jpg",
            "https://i.dummyjson.com/data/products/7/thumbnail.jpg",
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
        thumbnail: "https://www.themealdb.com/images/media/meals/pkopc31683207947.jpg",
        images: [
            "https://i.dummyjson.com/data/products/8/1.jpg",
            "https://i.dummyjson.com/data/products/8/2.jpg",
            "https://i.dummyjson.com/data/products/8/3.jpg",
            "https://i.dummyjson.com/data/products/8/4.jpg",
            "https://i.dummyjson.com/data/products/8/thumbnail.jpg",
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
        thumbnail: "https://www.themealdb.com/images/media/meals/vvpprx1487325699.jpg",
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
        thumbnail: "https://www.themealdb.com/images/media/meals/tytyxu1515363282.jpg",
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
        <div>
            <h1 className="font-semibold text-3xl mb-2">List Food Today</h1>
            <div className="w-[13.5rem] h-[4px] rounded-md bg-primary-light mb-6" />
            <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 gap-5">
                {foods.map((food, index) => (
                    <FoodItem key={index} food={food} />
                ))}
            </div>
        </div>
    );
}
