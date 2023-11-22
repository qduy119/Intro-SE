import FoodItem from "./FoodItem";

export default function Food() {
    const foods = [
        { id: 1, name: "Food 1" },
        { id: 2, name: "Food 2" },
        { id: 3, name: "Food 3" },
        { id: 4, name: "Food 4" },
        { id: 5, name: "Food 5" },
        { id: 6, name: "Food 6" },
        { id: 7, name: "Food 7" },
    ];
    return (
        <div>
            <ul className="list-none">
                {foods.map((food, index) => (
                    <FoodItem key={index} food={food} />
                ))}
            </ul>
        </div>
    );
}
