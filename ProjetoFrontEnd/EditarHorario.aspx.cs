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
    public partial class EditarHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ProfissionalBeleza pbeleza = new ProfissionalBeleza();
            Servicos servico = new Servicos();

            pbeleza.Nome = txtnome.Text;
            servico.Descricao = txtdescricao.Text;


            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            ProfissionalBelezaModel model = new ProfissionalBelezaModel(strCnn);

            if (Request.QueryString["id"] != null)
            {
                pbeleza.Id = Convert.ToInt32(Request.QueryString["id"]);
                model.Editar(pbeleza);
            }
            else
            {
                model.Inserir(pbeleza);
            }
        }
    }
}