<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Processo_ClasseDados.aspx.cs" Inherits="BSP_Application.Matrizes.Processo_ClasseDados" %>

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
                <h4>Matriz Processos/Classe de Dados</h4>
                <br />
                <br />
                <div class="row">
                    <label for="ListaProjetos" class="col-sm-2 control-label">Projeto Associado</label>
                    <div class="col-sm-8">
                        <asp:DropDownList ID="ListaProjetos" class="form-control" runat="server" Style="width: 40%" Enabled="false" />

                    </div>
                </div>
                <br />
                Alterar posição do processo
                    <div class="row">
                        <div class="col-sm-5">
                            <select class="form-control" runat="server" id="selectProcess"></select>
                        </div>
                        <div class="col-sm-2">
                            <input class="form-control" type="number" runat="server" id="tbxPosition" clientidmode="static" />
                        </div>
                        <div class="col-sm-3">
                            <asp:Button ID="btnOrder" CssClass="btn btn-block btn-success" runat="server" OnClick="btnOrder_Click" OnClientClick="if($('#tbxPosition').val()=='') return false;" Text="Alterar Posição"></asp:Button>
                        </div>
                    </div>
                <br />
                <center>
                <asp:PlaceHolder ID="ProcessoClasse" runat="server"></asp:PlaceHolder>
                     </center>
                <br />
                <div class="row" id="divGrupButton" style="display:none;">
                    <div class="col-sm-2">
                        <input class="form-control" type="text" id="groupName" placeholder="Nome do Grupo"/>
                    </div>
                    <div class="col-sm-4">
                        <button ID="Button1" Class="btn btn-block btn-success simple-btn" runat="server" OnClick="SaveGroup();">Gravar Grupo</button>
                    </div>
                </div>
                <br />
                <h8 class="col-sm-4 control-label"><b>C</b> - Classe de dados criada </h8>
                <br />
                <h8 class="col-sm-4 control-label"><b>U</b> - Classe de dados usada</h8>
                <br />
            </div>
            <!-- /.card -->
        </div>
        <!-- /.col-lg-9 -->

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <button type="button" class="btn btn-block btn-success" style="width: 20%" onclick="SaveProcessClasseMatrix();">Guardar</button>
                <br />
            </div>
        </div>
    </div>
    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
