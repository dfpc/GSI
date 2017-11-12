<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdicionarOrganizacao.aspx.cs" Inherits="BSP_Application.FormPages.AdicionarOrganizacao" %>

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

                <h4>Registar Entidade da Organização</h4>
                <br />
                <br />
                <div class="box-body">
                    <div class="form-group">

                        <%--    <label for="ListaProjetos" class="col-sm-4 control-label">Projeto Associado</label>
                        <div class="col-sm-8">
                        <asp:DropDownList ID="ListaProjetos" class="form-control" runat="server" style="width:40%"/>
                           <br />

                        </div>--%>
                        <label for="inputEmail3" class="col-sm-4 control-label">Nome da Organizaçao</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control" id="inputNome" placeholder="Nome da organização" runat="server" clientidmode="static">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="comment" class="col-sm-2 control-label">Descrição</label>

                        <div class="col-sm-8">
                            <textarea class="form-control" rows="5" id="comment" placeholder="Descrição" runat="server"></textarea>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="comment" class="col-sm-2 control-label">Projetos</label>
                        <div class="col-sm-12">
                            <asp:GridView ID="gdvProjetos" runat="server" DataKeyNames="IDProjeto" CellPadding="10" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Nome" HeaderText="Nome" ReadOnly="True" SortExpression="Nome" />
                                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" ReadOnly="True" SortExpression="Descricao" />
                                    <asp:TemplateField HeaderText="Associar">
                                        <ItemTemplate>
                                            <input type="checkbox" ID="chkAssociate" onchange="alert('<%# DataBinder.Eval(Container.DataItem, "IDProject") %>');" runat="server" HeaderText="Associar" Checked='<%# DataBinder.Eval(Container.DataItem, "Associate") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button ID="btnSave" CssClass="btn btn-block btn-success" Style="width: 20%" runat="server" OnClick="btnSave_Click" OnClientClick="return !ValidateOrganizationFields();" Text="Guardar"></asp:Button>
                            <br />

                        </div>
                    </div>
                </div>

            </div>
            <!-- /.card -->
        </div>
        <!-- /.col-lg-9 -->
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
