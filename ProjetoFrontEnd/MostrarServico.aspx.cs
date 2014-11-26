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
    public partial class MostrarServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string stringConexao = ConfigurationManager.
                ConnectionStrings["stringConexao"].ConnectionString;
            if (Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());

                ServicosModel sModel = new ServicosModel(stringConexao);

                Servicos servico = sModel.Obtem(id);

                hdCodigo.Value = id.ToString();
                lblservico.Text = servico.Nome;
                lblvalor.Text = servico.Valor.ToString();
                lbldescricao.Text = servico.Descricao;
                
                
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaInicial.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroServico.aspx?ID=" + hdCodigo.Value);
        }
      }
   }
