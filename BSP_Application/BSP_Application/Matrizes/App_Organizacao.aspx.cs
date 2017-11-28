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
    public partial class App_Organizacao : System.Web.UI.Page
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

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT O.Nome, O.Id FROM Organizacao O, OrganizacaoProjeto OP WHERE O.Id=OP.IDOrganizacao AND OP.IdProjeto=@idprojeto ORDER BY O.Nome", con);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);

            SqlDataReader rd = cmd.ExecuteReader();
            table.Append("<table border='1'>");
            table.Append("<tr><th>Aplicações/Organização</th>");
            int[] ids = new int[100];
            List<App_Organization> appOrg = new List<App_Organization>();

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


                cmd = new SqlCommand("SELECT A.Nome, A.Id FROM Aplicacao A WHERE A.IdProjeto=@idprojeto ORDER BY A.Nome", con);
                cmd.Parameters.AddWithValue("@idprojeto", idprojeto);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    table.Append("<tr>");
                    table.Append("<td>" + dr[0] + "</td>");

                    for (var i = 0; i < count; i++)
                    {
                        string aux = AdicionarRegistos.GetAppOrg(Convert.ToInt32(dr[1]), ids[i]);
                        if (!string.IsNullOrEmpty(aux))
                            appOrg.Add(new App_Organization() { IDApp = Convert.ToInt32(dr[1]), IDOrg = ids[i], Value = aux });
                        table.Append("<td><select onchange='app_OrganizacaoChange(this.value, "+ ids[i].ToString() + "," +  dr[1].ToString() + ");'>");
                        if (string.IsNullOrEmpty(aux))
                        {
                            table.Append("<option Value='0' selected></option>");
                        }
                        else
                            table.Append("<option Value='0'></option>");
                        if (aux == "A")
                            table.Append("<option Value='1' selected>A</option>");
                        else
                            table.Append("<option Value='1'>A</option>");
                        if (aux == "P")
                            table.Append("<option Value='2' selected>P</option>");
                        else
                            table.Append("<option Value='2'>P</option>");
                        if (aux == "A/P")
                            table.Append("<option Value='3' selected>A/P</option>");
                        else
                            table.Append("<option Value='3'>A/P</option>");
                        table.Append("</select></td>");
                    }
                    table.Append("</tr>");
                }
                dr.Close();
            }
            table.Append("</table>");
            AplicacaoOrganizacao.Controls.Add(new Literal { Text = table.ToString() });
            Session["ListAppOrganization"] = appOrg;
        }

        protected void ListaProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildMatrix();
        }

        [WebMethod]
        public static List<App_Organization> FirstGet()
        {
            if (HttpContext.Current.Session["ListAppOrganization"] == null) return new List<App_Organization>();
            return HttpContext.Current.Session["ListAppOrganization"] as List<App_Organization>;
        }

        [WebMethod]
        public static void SaveApp_Organization(List<App_Organization> appOrganization)
        {
            foreach (App_Organization ap in appOrganization)
                AdicionarRegistos.SaveAppOrganization(ap.IDApp, ap.IDOrg, ap.Value);
        }
    }
    public class App_Organization
    {
        public int IDApp { get; set; }
        public int IDOrg { get; set; }
        public string Value { get; set; }
    }
}