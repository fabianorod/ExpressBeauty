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

        public Cliente(int status, int id, string cpf, string cep, string logradouro, DateTime datan,
            string nome, string nomeu, string senha, int sexo, int cidade)
            : base(id, cpf, cep, logradouro, datan, nome, nomeu, senha, sexo, cidade)
        {
            Status = status;
        }
   }
}
