using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime DataRealizacao { get; set; }
        public DateTime Horario { get; set; }
        public Cliente Cliente { get; set; }

        public List<AgendamentoServico> agendamento { get; set; }


        public Agendamento() { }

        public Agendamento(int id, int status, DateTime datainicial, DateTime datafinal, DateTime horario, Cliente cliente) 
        {
            Id = id;
            Status = status;
            DataAgendamento = datainicial;
            DataRealizacao = datafinal;
            Horario = horario;
            Cliente = cliente;
        } 
    }
}
