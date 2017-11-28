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
                for (i = 0; i < data.d.lenght; i++)
                    App_Process.push(data.d[i]);
            }
        });
        firstget_AppProcess = false;
    }
    var value = '';
    if (selectedValue == "1")
        value = "A";
    else if (selectedValue == "2")
        value = "P";
    else if (selectedValue == "3")
        value = "A/P";
    var exists = false;
    for (i = 0; i < App_Process.length; i++) {
        if (App_Process[i].IDApp == IDApp && App_Process[i].IDProcess == IDProcess) {
            exists = true;
            if (value == '') {
                App_Process.splice(i, 1);
                return;
            }
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
var firstget_OrgProcess = true;
function Proc_OrganizacaoChange(selectedValue, IDOrg, IDProcess) {
    if (firstget_AppProcess) {
        $.ajax({
            type: 'POST',
            url: "/Matrizes/ProcessoOrganizacao.aspx/FirstGet",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: {},
            success: function (data) {
                for (i = 0; i < data.d.lenght; i++)
                    Org_Process.push(data.d[i]);
            }
        });
        firstget_OrgProcess = false;
    }

    var exists = false;
    for (i = 0; i < Org_Process.length; i++) {
        if (Org_Process[i].IDOrg == IDOrg && Org_Process[i].IDProcess == IDProcess) {
            exists = true;
            if (value == '') {
                Org_Process.splice(i, 1);
                return;
            }
            Org_Process[i].Value = selectedValue;
        }
    }

    if (!exists) {
        Org_Process.push({
            IDOrg: IDOrg, IDProcess: IDProcess, Value: selectedValue
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

var app_Org = [];
var firstget_app_Org = true;
function app_OrganizacaoChange(selectedValue, IDOrg, idapp) {
    if (firstget_app_Org) {
        $.ajax({
            type: 'POST',
            url: "/Matrizes/App_Organizacao.aspx/FirstGet",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: {},
            success: function (data) {
                for (i = 0; i < data.d.lenght; i++)
                    app_Org.push(data.d[i]);
            }
        });
        firstget_app_Org = false;
    }
    var value = '';
    if (selectedValue == "1")
        value = "A";
    else if (selectedValue == "2")
        value = "P";
    else if (selectedValue == "3")
        value = "A/P";
    var exists = false;
    for (i = 0; i < app_Org.length; i++) {
        if (app_Org[i].IDOrg == IDOrg && app_Org[i].IDApp == idapp) {
            exists = true;
            if (value == ''){
                app_Org.splice(i, 1);
                return;
            }
            app_Org[i].Value = value;
            break;
        }
    }
    if (value == '') return;
    if (!exists) {
        app_Org.push({
            IDOrg: IDOrg, IDApp: idapp, Value: value
        });
    }
}

function SaveAppOrgMatrix() {
    $.ajax({
        type: 'POST',
        url: "/Matrizes/App_Organizacao.aspx/SaveApp_Organization",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ appOrganization: app_Org }),
        success: function (data) {
        }
    });
}

var app_CD = [];
var firstget_app_CD = true;
function app_CDChange(selectedValue, IDCD, idapp) {
    if (firstget_app_CD) {
        $.ajax({
            type: 'POST',
            url: "/Matrizes/App_Organizacao.aspx/FirstGet",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: {},
            success: function (data) {
                for (i = 0; i < data.d.lenght; i++)
                    app_CD.push(data.d[i]);
            }
        });
        firstget_app_CD = false;
    }
    var exists = false;
    for (i = 0; i < app_CD.length; i++) {
        if (app_CD[i].IDClasseDados == IDCD && app_CD[i].IDApp == idapp) {
            exists = true;
            if (selectedValue == '') {
                app_CD.splice(i, 1);
                return;
            }
            app_CD[i].Value = selectedValue;
            break;
        }
    }
    if (selectedValue == '') return;
    if (!exists) {
        app_CD.push({
            IDClasseDados: IDCD, IDApp: idapp, Value: selectedValue
        });
    }
}

function SaveAppCDMatrix() {
    $.ajax({
        type: 'POST',
        url: "/Matrizes/App_ClasseDados.aspx/SaveApp_CD",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ appCD: app_CD }),
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
