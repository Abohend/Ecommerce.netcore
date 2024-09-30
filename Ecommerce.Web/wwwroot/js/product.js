var dtble;
$(document).ready(function () {
    loaddata();
});

function loaddata() {
    dtble = $("#table").DataTable({
        "ajax": {
            "url": "/Admin/Products/GetAllData"
        },
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <a href="/Admin/Products/Edit/${data}" class="btn btn-warning">Edit</a>
                            <a onClick=DeleteItem("/Admin/Products/Delete/${data}") class="btn btn-danger">Delete</a>
                            `

                }
            }

        ]
    });
}

function DeleteItem(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        dtble.ajax.reload();
                    }
                    else {
                        Swal.fire({
                            title: "Error!",
                            text: "Something went wrong",
                            icon: "error"
                        });
                    }
                }
            })
            Swal.fire({
                title: "Deleted!",
                text: "Your file has been deleted.",
                icon: "success"
            });
        }
    });
}