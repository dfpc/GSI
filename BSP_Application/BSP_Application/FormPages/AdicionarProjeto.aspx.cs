using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSP_Application.DataObjects;
using System.Data.SqlClient;
using System.Web.Services;

namespace BSP_Application.FormPages
{
    public partial class AdicionarProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    EditProject(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
            //AdicionarRegistos.AddProject();
        }

        private void EditProject(int id)
        {
            Projeto p = AdicionarRegistos.GetProjectById(id);
            inputNome.Value = p.Nome;
            comment.Value = p.Descricao;
        }

        protected void Guardar_Projeto(object sender, EventArgs e)
        {
            string nome = inputNome.Value;
            string descricao = comment.Value;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                AdicionarRegistos.EditProject(Convert.ToInt32(Request.QueryString["id"]), nome, descricao);
            }
            else
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string sql = "INSERT INTO Projeto (Nome, Descricao) values (@nome, @descricao)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("/Conteudos/ConsultarProjetos.aspx");
        }

        [WebMethod]
        public static Projeto getProjectById(int idProject)
        {
            return null;
        }
    }
}