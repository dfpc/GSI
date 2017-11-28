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

function editSumariacao(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $.ajax({
        url: "/Conteudos/ConsultarSumariacaoEntrevistas.aspx/EditSumariacao",
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

function EditOrganization(btn) {
   // var element = document.getElementsByTagName('h4');
    //element.innerHTML = 'Editar Organização';
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

var App_Process = [];
var firstget_AppProcess = true;
function App_ProcessoChange(selectedValue, IDApp, IDProcess) {
    if (firstget_AppProcess) {
        $.ajax({
            type: 'POST',
            url: "/Matrizes/App_Processo.aspx/FirstGet",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: {},
            success: function (data) {
            }
        });
        firstget_AppProcess = false;
    }
    var value = '';
    if (selectedValue == 1)
        value = "A";
    else if (selectedValue == 2)
        value = "P";
    else if (selectedValue == "3")
        value = "A/P";
    var exists = false;
    for (i = 0; i < App_Process.length; i++) {
        if (App_Process[i].IDApp == IDApp && App_Process[i].IDProcess == IDProcess) {
            exists = true;
            App_Process[i].Value = value;
        }
    }

    if (!exists) {
        App_Process.push({
            IDApp: IDApp, IDProcess: IDProcess, Value: value
        });
    }
}

function SaveAppProcessMatrix() {
    $.ajax({
        type: 'POST',
        url: "/Matrizes/App_Processo.aspx/SaveApp_Process",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ appProcess: App_Process }),
        success: function (data) {
        }
    });
}


var Org_Process = [];
function Proc_OrganizacaoChange(selectedValue, IDOrg, IDProcess) {
    var value = '';
    if (selectedValue == 1)
        value = "D";
    else if (selectedValue == 2)
        value = "F";
    else if (selectedValue == "3")
        value = "A";
    var exists = false;
    for (i = 0; i < Org_Process.length; i++) {
        if (Org_Process[i].IDOrg == IDOrg && App_Process[i].IDProcess == IDProcess) {
            exists = true;
            Org_Process[i].Value = value;
        }
    }

    if (!exists) {
        Org_Process.push({
            IDOrg: IDOrg, IDProcess: IDProcess, Value: value
        });
    }
}

function SaveOrgProcessMatrix() {
    $.ajax({
        type: 'POST',
        url: "/Matrizes/Processo_Organizacao.aspx/SaveOrg_Process",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ orgProcess: Org_Process }),
        success: function (data) {
        }
    });
}


/*var url = window.location.href;

var url_org = url.substring(23, 62);
var organizacao = "FormPages/AdicionarOrganizacao.aspx?id=";
if (url_org == organizacao)
{
    document.getElementsByTagName('h4').innerTHML = 'Editar Organização';

}
*/