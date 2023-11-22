import { Link } from "react-router-dom";

export default function FoodItem({ food }) {
    return (
        <li>
            <Link to={`/food/${food.id}`}>{food.name}</Link>
        </li>
    );
}
