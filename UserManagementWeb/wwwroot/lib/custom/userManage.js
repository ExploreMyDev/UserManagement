var url = "http://localhost:25403/api/values";

$(document).ready(function () {
    $("#idDob").datepicker();
    fnDisplayAllUsers();
});

function fnDisplayAllUsers() {

    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function (data) {
            $('.item').remove();
            if (data.length > 0) {
                $.each(data, function (key, value) {
                    $('#idUserList').append("<div class='list item'>" + value.Name + "</div><div class='list item'>" + value.DateOfBirth + "</div>");
                   
                });
            }
            else {
                $('#idUserList').append("<div class='list item'>No records found.</div>");
            }
           
        },
    });
}

function fnSaveDetails() {
    if (fnvalidateFrom())
        fnSaveUserDetails();
}

function fnSaveUserDetails() {
    var objUser = {
        Name: $('#idName').val(),
        DateOfBirth: $('#idDob').val()
    };
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        data: JSON.stringify(objUser),
        success: function (data) {
            $('#idName').val('');
            $('#idDob').val('');
            fnDisplayAllUsers();
            alert('User added successfully.');
        },
    });
}

function fnvalidateFrom() {
    var status = true;
    if ($('#idName').val() == "") {
        status = false;
        $('#idName').addClass('validationerror');
    }
    else {
        $('#idName').removeClass('validationerror');
    }

    return status;
}