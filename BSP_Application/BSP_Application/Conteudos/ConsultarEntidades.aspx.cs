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
    public partial class ConsultarEntidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["ListaEntidades"] = AdicionarRegistos.GetAllEntities();
                gdvEntidades.DataSource = Session["ListaEntidades"];
                gdvEntidades.DataBind();
            }
        }

        [WebMethod]
        public static bool DeleteEntidade(int index)
        {
            if (HttpContext.Current.Session["ListaEntidades"] == null) return false;
            int id = (HttpContext.Current.Session["ListaEntidades"] as List<Entidade>).ElementAt(index - 1).Id;
            return AdicionarRegistos.DeleteEntidade(id);
        }
    }
}