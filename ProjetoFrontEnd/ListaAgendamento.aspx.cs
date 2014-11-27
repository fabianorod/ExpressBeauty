using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Model;
using ProjetoBackEnd.Entity;

namespace ProjetoFrontEnd
{
    public partial class ListaAgendamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;

            AgendamentoServicoModel model = new AgendamentoServicoModel(stringConexao);

            listaAgenda.DataSource = model.Listar();
            listaAgenda.DataBind();
        }

        protected void Unnamed_Command(object sender, CommandEventArgs e)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;

            AgendamentoServicoModel model = new AgendamentoServicoModel(stringConexao);
            Agendamento agendamento = new Agendamento();

            agendamento.Id = Convert.ToInt32(e.CommandArgument);

            model.Excluir(agendamento);
            Response.Redirect("ListaAgendamento.aspx");
        }
    }
}