using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class AgendamentoModel
    {
        private string stringConexao;

        public AgendamentoModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(Agendamento agendamento)
        {
            using (AgendamentoData data = new AgendamentoData(stringConexao))
            {
                return data.Inserir(agendamento);
            }
        }

        public bool Editar(Agendamento agendamento)
        {
            using (AgendamentoData data = new AgendamentoData(stringConexao))
            {
                return data.Editar(agendamento);
            }
        }

        public bool Excluir(Agendamento agendamento)
        {
            using (AgendamentoData data = new AgendamentoData(stringConexao))
            {
                return data.Excluir(agendamento);
            }
        }

        public Agendamento Obtem(int numero)
        {
            using (AgendamentoData data = new AgendamentoData(stringConexao))
            {
                return data.Obtem(numero);
            }
        }

        public List<Agendamento> Listar()
        {
            using (AgendamentoData data = new AgendamentoData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
