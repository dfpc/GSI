using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSP_Application.DataObjects
{
    public class Objects
    {
    }

    public class User
    {
        public string Username { get; set; }
        public int IDUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
    }

    public class ClasseDados
    {
        public int IDClasseDados { get; set; }
        public int IDProjeto { get; set; }
        public string Projeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class Processo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Projeto { get; set; }
        public int IDProjeto { get; set; }
    }

    public class Projeto
    {
        public int IDProjeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class ProjetoOrganizacao
    {
        public int IDProjeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Associar { get; set; }
    }

    public class Organizacao
    {
        public int Id { get; set; }
        public int IDProjeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Projeto { get; set; }
    }

    public class Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Interno { get; set; }
        public string Tipo { get; set; }
        public string NomeTipo { get; set; }
    }

    public class Aplicacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IDProjeto { get; set; }


    }
}