import Category from './Category';

const foods = [
    { id: 1, name: "Food 1" },
    { id: 2, name: "Food 2" },
    { id: 3, name: "Food 3" },
    { id: 4, name: "Food 4" },
    { id: 5, name: "Food 5" },
    { id: 6, name: "Food 6" },
    { id: 7, name: "Food 7" },
];

const FoodCategory = () => {
  return (
    <div className='flex items-center justify-evenly'>
        {foods.map((food, index)=>{
            <Category image={index} food={food} />
        })}
    </div>
  )
}

export default FoodCategory