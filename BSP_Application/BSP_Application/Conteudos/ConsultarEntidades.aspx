<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarEntidades.aspx.cs" Inherits="BSP_Application.Conteudos.ConsultarEntidades" %>

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

                <h4>Consultar Entidades</h4>
                <br />
                <br />
                <center>
                <asp:GridView ID="gdvEntidades"  runat="server"  CellPadding="10" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Nome" HeaderText="Nome" ReadOnly="True" SortExpression="Nome" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" ReadOnly="True" SortExpression="Tipo" />
                        <asp:TemplateField>
                            <ItemTemplate>
                               <!-- <button class="btn btn-block" style="background-color:#FFFFFF; cursor: pointer; color:red"><i class="fa fa-trash-o fa-lg" aria-hidden="true"></i></button>-->
                                  <button  class="btn btn-block" style="background-color:#FFFFFF; cursor: pointer; color:red" runat="server" type="button" onclick="ShowModal(this);">
                                    <i class="fa fa-trash-o fa-lg" aria-hidden="true"></i>
                                </button>
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
    <div class="modal fade" id="deleteConfirm" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">Remover Entidade</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    Confirma que pretende eliminar esta Entidade?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                    <button id="lkbDeleteEntity" runat="server" clientidmode="Static" onclick="DeleteEntidade();" class="btn btn-primary">Confirmar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="DeleteError" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="alert alert-danger">
                      <strong>Erro!</strong> Não foi possível eliminar a entidade.
                    </div>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    Por favor verifique se tem Classes de dados associadas a esta entidade!
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Ok</button>
                </div>
            </div>
        </div>
    </div>

    
    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
