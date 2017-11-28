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
    public partial class ConsultarSumariacaoEntrevistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gdvEntrevistas.DataSource = AdicionarRegistos.GetAllSumariacao();
                gdvEntrevistas.DataBind();
            }

        }
        [WebMethod]
        public static string EditSumariacao(int index)
        {
            if (HttpContext.Current.Session["ListaProblemas"] == null) return string.Empty;
            int id = (HttpContext.Current.Session["ListaProblemas"] as List<Problema>).ElementAt(index - 1).IDProblema;
            return string.Concat("/FormPages/SumariacaoEntrevistas.aspx?id=", id.ToString());
        }
    }
}