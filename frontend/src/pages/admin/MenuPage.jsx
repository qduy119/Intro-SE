import { useState } from "react";
import { useNavigate } from "react-router-dom";
import AddIcon from "@mui/icons-material/Add";
// import EditIcon from "@mui/icons-material/Edit";
// import DeleteIcon from "@mui/icons-material/Delete";
// import RemoveIcon from "@mui/icons-material/Remove";
import Search from "../../components/Search/Search";
import UserMask from "../../components/User/UserMask";
import { foods } from "../../constants";
import AdminTable from "../../components/Table/Table";

const columns = [
    { field: "id", headerName: "ID", width: 70 },
    {
        field: "thumbnail",
        headerName: "Product",
        width: 100,
        sortable: false,
        renderCell: (rowData) => {
            const product = rowData.formattedValue;
            return (
                <div
                    className="w-[50px] h-[50px] bg-white bg-center bg-cover rounded-md border-[1px]"
                    style={{
                        backgroundImage: `url(${product})`,
                    }}
                />
            );
        },
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
        renderCell: (rowData) => {
            const rating = rowData.formattedValue;
            return (
                <div>
                    {Array.from({ length: 5 }, (_, index) => index).map(
                        (index) => (
                            <i
                                key={index}
                                className={`${
                                    index < rating ? "fa-solid" : "fa-regular"
                                } fa-star text-yellow-500`}
                            />
                        )
                    )}
                    <span className="ml-2">{rating}</span>
                </div>
            );
        },
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
];

const rows = foods;

export default function CategoryPage() {
    const [searchString, setSearchString] = useState("");
    const navigate = useNavigate();

    function handleSubmit(e) {
        e.preventDefault();
        if (searchString) {
            navigate(`/search?query=${searchString}`);
        }
    }
    return (
        <>
            <div className="flex pb-2 border-b-2 border-primary-light">
                <div className="flex flex-1 items-center justify-center">
                    <Search
                        search={searchString}
                        onSetSearch={setSearchString}
                        onSubmit={handleSubmit}
                    />
                </div>
                <UserMask
                    imageUrl={
                        "https://res.cloudinary.com/dlzyiprib/image/upload/v1694617729/e-commerces/user/kumz90hy8ufomdgof8ik.jpg"
                    }
                />
            </div>
            <div className="p-5">
                <h1 className="text-3xl font-bold text-gray-700 mb-1">MENU</h1>
                <div className="bg-primary-light w-[90px] h-[3px] rounded-[4px] mb-5" />
                <button className="mb-10 flex items-center gap-x-2 text-white text-xl font-semibold uppercase rounded-md px-4 py-3 bg-primary transition duration-150 hover:bg-primary-light">
                    add food
                    <AddIcon />
                </button>
                <div>
                    <AdminTable
                        rows={rows}
                        columns={columns}
                        pageSizeOptions={[10, 20, 30, 40, 50]}
                    />
                </div>
            </div>
        </>
    );
}
