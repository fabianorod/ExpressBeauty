using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class UF
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public List<Cidade> Cidades { get; set; }

        public UF() { }

        public UF(string sigla, string nome) 
        {
            Sigla = sigla;
            Nome = nome;
        }
    }
}
