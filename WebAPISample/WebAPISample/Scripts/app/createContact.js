

    $().ready(function () {
        // on button click, show modal
        $('#btnShowAddContact').click(function () {
            $('#addContactModal').modal('show');
        });

        $('#btnSaveContact').click(function () {
            var contact = {};

            contact.Name = $("#name").val();
            contact.PhoneNumber = $("#phonenumber").val();

            $.ajax({
                url: '/api/contacts',
                data: { Name: $("#name").val(), PhoneNumber: $("#phonenumber").val() },
                //data: $("#myform").serialize()
                method: "POST"
            })

            $.post(uri, contact)
                .done(function (data) {
                    loadContacts();
                    $("#addContactModal").modal('hide')         
                })
                .fail(function (jqXHR, status, err) {
                    alert(status + " - " + err);
                })
        });
    });