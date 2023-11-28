import { useParams } from "react-router-dom";
import AddIcon from "@mui/icons-material/Add";
import RemoveIcon from "@mui/icons-material/Remove";
import { foods } from "../../constants/index";
import { useState } from "react";

export default function FoodDetailPage() {
    const { id } = useParams();
    const food = foods.find((food) => food.id === +id) ?? [];
    const [thumbImage, setThumbImage] = useState(() => ({
        curr: -1,
        thumb: food.thumbnail,
    }));
    function handleShowThumbnail(e) {
        setThumbImage({ curr: +e.target.id, thumb: e.target.src });
    }
    return (
        <div className="px-4 py-8">
            <div className="block sm:flex gap-x-8">
                <div className="w-[100%] sm:w-[55%]">
                    <div>
                        <img
                            className="w-[100%] h-auto object-cover rounded-md"
                            src={thumbImage.thumb}
                            alt="Thumbnail"
                        />
                    </div>
                    <div className="mt-4 flex items-center flex-wrap gap-x-4 gap-y-2 w-full">
                        <img
                            className={`${
                                thumbImage.curr === -1
                                    ? "border-2 border-primary"
                                    : ""
                            } w-[80px] h-[50px] sm:w-[120px] sm:h-[80px] object-cover opacity-1 cursor-pointer hover:opacity-80 rounded-sm`}
                            src={food.thumbnail}
                            id={-1}
                            alt="Image"
                            onClick={(e) => handleShowThumbnail(e)}
                        />
                        {food.images.map((image, index) => (
                            <img
                                id={index}
                                key={index}
                                className={`${
                                    thumbImage.curr === index
                                        ? "border-2 border-primary"
                                        : ""
                                } w-[80px] h-[50px] sm:w-[120px] sm:h-[80px] object-cover opacity-1 cursor-pointer hover:opacity-80 rounded-sm`}
                                src={image}
                                alt="Image"
                                onClick={(e) => handleShowThumbnail(e)}
                            />
                        ))}
                    </div>
                </div>
                <div className="flex-1 mt-8 sm:mt-5">
                    <div>
                        <h3 className="font-semibold text-3xl text-primary-dark">
                            {food.name}
                        </h3>
                    </div>
                    <div className="mt-4">
                        <h3 className="font-bold text-xl uppercase">
                            Description:{" "}
                        </h3>
                        <p>{food.description}</p>
                    </div>
                    <h3 className="font-bold text-xl uppercase mt-4">
                        Rating: <span className="font-normal">10</span>
                    </h3>
                    <h3 className="font-bold text-xl uppercase mt-4">
                        Stock: <span className="font-normal">{food.stock}</span>
                    </h3>
                    <h3 className="font-bold text-xl uppercase mt-4">
                        Price: <span className="font-normal">{food.price}</span>
                    </h3>
                    <div className="flex items-center gap-x-4 mt-4">
                        <button className="border-none outline-none rounded-lg p-2 bg-gray-200 hover:bg-gray-300">
                            <RemoveIcon />
                        </button>
                        <p className="text-lg font-semibold">1</p>
                        <button className="border-none outline-none rounded-lg p-2 bg-gray-200 hover:bg-gray-300">
                            <AddIcon />
                        </button>
                    </div>
                    <div className="mt-4 flex items-center justify-between gap-x-5">
                        <button className="uppercase font-semibold text-xl border-none outline-none rounded-[4px] bg-primary hover:bg-primary-dark text-white text-center py-2 px-4 w-[50%] transition-all">
                            ORDER
                        </button>
                        <button className="uppercase font-semibold text-xl border-none outline-none rounded-[4px] bg-primary hover:bg-primary-dark text-white text-center py-2 px-4 w-[50%] transition-all">
                            ADD TO CART
                        </button>
                    </div>
                </div>
            </div>
            <div className="mt-10">
                <h1 className="font-semibold text-3xl mb-4">Reviews</h1>
            </div>
        </div>
    );
}
