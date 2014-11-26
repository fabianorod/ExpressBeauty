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
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public string NomeUsuario { get; set; }
        public int Sexo { get; set; }
        public string Senha { get; set; }
        public int CidadeId { get;set; }



        public List<Telefone> Telefones { get; set; }
        public List<Email> Emails { get; set; }

        public Pessoa() { }

        public Pessoa(int id, string cpf, string cep, string logradouro, DateTime datan, string nome, string nomeu, string senha, int sexo, int cidade)
        {
            Id = id;
            Cpf = cpf;
            Cep = cep;
            CidadeId = cidade;
            Logradouro = logradouro;
            DataNascimento = datan;
            Nome = nome;
            NomeUsuario = nomeu;
            Senha = senha;
            Sexo = sexo;

        }

    }
}
