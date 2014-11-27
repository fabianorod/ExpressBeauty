using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class Cidade 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string   Uf { get; set; }

        public List<Pessoa> Pessoa { get; set; }

        

        public Cidade() { }
 
        public Cidade(int id, string nome, string uf)
        {
            Id = id;
            Nome = nome;
            Uf = uf;
        }
           
    }
}
