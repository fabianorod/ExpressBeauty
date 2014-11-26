using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class ProfissionalBeleza : Pessoa
    {
        public int Status { get; set; }
        public decimal Salario { get; set; }

        public List<ProfissionalServico> agendamento { get; set; }

        public ProfissionalBeleza() { }

        public ProfissionalBeleza(int status, decimal salario, int id, string cpf, string logradouro, 
            int idade, string nome, int sexo, Cep cep)
            : base(id, cpf,  logradouro, idade, nome, sexo, cep)
        {
            Status = status;
            Salario = salario;
        }
    }
}
