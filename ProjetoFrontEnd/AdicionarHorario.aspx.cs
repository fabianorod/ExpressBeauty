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
    public partial class AdicionarHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarServicos();
                cbxHoras.Enabled = false;
                btnAdicionarServico.Enabled = false;
                tbDataHora.Enabled = false;
            }
            
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
           
            DateTime hoje = DateTime.Now.Date;
            
            DateTime DataSelecionada = Calendar2.SelectedDate;
            if (DataSelecionada < hoje)
            {
                lblfuncionario.Text = "Please, inform a valid date.";
            }
            else
            {
                string Caracter = "<span class='glyphicon glyphicon-chevron-down' aria-hidden='true'></span>";
                lblCaracter.Text = Caracter;
                cbxHoras.Enabled = true;
                btnAdicionarServico.Enabled = true;
            }
            
            string teste = DataSelecionada.ToString();
        }

        private void CarregarServicos()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;

            ServicosModel servicosModel = new ServicosModel(stringConexao);

            cbxNovoServicos.DataSource = servicosModel.Listar();

            cbxNovoServicos.DataValueField = "ID";
            cbxNovoServicos.DataTextField = "Nome";
            cbxNovoServicos.DataBind();
        }

        private void CarregarPbeleza()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;

            ProfissionalBelezaModel pbModel = new ProfissionalBelezaModel(stringConexao);

            cbxPbeleza.DataSource = pbModel.Listar();

            cbxPbeleza.DataValueField = "ID";
            cbxPbeleza.DataTextField = "Nome";
            cbxPbeleza.DataBind();
        }

        protected void cbxNovoServicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (IsPostBack)
            {
                //cbxPbeleza.Items.Clear();
                CarregarPbeleza();
            }
        }

        protected void btnAdicionarServico_Click(object sender, EventArgs e)
        {
            Agendamento agendamento = new Agendamento();
            ProfissionalBeleza pbeleza = new ProfissionalBeleza();
            Servicos servicos = new Servicos();
            Cliente cliente =  Session["cliente"] as Cliente;

            

            pbeleza.Id = Convert.ToInt32(cbxPbeleza.SelectedIndex);
            
            servicos.Id = Convert.ToInt32(cbxNovoServicos.SelectedIndex);
            agendamento.DataRealizacao = Convert.ToDateTime(Calendar2.SelectedDate);
            agendamento.DataAgendamento = DateTime.Now.Date;
            agendamento.Horario = Convert.ToDateTime(cbxHoras.SelectedValue);
            agendamento.Status = 1;
            agendamento.Cliente = cliente.Id;

            //string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

            //AgendamentoModel aModel = new AgendamentoModel(strCnn);

            //aModel.Inserir(agendamento, pbeleza, servicos);

            tbDataHora.Text = Calendar2.SelectedDate.Date.ToString("dd/MM/yyyy") + " - " + cbxHoras.SelectedValue;
            lsbServicos.Items.Add(cbxNovoServicos.SelectedItem.ToString());
           


        }

    }
}