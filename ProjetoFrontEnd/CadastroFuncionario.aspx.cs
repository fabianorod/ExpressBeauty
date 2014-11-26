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
            if (!IsPostBack)
            {
                CarregarEstados();
            }

            if (Request.QueryString["ID"] != null && !IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;
                int id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                ProfissionalBelezaModel model = new ProfissionalBelezaModel(stringConexao);
                ProfissionalBeleza pbeleza = model.Obtem(id);

                txtnome.Text = pbeleza.Nome;
                txtendereco.Text = pbeleza.Logradouro;
                txtcpf.Text = pbeleza.Cpf;
                txtidade.Text = pbeleza.DataNascimento.ToString();
                txtendereco.Text = pbeleza.Logradouro;
                txtcep.Text = pbeleza.Cep;
                txtmail.Text = pbeleza.Emails.ToString();
                txtmaila.Text = pbeleza.Emails.ToString();
                txttelefone.Text = pbeleza.Telefones.ToString();
                txttelefonea.Text = pbeleza.Telefones.ToString();
                txtnomeu.Text = pbeleza.NomeUsuario;
                txtsalario.Text = pbeleza.Salario.ToString();

                lblsenha.Visible = false;
                lblsenhac.Visible = false;
                txtsenha.Visible = false;
                txtsenhac.Visible = false;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ProfissionalBeleza pbeleza = new ProfissionalBeleza();
            Telefone telefone = new Telefone();
            Email email = new Email();
            List<Telefone> lt = new List<Telefone>();
            List<Email> le = new List<Email>();

            pbeleza.Nome= txtnome.Text;
            pbeleza.Cpf = txtcpf.Text;
            pbeleza.Logradouro = txtendereco.Text;
            pbeleza.DataNascimento = Convert.ToDateTime(txtidade.Text);
            pbeleza.Nome = txtnome.Text;

            if (RadioButton1.Checked)
            {
                pbeleza.Sexo = 1;
            }
            else
            {
                pbeleza.Sexo = 2;
            }

            pbeleza.Cep = txtcep.Text;
            pbeleza.Salario = Convert.ToDecimal(txtsalario.Text);

            Telefone tel1 = new Telefone();
            tel1.Numero = txttelefone.Text;
            tel1.Tipo = txttelefonet.Text;
            tel1.Pessoa = pbeleza;

            lt.Add(tel1);
            if (txttelefonea.Text.Count() > 0)
            {
                lt.Add(new Telefone(txttelefonea.Text, txttelefoneat.Text, pbeleza));
            }
            pbeleza.Telefones = lt;

            le.Add(new Email(txtmail.Text, pbeleza));

            if (txtmaila.Text.Count() > 0)
            {
                le.Add(new Email(txtmaila.Text, pbeleza));
            }


            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            ProfissionalBelezaModel model = new ProfissionalBelezaModel(strCnn);

            if (Request.QueryString["id"] != null)
            {
                pbeleza.Id = Convert.ToInt32(Request.QueryString["id"]);
                model.Editar(pbeleza);
            }
            if (!txtsenha.Text.Equals(txtsenhac.Text))
            {
                string js = "<script>alert('Senhas diferentes verifique!');</script>";
                Type cstype = this.GetType();
                if (!ClientScript.IsStartupScriptRegistered("script"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(cstype, "script", js);
                    return;
                }
            }
            else
            {
                model.Inserir(pbeleza);
            }
            Response.Redirect("PaginaInicial.aspx");
        }

        private void CarregarEstados()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;

            UFModel estadoModel = new UFModel(stringConexao);

            cbxEstados.DataSource = estadoModel.Listar();

            cbxEstados.DataValueField = "Sigla";
            cbxEstados.DataTextField = "Nome";
            cbxEstados.DataBind();
        }

        private void CarregarCidades(string estadoSigla)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;

            CidadeModel cidadeModel = new CidadeModel(stringConexao);

            cbxCidades.DataSource = cidadeModel.Listar(estadoSigla);

            cbxCidades.DataValueField = "Id";
            cbxCidades.DataTextField = "Nome";
            cbxCidades.Items.Clear();
            cbxCidades.Items.Add("Não Selecionado");
            cbxCidades.DataBind();
        }

        protected void cbxEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string estadoSigla = cbxEstados.SelectedValue;
            CarregarCidades(estadoSigla);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaInicial.aspx");
        }

    }
}