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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            Telefone telefone = new Telefone();
            Email email = new Email();
            Cidade cidade = new Cidade();
            Cep cep = new Cep();

            cliente.Nome = txtnome.Text;
            cliente.Cpf = txtcpf.Text;
            cliente.Logradouro = txtendereco.Text;
            cliente.Idade = Convert.ToInt32(txtidade.Text);
            cliente.Nome = txtnome.Text;

            if (RadioButton1.Checked)
            {
                cliente.Sexo = 1;
            }
            else
            {
                cliente.Sexo = 2;
            }

            cep.Numero = txtcep.Text;
            email.Endereco = txtmail.Text;
            email.Endereco = txtmaila.Text;
            cidade.Nome = txtcidade.Text;

            telefone.Numero = txttelefone.Text;
            telefone.Numero = txttelefonea.Text;


            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            ClienteModel model = new ClienteModel(strCnn);

            if (Request.QueryString["id"] != null)
            {
                cliente.Id = Convert.ToInt32(Request.QueryString["id"]);
                model.Editar(cliente);
            }
            else
            {
                model.Inserir(cliente);
            }
            Response.Redirect("MostrarCliente");
        }
    }
}