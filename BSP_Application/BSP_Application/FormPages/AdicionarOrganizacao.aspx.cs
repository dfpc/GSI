using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
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
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    EditOrganization(Convert.ToInt32(Request.QueryString["id"]));
                    hdIdOrganizacao.Value = Request.QueryString["id"];
                    Session["Projetos"] = AdicionarRegistos.GetAllProjectsToEditOrganization(Convert.ToInt32(Request.QueryString["id"]));
                }
                else
                    Session["Projetos"] = AdicionarRegistos.GetAllProjectsToOrganization();
                gdvProjetos.DataSource = Session["Projetos"];
                gdvProjetos.DataBind();
            }
        }

        private void EditOrganization(int id)
        {
            hTitle.InnerText = "Editar Entidade da Organização";
            Organizacao o = AdicionarRegistos.GetOrganizacaoById(id);
            inputNome.Value = o.Nome;
            comment.Value = o.Descricao;
        }

        [WebMethod]
        public static void SaveOrganization(string nome, string descricao, int[] projetos, int? id)
        {
            if (id != null && id > 0)
            {
                //AdicionarRegistos.DeleteOrganizationProjectByOrganization((int)id);
                AdicionarRegistos.EditOrganization((int)id, nome, descricao);
            }
            else
            {
                id = AdicionarRegistos.InsertOrganization(nome, descricao);
            }
            if (HttpContext.Current.Session["Projetos"] == null) return;
            List<ProjetoOrganizacao> po = HttpContext.Current.Session["Projetos"] as List<ProjetoOrganizacao>;

            foreach (int i in projetos)
            {
                AdicionarRegistos.InsertOrganizationProject((int)id, po.ElementAt(i).IDProjeto);
            }
        }
    }
}