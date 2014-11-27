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
                UFModel ufModel = new UFModel(stringConexao);

                Cliente cliente = cModel.Obtem(id);
                Telefone telefone = tModel.Obtem(id);
                Email email = eModel.Obtem(id);
                Cidade cidade = cdModel.Obtem(cliente.CidadeId);
                UF uf = ufModel.Obtem(cidade.Uf);

                hdCodigo.Value = id.ToString();
                lblnome.Text = cliente.Nome;
                lblcpf.Text = cliente.Cpf;
                lblendereco.Text = cliente.Logradouro;
                lblidade.Text = cliente.DataNascimento.ToString();
                lblcidade.Text = cidade.Nome;
                lblestado.Text = uf.Nome;

                if (cliente.Emails != null || cliente.Emails.Count > 0) 
                {
                    lblmail.Text = cliente.Emails[0].Endereco;
                    if (cliente.Emails[1] != null) 
                    {
                        lblmaila.Text = cliente.Emails[1].Endereco;
                    }
                }

                if (cliente.Telefones != null || cliente.Telefones.Count > 0)
                {
                    lbltelefone.Text = cliente.Telefones[0].Numero;
                    lbltelefonet.Text = cliente.Telefones[0].Tipo;
                    if (cliente.Telefones[1] != null)
                    {
                        lbltelefonea.Text = cliente.Telefones[1].Numero;
                        lbltelefoneat.Text = cliente.Telefones[1].Tipo;
                    }
                }


                

                lblcep.Text = cliente.Cep;
                lblstatus.Text = cliente.Status.ToString();

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