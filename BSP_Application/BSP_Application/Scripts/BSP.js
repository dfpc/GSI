﻿function validateForm() {
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
    if ($('#tbxUsername').val() == '') {
        $('#tbxUsername').addClass("is-invalid");
        error = true;
    }
    else
        $('#tbxUsername').removeClass("is-invalid");

    if ($('#tbxPassword').val() == '') {
        $('#tbxPassword').addClass("is-invalid");
        error = true;
    }
    else
        $('#tbxPassword').removeClass("is-invalid");
    return error;
}

function ValidateProcessFields() {
    var error = false;
    if ($('#inputNome').val() == '') {
        $('#inputNome').addClass("is-invalid");
        error = true;
    }
    else
        $('#inputNome').removeClass("is-invalid");
    return error;
}

function ValidateOrganizationFields() {
    var error = false;
    if ($('#inputNome').val() == '') {
        $('#inputNome').addClass("is-invalid");
        error = true;
    }
    else
        $('#inputNome').removeClass("is-invalid");
    return error;
}

function ValidateEntidadeFields() {
    var error = false;
    if ($('#inputNome').val() == '') {
        $('#inputNome').addClass("is-invalid");
        error = true;
    }
    else
        $('#inputNome').removeClass("is-invalid");
    return error;
}

function editProject(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $.ajax({
        url: "/Conteudos/ConsultarProjetos.aspx/EditProject",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        data: JSON.stringify({ index: index }),
        success: function (data) {
            if (data.d != '')
                window.location = data.d;
        }
    });
}

function editProcess(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $.ajax({
        url: "/Conteudos/ConsultarProcesso.aspx/EditProcess",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        data: JSON.stringify({ index: index }),
        success: function (data) {
            if (data.d != '')
                window.location = data.d;
        }
    });
}

function EditOrganization(btn){
    var index = btn.parentNode.parentNode.rowIndex;
    $.ajax({
        url: "/Conteudos/ConsultarOrganizacao.aspx/EditOrganization",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        type: 'POST',
        data: JSON.stringify({ index: index }),
        success: function (data) {
            if (data.d != '')
                window.location = data.d;
        }
    });
}

$(".simple-btn").click(function (evt) {
    // This stops the form submission.
    evt.preventDefault();
});

function DeleteEntidade() {
    $.ajax({
        type: 'POST',
        url: "/Conteudos/ConsultarEntidades.aspx/DeleteEntidade",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ index: $('#lkbDeleteEntity').attr('data-index') }),
        success: function (data) {
            if (data.d == true)
                window.location = window.location;
            else {
                $('#deleteConfirm').modal('hide');
                $('#DeleteError').modal();
            }
        }
    });
}

function ShowModal(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $('#lkbDeleteEntity').attr('data-index', index);
    $('#deleteConfirm').modal();
}

var projects = [];
function SelectProject(check) {
    var index = check.parentNode.parentNode.rowIndex;
    if (check.checked)
        projects.push(index);
    else
        for (i = 0; i < projects.length; i++)
            if (projects[i] == index)
                projects.splice(i, 1);
}

function SaveOrganization() {
    if (!ValidateOrganizationFields()) {
        $.ajax({
            type: 'POST',
            url: "/FormPages/AdicionarOrganizacao.aspx/SaveOrganization",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ nome: $('#inputNome').val(), descricao: $('#comment').val(), projetos: projects, id: $('#hdIdOrganizacao').val() }),
            success: function (data) {
                window.location = "/Conteudos/ConsultarOrganizacao.aspx";
            }
        });
    }
}