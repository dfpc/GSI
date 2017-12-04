using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSP_Application.DataObjects;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;

namespace BSP_Application.FormPages
{
    public partial class RegistoFuncoesEquipa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string com = "Select Nome, IdProjeto FROM Projeto";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ListaProjetos.DataSource = dt;
                ListaProjetos.DataTextField = "Nome";
                ListaProjetos.DataValueField = "IDProjeto";
                ListaProjetos.DataBind();
            }
        }



        protected void avancar_Click1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            string sql = "INSERT INTO GrupoDirecao (IDProjeto, Nome) values (@idprojeto, @nome)";
            conn.Open();

            int idprojeto = Int32.Parse(ListaProjetos.SelectedValue);
            string grupo = grupotextarea.Value;

            string[] sArray = grupo.Split(';');
            for (int i=0; i<sArray.Length;i++)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", sArray[i]);
                cmd.Parameters.AddWithValue("@idprojeto", idprojeto);
                cmd.ExecuteNonQuery();
            }
           
            Response.Redirect("/FormPages/RegistoFuncoesEquipaP2.aspx");


        }
    }
}