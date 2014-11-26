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
    public partial class CadastroFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ProfissionalBeleza pbeleza = new ProfissionalBeleza();
            Telefone telefone = new Telefone();
            Email email = new Email();
            Cidade cidade = new Cidade();
            Cep cep = new Cep();

            pbeleza.Nome= txtnome.Text;
            pbeleza.Cpf = txtcpf.Text;
            pbeleza.Logradouro = txtendereco.Text;
            pbeleza.Idade = Convert.ToInt32(txtidade.Text);
            pbeleza.Nome = txtnome.Text;

            if (RadioButton1.Checked)
            {
                pbeleza.Sexo = 1;
            }
            else
            {
                pbeleza.Sexo = 2;
            }

            cep.Numero = txtcep.Text;
            pbeleza.Salario = Convert.ToDecimal(txtsalario.Text);
            email.Endereco = txtmail.Text;
            email.Endereco = txtmaila.Text; 
            cidade.Nome = txtcidade.Text;
            telefone.Numero = txttelefone.Text;
            telefone.Numero = txttelefonea.Text;


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

        protected void Unnamed15_Click(object sender, EventArgs e)
        {

        }
    }
}