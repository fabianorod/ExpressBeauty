using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Telefone
    {
        public string Numero { get; set; }
        public string Ddd { get; set; }
        public Pessoa Pessoa { get; set; }

        public Telefone() { }

        public Telefone(string numero, string ddd, Pessoa pessoa) 
        {
            Numero = numero;
            Ddd = ddd;
            Pessoa = pessoa;
        }
    }
}
