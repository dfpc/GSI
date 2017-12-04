using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.FormPages
{
    public partial class AdicionarEntidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdicionarRegistos.InsertEntidade(inputNome.Value, cmbType.Items[cmbType.SelectedIndex].Text, ckbIntern.Checked);

            Response.Write("<script>alert('Entidade adicionada com sucesso!');window.location.href ='/Conteudos/ConsultarEntidades.aspx';</script>");
        
        }
    }
}