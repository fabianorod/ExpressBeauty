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
    public partial class MostrarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string stringConexao = ConfigurationManager.
                ConnectionStrings["stringConexao"].ConnectionString;
            if (Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());

                ClienteModel cModel = new ClienteModel(stringConexao);
                EmailModel eModel = new EmailModel(stringConexao);
                TelefoneModel tModel = new TelefoneModel(stringConexao);
                CidadeModel cdModel = new CidadeModel(stringConexao);
                CepModel cepModel = new CepModel(stringConexao);

                Cliente cliente = cModel.Obtem(id);
                Telefone telefone = tModel.Obtem(id);
                Email email = new Email();
                Cidade cidade = new Cidade();
                Cep cep = new Cep();

                hdCodigo.Value = id.ToString();
                lblnome.Text = cliente.Nome;
                lblcpf.Text = cliente.Cpf;
                lblendereco.Text = cliente.Logradouro;
                lblidade.Text = cliente.Idade.ToString();
                lblcidade.Text = cidade.Nome;
                lblmail.Text = email.Endereco;
                lblmaila.Text = email.Endereco;
                lbltelefone.Text = telefone.Numero;
                lbltelefonea.Text = telefone.Numero;


                if (cliente.Sexo == 1) 
                {
                    lblsexo.Text = "Masculino";
                } 
                else
                {
                    lblsexo.Text = "Feminino";
                }

                
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaInicial.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroCliente.aspx?ID=" + hdCodigo.Value);
        }
    }
}