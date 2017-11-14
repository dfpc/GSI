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
                gdvAplicacoes.DataSource = AdicionarRegistos.GetAllAplications();
                gdvAplicacoes.DataBind();
            }
        }
    }
}