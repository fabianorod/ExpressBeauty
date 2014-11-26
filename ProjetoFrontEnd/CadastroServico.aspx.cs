using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Model;
using System.Configuration;

namespace ProjetoFrontEnd
{
    public partial class Cadastro_Servico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null && !IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;
                int id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                ServicosModel model = new ServicosModel(stringConexao);
                Servicos servico = model.Obtem(id);

                txtnome.Text = servico.Nome;
                txtdescricao.Text = servico.Descricao;
                txtvalor.Text = servico.Valor.ToString();
                
            }
        }

         protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Servicos servico = new Servicos();

            servico.Nome = txtnome.Text;
            servico.Valor = Convert.ToDecimal(txtvalor.Text);
            servico.Descricao = txtdescricao.Text;

            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            ServicosModel model = new ServicosModel(strCnn);

            if (Request.QueryString["id"] != null)
            {
                servico.Id = Convert.ToInt32(Request.QueryString["id"]);
                model.Editar(servico);
            }
            else
            {
                model.Inserir(servico);
            }
            Response.Redirect("PaginaInicial.aspx");
        }

         protected void Unnamed2_Click(object sender, EventArgs e)
         {
             Response.Redirect("PaginaInicial.aspx");
         }
    }
}