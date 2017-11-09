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
    public partial class Processo_ClasseDados : System.Web.UI.Page
    {


        StringBuilder table = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CD.Nome AS Classe, P.Nome AS Processo FROM ClasseDados CD, Processo P WHERE CD.IDProjeto=P.IDProjeto", conn);
                SqlDataReader rd = cmd.ExecuteReader();
                table.Append("<table border='1'>");
                table.Append("<tr><th>Processos/Classe de Dados</th>");

                if (rd.HasRows)
                {
                    int count = 0;
                    while(rd.Read())
                    {
                       
                        table.Append("<th class='rotate'>" + rd[0] + "</th>");
                        count++;

                    }
                    table.Append("</tr>");
                    rd.Close();
                   


                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        table.Append("<tr>");
                        table.Append("<td>" + dr[1] +"</td>");
                        for (var i = 0; i < count; i++)
                        {
                            table.Append("<td></td>");
                        }
                        table.Append("</tr>");

                    }
                    dr.Close();
                }
                table.Append("</table>");
                ProcessoClasse.Controls.Add(new Literal { Text = table.ToString() });

            }
        }
       

    }
}