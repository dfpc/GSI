using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSP_Application.DataObjects
{
    public class AdicionarRegistos
    {
        public static User Authenticate(string username, string password)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<User>("SELECT * FROM Utilizador WHERE Username={0} AND Password={1}", username, password).FirstOrDefault();
            }
        }

        public static void InsertUser(string username, string password, string email, string name)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("INSERT INTO Utilizador (Username, Password, Email, Nome, IsAdmin) VALUES({0}, {1}, {2}, {3}, 0)",
                    username, password, email, name);
            }
        }

        public static void InsertProcess(string name, string description, int idproject, string camada)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("INSERT INTO Processo (IDProjeto, Nome, Descricao, Camada) VALUES({0}, {1}, {2}, {3})",
                    idproject, name, description, camada);
            }
        }

        public static int InsertOrganization(string name, string description)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<int>("INSERT INTO Organizacao (Nome, Descricao) VALUES({0}, {1}) SELECT CAST(SCOPE_IDENTITY() AS INT)", name, description).FirstOrDefault();
            }
        }

        public static void InsertOrganizationProject(int idorganizacao, int idprojeto)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("INSERT INTO OrganizacaoProjeto (IDProjeto, IDOrganizacao) VALUES({0}, {1})",
                    idprojeto, idorganizacao);
            }
        }

        public static void InsertEntidade(string name, string tipo, bool interno)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("INSERT INTO Entidade (Nome, Tipo, Interno) VALUES({0}, {1}, {2})",
                    name, tipo, interno);
            }
        }

        public static List<ClasseDados> GetAllDataClasses()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<ClasseDados>("exec spGetAllDataClasses").ToList();
            }
        }

        public static List<Entidade> GetAllEntities()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Entidade>("exec spGetAllEntities").ToList();
            }
        }

        public static List<Processo> GetAllProcess()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Processo>("exec spGetAllProcess").ToList();
            }
        }

        public static List<Projeto> GetAllProjects()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Projeto>("SELECT * FROM Projeto").ToList();
            }
        }

        public static List<ProjetoOrganizacao> GetAllProjectsToOrganization()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<ProjetoOrganizacao>("SELECT * FROM Projeto").ToList();
            }
        }

        public static List<Organizacao> GetAllOrganizations()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Organizacao>("exec spGetAllOrganizations").ToList();
            }
        }

        public static bool DeleteOrganization(int idorganization)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<bool>("exec spDeleteOrganization {0}", idorganization).FirstOrDefault();
            }
        }

        public static bool DeleteProject(int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<bool>("exec spDeleteProject {0}", idproject).FirstOrDefault();
            }
        }

        public static bool DeleteEntidade(int identidade)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<bool>("exec spDeleteEntidade {0}", identidade).FirstOrDefault();
            }
        }

        public static Projeto GetProjectById(int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Projeto>("SELECT * FROM PROJETO WHERE IDProjeto = {0}", idproject).FirstOrDefault();
            }
        }

        public static void EditProject(int idproject, string nome, string descricao)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("UPDATE PROJETO SET Nome = {1}, Descricao = {2} WHERE IDProjeto = {0}",
                    idproject, nome, descricao);
            }
        }

        public static void EditProcess(int id, string nome, string descricao, int projeto, string camada)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("UPDATE Processo SET Nome = {1}, Descricao = {2}, Camada ={3}, IDProjeto = {4} WHERE Id = {0}",
                    id, nome, descricao, camada, projeto);
            }
        }

        public static Processo GetProcessById(int idprocess)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Processo>("SELECT * FROM PROCESSO WHERE Id = {0}", idprocess).FirstOrDefault();
            }
        }

        public static List<Aplicacao> GetAllAplications()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Aplicacao>("SELECT * FROM Aplicacao").ToList();
            }
        }

        public static List<Problema> GetAllSumariacao()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Problema>("SELECT P.GrupoProcesso, P.Causa, P.Efeito, P.Importancia, P.PotencialSolucao, PR.Nome AS ProcessoC, CD.Nome AS ClasseC FROM Problema P, Processo PR, ClasseDados CD WHERE P.IDClasseDados = CD.Id AND P.IDProcesso = PR.Id").ToList();
            }
        }
    }
}