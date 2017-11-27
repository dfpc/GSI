﻿using System;
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
            }
        }

        protected void ListaProjetos_SelectedIndexChanged(object sender, EventArgs e)
        {

            string idprojeto = ListaProjetos.SelectedValue;
            SqlConnection conn2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
            conn2.Open();
            SqlCommand cmd = new SqlCommand("SELECT O.Nome, P.Nome, O.Id idorg, P.Id idproc FROM Organizacao O, Processo P, OrganizacaoProjeto OP WHERE OP.IDProjeto=P.IDProjeto AND OP.IDProjeto=@idprojeto AND OP.IDOrganizacao=O.Id ORDER BY O.Nome, P.Nome", conn2);
            cmd.Parameters.AddWithValue("@idprojeto", idprojeto);

            SqlDataReader rd = cmd.ExecuteReader();
            table.Append("<table border='1'>");
            table.Append("<tr><th>Processos/Organização</th>");

            string organizacao = "";
                if (rd.HasRows)
                {
                    int count = 0;
                    while (rd.Read())
                    {
                        if (organizacao != rd[0].ToString()) { 
                        table.Append("<th class='verticalTableHeader'>" + rd[0] + "</th>");
                        count++;
                        }
                         organizacao = rd[0].ToString();

                }
                    table.Append("</tr>");
                    rd.Close();



                    SqlDataReader dr = cmd.ExecuteReader();
                    string processo = "";


                    while (dr.Read())
                    {
                        if (processo != dr[1].ToString())
                        {
                            table.Append("<tr>");
                            table.Append("<td>" + dr[1] + "</td>");
                            for (var i = 0; i < count; i++)
                            {
                                table.Append("<td>"+
                                             "<center><select onchange='Proc_OrganizacaoChange(this.value, " + dr[2].ToString() + "," + dr[3].ToString() + ");>" +
                                             "<option value = 'D' > D </ option >"+
                                             "<option value = 'F' > F </ option >"+
                                             "<option value = 'A' > A </ option >"+
                                             "</select></center></td>"
                                             );
                            }
                            table.Append("</tr>");
                            processo = dr[1].ToString();

                        }
                    }
                    dr.Close();
                }
                table.Append("</table>");
                ProcessoOrganizacao.Controls.Add(new Literal { Text = table.ToString() });

            }
        }
    }
