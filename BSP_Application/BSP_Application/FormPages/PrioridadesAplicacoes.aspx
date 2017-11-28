<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrioridadesAplicacoes.aspx.cs" Inherits="BSP_Application.FormPages.PrioridadesAplicacoes" %>

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
                <h4>Definir prioridades das aplicações</h4>
                <br />
                <br /> 
                <div class="row">
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label  for="inpTeste1">Aplicações</label>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label  for="inpTeste1">Beneficios Potenciais</label>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label  for="inpTeste1">Impacto</label>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label  for="inpTeste1">Probabilidade de Sucesso</label>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label  for="inpTeste1">Procura</label>
                        </div>
                    </div>
                </div>
        <ul class="nav row" runat="server" id="ulPrioridades">
        </ul>
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col-lg-9 -->

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button cssclass="btn btn-block btn-success" runat="server" id="btnSavePrioridades" OnClick="btnSavePrioridades_Click" style="width: 20%" Text="Guardar"></asp:Button>
                <br />
            </div>
        </div>
    </div>
    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
