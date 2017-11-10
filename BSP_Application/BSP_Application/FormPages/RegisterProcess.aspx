﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterProcess.aspx.cs" Inherits="BSP_Application.FormPages.RegisterProcess" %>

<%@ Register Src="~/UserControls/MainMenu.ascx" TagPrefix="uc1" TagName="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentLeftSide" runat="server">
    <uc1:MainMenu runat="server" ID="MainMenu" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="card card-outline-secondary my-4">
        <div class="card-body">
            <div class="container-fluid">
                <h4>Registar Processo</h4>
                <div class="box-body" style="margin-top: 50px;">
                    <div class="form-group">
                        <label for="ListaProjetos" class="col-sm-4 control-label">Projeto Associado</label>
                        <div class="col-sm-8">
                        <asp:DropDownList ID="ListaProjetos" class="form-control" runat="server" style="width:40%"/>
                           <br />

                        </div>
                        <label for="inputEmail3" class="col-sm-4 control-label">Nome do Processo</label>

                        <div class="col-sm-8">
                            <input type="text" class="form-control" id="inputNome" runat="server" clientidmode="static" placeholder="Nome do Processo">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="inputPassword3" class="col-sm-2 control-label">Descrição</label>

                        <div class="col-sm-8">
                            <textarea class="form-control" rows="5" id="comment" runat="server" placeholder="Descrição"></textarea>
                        </div>
                    </div>

                    <div class="form-group">

                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button id="btnSave" cssclass="btn btn-block btn-success" style="width: 20%" runat="server" OnClick="btnSave_Click" OnClientClick="return !ValidateProcessFields();" Text="Guardar"></asp:Button>
                            <br />

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.card -->
    </div>
    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>