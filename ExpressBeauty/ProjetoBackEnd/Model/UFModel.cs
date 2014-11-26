using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class UFModel
    {
        private string stringConexao;

        public UFModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(UF uf)
        {
            using (UFData data = new UFData(stringConexao))
            {
                return data.Inserir(uf);
            }
        }

        public bool Editar(UF uf)
        {
            using (UFData data = new UFData(stringConexao))
            {
                return data.Editar(uf);
            }
        }

        public bool Excluir(UF uf)
        {
            using (UFData data = new UFData(stringConexao))
            {
                return data.Excluir(uf);
            }
        }

        public UF Obtem(string sigla)
        {
            using (UFData data = new UFData(stringConexao))
            {
                return data.Obtem(sigla);
            }
        }

        public List<UF> Listar()
        {
            using (UFData data = new UFData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
