<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdicionarProjeto.aspx.cs" Inherits="BSP_Application.FormPages.AdicionarProjeto" %>

<%@ Register Src="~/UserControls/MainMenu.ascx" TagPrefix="uc1" TagName="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentLeftSide" runat="server">
    <uc1:MainMenu runat="server" ID="MainMenu1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!-- Page Content -->
    <div class="card card-outline-secondary my-4">
        <div class="card-body">
            <div class="container-fluid">

                <h4 id="hTitle" runat="server">Registar Projeto</h4>
                <br />
                <br />
                <div class="box-body">
                    <div class="form-group">
                        <label for="inputNome" class="col-sm-4 control-label">Nome do Projeto</label>

                        <div class="col-sm-8">
                            <input type="text" class="form-control" id="inputNome" placeholder="Nome do Projeto" runat="server">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword3" class="col-sm-2 control-label">Descrição</label>

                        <div class="col-sm-8">
                            <textarea class="form-control" rows="5" id="comment" placeholder="Descrição" runat="server"></textarea>
                        </div>
                    </div>

                    <div class="form-group">

                        <div class="col-sm-offset-2 col-sm-10">
                           <!-- <button type="button" runat="server" class="btn btn-block btn-success" onclick="Guardar_Projeto"  style="width: 20%">Guardar</button>-->
                            <asp:Button ID="teste" runat="server" class="btn btn-block btn-success" style="width: 20%" Text="Guardar" OnClick="Guardar_Projeto" />
                            <br />

                        </div>
                    </div>
                </div>

            </div>
            <!-- /.card -->
        </div>
        <!-- /.col-lg-9 -->
    </div>
    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
