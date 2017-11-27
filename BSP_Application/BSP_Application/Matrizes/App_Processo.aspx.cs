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
    public partial class App_Processo : System.Web.UI.Page
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
            int idprojeto = Convert.ToInt32(ListaProjetos.SelectedValue);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT A.Nome, P.Nome, A.Id as IDAplicacao, P.Id as IDProcesso FROM Aplicacao A, Processo P WHERE A.IdProjeto=P.IDProjeto AND A.IdProjeto=@idprojeto ORDER BY A.Nome", con);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);
            List<App_Process> appProcess = new List<App_Process>();

            SqlDataReader rd = cmd.ExecuteReader();
            table.Append("<table border='1'>");
            table.Append("<tr><th>Aplicações/Processos</th>");
            int[] ids = new int[100];

            string processo = "";
            if (rd.HasRows)
            {
                int count = 0;
                while (rd.Read())
                {
                    if (processo != rd[1].ToString())
                    {
                        table.Append("<th class='verticalTableHeader'>" + rd[1] + "</th>");
                        ids[count] = Convert.ToInt32(rd[3]);
                        count++;
                    }
                    processo = rd[1].ToString();
                }
                table.Append("</tr>");
                rd.Close();

                if (ids[0] == 0) return;
                SqlDataReader dr = cmd.ExecuteReader();
                string aplicacao = "";

                while (dr.Read())
                {

                    if (aplicacao != dr[0].ToString())
                    {
                        table.Append("<tr>");
                        table.Append("<td>" + dr[0] + "</td>");

                        for (var i = 0; i < count; i++)
                        {
                            string aux = AdicionarRegistos.GetAppProcess(Convert.ToInt32(dr[2]), ids[i]);
                            appProcess.Add(new App_Process() { IDApp = Convert.ToInt32(dr[2]), IDProcess = ids[i], Value = aux });
                            table.Append("<td><select onchange='App_ProcessoChange(this.value, " + dr[2].ToString() + "," + ids[i].ToString() + ");'>");
                            if (string.IsNullOrEmpty(aux))
                            {
                                table.Append("<option Value='0' selected></option>");
                            }
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
                        aplicacao = dr[0].ToString();
                    }
                }
                dr.Close();
            }
            table.Append("</table>");
            AplicacaoProcesso.Controls.Add(new Literal { Text = table.ToString() });
            Session["ListAppProcess"] = appProcess;
        }

        protected void ListaProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildMatrix();
        }

        [WebMethod]
        public static List<App_Process> FirstGet()
        {
            if (HttpContext.Current.Session["ListAppProcess"] == null) return new List<App_Process>();
                return HttpContext.Current.Session["ListAppProcess"] as List<App_Process>;
        }

        [WebMethod]
        public static void SaveApp_Process(List<App_Process> appProcess)
        {
            foreach (App_Process ap in appProcess)
                AdicionarRegistos.SaveAppProcess(ap.IDApp, ap.IDProcess, ap.Value);
        }
    }
}