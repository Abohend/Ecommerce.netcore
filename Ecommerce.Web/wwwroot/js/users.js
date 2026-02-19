var dtble;
$(document).ready(function () {
    loaddata();
});

function loaddata() {
    dtble = $("#table").DataTable({
        "responsive": true,
        "pageLength": 5,
        "lengthMenu": [[5, 7, 10, 15], [5, 7, 10, 15]],
        "ajax": {
            "url": "/Admin/User/GetAllData"
        },
        "columns": [
            { "data": "name" },
            { "data": "email" },
            { "data": "role" },
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
            success: function (response) {
                toastr.success("User lock status updated");
                console.log("Lock status updated");
            },
            error: function () {
                toastr.error("Error during the request.");
                // Revert checkbox if failed
                var checkbox = $(`#flexSwitchCheckDefault_${userId}`);
                checkbox.prop('checked', !checkbox.is(':checked'));
            }
        });
    });
}
