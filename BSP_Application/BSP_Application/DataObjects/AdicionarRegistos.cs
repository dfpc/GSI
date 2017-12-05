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

        public static List<ProjetoOrganizacao> GetAllProjectsToEditOrganization(int idorganization)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<ProjetoOrganizacao>("exec spGetAllProjectsByOrganization {0}", idorganization).ToList();
            }
        }

        public static void DeleteOrganizationProjectByOrganization(int idorganization)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("DELETE OrganizacaoProjeto WHERE IDOrganizacao = {0}", idorganization);
            }
        }

        public static void DeleteOrganizationProjectByProject(int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("DELETE OrganizacaoProjeto WHERE IDProjeto = {0}", idproject);
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

        public static bool DeleteProblem(int idproblema)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<bool>("exec spDeleteProblem {0}", idproblema).FirstOrDefault();
            }
        }
        public static bool DeleteOrgEntity(int idorganizacao)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<bool>("exec spDeleteOrgEntity {0}", idorganizacao).FirstOrDefault();
            }
        }
        public static bool DeleteClass(int idclasse)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<bool>("exec spDeleteClass {0}", idclasse).FirstOrDefault();
            }
        }

        public static bool DeleteApplication(int idaplicacao)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<bool>("exec spDeleteAplication {0}", idaplicacao).FirstOrDefault();
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

        public static bool DeleteProcess(int idprocesso)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<bool>("exec spDeleteProcesso {0}", idprocesso).FirstOrDefault();
            }
        }

        public static Projeto GetProjectById(int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Projeto>("SELECT * FROM PROJETO WHERE IDProjeto = {0}", idproject).FirstOrDefault();
            }
        }


        public static Aplicacao GetApplicationById(int idapp)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Aplicacao>("SELECT A.*, P.Nome as NomeProjeto FROM Aplicacao A, Projeto P WHERE A.IdProjeto = P.IDProjeto AND A.Id = {0}", idapp).FirstOrDefault();
            }
        }

        public static ClasseDados GetClassDataById(int idclass)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<ClasseDados>("SELECT CD.*, P.Nome as NomeProjeto, E.Nome as NomeEntidade FROM ClasseDados CD, Entidade E, Projeto P WHERE P.IDProjeto = CD.IDProjeto AND E.Id = CD.IDEntidade AND CD.Id = {0}", idclass).FirstOrDefault();
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


        public static void EditClass(int idclasse, string nome, string descricao, int idprojeto, int identidade)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("UPDATE ClasseDados SET Nome = {1}, Descricao = {2}, IDProjeto = {3}, IDEntidade = {4} WHERE Id = {0}",
                    idclasse, nome, descricao, idprojeto, identidade);
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

        public static void EditOrganization(int id, string nome, string descricao)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("UPDATE Organizacao SET Nome = {1}, Descricao = {2} WHERE Id = {0}",
                    id, nome, descricao);
            }
        }

        public static void EditApplication(int id, string nome, string descricao, int idprojeto)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("UPDATE Aplicacao SET Nome = {1}, Descricao = {2}, IdProjeto = {3} WHERE Id = {0}",
                    id, nome, descricao, idprojeto);
            }
        }


        public static void EditSumariacao(int idproblem, string causa, string efeito, string importancia, int idprocesso, int idclasse, string solucao, string grupo)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("UPDATE Problema SET Causa = {1}, Efeito = {2}, Importancia = {3}, IDProcesso = {4}, IDClasseDados = {5}, PotencialSolucao = {6}, GrupoProcesso = {7} WHERE Id = {0}",
                    idproblem, causa, efeito, importancia, idprocesso, idclasse, solucao, grupo);
            }
        }

        public static Processo GetProcessById(int idprocess)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Processo>("SELECT * FROM PROCESSO WHERE Id = {0}", idprocess).FirstOrDefault();
            }
        }

        public static Organizacao GetOrganizacaoById(int id)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Organizacao>("SELECT * FROM Organizacao WHERE Id = {0}", id).FirstOrDefault();
            }
        }

        public static Problema GetProblemaById(int id)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Problema>("SELECT * FROM Problema WHERE Id = {0}", id).FirstOrDefault();
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
                return db.Database.SqlQuery<Problema>("SELECT P.Id as IDProblema, P.GrupoProcesso, P.Causa, P.Efeito, P.Importancia, P.PotencialSolucao, PR.Nome AS ProcessoC, CD.Nome AS ClasseC FROM Problema P, Processo PR, ClasseDados CD WHERE P.IDClasseDados = CD.Id AND P.IDProcesso = PR.Id").ToList();
            }
        }

        public static void SaveAppProcess(int idapp, int idprocess, string value)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("exec spInsertAppProcess @idApp={0}, @Idprocess={1}, @Apoio={2}", idapp, idprocess, value);
            }
        }

        public static void SaveAppOrganization(int idapp, int idorg, string value)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("exec spInsertAppOrg @idApp={0}, @idOrg={1}, @Apoio={2}", idapp, idorg, value);
            }
        }
        public static void SaveAppCD(int idapp, int idcd, string value)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("exec spInsertAppCD @idApp={0}, @idCD={1}, @Relacao={2}", idapp, idcd, value);
            }
        }

        public static string GetAppProcess(int idapp, int idprocess)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<string>("SELECT Apoio FROM AplicacaoProcesso WHERE IdAplicacao = {0} AND IDProcesso = {1}", idapp, idprocess).FirstOrDefault();
            }
        }

        public static string GetAppOrg(int idapp, int idOrg)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<string>("SELECT Apoio FROM AplicacaoOrganizacao WHERE IdAplicacao = {0} AND IDOrganizacao = {1}", idapp, idOrg).FirstOrDefault();
            }
        }

        public static string GetAppCD(int idapp, int idClasseDados)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<string>("SELECT Relacao FROM AplicacaoClasseDados WHERE IdAplicacao = {0} AND IDClasseDados = {1}", idapp, idClasseDados).FirstOrDefault();
            }
        }

        public static string GetOrgProcess(int idorg, int idprocess)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<string>("SELECT Relacao FROM ProcessoOrganizacao WHERE IDOrganizacao = {0} AND IdProcesso = {1}", idorg, idprocess).FirstOrDefault();
            }
        }

        public static void SaveOrgProcess(int idorg, int idprocess, string value)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("exec spInsertOrgProcess @Idprocess={0}, @idOrg={1}, @Relacao={2}", idprocess, idorg, value);
            }
        }

        public static string GetProcessoClass(int idprocess, int idclasse)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<string>("SELECT Relacao FROM ProcessoClasseDados WHERE IdProcesso = {0} AND IDClasseDados = {1}", idprocess, idclasse).FirstOrDefault();
            }
        }


        public static void SaveProcessClasse(int idclasse, int idprocesso, string value)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("exec spInsertProcClasse @idProc={0}, @idClasse={1}, @relacao={2}", idprocesso, idclasse, value);
            }
        }

        public static void DeleteProcessClasseByClass(int idclasse, string value)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("DELETE ProcessoClasseDados WHERE IDClasseDados = {0} AND Relacao = {1}", idclasse, value);
            }
        }

        public static void SaveProblems(Problema p, int idprocesso, int idclassedados)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("exec spInsertUpdateProblems @Causa = {0}, @Efeito = {1}, @Importancia = {2}, @IDProcesso ={3}, @IDClasseDados ={4}, @PotencialSolucao = {5}, @GrupoProcesso ={6}, @IDProblema = {7}",
                    p.Causa, p.Efeito, p.Importancia, idprocesso, idclassedados, p.PotencialSolucao, p.GrupoProcesso, p.IDProblema);
            }
        }

        public static List<ClasseDados> GetClassDataByProject(int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<ClasseDados>("SELECT Nome, Id AS IDClasseDados FROM ClasseDados WHERE IDProjeto= {0}", idproject).ToList();
            }
        }

        public static List<Processo> GetProcessByProject(int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Processo>("SELECT Nome, Id FROM Processo WHERE IDProjeto= {0}", idproject).ToList();
            }
        }

        public static List<ProcessoClasseDados> GetProcessoClasseDadosByProject(int idproject)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<ProcessoClasseDados>("EXEC spGetProcessoClasseDadosByCreateRelation @IDProjeto= {0}", idproject).ToList();
            }
        }

        public static void SaveProcessPosition(int idprocess, int? position)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("UPDATE ProcessoClasseDados set Posicao = {0} WHERE IDProcesso = {1}", position, idprocess);
            }
        }

        public static void SaveGroups(int idclasse, int idprocess, string name)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("INSERT INTO GrupoProcessoClasseDados (IDClasseDados, IDProcesso, NomeGrupo) VALUES({0}, {1}, {2})", idclasse, idprocess, name);
            }
        }

        public static List<Group> GetGroups()
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                return db.Database.SqlQuery<Group>("SELECT * FROM GrupoProcessoClasseDados").ToList();
            }
        }

        public static void InsertPriority(int idapp, int idfator, int value)
        {
            using (DataBaseConnect db = new DataBaseConnect())
            {
                db.Database.ExecuteSqlCommand("INSERT INTO Prioridade (IDProjeto, IDFator, Valor) VALUES ({0}, {1}, {2})", idapp, idfator, value);
            }
        }
    }
}