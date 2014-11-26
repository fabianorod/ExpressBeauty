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
    public partial class MostrarFuncionario : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
        {
            string stringConexao = ConfigurationManager.
                ConnectionStrings["stringConexao"].ConnectionString;
            if (Request.QueryString["ID"] != null)
            {
                int id = int.Parse(Request.QueryString["ID"].ToString());

                ProfissionalBelezaModel pModel = new ProfissionalBelezaModel(stringConexao);
                EmailModel eModel = new EmailModel(stringConexao);
                TelefoneModel tModel = new TelefoneModel(stringConexao);
                CidadeModel cdModel = new CidadeModel(stringConexao);

                ProfissionalBeleza pbeleza = pModel.Obtem(id);
                Telefone telefone = tModel.Obtem(id);
                Email email = new Email();
                Cidade cidade = new Cidade();

                hdCodigo.Value = id.ToString();
                lblnome.Text = pbeleza.Nome;
                lblcpf.Text = pbeleza.Cpf;
                lblendereco.Text = pbeleza.Logradouro;
                lblidade.Text = pbeleza.DataNascimento.ToString();
                lblcidade.Text = cidade.Nome;
                lblmail.Text = email.Endereco;
                lblmaila.Text = email.Endereco;
                lbltelefone.Text = telefone.Numero;
                lbltelefonea.Text = telefone.Numero;
                lblsalario.Text = pbeleza.Salario.ToString();


                if (pbeleza.Sexo == 1) 
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
            Response.Redirect("CadastroProfissional.aspx?ID=" + hdCodigo.Value);
        }
    }
        }