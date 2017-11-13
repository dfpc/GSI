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

        public static void InsertProcess(string name, string description, int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("INSERT INTO Processo (IDProjeto, Nome, Descricao) VALUES({0}, {1}, {2})",
                    idproject, name, description);
            }
        }

        public static void InsertOrganization(string name, string description, int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("INSERT INTO Organizacao (IDProjeto, Nome, Descricao) VALUES({0}, {1}, {2})",
                    idproject, name, description);
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

        public static Processo GetProcessById(int idprocess)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Processo>("SELECT * FROM PROCESSO WHERE Id = {0}", idprocess).FirstOrDefault();
            }
        }

        public static void EditProcess(int idprocess, string nome, string descricao, int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("UPDATE Processo SET Nome = {1}, Descricao = {2}, IDProjeto = {3} WHERE Id = {0}",
                    idprocess, nome, descricao, idproject);
            }
        }

        public static List<Aplicacao> GetAllAplications()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Aplicacao>("SELECT * FROM Aplicacao").ToList();
            }
        }
    }
}