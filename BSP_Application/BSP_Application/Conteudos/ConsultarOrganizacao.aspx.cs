using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.Conteudos
{
    public partial class ConsultarOrganizacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["ListaOrganizacoes"] = AdicionarRegistos.GetAllOrganizations();
                gdvOrganizacao.DataSource = Session["ListaOrganizacoes"];
                gdvOrganizacao.DataBind();
            }
        }

        protected void lkbDeleteOrganization_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string EditOrganization(int index)
        {
            if (HttpContext.Current.Session["ListaOrganizacoes"] == null) return string.Empty;
            int id = (HttpContext.Current.Session["ListaOrganizacoes"] as List<Organizacao>).ElementAt(index - 1).Id;
            return string.Concat("/FormPages/AdicionarOrganizacao.aspx?id=", id.ToString());
        }
    }
}