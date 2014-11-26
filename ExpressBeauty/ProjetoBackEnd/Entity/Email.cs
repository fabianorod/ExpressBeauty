using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Email
    {
        public string Endereco { get; set; }
        public Pessoa Pessoa { get; set; }

        public Email() { }

        public Email(string endereco, Pessoa pessoa) 
        {
            Endereco = endereco;
            Pessoa = pessoa;
        }
    }
}
