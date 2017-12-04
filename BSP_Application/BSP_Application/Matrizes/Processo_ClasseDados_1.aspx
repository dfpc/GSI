<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Processo_ClasseDados_1.aspx.cs" Inherits="BSP_Application.Matrizes.Processo_ClasseDados_1" %>

<%@ Register Src="~/UserControls/MainMenu.ascx" TagPrefix="uc1" TagName="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftSide" runat="server">
    <uc1:MainMenu runat="server" ID="MainMenu1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!-- Page Content -->
    <div class="card card-outline-secondary my-4">
        <div class="card-body">
            <div class="container-fluid">
                <h4>Matriz Processos/Classe de Dados</h4>
                <br />
                <br />
                <label for="ListaProjetos" class="col-sm-4 control-label">Projeto Associado</label>
                <div class="col-sm-8">
                    <asp:DropDownList ID="ListaProjetos" ClientIDMode="Static" class="form-control" runat="server" Style="width: 40%" AutoPostBack="True" OnSelectedIndexChanged="ListaProjetos_SelectedIndexChanged" />
                    <br />
                </div>
                <div id="divProjectsForm" runat="server" class="col-sm-12">
                    Seleccione o Processo responsável pela criação de cada classe de dados
                    <br />
                </div>
                <br /> <br />
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <button ID="btnNext" Class="btn btn-block btn-success simple-btn" Style="width: 20%" runat="server" onclick="SaveProcessClassData();">Avançar</button>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="NextError" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="alert alert-danger">
                      <strong>Erro!</strong> Não é possível avançar.
                    </div>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    Cada processo tem que criar pelo menos uma classe de dados!
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default simple-btn" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
