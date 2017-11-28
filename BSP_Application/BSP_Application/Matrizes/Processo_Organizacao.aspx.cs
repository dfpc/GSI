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
    public partial class Processo_Organizacao : System.Web.UI.Page
    {
        StringBuilder table = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                string com = "Select DISTINCT Nome, O.IDProjeto AS idp from Projeto O, OrganizacaoProjeto OP WHERE O.IDProjeto=OP.IDProjeto";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ListaProjetos.DataSource = dt;
                ListaProjetos.DataTextField = "Nome";
                ListaProjetos.DataValueField = "idp";
                ListaProjetos.DataBind();

                BuildMatrix();
            }
        }

        private void BuildMatrix()
        {
            string idprojeto = ListaProjetos.SelectedValue;
            SqlConnection conn2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            conn2.Open();
            SqlCommand cmd = new SqlCommand("SELECT O.Nome, O.Id FROM Organizacao O, OrganizacaoProjeto OP WHERE OP.IDProjeto=@idprojeto AND OP.IDOrganizacao=O.Id ORDER BY O.Nome", conn2);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);

            SqlDataReader rd = cmd.ExecuteReader();
            
            cmd = new SqlCommand("SELECT P.Nome, P.Id  FROM Processo P WHERE p.IDProjeto=@idprojeto ORDER BY P.Nome", conn2);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);

            SqlDataReader dr = cmd.ExecuteReader();
            table.Append("<table border='1'>");
            table.Append("<tr><th>Processos/Organização</th>");
            int[] ids = new int[100];
            List<Org_Process> OrgProcess = new List<Org_Process>();

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

                while (dr.Read())
                {
                    table.Append("<tr>");
                    table.Append("<td>" + dr[0] + "</td>");
                    for (var i = 0; i < count; i++)
                    {
                        string aux = AdicionarRegistos.GetOrgProcess(Convert.ToInt32(dr[1]), ids[i]);
                        OrgProcess.Add(new Org_Process() { IDOrg = Convert.ToInt32(dr[1]), IDProcess = ids[i], Value = aux });
                        table.Append("<td>" +
                                     "<center><select onchange='Proc_OrganizacaoChange(this.value, " + dr[1].ToString() + "," + ids[i].ToString() + ");'>");
                        if (string.IsNullOrEmpty(aux))
                        {
                            table.Append("<option value = ' ' selected>  </ option >");
                        }
                        else
                            table.Append("<option value = ' '>  </ option >");
                        if (aux == "A")
                            table.Append("<option Value='A' selected>A</option>");
                        else
                            table.Append("<option value = 'A' > A </ option >");
                        if (aux == "D")
                            table.Append("<option Value='D' selected>D</option>");
                        else
                            table.Append(" <option value = 'D' > D </ option> ");
                        if (aux == "A/P")
                            table.Append("<option Value='F' selected>F</option>");
                        else
                            table.Append("<option value = 'F' > F </ option >");
                        table.Append("</select></center></td>");
                }
                table.Append("</tr>");
            }
            dr.Close();
        }
        table.Append("</table>");
            ProcessoOrganizacao.Controls.Add(new Literal { Text = table.ToString()
    });
            Session["ListOrgProcess"] = OrgProcess;
        }

protected void ListaProjetos_SelectedIndexChanged(object sender, EventArgs e)
{
    BuildMatrix();
}

[WebMethod]
public static List<Org_Process> FirstGet()
{
    if (HttpContext.Current.Session["ListOrgProcess"] == null) return new List<Org_Process>();
    return HttpContext.Current.Session["ListOrgProcess"] as List<Org_Process>;
}

[WebMethod]
public static void SaveOrg_Process(List<Org_Process> orgProcess)
{
    foreach (Org_Process op in orgProcess)
        AdicionarRegistos.SaveOrgProcess(op.IDOrg, op.IDProcess, op.Value);
}
    }
    public class Org_Process
{
    public int IDOrg { get; set; }
    public int IDProcess { get; set; }
    public string Value { get; set; }
}
}
