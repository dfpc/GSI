﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="App_Organizacao.aspx.cs" Inherits="BSP_Application.Matrizes.App_Organizacao" %>

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
                <h4>Matriz Aplicações/Organização</h4>
                <br />
                <br />
                 <label for="ListaProjetos" class="col-sm-4 control-label">Projeto Associado</label>
                   <div class="col-sm-8">
                    <asp:DropDownList ID="ListaProjetos"   AutoPostBack="True" OnSelectedIndexChanged="ListaProjetos_SelectedIndexChanged" class="form-control" runat="server" style="width:40%"/>
                      <br />
                        </div>
                <center>
                <asp:PlaceHolder ID="AplicacaoOrganizacao" runat="server"></asp:PlaceHolder>
            </div>
            <!-- /.card -->
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <button type="button" class="btn btn-block btn-success" style="width: 20%">Guardar</button>
                <br />

            </div>
        </div>
        <!-- /.col-lg-9 -->
    </div>
    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
