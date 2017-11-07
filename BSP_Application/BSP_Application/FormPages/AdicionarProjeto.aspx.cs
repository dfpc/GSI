using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSP_Application.DataObjects;
using System.Data.SqlClient;

namespace BSP_Application.FormPages
{
    public partial class AdicionarProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //AdicionarRegistos.AddProject();
        }

        protected void Guardar_Projeto(object sender, EventArgs e)
        {
            string nome = inputNome.Value;
            string descricao = comment.Value;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            string sql = "INSERT INTO Projeto (Nome, Descricao) values (@nome, @descricao)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            cmd.ExecuteNonQuery();
        }
    }
}