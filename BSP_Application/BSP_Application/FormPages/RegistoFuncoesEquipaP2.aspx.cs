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
    public partial class RegistoFuncoesEquipaP2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string com = "Select Nome, Id FROM GrupoDirecao";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ListaGrupos.DataSource = dt;
                ListaGrupos.DataTextField = "Nome";
                ListaGrupos.DataValueField = "Id";
                ListaGrupos.DataBind();
            }

        }

     

        protected void guardar_Click1(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            string sql = "INSERT INTO Funcao (IDGrupoDirecao, Nome) values (@idgrupo, @nome)";
            conn.Open();

            int idgrupo = Int32.Parse(ListaGrupos.SelectedValue);
            string funcao = funcaotextarea.Value;

            string[] sArray = funcao.Split(';');
            for (int i = 0; i < sArray.Length; i++)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", sArray[i]);
                cmd.Parameters.AddWithValue("@idgrupo", idgrupo);
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("/Conteudos/ConsultarFuncoesEquipa.aspx");
        }
    }
}