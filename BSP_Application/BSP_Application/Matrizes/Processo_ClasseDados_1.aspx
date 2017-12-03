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
                    <asp:DropDownList ID="ListaProjetos" class="form-control" runat="server" Style="width: 40%" AutoPostBack="True" OnSelectedIndexChanged="ListaProjetos_SelectedIndexChanged" />
                    <br />
                </div>
                <div id="divProjectsForm" runat="server" class="col-sm-12">
                    Seleccione o Processo responsável pela criação de cada classe de dados
                    <br />
                </div>
                <br /> <br />
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <button ID="btnNext" CssClass="btn btn-block btn-success" Style="width: 20%" runat="server" OnClick="btnNext_Click" Text="Avançar"/>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
