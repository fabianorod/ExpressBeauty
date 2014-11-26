using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Cep
    {
        public string Numero { get; set; }
        public Cidade Cidade { get; set; }
       

        List<Pessoa> Pessoas { get; set; }

        public Cep() { }

        public Cep(string numero, Cidade cidade)
        {
            Numero = numero;
            Cidade = cidade;
        }
    }
}
