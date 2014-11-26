using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Logradouro { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }
        public Cep Cep { get; set; }


        public List<Telefone> Telefones { get; set; }
        public List<Email> Emails { get; set; }

        public Pessoa() { }

        public Pessoa(int id, string cpf, string logradouro, int idade, string nome, int sexo, Cep cep)
        {
            Id = id;
            Cpf = cpf;
            Logradouro = logradouro;
            Idade = idade;
            Nome = nome;
            Sexo = sexo;
            Cep = cep;
        }

    }
}
