﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarOrganizacao.aspx.cs" Inherits="BSP_Application.Conteudos.ConsultarOrganizacao" %>

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

                <h4>Consultar Entidades da Organização</h4>
                <br />
                <br />
                <center>
                <asp:GridView ID="gdvOrganizacao" runat="server" DataKeyNames="Id" CellPadding="5" AutoGenerateColumns="false">
                    <Columns>
                         <asp:BoundField DataField="Nome" HeaderText="Nome" ReadOnly="True" SortExpression="Nome" />
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" ReadOnly="True" SortExpression="Tipo" />
                        <asp:TemplateField>
                            <ItemTemplate>
                              <button class="btn btn-block simple-btn" onclick="EditOrganization(this);" style="background-color:#FFFFFF; cursor: pointer; color:green"><i class="fa fa-pencil fa-lg" aria-hidden="true"></i></button>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>

                                <button  class="btn btn-block simple-btn" style="background-color:#FFFFFF; cursor: pointer; color:red"  data-toggle="modal" runat="server" type="button" onclick="showModalOrgEntity(this);"  data-postcommand="">
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
    <!-- /.container -->

    <div class="modal fade" id="deleteConfirmModalOrganization" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Remover Entidade da Organização</h4>
                        <button type="button" class="close simple-btn" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        Confirma que pretende eliminar esta Entidade da Organização?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default simple-btn" data-dismiss="modal">Cancelar</button>
                    <button id="lkbDeleteOrgEntity" runat="server" clientidmode="Static" onclick="DeleteEntOrganizacao();" class="btn btn-primary simple-btn">Confirmar</button>
                    </div>
                </div>
            </div>
        </div>

         <div class="modal fade" id="DeleteError" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="alert alert-danger">
                      <strong>Erro!</strong> Não foi possível eliminar a Entidade da Organização.
                    </div>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    Por favor verifique se tem dados associados à Entidade da Organização!
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
