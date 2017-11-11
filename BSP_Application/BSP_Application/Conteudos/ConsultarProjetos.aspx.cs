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

namespace BSP_Application.Conteudos
{
    public partial class ConsultarProjetos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["ListaProjetos"] = AdicionarRegistos.GetAllProjects();
                gdvProjetos.DataSource = Session["ListaProjetos"];
                gdvProjetos.DataBind();
            }
        }

        protected void EditarProjeto_Click(object sender, EventArgs e)
        {
            //vai a base de dados buscar o projeto

        }

        protected void lkbDeleteProjeto_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");

        }

        [WebMethod]
        public static string EditProject(int index)
        {
            if (HttpContext.Current.Session["ListaProjetos"] == null) return string.Empty;
            int id = (HttpContext.Current.Session["ListaProjetos"] as List<Projeto>).ElementAt(index).IDProjeto;
            return string.Concat("/FormPages/AdicionarProjeto.aspx?id=", id.ToString());
        }
        
    }
}