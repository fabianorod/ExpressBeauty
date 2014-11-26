using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class AgendamentoServico
    {
        public Agendamento Agendamento { get; set; }
        public Servicos Servicos { get; set; }

        public AgendamentoServico() { }

        public AgendamentoServico(Agendamento agendamento, Servicos servicos)
        {
            Agendamento = Agendamento;
            Servicos = servicos;
        }
    }
}
