<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarOrganizacao.aspx.cs" Inherits="BSP_Application.Conteudos.ConsultarOrganizacao" %>

<%@ Register Src="~/UserControls/MainMenu.ascx" TagPrefix="uc1" TagName="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftSide" runat="server">
    <uc1:MainMenu runat="server" ID="MainMenu1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!-- Page Content -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div class="card card-outline-secondary my-4">
        <div class="card-body">
            <div class="container-fluid">

                <h4>Consultar Organizações</h4>
                <br />
                <br />
                <center>
                <asp:GridView ID="gdvOrganizacao" runat="server" DataKeyNames="Id" CellPadding="5">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                              <button class="btn btn-block" style="background-color:#FFFFFF; cursor: pointer; color:green"><i class="fa fa-pencil fa-lg" aria-hidden="true"></i></button>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>

                                <button  class="btn btn-block" style="background-color:#FFFFFF; cursor: pointer; color:red"  data-toggle="modal" runat="server" type="button" data-target="#deleteConfirmModal" data-postcommand="">
                                    <i class="fa fa-trash-o fa-lg" aria-hidden="true"></i></button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    </center>
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col-lg-9 -->
    </div>
    <!-- /.container -->

    <div class="modal fade" id="deleteConfirmModal" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Remover organização</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        Confirma que pretende eliminar esta Organização?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <asp:LinkButton ID="lkbDeleteOrganization" runat="server" ClientIDMode="Static" OnClick="lkbDeleteOrganization_Click" CssClass="btn btn-primary">Confirmar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
