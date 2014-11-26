using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBackEnd.Entity
{
    public class ProfissionalServico
    {
        public ProfissionalBeleza Profissional { get; set; }
        public Servicos Servicos { get; set; }

        public ProfissionalServico() { }

        public ProfissionalServico(ProfissionalBeleza profissional, Servicos servicos)
        {
            Profissional = profissional;
            Servicos = servicos;
        }
    }
}
