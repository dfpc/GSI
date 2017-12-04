<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="BSP_Application.UserControls.MainMenu" %>


<h1 class="my-4"></h1>
<div id="MainMenu">
    <div class="list-group panel" style="color: white;">
        <a href="#demo4" class="list-group-item list-group-item-success" data-toggle="collapse" data-parent="#MainMenu">Projetos<i class="fa fa-caret-down"></i></a>
        <div class="collapse" id="demo4">
            <a href="/FormPages/AdicionarProjeto.aspx" style="font-size: small;" class="list-group-item">Adicionar Projeto</a>
            <a href="/Conteudos/ConsultarProjetos.aspx" style="font-size: small;" class="list-group-item">Consultar Projetos</a>
            <a href="/FormPages/RegisterProcess.aspx" style="font-size: small;" class="list-group-item">Registar Processo</a>
            <a href="/Conteudos/ConsultarProcesso.aspx" style="font-size: small;" class="list-group-item">Consultar Processos</a>
            <a href="/FormPages/RegistoClasseDados.aspx" style="font-size: small;" class="list-group-item">Registar Classe de Dados</a>
            <a href="/Conteudos/ConsultarClasseDados.aspx" style="font-size: small;" class="list-group-item">Consultar Classes de Dados</a>
            <a href="/FormPages/RegistoAplicacoes.aspx" style="font-size: small;" class="list-group-item">Registar Aplicação</a>
            <a href="/Conteudos/ConsultarAplicacoes.aspx" style="font-size: small;" class="list-group-item">Consultar Aplicações</a>
        </div>
        <a href="#Matrizes1" class="list-group-item list-group-item-success" data-toggle="collapse" data-parent="#MainMenu">Preencher Matriz da Arquitetura de Informação<i class="fa fa-caret-down"></i></a>
        <div class="collapse" id="Matrizes1">
            <a href="/Matrizes/Processo_ClasseDados_1.aspx" style="font-size: small;" class="list-group-item">Processos/Classes de Dados</a>
            <a href="/Matrizes/Processo_Organizacao.aspx" style="font-size: small;" class="list-group-item">Processos/Organização</a>
        </div>
        <a href="#demo5" class="list-group-item list-group-item-success" data-toggle="collapse" data-parent="#MainMenu">Preencher Matrizes de Aplicações<i class="fa fa-caret-down"></i></a>
        <div class="collapse" id="demo5">
            <a href="/Matrizes/App_Processo.aspx" style="font-size: small;" class="list-group-item">Aplicações/Processos</a>
            <a href="/Matrizes/App_Organizacao.aspx" style="font-size: small;" class="list-group-item">Aplicações/Organização</a>
            <a href="/Matrizes/App_ClasseDados.aspx" style="font-size: small;" class="list-group-item">Aplicações/Classe de Dados</a>
        </div>
        <a href="/FormPages/AdicionarOrganizacao.aspx" class="list-group-item list-group-item-success">Registar Entidade da Organização</a>
        <a href="/Conteudos/ConsultarOrganizacao.aspx" class="list-group-item list-group-item-success">Consultar Entidades da Organização</a>
        <a href="/FormPages/AdicionarEntidade.aspx" class="list-group-item list-group-item-success" data-parent="#MainMenu">Registar Entidade</a>
        <a href="/Conteudos/ConsultarEntidades.aspx" class="list-group-item list-group-item-success" data-parent="#MainMenu">Consultar Entidades</a>
        <a href="/FormPages/SumariacaoEntrevistas.aspx" class="list-group-item list-group-item-success" data-parent="#MainMenu">Registar Sumariação de Entrevistas</a>
        <a href="/Conteudos/ConsultarSumariacaoEntrevistas.aspx" class="list-group-item list-group-item-success" data-parent="#MainMenu">Consultar Sumariação de Entrevistas</a>
        <a href="/FormPages/PrioridadesAplicacoes.aspx" class="list-group-item list-group-item-success" data-parent="#MainMenu">Definir Prioridades para as Aplicações</a>
        <a href="/FormPages/RegistoFuncoesEquipa.aspx" class="list-group-item list-group-item-success" data-parent="#MainMenu">Registar Funções da Equipa de Direção do SI</a>
        <a href="/Conteudos/ConsultarFuncoesEquipa.aspx" class="list-group-item list-group-item-success" data-parent="#MainMenu">Consultar Funções da Equipa de Direção do SI</a>

    </div>
</div>
