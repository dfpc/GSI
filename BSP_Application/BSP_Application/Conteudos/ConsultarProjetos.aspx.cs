using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.Conteudos
{
    public partial class ConsultarProjetos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            //string com = "Select Nome, IDProjeto from Projeto";
            //SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
            //DataTable dt = new DataTable();
            //adpt.Fill(dt);
            //ListaProjetos.DataSource = dt;
            //ListaProjetos.DataBind();
            //ListaProjetos.DataTextField = "Nome";
            //ListaProjetos.DataValueField = "IDProjeto";
            //ListaProjetos.DataBind();

        }
    }
}