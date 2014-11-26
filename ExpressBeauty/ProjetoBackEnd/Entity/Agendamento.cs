using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Agendamento
    {
        public int Numero { get; set; }
        public int Status { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime Horario { get; set; }
        public Cliente Cliente { get; set; }
        public ProfissionalBeleza Profissional { get; set; }

        public List<AgendamentoServico> agendamento { get; set; }
        public List<ProfissionalServico> profissionals { get; set; }

        public Agendamento() { }

        public Agendamento(int numero, int status, DateTime datainicial, DateTime datafinal, DateTime horario, Cliente cliente, 
            ProfissionalBeleza profissional) 
        {
            Numero = numero;
            Status = status;
            DataInicial = datainicial;
            DataFinal = datafinal;
            Horario = horario;
            Cliente = cliente;
            Profissional = profissional;
        } 
    }
}
