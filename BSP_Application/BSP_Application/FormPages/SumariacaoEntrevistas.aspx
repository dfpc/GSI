<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SumariacaoEntrevistas.aspx.cs" Inherits="BSP_Application.FormPages.SumariacaoEntrevistas" %>

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
                <h4>Sumariação de Entrevistas</h4>
                <br />
                <br />
                <!--<asp:GridView ID="gdvSumariacaoEntrevistas" runat="server" DataKeyNames="Id" CellPadding="5">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <button>Edit</button>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <button>Delete</button>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Button" InsertText="Novo" InsertVisible="true"  />
                    </Columns>
                </asp:GridView>-->

                                <div class="box-body">
                    <div class="form-group">
                        
   
                        <label for="inputEmail3" class="col-sm-4 control-label">Grupo de Processos</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" runat="server" id="grupo_processos" placeholder="Grupo de Processos"  clientidmode="static">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="comment" class="col-sm-2 control-label">Causa</label>

                        <div class="col-sm-8">
                            <textarea class="form-control" runat="server" rows="3" id="causa" placeholder="Causa"></textarea>
                        </div>
                    </div>
                        <div class="form-group">
                        <label for="comment" class="col-sm-2 control-label">Efeito</label>

                        <div class="col-sm-8">
                            <textarea class="form-control" runat="server" rows="3" id="efeito" placeholder="Efeito"></textarea>
                        </div>
                    </div>
                    </div>
                        <div class="form-group">
                        <label for="comment" class="col-sm-2 control-label">Importância</label>

                        <div class="col-sm-8">
                            <asp:DropDownList ID="ListaImportancia" class="form-control" runat="server" style="width:40%">
                                <asp:ListItem>Relativa</asp:ListItem>
                                <asp:ListItem>Cr&#237;tica</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                 <div class="form-group">
                <label for="inputEmail3" class="col-sm-4 control-label">Processo Causador</label>
                        <div class="col-sm-8">
                        <asp:DropDownList ID="ListaProcesso" class="form-control" runat="server" style="width:40%"/>
                        </div>                      
                </div>
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-4 control-label">Classe de Dados Criadora</label>
                        <div class="col-sm-8">
                        <asp:DropDownList ID="ListaClasse" class="form-control" runat="server" style="width:40%"/>
                        </div>
                </div>

                  <div class="form-group">
                        <label for="comment" class="col-sm-4 control-label">Solução Potencial</label>

                        <div class="col-sm-8">
                            <textarea class="form-control"  rows="3" id="solucao_potencial" placeholder="Solução Potencial" runat="server"></textarea>
                        </div>
                    </div>
                       <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="registar_entrevista" runat="server" class="btn btn-block btn-success" style="width: 20%" Text="Guardar" OnClick="Guardar_SumariacaoEntrevistas"/>
                <br />
            </div>
        </div>
                </div>
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col-lg-9 -->


    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
