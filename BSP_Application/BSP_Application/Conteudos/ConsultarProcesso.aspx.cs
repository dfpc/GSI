using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.Conteudos
{
    public partial class ConsultarProcesso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gdvProcesso.DataSource = AdicionarRegistos.GetAllProcess();
                gdvProcesso.DataBind();

            }
        }

        protected void lkbDeleteProcesso_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string EditProcess(int index)
        {
            if (HttpContext.Current.Session["ListaProcessos"] == null) return string.Empty;
            int id = (HttpContext.Current.Session["ListaProcessos"] as List<Processo>).ElementAt(index - 1).Id;
            return string.Concat("/FormPages/RegisterProcess.aspx?id=", id.ToString());
        }
    }
}