﻿using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
               // gdvClassesDados.DataSource = AdicionarRegistos.GetAllDataClasses2();
                gdvClassesDados.DataBind();
            }
        }

        protected void lkbDeleteClass_Click(object sender, EventArgs e)
        {

        }
    }
}