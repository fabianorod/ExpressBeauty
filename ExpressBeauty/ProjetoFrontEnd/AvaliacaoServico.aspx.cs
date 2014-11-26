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
    public partial class AvaliacaoServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Servicos servico = new Servicos();
            Cliente cliente = new Cliente();

            //cliente.Nome = txtNome.Text;
            //servico.Descricao = txtdescricao.Text;

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
        }
    }
}