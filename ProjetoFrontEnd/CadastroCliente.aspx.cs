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
            if (!IsPostBack)
            {
                CarregarEstados();
            }

            if (Request.QueryString["ID"] != null && !IsPostBack)
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;
                int id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                ClienteModel model = new ClienteModel(stringConexao);
                Cliente cliente = model.Obtem(id);

                txtnome.Text = cliente.Nome;
                txtendereco.Text = cliente.Logradouro;
                txtcpf.Text = cliente.Cpf;
                txtidade.Text = cliente.DataNascimento.ToString();
                txtendereco.Text = cliente.Logradouro;
                txtcep.Text = cliente.Cep;
                txtmail.Text = cliente.Emails.ToString();
                txtmaila.Text = cliente.Emails.ToString();
                txttelefone.Text = cliente.Telefones.ToString();
                txttelefonea.Text = cliente.Telefones.ToString();
                txtnomeu.Text = cliente.NomeUsuario;


                lblsenha.Visible = false;
                lblsenhac.Visible = false;
                txtsenha.Visible = false;
                txtsenhac.Visible = false;
            }
        }

        protected void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            Telefone telefone = new Telefone();
            Email email = new Email();
            List<Telefone> lt = new List<Telefone>();
            List<Email> le = new List<Email>();

            //DateTime thisDate = new DateTime(2008, 3, 15);
            //CultureInfo culture = new CultureInfo("pt-BR");  

            cliente.Nome = txtnome.Text;
            cliente.Cpf = txtcpf.Text;
            cliente.Logradouro = txtendereco.Text;
            cliente.DataNascimento = Convert.ToDateTime(txtidade.Text);
            cliente.Nome = txtnome.Text;

            if (RadioButton1.Checked)
            {
                cliente.Sexo = 1;
            }
            else
            {
                cliente.Sexo = 2;
            }

            cliente.CidadeId = Convert.ToInt32(cbxCidades.SelectedValue);

            cliente.Cep = txtcep.Text;
            cliente.NomeUsuario = txtnomeu.Text;
            cliente.Senha = txtsenha.Text;
            cliente.Status = 1;


            Telefone tel1 = new Telefone();
            tel1.Numero = txttelefone.Text;
            tel1.Tipo = txttelefonet.Text;
            tel1.Pessoa = cliente;

            lt.Add(tel1);
            if (txttelefonea.Text.Count() > 0)
            {
                lt.Add(new Telefone(txttelefonea.Text, txttelefoneat.Text, cliente));
            }
            cliente.Telefones = lt;

            le.Add(new Email(txtmail.Text, cliente));

            if (txtmaila.Text.Count() > 0)
            {
                le.Add(new Email(txtmaila.Text, cliente));
            }

            cliente.Emails = le;
            


            string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            ClienteModel model = new ClienteModel(strCnn);

            if (Request.QueryString["id"] != null)
            {
                cliente.Id = Convert.ToInt32(Request.QueryString["id"]);
                model.Editar(cliente);
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
                model.Inserir(cliente);
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