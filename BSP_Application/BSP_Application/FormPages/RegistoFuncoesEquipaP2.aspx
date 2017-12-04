<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistoFuncoesEquipaP2.aspx.cs" Inherits="BSP_Application.FormPages.RegistoFuncoesEquipaP2" %>

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
                <h4>Registar Funções da Equipa de direção dos SI</h4>
                <h5>2º Passo</h5>
                <div class="box-body" style="margin-top: 50px;">
                   
                    <div class="form-group">
                          <label for="ListaGrupos" class="col-sm-4 control-label">Grupo Associado</label>
                        <div class="col-sm-8">
                        <asp:DropDownList ID="ListaGrupos" class="form-control" runat="server" style="width:40%"/>
                           <br />

                        </div>
    
                        <label for="inputEmail3" class="col-sm-10 control-label">Insira as funções que pretende para cada grupo da equipa, <b>separados por ";"</b></label>


                        <div class="col-sm-10">
                            <textarea class="form-control" rows="7" id="funcaotextarea" placeholder="Funções separadas por ponto e vírgula" runat="server"></textarea>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                          <!--  <a href="#demo5">Adicionar Mais</a><br />-->
                            <br />
                            <asp:Button ID="guardar" runat="server" class="btn btn-block btn-success" style="width: 20%" Text="Guardar" OnClick="guardar_Click1" />
                           

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
