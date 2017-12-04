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
            List<ProcessoClasseDados> pcd = AdicionarRegistos.GetProcessoClasseDadosByProject(Convert.ToInt32(idProject));

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
                foreach (Processo process in p)
                {
                    select.Items.Add(new ListItem(process.Nome, process.Id.ToString()));
                }
                ProcessoClasseDados aux = pcd.FirstOrDefault(it => it.IDClasseDados == c.IDClasseDados);
                if (aux != null)
                    select.SelectedIndex = select.Items.IndexOf(select.Items.FindByValue(aux.IDProcesso.ToString()));
                select.Attributes.Add("class", "form-control process-selection");
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
            List<Processo> p = AdicionarRegistos.GetProcessByProject(idproject);
            int count = 0;
            List<int> aux = array.ToList();
            foreach(Processo paux in p)
            {
                if (!aux.Exists(it => it == paux.Id)) return string.Empty;
            }
            
            foreach (ClasseDados c in cd)
            {
                AdicionarRegistos.DeleteProcessClasseByClass(c.IDClasseDados, "C");
                AdicionarRegistos.SaveProcessClasse(c.IDClasseDados, array[count], "C");
                count++;
            }
            return "/Matrizes/Processo_ClasseDados.aspx?id="+idproject.ToString();
        }
    }
}