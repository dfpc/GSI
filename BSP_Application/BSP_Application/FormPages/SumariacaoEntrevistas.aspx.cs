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

            }

            if (!IsPostBack)
            {
                // Lista Classes de Dados
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

            }

        }
        protected void Guardar_SumariacaoEntrevistas(object sender, EventArgs e)
        {
            
            string grupo_ = grupo_processos.Value;
            string causa_ = causa.Value;
            string efeito_ = efeito.Value;
            string importancia_ = importancia.Value;
            string solucao_ = solucao_potencial.Value;
            int idProcesso = Int32.Parse(ListaProcesso.SelectedValue);
            int idClasse = Int32.Parse(ListaClasse.SelectedValue);
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            string sql = "INSERT INTO Problema (Causa, Efeito, Importancia, IDProcesso, IDClasseDados, PotencialSolucao, GrupoProcesso) values (@causa, @efeito, @importancia, @idprocesso, @idclasse, @potencialsolucao, @grupoprocesso)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@causa", causa_);
            cmd.Parameters.AddWithValue("@efeito", efeito_);
            cmd.Parameters.AddWithValue("@importancia", importancia_);
            cmd.Parameters.AddWithValue("@idprocesso", idProcesso );
            cmd.Parameters.AddWithValue("@idclasse", idClasse);
            cmd.Parameters.AddWithValue("@potencialsolucao", solucao_);
            cmd.Parameters.AddWithValue("@grupoprocesso", grupo_);

            cmd.ExecuteNonQuery();
        }
    }
}