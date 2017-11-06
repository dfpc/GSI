function validateForm() {
    var error = false;
    if ($('#tbxPassword').val() == '') {
        error = true;
        $('#tbxPassword').addClass("is-invalid");
    }
    else
        $('#tbxPassword').removeClass("is-invalid");
    if ($('#tbxPasswordConfirm').val() == '') {
        error = true;
        $('#tbxPasswordConfirm').addClass("is-invalid");
    }
    else
        $('#tbxPasswordConfirm').removeClass("is-invalid");
    if ($('#inputUsername').val() == '') {
        error = true;
        $('#inputUsername').addClass("is-invalid");
    }
    else
        $('#inputUsername').removeClass("is-invalid");
    if ($('#tbxEmail').val() == '') {
        error = true;
        $('#tbxEmail').addClass("is-invalid");
    }
    else
        $('#tbxEmail').removeClass("is-invalid");
    if ($('#tbxPassword').val() != '' && $('#tbxPasswordConfirm').val() != '') {
        if ($('#tbxPassword').val() != $('#tbxPasswordConfirm').val()) {
            error = true;
            $('#tbxPasswordConfirm').addClass("is-invalid");
            $('#tbxPassword').addClass("is-invalid");
        }
        else {
            $('#tbxPasswordConfirm').removeClass("is-invalid");
            $('#tbxPassword').removeClass("is-invalid");
        }
    }

    return error;
}

function CheckLoginData() {
    var error = false;
    if ($('#tbxUsername').val() == ''){
        $('#tbxUsername').addClass("is-invalid");
        error = true;
    }
    else
        $('#tbxUsername').removeClass("is-invalid");

    if ($('#tbxPassword').val() == ''){
        $('#tbxPassword').addClass("is-invalid");
        error = true;
    }
    else
        $('#tbxPassword').removeClass("is-invalid");
    return error;
}