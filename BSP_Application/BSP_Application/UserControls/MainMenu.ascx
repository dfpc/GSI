<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="BSP_Application.UserControls.MainMenu" %>


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
