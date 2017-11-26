<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistoAplicacoes.aspx.cs" Inherits="BSP_Application.FormPages.RegistoAplicacoes" %>

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

                <h4>Registar Aplicações</h4>
                <br />
                <br />
                <div class="box-body">
                    <div class="form-group">
                        
                        <label for="ListaProjetos" class="col-sm-4 control-label">Projeto Associado</label>
                        <div class="col-sm-8">
                        <asp:DropDownList ID="ListaProjetos" class="form-control" runat="server" style="width:40%"/>
                           <br />

                        </div>
                        <label for="inputEmail3" class="col-sm-4 control-label">Nome da Aplicação</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" id="inputNome" placeholder="Nome da Aplicação" runat="server" clientidmode="static">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="comment" class="col-sm-2 control-label">Descrição</label>

                        <div class="col-sm-8">
                            <textarea class="form-control" rows="5" id="comment" placeholder="Descrição" runat="server"></textarea>
                        </div>
                    </div>
                 

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button ID="registaraplicacao" runat="server" class="btn-block btn-success" style="width: 20%" Text="Guardar" OnClick="registaraplicacao_Click"/>
                            <br />

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
