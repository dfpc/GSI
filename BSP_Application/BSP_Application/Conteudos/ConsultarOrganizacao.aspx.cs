﻿using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.Conteudos
{
    public partial class ConsultarOrganizacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gdvOrganizacao.DataSource = AdicionarRegistos.GetAllOrganizations();
                gdvOrganizacao.DataBind();
            }
        }

        protected void lkbDeleteOrganization_Click(object sender, EventArgs e)
        {

        }
    }
}