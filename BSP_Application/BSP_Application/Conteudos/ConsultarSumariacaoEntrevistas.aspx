<%@ Page  Title=""  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarSumariacaoEntrevistas.aspx.cs" Inherits="BSP_Application.Conteudos.ConsultarSumariacaoEntrevistas" %>


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

                <h4>Consultar Sumariação de Entrevistas</h4>
                <br />
                <br />
                <center>
                <asp:GridView ID="gdvEntrevistas"  runat="server"  CellPadding="10" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="GrupoProcesso" HeaderText="Grupo de Processos" ReadOnly="True" SortExpression="GrupoProcesso" />
                        <asp:BoundField DataField="Causa" HeaderText="Causa" ReadOnly="True" SortExpression="Causa" />
                        <asp:BoundField DataField="Efeito" HeaderText="Efeito" ReadOnly="True" SortExpression="Efeito" />
                        <asp:BoundField DataField="Importancia" HeaderText="Importância" ReadOnly="True" SortExpression="Importancia" />
                        <asp:BoundField DataField="ProcessoC" HeaderText="Processo Causador" ReadOnly="True" SortExpression="ProcessoC" />
                        <asp:BoundField DataField="ClasseC" HeaderText="Classe de Dados Criadora" ReadOnly="True" SortExpression="ClasseC" />
                        <asp:BoundField DataField="PotencialSolucao" HeaderText="Solução Potencial" ReadOnly="True" SortExpression="PotencialSolucao" />

                        <asp:TemplateField>
                             <ItemTemplate>
                              <button class="btn btn-block simple-btn" onclick="editSumariacao(this);" style="background-color:#FFFFFF; cursor: pointer; color:green"><i class="fa fa-pencil fa-lg" aria-hidden="true"></i></button>
                            </ItemTemplate>
                       </asp:TemplateField>
                                                <asp:TemplateField>

                            <ItemTemplate>
                               <!-- <button class="btn btn-block" style="background-color:#FFFFFF; cursor: pointer; color:red"><i class="fa fa-trash-o fa-lg" aria-hidden="true"></i></button>-->
                                  <button  class="btn btn-block simple-btn" style="background-color:#FFFFFF; cursor: pointer; color:red" runat="server" type="button">
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
