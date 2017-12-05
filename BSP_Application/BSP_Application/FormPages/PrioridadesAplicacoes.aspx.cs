using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BSP_Application.FormPages
{
    public partial class PrioridadesAplicacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Aplicacao> apps = AdicionarRegistos.GetAllAplications();
                Session["ApplicationsList"] = apps;
                foreach (Aplicacao a in apps)
                {
                    ulPrioridades.InnerHtml += "<li class='col-sm-12'><div class='row'><div class='col-sm-3'><div class='form-group'><label class='form-control'>" + a.Nome + "</ label ></div></div>" +
                    "<div class='col-sm-2'><div class='form-group'><input class='form-control' runat='server' clientidmode='static' id='priority1" + a.Id + "' type='number' min='0' max='10'/></div></div>"
                    + "<div class='col-sm-2'><div class='form-group'><input class='form-control' runat='server' clientidmode='static' id='priority2" + a.Id + "' type='number' min='0' max='10'/></div></div>"
                    + "<div class='col-sm-2'><div class='form-group'><input class='form-control' runat='server' clientidmode='static' id='priority3" + a.Id + "' type='number' min='0' max='10'/></div></div>"
                    + "<div class='col-sm-2'><div class='form-group'><input class='form-control' runat='server' clientidmode='static' id='priority4" + a.Id + "' type='number' min='0' max='10'/></div></div></div></li>";
                }
            }
        }

        [WebMethod]
        public static string SavePriority(string[] array)
        {
            List<Aplicacao> apps = HttpContext.Current.Session["ApplicationsList"] as List<Aplicacao>;
            int count = 0;
            foreach (Aplicacao app in apps)
            {
                if (string.IsNullOrEmpty(array[count])) return string.Empty;
                AdicionarRegistos.InsertPriority(app.Id, 1, Convert.ToInt32(array[count]));
                AdicionarRegistos.InsertPriority(app.Id, 2, Convert.ToInt32(array[count + 1]));
                AdicionarRegistos.InsertPriority(app.Id, 3, Convert.ToInt32(array[count + 2]));
                AdicionarRegistos.InsertPriority(app.Id, 4, Convert.ToInt32(array[count + 3]));
                count += 4;
            }
            return string.Empty;
        }
    }
}