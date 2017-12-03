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
    public partial class ConsultarClasseDados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gdvClassesDados.DataSource = AdicionarRegistos.GetAllDataClasses();
                gdvClassesDados.DataBind();
            }
        }

        [WebMethod]
        public static bool DeleteClass(int index)
        {
            if (HttpContext.Current.Session["ListaClasses"] == null) return false;
            int id = (HttpContext.Current.Session["ListaClasses"] as List<ClasseDados>).ElementAt(index - 1).IDClasseDados;
            return AdicionarRegistos.DeleteClass(id);
        }


    }
}