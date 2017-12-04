using BSP_Application.DataObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BSP_Application.Matrizes
{
    public partial class Processo_ClasseDados : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();

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

                ListaProjetos.SelectedIndex = ListaProjetos.Items.IndexOf(ListaProjetos.Items.FindByValue(Request.QueryString["id"]));

                List<Processo> processos = AdicionarRegistos.GetProcessByProject(Convert.ToInt32(Request.QueryString["id"]));
                selectProcess.DataSource = processos;
                selectProcess.DataValueField = "Id";
                selectProcess.DataTextField = "Nome";
                selectProcess.DataBind();

                BuildMatrix();
            }
        }

        private void BuildMatrix()
        {
            string idprojeto = ListaProjetos.SelectedValue;

            table.Append("<table border='1'>");
            table.Append("<tr><th>Processos/Classe de Dados</th>");
            List<Processo_Classe> ProcClasse = new List<Processo_Classe>();
            List<ProcessoClasseDados> pcd = AdicionarRegistos.GetProcessoClasseDadosByProject(Convert.ToInt32(idprojeto));

            List<int> ids = new List<int>();
            List<int> idsc = new List<int>();
            foreach (ProcessoClasseDados cd in pcd)
            {
                table.Append("<th class='verticalTableHeader'>" + cd.ClasseDados + "</th>");
                idsc.Add(cd.IDClasseDados);
            }
            table.Append("</tr>");

            if (idsc.Count == 0) return;
            int count = 1;
            foreach (ProcessoClasseDados p in pcd)
            {
                if (!ids.Exists(it => it == p.IDProcesso))
                {
                    table.Append("<tr>");
                    table.Append("<td>" + p.Processo + "</td>");
                    if(p.Posicao==null)
                        AdicionarRegistos.SaveProcessPosition(p.IDProcesso, count);
                    count++;
                    for (var i = 0; i < idsc.Count; i++)
                    {
                        string aux = AdicionarRegistos.GetProcessoClass(p.IDProcesso, idsc[i]);
                        if (!string.IsNullOrEmpty(aux))
                            ProcClasse.Add(new Processo_Classe() { IDClasseDados = idsc[i], IDProcesso = p.IDProcesso, Value = aux });
                        if (aux == "C")
                        {
                            table.Append("<td><center><label>C</label></center></td>");
                        }
                        else
                        {
                            table.Append("<td><center>" +
                                "<select onchange='Proc_ClasseChange(this.value, \"" + p.IDProcesso.ToString() + "\",\"" + idsc[i].ToString() + "\");' > ");
                            if (string.IsNullOrEmpty(aux))
                                table.Append("<option value = ' ' selected='selected'>  </ option >");
                            else
                                table.Append("<option value = ' '>  </ option >");

                            if (aux == "U")
                                table.Append("<option Value='U' selected='selected'>U</option>");
                            else
                                table.Append("<option value = 'U' > U </ option >");

                            table.Append("</select></center></td>");
                        }
                    }
                    table.Append("</tr>");
                    ids.Add(p.IDProcesso);
                }
            }
            table.Append("</table>");
            ProcessoClasse.Controls.Add(new Literal { Text = table.ToString() });
            Session["ListProcClasse"] = ProcClasse;
        }

        protected void ListaProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildMatrix();
        }

        [WebMethod]
        public static List<Processo_Classe> FirstGet()
        {
            if (HttpContext.Current.Session["ListProcClasse"] == null) return new List<Processo_Classe>();
            return HttpContext.Current.Session["ListProcClasse"] as List<Processo_Classe>;
        }

        [WebMethod]
        public static void SaveProcesso_Classe(List<Processo_Classe> processClasse)
        {
            foreach (Processo_Classe pc in processClasse)
                AdicionarRegistos.SaveProcessClasse(pc.IDClasseDados, pc.IDProcesso, pc.Value);
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            int process = Convert.ToInt32(selectProcess.Value);
            int position = Convert.ToInt32(tbxPosition.Value);
            List<ProcessoClasseDados> pcd = AdicionarRegistos.GetProcessoClasseDadosByProject(Convert.ToInt32(Request.QueryString["id"]));
            List<ProcessoClasseDados> aux = pcd.FindAll(it => it.IDProcesso == process);

            ProcessoClasseDados aux2 = pcd.FirstOrDefault(it => it.Posicao == position);
            if (aux2 != null)
            {
                aux2.Posicao = aux.First().Posicao;
                AdicionarRegistos.SaveProcessPosition(aux2.IDProcesso, aux2.Posicao);
            }
            foreach (ProcessoClasseDados p in aux)
            {
                p.Posicao = position;
                AdicionarRegistos.SaveProcessPosition(p.IDProcesso, position);
            }

            BuildMatrix();
        }
    }
    public class Processo_Classe
    {
        public int IDClasseDados { get; set; }
        public int IDProcesso { get; set; }
        public string Value { get; set; }
    }
}