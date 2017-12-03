using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BSP_Application.Matrizes
{
    public partial class Processo_ClasseDados_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string com = "Select Nome, IDProjeto from Projeto";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ListaProjetos.DataSource = dt;
                ListaProjetos.DataTextField = "Nome";
                ListaProjetos.DataValueField = "IDProjeto";
                ListaProjetos.DataBind();
                BuildForm();
            }
        }

        private void BuildForm()
        {
            int idProject = Convert.ToInt32(ListaProjetos.SelectedValue);

            List<ClasseDados> cd = AdicionarRegistos.GetClassDataByProject(idProject);
            List<Processo> p = AdicionarRegistos.GetProcessByProject(idProject);

            foreach (ClasseDados c in cd)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "row");
                div.ID = "div" + c.IDClasseDados;
                HtmlGenericControl label = new HtmlGenericControl("label");
                label.Attributes.Add("class", "col-sm-2 control-label");
                label.InnerText = c.Nome;
                div.Controls.Add(label);
                HtmlGenericControl div2 = new HtmlGenericControl("div");
                div2.Attributes.Add("class", "col-sm-8");
                div2.ID = "div2" + c.IDClasseDados;
                HtmlSelect select = new HtmlSelect();
                select.ID = "select" + c.IDClasseDados;
                select.Attributes.Add("id", "select" + c.IDClasseDados);
                select.Attributes.Add("runat", "server");
                foreach (Processo process in p)
                {
                    select.Items.Add(new ListItem(process.Nome, process.Id.ToString()));
                }
                select.Attributes.Add("class", "form-control");
                div2.Controls.Add(select);
                div.Controls.Add(div2);
                divProjectsForm.Controls.Add(div);
            }
        }

        protected void ListaProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildForm();
        }

        [WebMethod]
        public static string SaveClassDataProcess(int[] array, int idproject)
        {
            List<ClasseDados> cd = AdicionarRegistos.GetClassDataByProject(idproject);

            int count = 0;
            foreach (ClasseDados c in cd)
            {
                AdicionarRegistos.SaveProcessClasse(c.IDClasseDados, array[count], "C");
                count++;
            }
            return "/Matrizes/Processo_ClasseDados.aspx";
        }
    }
}