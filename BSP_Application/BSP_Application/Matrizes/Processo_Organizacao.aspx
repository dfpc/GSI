<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Processo_Organizacao.aspx.cs" Inherits="BSP_Application.Matrizes.Processo_Organizacao" %>

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
                <h4>Matriz Processos/Organização</h4>
                <br />
                <br />
                <label for="ListaProjetos" class="col-sm-4 control-label">Projeto Associado</label>
                        <div class="col-sm-8">
                        <asp:DropDownList ID="ListaProjetos" AutoPostBack="True" OnSelectedIndexChanged="ListaProjetos_SelectedIndexChanged" class="form-control" runat="server" style="width:40%"/>
                           <br />

                        </div>
                 <center>
                <asp:PlaceHolder ID="ProcessoOrganizacao" runat="server"></asp:PlaceHolder>
                     </center>
                     <br />
                     <br />
                     <h8 class="col-sm-4 control-label"><b>D</b> - Decisor </h8><br />
                     <h8 class="col-sm-4 control-label"><b>F</b> - Fortemente envolvido</h8><br />
                     <h8 class="col-sm-4 control-label"><b>A</b> - Algum envolvimento</h8> 
            </div>
            <!-- /.card -->
       
            </div>
        <!-- /.col-lg-9 -->

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <button type="button" class="btn btn-block btn-success simple-btn" style="width: 20%" onclick="SaveOrgProcessMatrix();">Guardar</button>
                <br />
            </div>
        </div>
    </div>
    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
