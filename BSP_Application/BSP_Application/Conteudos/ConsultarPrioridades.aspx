<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarPrioridades.aspx.cs" Inherits="BSP_Application.Conteudos.ConsultarPrioridades" %>

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

                <h4>Consultar Prioridades para as Aplicações</h4>
                <br />
                <br /> 
<center>       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
    <HeaderStyle HorizontalAlign="Center" />

       <Columns>

           <asp:BoundField DataField="Grupo" HeaderText="Aplicação" ItemStyle-Width="150" />
           <asp:BoundField DataField="Funcao" HeaderText="Benefícios Potenciais" ItemStyle-Width="150" />
           <asp:BoundField DataField="" HeaderText="Impacto" ItemStyle-Width="150" />
           <asp:BoundField DataField="" HeaderText="Probabilidade de Sucesso" ItemStyle-Width="150" />
           <asp:BoundField DataField="" HeaderText="Procura" ItemStyle-Width="150" />


       </Columns>
   </asp:GridView>

</center>



    <!-- /.container -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
