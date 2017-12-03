<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarClasseDados.aspx.cs" Inherits="BSP_Application.Conteudos.ConsultarClasseDados" %>

<%@ Register Src="~/UserControls/MainMenu.ascx" TagPrefix="uc1" TagName="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentLeftSide" runat="server">
    <uc1:MainMenu runat="server" ID="MainMenu1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!-- Page Content -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div class="card card-outline-secondary my-4">
        <div class="card-body">
            <div class="container-fluid">

                <h4>Consultar Classe de Dados</h4>
                <br />
                <br /> 
                <center>
                <asp:GridView ID="gdvClassesDados"  runat="server"  CellPadding="5" AutoGenerateColumns="false">
                    <Columns>
                         <asp:BoundField DataField="Nome" HeaderText="Nome" ReadOnly="True" SortExpression="Nome" />
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" ReadOnly="True" SortExpression="Tipo" />
                        <asp:BoundField DataField="Projeto" HeaderText="Projecto Associado" ReadOnly="True" SortExpression="Tipo" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <button class="btn btn-block simple-btn" style="background-color:#FFFFFF; cursor: pointer; color:green"><i class="fa fa-pencil fa-lg" aria-hidden="true"></i></button>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                               <!-- <button class="btn btn-block" style="background-color:#FFFFFF; cursor: pointer; color:red"><i class="fa fa-trash-o fa-lg" aria-hidden="true"></i></button>-->
                                  <button  class="btn btn-block simple-btn" style="background-color:#FFFFFF; cursor: pointer; color:red"  data-toggle="modal" runat="server" type="button" data-target="#deleteConfirmClass" data-postcommand="">
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
     <div class="modal fade" id="deleteConfirmClass" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModalLabel">Remover Classe de Dados</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        Confirma que pretende eliminar esta Classe de Dados?
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <asp:LinkButton ID="lkbDeleteClass" runat="server" ClientIDMode="Static" OnClick="lkbDeleteClass_Click" CssClass="btn btn-primary">Confirmar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
