using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.FormPages
{
    public partial class AdicionarOrganizacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gdvProjetos.DataSource = AdicionarRegistos.GetProjectOrganization();
                gdvProjetos.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //AdicionarRegistos.InsertOrganization(inputNome.Value, comment.Value, Int32.Parse(ListaProjetos.SelectedValue));
        }
    }
}