import { useState } from "react";
import Search from "../../components/Search/Search";
import AddIcon from "@mui/icons-material/Add";
// import EditIcon from "@mui/icons-material/Edit";
// import DeleteIcon from "@mui/icons-material/Delete";
import UserMask from "../../components/User/UserMask";
import AdminTable from "../../components/Table/Table";
import { categories } from "../../constants";

const columns = [
    { field: "id", headerName: "ID", width: 100 },
    {
        field: "thumbnail",
        headerName: "Category",
        headerAlign: "center",
        align: "center",
        width: 100,
        sortable: false,
        renderCell: (rowData) => {
            const image = rowData.formattedValue;
            return (
                <div
                    className="w-[50px] h-[50px] bg-center bg-cover rounded-md"
                    style={{
                        backgroundImage: `url(${image})`,
                    }}
                />
            );
        },
    },
    {
        field: "name",
        headerName: "Name",
        width: 150,
        headerAlign: "center",
        align: "center",
    },
    {
        field: "description",
        headerName: "Description",
        width: 300,
        headerAlign: "center",
        align: "left",
    },
];

const rows = categories;

export default function CategoryPage() {
    const [searchString, setSearchString] = useState("");

    function handleSubmit(e) {
        e.preventDefault();
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
                <h1 className="text-3xl font-bold text-gray-700 mb-1">
                    CATEGORY
                </h1>
                <div className="bg-primary-light w-[154px] h-[3px] rounded-[4px] mb-5" />
                <button className="mb-10 flex items-center gap-x-2 text-white text-xl font-semibold uppercase rounded-md px-4 py-3 bg-primary transition duration-150 hover:bg-primary-light">
                    add category
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
