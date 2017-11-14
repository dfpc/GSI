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
            }
        }
        protected void ListaProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idprojeto = ListaProjetos.SelectedIndex;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT A.Nome, O.Nome FROM Aplicacao A, Organizacao O, OrganizacaoProjeto OP WHERE A.IdProjeto=OP.IDProjeto AND O.Id=OP.IDOrganizacao AND A.IdProjeto=@idprojeto ORDER BY A.Nome", con);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);

            SqlDataReader rd = cmd.ExecuteReader();
            table.Append("<table border='1'>");
            table.Append("<tr><th>Aplicações/Organização</th>");

            string organizacao = "";
            if (rd.HasRows)
            {
                int count = 0;
                while (rd.Read())
                {
                    if (organizacao != rd[1].ToString())
                    { 
                    table.Append("<th class='verticalTableHeader'>" + rd[1] + "</th>");
                    count++;
                    organizacao = rd[1].ToString();
                    }

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
            AplicacaoOrganizacao.Controls.Add(new Literal { Text = table.ToString() });

        }
    }
}