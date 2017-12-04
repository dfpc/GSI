using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.FormPages
{
    public partial class RegistoClasseDados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string com = "Select Nome, IDProjeto from Projeto";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ListaProjetos.DataSource = dt;
                ListaProjetos.DataTextField = "Nome";
                ListaProjetos.DataValueField = "IDProjeto";
                ListaProjetos.DataBind();

                ListaEntidades.DataSource = AdicionarRegistos.GetAllEntities();
                ListaEntidades.DataTextField = "NomeTipo";
                ListaEntidades.DataValueField = "Id";
                ListaEntidades.DataBind();


                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    editClass(Convert.ToInt32(Request.QueryString["id"]));
                }

            }
        }

        private void editClass(int id)
        {
            ClasseDados cd = AdicionarRegistos.GetClassDataById(id);
            ListaProjetos.SelectedIndex = ListaProjetos.Items.IndexOf(ListaProjetos.Items.FindByText(cd.NomeProjeto));
            ListaEntidades.SelectedIndex = ListaEntidades.Items.IndexOf(ListaEntidades.Items.FindByText(cd.NomeEntidade));
            inputNome.Value = cd.Nome;
            comment.Value = cd.Descricao;
        }

        protected void Guardar_ClasseDados(object sender, EventArgs e)
        {
            string nome = inputNome.Value;
            string descricao = comment.Value;
            int idprojeto = Int32.Parse(ListaProjetos.SelectedValue);
            int identidade = Int32.Parse(ListaEntidades.SelectedValue);

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                AdicionarRegistos.EditClass(Convert.ToInt32(Request.QueryString["id"]), nome, descricao, idprojeto, identidade);
            }
            else
            { 
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            string sql = "INSERT INTO ClasseDados (Nome, Descricao, IDProjeto, IDEntidade) values (@nome, @descricao, @idprojeto, @identidade)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);
            cmd.Parameters.AddWithValue("@identidade", identidade);

            cmd.ExecuteNonQuery();
            }
            Response.Write("<script>alert('Classe de dados registada com sucesso!');window.location.href ='/Conteudos/ConsultarClasseDados.aspx';</script>");
      

        }

        [WebMethod]
        public static ClasseDados GetClassDataById(int idclasse)
        {
            return null;
        }
    }
}