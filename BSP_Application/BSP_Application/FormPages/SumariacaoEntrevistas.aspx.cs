using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.FormPages
{
    public partial class SumariacaoEntrevistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lista Classes de Dados
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string com = "Select Nome, Id from ClasseDados";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ListaClasse.DataSource = dt;
                ListaClasse.DataTextField = "Nome";
                ListaClasse.DataValueField = "Id";
                ListaClasse.DataBind();
                conn.Close();

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {   
                    editSumariacaoEntrevistas(Convert.ToInt32(Request.QueryString["id"]));
                }
            }

            if (!IsPostBack)
            {
                //Lista Classes de Dados
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string com = "Select Nome, Id from Processo";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                ListaProcesso.DataSource = dt;
                ListaProcesso.DataTextField = "Nome";
                ListaProcesso.DataValueField = "Id";
                ListaProcesso.DataBind();
                conn.Close();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    editSumariacaoEntrevistas(Convert.ToInt32(Request.QueryString["id"]));

              List<Group> groups = new List<Group>();
                groups.Add(new Group() { Id = 1, NomeGrupo = "Grupo 1" });
                groups.Add(new Group() { Id = 2, NomeGrupo = "Grupo 2" });
                grupo_processos.DataSource = groups;
                grupo_processos.DataTextField = "NomeGrupo";
                grupo_processos.DataValueField = "Id";
                grupo_processos.DataBind();
            }

        }

        private void editSumariacaoEntrevistas(int id)
        {
            hTitle.InnerText = "Editar Sumariação de Entrevistas";
            Problema problema = AdicionarRegistos.GetProblemaById(id);
            ListaProcesso.SelectedIndex = ListaProcesso.Items.IndexOf(ListaProcesso.Items.FindByText(problema.ProcessoC));
            ListaClasse.SelectedIndex = ListaClasse.Items.IndexOf(ListaClasse.Items.FindByText(problema.ClasseC));
            grupo_processos.Value = problema.GrupoProcesso;
            causa.Value = problema.Causa;
            efeito.Value = problema.Efeito;
            solucao_potencial.Value = problema.PotencialSolucao;
            ListaImportancia.SelectedIndex = ListaImportancia.Items.IndexOf(ListaImportancia.Items.FindByText(problema.Importancia));
        }

        protected void Guardar_SumariacaoEntrevistas(object sender, EventArgs e)
        {
            int idProcesso = Int32.Parse(ListaProcesso.SelectedValue);
            int idClasse = Int32.Parse(ListaClasse.SelectedValue);
            Problema p = new Problema()
            {
                Causa = causa.Value,
                Efeito = efeito.Value,
                Importancia = ListaImportancia.SelectedValue,
                PotencialSolucao = solucao_potencial.Value,
                GrupoProcesso = grupo_processos.Value
            };
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                p.IDProblema = (Convert.ToInt32(Request.QueryString["id"]));
            AdicionarRegistos.SaveProblems(p, idProcesso, idClasse);
            Response.Write("<script>alert('Registo inserido com sucesso!');window.location.href ='/Conteudos/ConsultarSumariacaoEntrevistas.aspx';</script>");
          
        }
    }
}