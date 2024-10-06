var dtble;
$(document).ready(function () {
    loaddata();
});

function loaddata() {
    dtble = $("#table").DataTable({
        "ajax": {
            "url": "/Admin/User/GetAllData"
        },
        "columns": [
            { "data": "name" },
            { "data": "email" },
            { "data": "address" },
            {
                "data": "id",
                "render": function (data, type, row) {
                    const isLockedOut = row.lockoutEnabled === true && row.lockoutEnd !== null && new Date(row.lockoutEnd) > new Date();

                    return `
                        <div class="form-check form-switch ps-0">
                            <input class="form-check-input ms-auto lock-switch" type="checkbox" id="flexSwitchCheckDefault_${data}" data-id="${data}" ${isLockedOut ? 'checked' : ''}>
                        </div>
                    `;
                }
            }
        ]
    });

    // Add event listener for dynamically generated checkboxes
    $('#table').on('change', '.lock-switch', function () {
        var userId = $(this).data('id');
        //var isLocked = $(this).is(':checked');

        // AJAX request to trigger LockUnlock method
        $.ajax({
            url: `/Admin/User/LockUnlock/${userId}`,
            type: 'POST',
            data: JSON.stringify({ id: userId }),
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                
            },
            error: function () {
                alert("Error during the request.");
            }
        });
    });
}
