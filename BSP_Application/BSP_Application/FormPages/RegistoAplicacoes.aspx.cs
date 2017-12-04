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
    public partial class RegistoAplicacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string com = "Select Nome, Descricao, IdProjeto FROM Aplicacao";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ListaProjetos.DataSource = dt;
                ListaProjetos.DataTextField = "Nome";
                ListaProjetos.DataValueField = "IDProjeto";
                ListaProjetos.DataBind();



                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    EditApplication(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
        }
        private void EditApplication(int id)
        {
            hTitle.InnerText = "Editar Aplicações";
            Aplicacao a = AdicionarRegistos.GetApplicationById(id);
            inputNome.Value = a.Nome;
            comment.Value = a.Descricao;
            ListaProjetos.SelectedIndex = ListaProjetos.Items.IndexOf(ListaProjetos.Items.FindByText(a.NomeProjeto));
           
        }

        protected void registaraplicacao_Click(object sender, EventArgs e)
        {
            string nome = inputNome.Value;
            string descricao = comment.Value;
            int idprojeto = Int32.Parse(ListaProjetos.SelectedValue);
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                AdicionarRegistos.EditApplication(Convert.ToInt32(Request.QueryString["id"]), nome, descricao, idprojeto);
            }
            else
            {

                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string sql = "INSERT INTO Aplicacao (Nome, Descricao, IdProjeto) values (@nome, @descricao, @projeto)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@projeto", idprojeto);
                cmd.ExecuteNonQuery();

            }
            Response.Write("<script>alert('Aplicação registada com sucesso!');window.location.href ='/Conteudos/ConsultarAplicacoes.aspx';</script>");
        
        }

        [WebMethod]
        public static Aplicacao getApplicationById(int idApplication)
        {
            return null;
        }



    }
}