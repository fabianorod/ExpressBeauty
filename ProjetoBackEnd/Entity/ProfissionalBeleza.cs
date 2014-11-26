using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class ProfissionalBeleza : Pessoa
    {
        public int TipoPermicao { get; set; }
        public decimal Salario { get; set; }

        public ProfissionalBeleza() { }

        public ProfissionalBeleza(int tipopermicao, decimal salario, int id, string cpf, string cep, string logradouro, 
            DateTime datan, string nome, string nomeu, string senha, int sexo, int cidade)
            : base(id, cpf, cep, logradouro, datan, nomeu, nome, senha, sexo, cidade)
        {
            TipoPermicao = tipopermicao;
            Salario = salario;
        }
    }
}
