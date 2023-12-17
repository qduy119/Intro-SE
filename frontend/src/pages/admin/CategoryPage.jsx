import { useState } from "react";
import { useDropzone } from "react-dropzone";
import Search from "../../components/Search/Search";
import AddIcon from "@mui/icons-material/Add";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import UserMask from "../../components/User/UserMask";
import AdminTable from "../../components/Table/Table";
import { categories } from "../../constants";
import ImageIcon from "@mui/icons-material/Image";
import Modal from "../../components/Modal/Modal";

const CategoryPage = () => {
  const [searchString, setSearchString] = useState("");
  const [showModal, setShowModal] = useState(false);
  const [newCategory, setNewCategory] = useState({
    id: categories.length + 1,
    name: "",
    description: "",
    thumbnail: "",
  });
  const [updatedRows, setUpdatedRows] = useState([...categories]);
  const [editingCategoryId, setEditingCategoryId] = useState(null);

  const handleInputChange = (field, value) => {
    setNewCategory({ ...newCategory, [field]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (editingCategoryId !== null) {
      // Update existing category
      const updatedCategories = updatedRows.map((category) =>
        category.id === editingCategoryId ? { ...newCategory, id: editingCategoryId } : category
      );
      setUpdatedRows(updatedCategories);
      setEditingCategoryId(null);
    } else {
      // Add new category
      const updatedCategories = [...updatedRows, { ...newCategory }];
      setUpdatedRows(updatedCategories);
    }

    setNewCategory({
      id: updatedRows.length + 1,
      name: "",
      description: "",
      thumbnail: "",
    });
    setShowModal(false);
  };

  const onDrop = (acceptedFiles) => {
    const file = acceptedFiles[0];
    const reader = new FileReader();

    reader.onload = (event) => {
      const imageUrl = event.target.result;
      setNewCategory({ ...newCategory, thumbnail: imageUrl });
    };

    reader.readAsDataURL(file);
  };

  const { getRootProps, getInputProps } = useDropzone({
    accept: "image/*",
    onDrop,
  });

  const toggleModal = () => {
    setShowModal(!showModal);
    setEditingCategoryId(null);
  };

  const handleCloseModal = () => {
    setNewCategory({
      id: updatedRows.length + 1,
      name: "",
      description: "",
      thumbnail: "",
    });
    setShowModal(false);
    setEditingCategoryId(null);
  };

  const handleEdit = (categoryId) => {
    setEditingCategoryId(categoryId);
    const categoryToEdit = updatedRows.find((category) => category.id === categoryId);
    setNewCategory({ ...categoryToEdit });
    setShowModal(true);
  };

  const handleDelete = (categoryId) => {
    const updatedCategories = updatedRows.filter((category) => category.id !== categoryId);
    setUpdatedRows(updatedCategories);
  };

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
    {
      field: "actions",
      headerName: "Actions",
      width: 150,
      headerAlign: "center",
      align: "center",
      sortable: false,
      renderCell: (rowData) => {
        return (
          <div className="flex items-center justify-center space-x-2">
            <EditIcon
              className="cursor-pointer z-50"
              onClick={() => handleEdit(rowData.row.id)}
            />
            <DeleteIcon
              className="cursor-pointer z-50"
              onClick={() => handleDelete(rowData.row.id)}
            />
          </div>
        );
      },
    },
  ];

  return (
    <div className="min-h-screen flex flex-col">
      <div className="flex pb-2 border-b-2 border-primary-light items-center justify-between">
        <Search
          search={searchString}
          onSetSearch={setSearchString}
          onSubmit={handleSubmit}
          className="flex-1"
        />
        <UserMask />
      </div>
      <div className="flex-1 p-5 flex flex-col">
        <h1 className="text-3xl font-bold text-gray-700 mb-1">CATEGORY</h1>
        <div className="bg-primary-light w-[154px] h-[3px] rounded-[4px] mb-5" />
        <button
          onClick={toggleModal}
          className="w-full max-w-fit mb-10 flex items-center gap-x-2 text-white text-xl font-semibold uppercase rounded-md px-4 py-3 bg-primary transition duration-150 hover:bg-primary-light"
        >
          
              Add category
              <AddIcon />
         
        </button>
        {showModal && (
          <Modal onClose={handleCloseModal}>
            <form onSubmit={handleSubmit} className="flex flex-col space-y-4">
              <div className="flex flex-col mb-4">
                <label htmlFor="categoryName" className="text-sm font-semibold text-gray-600">
                  Category Name
                </label>
                <input
                  id="categoryName"
                  className="border-none outline-none py-2 px-3 rounded-[4px] bg-gray-100"
                  type="text"
                  placeholder="Enter category name"
                  value={newCategory.name}
                  onChange={(e) => handleInputChange("name", e.target.value)}
                />
              </div>
              <div className="flex flex-col mb-4">
                <label htmlFor="categoryDescription" className="text-sm font-semibold text-gray-600">
                  Category Description
                </label>
                <textarea
                  id="categoryDescription"
                  placeholder="Enter category description"
                  value={newCategory.description}
                  onChange={(e) => handleInputChange("description", e.target.value)}
                  className="border-none outline-none py-2 px-3 rounded-[4px] bg-gray-100 h-32 resize-none"
                />
              </div>

              <div className="flex flex-col mb-4 cursor-pointer">
                <label htmlFor="foodThumbnail" className="text-sm font-semibold text-gray-600">
                  Food Image
                </label>
                <div {...getRootProps()} className="dropzone" style={{ border: '2px dashed #ccc', borderRadius: '8px', padding: '16px', textAlign: 'center' }}>

                  {newCategory.thumbnail ? (
                    <img
                      src={newCategory.thumbnail}
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
                  {editingCategoryId !== null ? "Update Category" : "Add Category"}
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
        <div className="flex-1">
          <AdminTable
            rows={updatedRows}
            columns={columns}
            pageSizeOptions={[10, 20, 30, 40, 50]}
          />
        </div>
      </div>
    </div>
  );
};

export default CategoryPage;
