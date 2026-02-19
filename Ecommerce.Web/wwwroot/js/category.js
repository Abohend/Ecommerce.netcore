var dtble;
$(document).ready(function () {
    loaddata();
});

function loaddata() {
    dtble = $("#table").DataTable({
        "responsive": true,
        "ajax": {
            "url": "/Admin/Categories/GetAllData"
        },
        "pageLength": 5,
        "lengthMenu": [[5, 7, 10, 15], [5, 7, 10, 15]],
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { 
                 "data": "createdTime",
                 "render": function(data) {
                     return new Date(data).toLocaleString();
                 }
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <a href="/Admin/Categories/Edit/${data}" class="btn btn-outline-warning">Edit</a>
                            <a onClick=DeleteItem("/Admin/Categories/Delete/${data}") class="btn btn-outline-danger">Delete</a>
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
