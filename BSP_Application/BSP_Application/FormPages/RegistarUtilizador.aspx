<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistarUtilizador.aspx.cs" Inherits="BSP_Application.FormPages.RegistarUtilizador" %>

<%@ Register Src="~/UserControls/MainMenu.ascx" TagPrefix="uc1" TagName="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftSide" runat="server">
    <uc1:MainMenu runat="server" ID="MainMenu1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="card card-outline-secondary my-4">
        <div class="card-body">
            <div class="container-fluid">

                <h4>Registar Novo Utilizador</h4>
                <div class="box-body" style="margin-top: 50px;">
                    <div class="form-group">
                        <label for="inputUsername" class="control-label">Username *</label>
                        <div class="row">
                            <div class="col-lg-8">
                                <input type="text" class="form-control" id="inputUsername" placeholder="Username" runat="server" clientidmode="static">
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="tbxPassword" class="control-label">Password *</label>
                        <div class="row">
                            <div class="col-lg-8">
                                <input type="password" class="form-control" id="tbxPassword" placeholder="Password" runat="server" clientidmode="static" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="tbxPasswordConfirm" class="control-label">Confirmação de Password *</label>
                        <div class="row">
                            <div class="col-lg-8">
                                <input type="password" class="form-control" id="tbxPasswordConfirm" placeholder="Password" runat="server" clientidmode="static" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="tbxEmail" class="control-label">Email *</label>
                        <div class="row">
                            <div class="col-lg-8">
                                <input type="email" class="form-control" id="tbxEmail" placeholder="exemplo@email.pt" runat="server" clientidmode="static" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-lg-8">
                                <label for="tbxNome" class="control-label">Nome</label>
                                <input type="text" class="form-control" id="tbxNome" placeholder="Nome" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row" style="float:right;">
                        <div class="col-lg-12">
                            <asp:Button ID="SaveButton" CssClass="btn btn-block btn-success" runat="server" Text="Guardar" OnClick="SaveButton_Click" OnClientClick="return !validateForm();" />
                        </div>
                    </div>
                </div>

            </div>
            <!-- /.card -->
        </div>
        <!-- /.col-lg-9 -->
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
