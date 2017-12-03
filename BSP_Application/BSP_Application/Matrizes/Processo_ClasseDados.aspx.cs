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

                BuildMatrix();

            }
        }

        private void BuildMatrix()
        {
            string idprojeto = ListaProjetos.SelectedValue;

            SqlConnection conn2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            conn2.Open();
            SqlCommand cmd = new SqlCommand("SELECT Nome, Id FROM ClasseDados WHERE IDProjeto=@idprojeto", conn2);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);

            SqlDataReader rd = cmd.ExecuteReader();
            table.Append("<table border='1'>");
            table.Append("<tr><th>Processos/Classe de Dados</th>");
            int[] ids = new int[100];
            List<Processo_Classe> ProcClasse = new List<Processo_Classe>();

            if (rd.HasRows)
            {
                int count = 0;
                while (rd.Read())
                {

                    table.Append("<th class='verticalTableHeader'>" + rd[0] + "</th>");
                    ids[count] = Convert.ToInt32(rd[1]);

                    count++;

                }
                table.Append("</tr>");
                rd.Close();

                if (ids[0] == 0) return;
                
                cmd = new SqlCommand("SELECT Nome, Id FROM Processo WHERE IDProjeto=@idprojeto", conn2);
                cmd.Parameters.AddWithValue("@idprojeto", idprojeto);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    table.Append("<tr>");
                    table.Append("<td>" + dr[0] + "</td>");
                    for (var i = 0; i < count; i++)
                    {
                        string aux = AdicionarRegistos.GetProcessoClass(Convert.ToInt32(dr[1]),ids[i]);
                        if (!string.IsNullOrEmpty(aux))
                            ProcClasse.Add(new Processo_Classe() { IDClasseDados = ids[i], IDProcesso = Convert.ToInt32(dr[1]), Value = aux });

                        table.Append("<td><center>" +
                            "<select onchange='Proc_ClasseChange(this.value, \"" + dr[1].ToString() + "\",\"" + ids[i].ToString() + "\");'> ");
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
                    table.Append("</tr>");
                }
                dr.Close();
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
    }
    public class Processo_Classe
    {
        public int IDClasseDados { get; set; }
        public int IDProcesso { get; set; }
        public string Value { get; set; }
    }
}