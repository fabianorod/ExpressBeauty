using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Telefone
    {
        private string p;

        public string Numero { get; set; }
        public string Tipo { get; set; }
        public Pessoa Pessoa { get; set; }

        public Telefone() { }

        public Telefone(string numero, string tipo, Pessoa pessoa) 
        {
            Numero = numero;
            Tipo = tipo;
            Pessoa = pessoa;
        }
    }
}
