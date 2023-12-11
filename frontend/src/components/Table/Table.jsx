import { DataGrid, GridToolbar } from "@mui/x-data-grid";

export default function AdminTable({ rows, columns, pageSizeOptions }) {
    return (
        <div style={{ width: "100%" }} className="mt-8">
            <DataGrid
                autoHeight
                rows={rows}
                columns={columns}
                initialState={{
                    pagination: {
                        paginationModel: {
                            page: 0,
                            pageSize: pageSizeOptions[0],
                        },
                    },
                }}
                pageSizeOptions={pageSizeOptions}
                checkboxSelection
                slots={{ toolbar: GridToolbar }}
                style={{ fontSize: 16 }}
                density="comfortable"
            />
        </div>
    );
}
