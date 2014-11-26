using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Cliente : Pessoa
    {
        public int Status { get; set; }

        public Cliente() { }

        public Cliente(int status, int id, string cpf, string logradouro, int idade, string nome, int sexo, Cep cep)
            : base(id, cpf, logradouro, idade, nome, sexo, cep)
        {
            Status = status;
        }
   }
}
