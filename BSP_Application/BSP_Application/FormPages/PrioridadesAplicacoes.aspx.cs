using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        /*  protected void btnSavePrioridades_Click(object sender, EventArgs e)
          {
              List<Aplicacao> apps = AdicionarRegistos.GetAllAplications();

              foreach (Aplicacao a in apps)
              {
                   ulPrioridades.FindControl("priority1" + a.Id);




              }
          }
          */

<<<<<<< HEAD
            foreach (Aplicacao a in apps)
            {
                 ulPrioridades.FindControl("priority1" + a.Id);
               
            
=======
>>>>>>> e674ef9b1f907cffe2d15a7d3407d04ee719dd33


    }
}