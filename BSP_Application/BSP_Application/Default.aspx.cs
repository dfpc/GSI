using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           User user = AdicionarRegistos.Authenticate(tbxUsername.Value, tbxPassword.Value);
            if(user!=null)
            {
                Session["IDUser"] = user.IDUser;
                Session["Username"] = user.Username;
                Session["IsAdmin"] = user.Admin;
                Response.Redirect("/FormPages/AdicionarProjeto.aspx");
            }
        }
    }
}