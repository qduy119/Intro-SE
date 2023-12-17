import { useState } from "react";
import { useNavigate } from "react-router-dom";
import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import Search from "../../components/Search/Search";
import UserMask from "../../components/User/UserMask";
import { foods } from "../../constants";
import AdminTable from "../../components/Table/Table";
import { useDropzone } from "react-dropzone";
import ImageIcon from '@mui/icons-material/Image';
import Modal from "../../components/Modal/Modal";

const MenuPage = () => {
    const [searchString, setSearchString] = useState("");
    const [showAddForm, setShowAddForm] = useState(false);
    const [newFood, setNewFood] = useState({
        id: foods.length + 1,
        thumbnail: "",
        name: "",
        description: "",
        price: 0,
        discount: 0,
        stock: 0,
    });
    const [updatedRows, setUpdatedRows] = useState([...foods]);
    const [editingFoodId, setEditingFoodId] = useState(null);
    const navigate = useNavigate();

    const handleInputChange = (field, value) => {
        setNewFood({ ...newFood, [field]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        if (editingFoodId !== null) {
            // Update existing food
            const updatedFoods = updatedRows.map((food) =>
                food.id === editingFoodId ? { ...newFood, id: editingFoodId } : food
            );
            setUpdatedRows(updatedFoods);
            setEditingFoodId(null);
        } else {
            // Add new food
            const updatedFoods = [...updatedRows, { ...newFood }];
            setUpdatedRows(updatedFoods);
        }

        setNewFood({
            id: updatedRows.length + 1,
            thumbnail: "",
            name: "",
            description: "",
            price: 0,
            discount: 0,
            stock: 0,
        });
        setShowAddForm(false);
        setEditingFoodId(null);
    };

    const onDrop = (acceptedFiles) => {
        const file = acceptedFiles[0];
        const reader = new FileReader();

        reader.onload = (event) => {
            const imageUrl = event.target.result;
            setNewFood({ ...newFood, thumbnail: imageUrl });
        };

        reader.readAsDataURL(file);
    };

    const { getRootProps, getInputProps } = useDropzone({
        accept: "image/*",
        onDrop,
    });

    const handleEdit = (foodId) => {
        setEditingFoodId(foodId);
        const foodToEdit = updatedRows.find((food) => food.id === foodId);
        setNewFood({ ...foodToEdit });
        setShowAddForm(true);
    };

    const handleDelete = (foodId) => {
        const updatedFoods = updatedRows.filter((food) => food.id !== foodId);
        setUpdatedRows(updatedFoods);
    };

    const toggleAddForm = () => {
        setShowAddForm(!showAddForm);
        setEditingFoodId(null);
    };

    const handleCloseModal = () => {
        setNewFood({
            id: updatedRows.length + 1,
            thumbnail: "",
            name: "",
            description: "",
            price: 0,
            discount: 0,
            stock: 0,
        });
        setShowAddForm(false);
        setEditingFoodId(null);
    };

    const columns = [
        { field: "id", headerName: "ID", width: 70 },
        {
            field: "thumbnail",
            headerName: "Product",
            width: 100,
            sortable: false,
            renderCell: (rowData) => (
                <div
                    className="w-[50px] h-[50px] bg-white bg-center bg-cover rounded-md border-[1px]"
                    style={{
                        backgroundImage: `url(${rowData.formattedValue})`,
                    }}
                />
            ),
        },
        {
            field: "name",
            headerName: "Name",
            width: 100,
            sortable: false,
        },
        {
            field: "description",
            headerName: "Description",
            width: 200,
            sortable: false,
            headerAlign: "center",
        },
        {
            field: "price",
            headerName: "Price",
            headerAlign: "center",
            align: "center",
            type: "number",
            width: 100,
        },
        {
            field: "discount",
            headerName: "Discount",
            headerAlign: "center",
            type: "number",
            width: 100,
            align: "center",
        },
        {
            field: "rating",
            headerName: "Rating",
            type: "number",
            width: 150,
            renderCell: (rowData) => (
                <div>
                    {Array.from({ length: 5 }, (_, index) => index).map((index) => (
                        <i
                            key={index}
                            className={`${index < rowData.formattedValue ? "fa-solid" : "fa-regular"
                                } fa-star text-yellow-500`}
                        />
                    ))}
                    <span className="ml-2">{rowData.formattedValue}</span>
                </div>
            ),
            headerAlign: "center",
            align: "right",
        },
        {
            field: "stock",
            headerName: "Stock",
            headerAlign: "center",
            type: "number",
            width: 100,
            align: "center",
        },
        {
            field: "actions",
            headerName: "Actions",
            width: 150,
            sortable: false,
            renderCell: (rowData) => (
                <div className="flex items-center justify-end space-x-2">
                    <EditIcon
                        className="cursor-pointer"
                        onClick={() => handleEdit(rowData.row.id)}
                    />
                    <DeleteIcon
                        className="cursor-pointer"
                        onClick={() => handleDelete(rowData.row.id)}
                    />
                </div>
            ),
        },
    ];

    return (
        <>
            <div className="flex pb-2 border-b-2 border-primary-light">
                <div className="flex flex-1 items-center justify-center">
                    <Search
                        search={searchString}
                        onSetSearch={setSearchString}
                        onSubmit={() => {
                            if (searchString) {
                                navigate(`/search?query=${searchString}`);
                            }
                        }}
                    />
                </div>
                <UserMask />
            </div>
            <div className="p-5">
                <h1 className="text-3xl font-bold text-gray-700 mb-1">MENU</h1>
                <div className="bg-primary-light w-[90px] h-[3px] rounded-[4px] mb-5" />
                <button
                    onClick={toggleAddForm}
                    className="w-full max-w-fit mb-10 flex items-center gap-x-2 text-white text-xl font-semibold uppercase rounded-md px-4 py-3 bg-primary transition duration-150 hover:bg-primary-light"
                >
                    Add menu
                    <AddIcon />
                </button>
                {showAddForm && (
                    <Modal onClose={handleCloseModal}>
                        <form onSubmit={handleSubmit} className="flex flex-col space-y-4">
                            <div className="flex flex-col md:flex-row md:space-x-4">
                                <div className="flex flex-col mb-4 md:w-1/2">
                                    <div className="flex flex-col mb-4 md:w-full">
                                        <label htmlFor="foodName" className="text-sm font-semibold text-gray-600">
                                            Food Name
                                        </label>
                                        <input
                                            id="foodName"
                                            className="border-none outline-none py-2 px-3 rounded-[4px] bg-gray-100"
                                            type="text"
                                            placeholder="Enter food name"
                                            value={newFood.name}
                                            onChange={(e) => handleInputChange("name", e.target.value)}
                                        />
                                    </div>
                                    <div className="flex flex-col mb-4 md:w-full">
                                        <label htmlFor="foodPrice" className="text-sm font-semibold text-gray-600">
                                            Food Price
                                        </label>
                                        <input
                                            id="foodPrice"
                                            type="number"
                                            placeholder="Enter food price"
                                            value={newFood.price}
                                            onChange={(e) => handleInputChange("price", e.target.value)}
                                            className="border-none outline-none py-2 px-3 rounded-[4px] bg-gray-100"
                                        />
                                    </div>
                                    <div className="flex flex-col mb-4 md:w-full">
                                        <label htmlFor="foodDiscount" className="text-sm font-semibold text-gray-600">
                                            Food Discount
                                        </label>
                                        <input
                                            id="foodDiscount"
                                            type="number"
                                            placeholder="Enter food discount"
                                            value={newFood.discount}
                                            onChange={(e) => handleInputChange("discount", e.target.value)}
                                            className="border-none outline-none py-2 px-3 rounded-[4px] bg-gray-100"
                                        />
                                    </div>
                                    <div className="flex flex-col md:w-full">
                                        <label htmlFor="foodStock" className="text-sm font-semibold text-gray-600">
                                            Food Stock
                                        </label>
                                        <input
                                            id="foodStock"
                                            type="number"
                                            placeholder="Enter food stock"
                                            value={newFood.stock}
                                            onChange={(e) => handleInputChange("stock", e.target.value)}
                                            className="border-none outline-none py-2 px-3 rounded-[4px] bg-gray-100"
                                        />
                                    </div>
                                </div>
                                <div className="flex flex-col mb-4 md:w-1/2">
                                    <label htmlFor="foodDescription" className="text-sm font-semibold text-gray-600">
                                        Food Description
                                    </label>
                                    <textarea
                                        id="foodDescription"
                                        placeholder="Enter food description"
                                        value={newFood.description}
                                        onChange={(e) => handleInputChange("description", e.target.value)}
                                        className="border-none outline-none py-2 px-3 rounded-[4px] bg-gray-100 h-full resize-none"
                                    />
                                </div>
                            </div>
                            <div className="flex flex-col mb-4 cursor-pointer">
                                <label htmlFor="foodThumbnail" className="text-sm font-semibold text-gray-600">
                                    Food Image
                                </label>
                                <div {...getRootProps()} className="dropzone" style={{ border: '2px dashed #ccc', borderRadius: '8px', padding: '16px', textAlign: 'center' }}>

                                    {newFood.thumbnail ? (
                                        <img
                                            src={newFood.thumbnail}
                                            alt="Food Thumbnail"
                                            className="w-[300px] h-[300px] object-cover mt-2 flex justify-center mx-auto"
                                        />
                                    ) : (
                                        <>
                                            <input {...getInputProps()} />
                                            <p style={{ margin: '8px 0' }}>
                                                Drag and drop an image here, or click to select an image
                                            </p>
                                            <ImageIcon style={{ fontSize: '48px', color: '#555' }} />
                                        </>
                                    )}
                                </div>
                            </div>
                            <div className="flex space-x-2">

                                <button
                                    type="submit"
                                    className="uppercase font-bold py-2 px-4 rounded-md bg-primary text-white hover:bg-primary-light transition duration-150 self-start"
                                >
                                    {editingFoodId !== null ? "Update Food" : "Add Food"}
                                </button>

                                <button
                                    type="button"
                                    onClick={handleCloseModal}
                                    className="uppercase font-bold py-2 px-4 rounded-md bg-gray-400 text-white opacity-100 hover:opacity-90 transition duration-150 self-start mr-2"
                                >
                                    Cancel
                                </button>

                            </div>
                        </form>
                    </Modal>
                )}
                <div>
                    <AdminTable
                        rows={updatedRows}
                        columns={columns}
                        pageSizeOptions={[10, 20, 30, 40, 50]}
                    />
                </div>
            </div>
        </>
    );
};

export default MenuPage;
