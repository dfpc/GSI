<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="BSP_Application.UserControls.MainMenu" %>


<h1 class="my-4"></h1>
<div id="MainMenu">
    <div class="list-group panel" style="color: white;">
        <a href="#demo4" class="list-group-item list-group-item-success" data-toggle="collapse" data-parent="#MainMenu">Projetos<i class="fa fa-caret-down"></i></a>
        <div class="collapse" id="demo4">
            <a href="/FormPages/AdicionarProjeto.aspx" class="list-group-item">Adicionar Projeto</a>
            <a href="/Conteudos/ConsultarProjetos.aspx" class="list-group-item">Consultar Projetos</a>
            <a href="/FormPages/RegisterProcess.aspx" class="list-group-item active">Registar Processo</a>
            <a href="/Conteudos/ConsultarProcesso.aspx" class="list-group-item">Consultar Processos</a>
            <a href="/FormPages/RegistoClasseDados.aspx" class="list-group-item">Registar Classe de Dados</a>
            <a href="/Conteudos/ConsultarClasseDados.aspx" class="list-group-item">Consultar Classes de Dados</a>
            <a href="#" class="list-group-item">Preencher Matriz da Arquitetura de Informação</a>
        </div>
        <a href="#demo5" class="list-group-item list-group-item-success" data-toggle="collapse" data-parent="#MainMenu">Preencher Matrizes de Aplicações<i class="fa fa-caret-down"></i></a>
        <div class="collapse" id="demo5">
            <a href="/Matrizes/App_Processo.aspx" class="list-group-item">Aplicações/Processos</a>
            <a href="/Matrizes/App_Organizacao.aspx" class="list-group-item">Aplicações/Organização</a>
            <a href="/Matrizes/App_ClasseDados.aspx" class="list-group-item">Aplicações/Classe de Dados</a>

        </div>
        <a href="#" class="list-group-item list-group-item-success" data-parent="#MainMenu">Registar Sumariação de Entrevistas</a>
        <a href="#" class="list-group-item list-group-item-success" data-parent="#MainMenu">Definir Prioridades para as Aplicações</a>
        <a href="/FormPages/RegistoFuncoesEquipa.aspx" class="list-group-item list-group-item-success" data-parent="#MainMenu">Registar Funções da Equipa de Direção do SI</a>
    </div>
</div>
