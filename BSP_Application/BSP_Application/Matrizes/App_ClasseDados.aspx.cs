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
    public partial class App_ClasseDados : System.Web.UI.Page
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
            int idprojeto = ListaProjetos.SelectedIndex;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT CD.Nome, CD.Id FROM ClasseDados CD WHERE CD.IdProjeto=@idprojeto ORDER BY CD.Nome", con);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);

            SqlDataReader rd = cmd.ExecuteReader();
            table.Append("<table border='1'>");
            table.Append("<tr><th>Aplicações/Classe de Dados</th>");
            int[] ids = new int[100];
            List<App_CDados> appCD = new List<App_CDados>();
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
                            string aux = AdicionarRegistos.GetAppCD(Convert.ToInt32(dr[1]), ids[i]);
                            if (!string.IsNullOrEmpty(aux))
                                appCD.Add(new App_CDados() { IDApp = Convert.ToInt32(dr[1]), IDClasseDados = ids[i], Value = aux });
                            table.Append("<td><select onchange='app_CDChange(this.value, " + ids[i].ToString() + "," + dr[1].ToString() + ");'>");
                            if (string.IsNullOrEmpty(aux))
                            {
                                table.Append("<option Value='0' selected></option>");
                            }
                            else
                                table.Append("<option Value='0'></option>");
                            if (aux == "X")
                                table.Append("<option Value='X' selected>X</option>");
                            else
                                table.Append("<option Value='X'>X</option>");
                            table.Append("</select></td>");
                        }
                        table.Append("</tr>");
                }
                dr.Close();
            }
            table.Append("</table>");
            AplicacaoClasse.Controls.Add(new Literal { Text = table.ToString() });
            Session["ListAppCD"] = appCD;
        }

        protected void ListaProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildMatrix();
        }

        [WebMethod]
        public static List<App_CDados> FirstGet()
        {
            if (HttpContext.Current.Session["ListAppCD"] == null) return new List<App_CDados>();
            return HttpContext.Current.Session["ListAppCD"] as List<App_CDados>;
        }

        [WebMethod]
        public static void SaveApp_CD(List<App_CDados> appCD)
        {
            foreach (App_CDados ap in appCD)
                AdicionarRegistos.SaveAppCD(ap.IDApp, ap.IDClasseDados, ap.Value);
        }
    }

    public class App_CDados
    {
        public int IDApp { get; set; }
        public int IDClasseDados { get; set; }
        public string Value { get; set; }
    }
}