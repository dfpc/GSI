﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterProcess.aspx.cs" Inherits="BSP_Application.FormPages.RegisterProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
        <div class="container">
            <a class="navbar-brand" href="#">Aplicação WEB para BSP</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">
                </ul>
            </div>
        </div>
    </nav>
    <!-- Page Content -->
    <div class="container">
        <div class="row">
            <div class="col-lg-3">

                <h1 class="my-4"></h1>
                <div id="MainMenu">
                    <div class="list-group panel" style="color: white;">
                        <a href="#demo4" class="list-group-item list-group-item-success" data-toggle="collapse" data-parent="#MainMenu">Projetos<i class="fa fa-caret-down"></i></a>
                        <div class="collapse" id="demo4">
                            <a href="Adicionar Projeto.html" class="list-group-item">Adicionar Projeto</a>
                            <a href="Consultar Projeto.html" class="list-group-item">Consultar Projetos</a>
                            <a href="Registar Processos.html" class="list-group-item active">Registar Processo</a>
                            <a href="Consultar Processo.html" class="list-group-item">Consultar Processos</a>
                            <a href="Registar Classe de Dados.html" class="list-group-item">Registar Classe de Dados</a>
                            <a href="Consultar Classe de Dados.html" class="list-group-item">Consultar Classes de Dados</a>
                            <a href="#" class="list-group-item">Preencher Matriz da Arquitetura de Informação</a>
                        </div>
                        <a href="#demo5" class="list-group-item list-group-item-success" data-toggle="collapse" data-parent="#MainMenu">Preencher Matrizes de Aplicações<i class="fa fa-caret-down"></i></a>
                        <div class="collapse" id="demo5">
                            <a href="Aplicações Processos.html" class="list-group-item">Aplicações/Processos</a>
                            <a href="Aplicações Organização.html" class="list-group-item">Aplicações/Organização</a>
                            <a href="Aplicações Classe de Dados.html" class="list-group-item">Aplicações/Classe de Dados</a>

                        </div>
                        <a href="#" class="list-group-item list-group-item-success" data-parent="#MainMenu">Registar Sumariação de Entrevistas</a>
                        <a href="#" class="list-group-item list-group-item-success" data-parent="#MainMenu">Definir Prioridades para as Aplicações</a>
                        <a href="Registar Funções Equipa.html" class="list-group-item list-group-item-success" data-parent="#MainMenu">Registar Funções da Equipa de Direção do SI</a>
                    </div>
                </div>
            </div>
            <!-- /.col-lg-3 -->

            <div class="col-lg-9">
                <div class="card card-outline-secondary my-4">
                    <div class="card-body">
                        <div class="container-fluid">


                            <h4>Registar Processo</h4>
                            <br />
                            <br />
                            <div class="box-body">
                                <div class="form-group">
                                    <label for="inputEmail3" class="col-sm-4 control-label">Nome do Processo</label>

                                    <div class="col-sm-8">
                                        <input type="nome" class="form-control" id="inputNome" placeholder="Nome do Processo">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="inputPassword3" class="col-sm-2 control-label">Descrição</label>

                                    <div class="col-sm-8">
                                        <textarea class="form-control" rows="5" id="comment" placeholder="Descrição"></textarea>
                                    </div>
                                </div>

                                <div class="form-group">

                                    <div class="col-sm-offset-2 col-sm-10">
                                        <button type="button" class="btn btn-block btn-success" style="width: 20%">Guardar</button>
                                        <br />

                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                    <!-- /.card -->
                </div>
                <!-- /.col-lg-9 -->
            </div>
        </div>
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
