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

function editApplication(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $.ajax({
        url: "/Conteudos/ConsultarAplicacoes.aspx/EditApplication",
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






function editClasseDados(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $.ajax({
        url: "/Conteudos/ConsultarClasseDados.aspx/EditClass",
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

function DeleteProblema() {
    $.ajax({
        type: 'POST',
        url: "/Conteudos/ConsultarSumariacaoEntrevistas.aspx/DeleteProblem",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ index: $('#lkbDeleteProblem').attr('data-index') }),
        success: function (data) {
            if (data.d == true)
                window.location = window.location;
            else {
                $('#deleteConfirmProblem').modal('hide');
                $('#DeleteError').modal();
            }
        }
    });
}



function DeleteProjeto() {
    $.ajax({
        type: 'POST',
        url: "/Conteudos/ConsultarProjetos.aspx/DeleteProject",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ index: $('#lkbDeleteProject').attr('data-index') }),
        success: function (data) {
            if (data.d == true)
                window.location = window.location;
            else {
                $('#deleteConfirmProject').modal('hide');
                $('#DeleteError').modal();
            }
        }
    });
}

function DeleteClasse() {
    $.ajax({
        type: 'POST',
        url: "/Conteudos/ConsultarClasseDados.aspx/DeleteClass",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ index: $('#lkbDeletClass').attr('data-index') }),
        success: function (data) {
            if (data.d == true)
                window.location = window.location;
            else {
                $('#deleteConfirmClass').modal('hide');
                $('#DeleteError').modal();
            }
        }
    });
}




function DeleteProcesso() {
    $.ajax({
        type: 'POST',
        url: "/Conteudos/ConsultarProcesso.aspx/DeleteProcess",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ index: $('#lkbDeletProcess').attr('data-index') }),
        success: function (data) {
            if (data.d == true)
                window.location = window.location;
            else {
                $('#deleteConfirmProcess').modal('hide');
                $('#DeleteError').modal();

            }
        }
    });
}
function DeleteAplicacao() {
    $.ajax({
        type: 'POST',
        url: "/Conteudos/ConsultarAplicacoes.aspx/DeleteApplication",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ index: $('#lkbDeleteApplication').attr('data-index') }),
        success: function (data) {
            if (data.d == true)
                window.location = window.location;
            else {
                $('#deleteConfirmApplication').modal('hide');
                $('#DeleteError').modal();

            }
        }
    });
}

function DeleteEntOrganizacao() {
    $.ajax({
        type: 'POST',
        url: "/Conteudos/ConsultarOrganizacao.aspx/DeleteOrgEntity",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ index: $('#lkbDeleteOrgEntity').attr('data-index') }),
        success: function (data) {
            if (data.d == true)
                window.location = window.location;
            else {
                $('#deleteConfirmModalOrganization').modal('hide');
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


function showModalProcess(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $('#lkbDeletProcess').attr('data-index', index);
    $('#deleteConfirmProcess').modal();
}

function showModalProject(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $('#lkbDeleteProject').attr('data-index', index);
    $('#deleteConfirmProject').modal();
}

function showModalClass(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $('#lkbDeletClass').attr('data-index', index);
    $('#deleteConfirmClass').modal();
}

function showModalApplication(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $('#lkbDeleteApplication').attr('data-index', index);
    $('#deleteConfirmApplication').modal();
}

function showModalProblem(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $('#lkbDeleteProblem').attr('data-index', index);
    $('#deleteConfirmProblem').modal();
}

function showModalOrgEntity(btn) {
    var index = btn.parentNode.parentNode.rowIndex;
    $('#lkbDeleteOrgEntity').attr('data-index', index);
    $('#deleteConfirmModalOrganization').modal();
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
            if (value == '') {
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

var proc_CD = [];
var firstget_proc_CD = true;
function Proc_ClasseChange(selectedValue, IDProcesso, idclasse) {
    if (firstget_proc_CD) {
        $.ajax({
            type: 'POST',
            url: "/Matrizes/Processo_ClasseDados.aspx/FirstGet",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: {},
            success: function (data) {
                for (i = 0; i < data.d.lenght; i++)
                    proc_CD.push(data.d[i]);
            }
        });
        firstget_proc_CD = false;
    }
    var exists = false;
    for (i = 0; i < proc_CD.length; i++) {
        if (proc_CD[i].IDProcesso == IDProcesso && proc_CD[i].IDClasseDados == idclasse) {
            exists = true;
            if (selectedValue == '') {
                proc_CD.splice(i, 1);
                return;
            }
            proc_CD[i].Value = selectedValue;
            break;
        }
    }
    if (selectedValue == '') return;
    if (!exists) {
        proc_CD.push({
            IDProcesso: IDProcesso, IDClasseDados: idclasse, Value: selectedValue
        });
    }
    firstget_proc_CD = false;
}

var app_CD = [];
var firstget_app_CD = true;
function app_CDChange(selectedValue, IDCD, idapp) {
    if (firstget_app_CD) {
        $.ajax({
            type: 'POST',
            url: "/Matrizes/Processo_ClasseDados.aspx/FirstGet",
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

function SaveProcessClasseMatrix() {
    $.ajax({
        type: 'POST',
        url: "/Matrizes/Processo_ClasseDados.aspx/SaveProcesso_Classe",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ processClasse: proc_CD }),
    });
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

function SaveProcessClassData() {
    var controls = document.getElementsByClassName("process-selection");
    var selections = [];
    for (i = 0; i < controls.length; i++)
        selections[i] = controls[i].value;

    $.ajax({
        type: 'POST',
        url: "/Matrizes/Processo_ClasseDados_1.aspx/SaveClassDataProcess",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ array: selections, idproject: $('#ListaProjetos').val() }),
        success: function (data) {
            if (data.d != '')
                window.location = data.d;
            else {
                $('#NextError').modal();
            }
        }
    });
}


function getPrioridades() {
    var prioridades = new Array;
    var size = document.getElementsByClassName("row").length;
    for (var i = 3; i < size; i++) {
            var aux = document.getElementsByClassName("row")[i].getElementsByTagName("input");
            var beneficio = aux[0].val;
            var impacto = aux[1].val;
            var probabilidade = aux[2].val;
            var procura = aux[3].val;

            prioridades.push(beneficio);
            prioridades.push(impacto);
            prioridades.push(probabilidade);
            prioridades.push(procura);
    }

    $.ajax({
        type: 'POST',
        url: "/FormPages/PrioridadesAplicacoes.aspx/SavePriority",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ array: prioridades}),
        success: function (data) {
            if (data.d != '')
                window.location = data.d;
            else {
                
            }
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
var group = [];
function selectPosition(td, idprocess, idclass) {
    if (td.className.indexOf("tdSelected") >= 0) {
        td.className = ("Table-style");
        for (i = 0; i < group.lenght; i++)
            if (group[i] == idprocess + "|" + idclass)
                group.splice(i, 1);
    }
    else {
        td.className = ("Table-style tdSelected");
        group.push(idprocess + "|" + idclass);
        $('#divGrupButton').attr("style", "display:block");
    }
}

function SaveGroup() {
    if ($('#groupName').val() != '') {
        $.ajax({
            type: 'POST',
            url: "/Matrizes/Processo_ClasseDados.aspx/SaveGroup",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ group: group, name: $('#groupName').val() }),
            success: function (data) {
                group = [];
                $('#divGrupButton').attr("style", "display:none");
            }
        });
    }
}