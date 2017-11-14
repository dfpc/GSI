using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
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



            }
        }


        protected void ListaProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idprojeto = ListaProjetos.SelectedIndex;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT A.Nome, P.Nome FROM Aplicacao A, Processo P WHERE A.IdProjeto=P.IDProjeto AND A.IdProjeto=@idprojeto ORDER BY A.Nome", con);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);

            SqlDataReader rd = cmd.ExecuteReader();
            table.Append("<table border='1'>");
            table.Append("<tr><th>Aplicações/Processos</th>");

            string processo = "";
            if (rd.HasRows)
            {
                int count = 0;
                while (rd.Read())
                {
                    if (processo != rd[1].ToString())
                    {
                        table.Append("<th class='verticalTableHeader'>" + rd[1] + "</th>");
                        count++;
                    }

                   
                    processo = rd[1].ToString();
                }
                table.Append("</tr>");
                rd.Close();



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
                            table.Append("<td></td>");
                        }
                        table.Append("</tr>");
                        aplicacao = dr[0].ToString();
                    }
                }
                dr.Close();
            }
            table.Append("</table>");
            AplicacaoProcesso.Controls.Add(new Literal { Text = table.ToString() });

        }
    }
}