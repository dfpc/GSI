<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistoFuncoesEquipa.aspx.cs" Inherits="BSP_Application.FormPages.RegistoFuncoesEquipa" %>

<%@ Register Src="~/UserControls/MainMenu.ascx" TagPrefix="uc1" TagName="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentLeftSide" runat="server">
    <uc1:MainMenu runat="server" ID="MainMenu" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!-- Page Content -->
    <div class="card card-outline-secondary my-4">
        <div class="card-body">
            <div class="container-fluid">
                <h4>Registar Funções da Equipa de direção dos SI</h4>
                <div class="box-body" style="margin-top: 50px;">
                    <div class="form-group">
                        <label for="inputEmail3" class="col-sm-4 control-label">Grupo</label>

                        <div class="col-sm-8">
                            <input type="nome" class="form-control" id="inputNome" placeholder="Grupo">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword3" class="col-sm-2 control-label">Função</label>

                        <div class="col-sm-8">
                            <textarea class="form-control" rows="5" id="comment" placeholder="Função"></textarea>
                        </div>
                    </div>

                    <div class="form-group">


                        <div class="col-sm-offset-2 col-sm-10">
                            <a href="#demo5">Adicionar Mais</a><br />
                            <br />
                            <button type="button" class="btn btn-block btn-success" style="width: 20%">Guardar</button>
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
    <!-- Footer -->
    <footer style="position: fixed; left: 0px; bottom: 0px; height: 30px; width: 100%;" class="py-3 bg-dark">
        <div class="container">
        </div>
        <!-- /.container -->
    </footer>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
