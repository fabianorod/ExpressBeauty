using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Servicos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }

        public List<AgendamentoServico> servicos { get; set;  }

        public Servicos() { }

        public Servicos(int id, string nome, decimal valor, string descricao) 
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Descricao = descricao;
        }
    }
}
