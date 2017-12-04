using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.FormPages
{
    public partial class RegistarUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            AdicionarRegistos.InsertUser(inputUsername.Value, tbxPassword.Value, tbxEmail.Value, tbxNome.Value);
            Response.Write("<script>alert('Utilizador registado com sucesso!');</script>");
        }
    }
}