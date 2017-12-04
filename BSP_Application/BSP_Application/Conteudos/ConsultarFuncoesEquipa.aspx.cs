using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSP_Application.DataObjects;
using System.Data.SqlClient;
using System.Web.Services;
using System.Data;

namespace BSP_Application.Conteudos
{
    public partial class ConsultarFuncoesEquipa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BSP_DataBase.mdf;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT F.Nome as Funcao, GD.Nome as Grupo FROM Funcao F, GrupoDirecao GD WHERE F.IDGrupoDirecao = GD.Id", con);
                SqlDataReader rd = cmd.ExecuteReader();

                GridView1.DataSource = rd;
                GridView1.DataBind();
                con.Close();

                for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridViewRow row = GridView1.Rows[rowIndex];
                    GridViewRow previousRow = GridView1.Rows[rowIndex + 1];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Text == previousRow.Cells[i].Text)
                        {
                            row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                                   previousRow.Cells[i].RowSpan + 1;
                            previousRow.Cells[i].Visible = false;
                        }
                    }

                    GridView1.Columns[0].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    GridView1.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    

                }
            }
        }


       




        }
    }