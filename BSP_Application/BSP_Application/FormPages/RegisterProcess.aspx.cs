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

namespace BSP_Application.FormPages
{
    public partial class RegisterProcess : System.Web.UI.Page
    {
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



                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    EditProcess(Convert.ToInt32(Request.QueryString["id"]));
                }

            }
        }

        private void EditProcess(int id)
        {
            Processo p = AdicionarRegistos.GetProcessById(id);
            inputNome.Value = p.Nome;
            comment.Value = p.Descricao;
            ListaProjetos.SelectedIndex = 1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                AdicionarRegistos.EditProcess(Convert.ToInt32(Request.QueryString["id"]), inputNome.Value, comment.Value, Int32.Parse(ListaProjetos.SelectedValue), camadasDrop.Text);
            }
            else
            {
                AdicionarRegistos.InsertProcess(inputNome.Value, comment.Value, Int32.Parse(ListaProjetos.SelectedValue), camadasDrop.Text);
            }
            Response.Redirect("/Conteudos/ConsultarProcesso.aspx");

        }


        [WebMethod]
        public static Processo getProcessById(int idProcess)
        {
            return null;
        }
    }
}
