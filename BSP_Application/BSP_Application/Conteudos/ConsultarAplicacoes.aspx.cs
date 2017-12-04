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
    public partial class ConsultarAplicacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*gdvAplicacoes.DataSource = AdicionarRegistos.GetAllAplications();
                gdvAplicacoes.DataBind();*/

                Session["ListaAplicacoes"] = AdicionarRegistos.GetAllAplications();
                gdvAplicacoes.DataSource = Session["ListaAplicacoes"];
                gdvAplicacoes.DataBind();
            }
        }

        [WebMethod]
        public static string EditApplication(int index)
        {
            if (HttpContext.Current.Session["ListaAplicacoes"] == null) return string.Empty;
            int id = (HttpContext.Current.Session["ListaAplicacoes"] as List<Aplicacao>).ElementAt(index - 1).Id;
            return string.Concat("/FormPages/RegistoAplicacoes.aspx?id=", id.ToString());
        }

        [WebMethod]
        public static bool DeleteApplication(int index)
        {
            if (HttpContext.Current.Session["ListaAplicacoes"] == null) return false;
            int id = (HttpContext.Current.Session["ListaAplicacoes"] as List<Aplicacao>).ElementAt(index - 1).Id;
            return AdicionarRegistos.DeleteApplication(id);
        }
    }
}