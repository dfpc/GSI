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
    public partial class AdicionarOrganizacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Projetos"] = AdicionarRegistos.GetAllProjectsToOrganization();
                gdvProjetos.DataSource = Session["Projetos"];
                gdvProjetos.DataBind();
            }
        }

        [WebMethod]
        public static void SaveOrganization(string nome, string descricao, int[] projetos)
        {
            int id = AdicionarRegistos.InsertOrganization(nome, descricao);
            if (HttpContext.Current.Session["Projetos"] == null) return;
            List<ProjetoOrganizacao> po = HttpContext.Current.Session["Projetos"] as List<ProjetoOrganizacao>;

            foreach (int i in projetos)
            {
                AdicionarRegistos.InsertOrganizationProject(id, po.ElementAt(i).IDProjeto);
            }
        }
    }
}