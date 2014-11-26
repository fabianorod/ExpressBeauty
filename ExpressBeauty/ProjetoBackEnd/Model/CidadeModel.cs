using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class CidadeModel
    {
        private string stringConexao;

        public CidadeModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(Cidade cidade)
        {
            using (CidadeData data = new CidadeData(stringConexao))
            {
                return data.Inserir(cidade);
            }
        }

        public bool Editar(Cidade cidade)
        {
            using (CidadeData data = new CidadeData(stringConexao))
            {
                return data.Editar(cidade);
            }
        }

        public bool Excluir(Cidade cidade)
        {
            using (CidadeData data = new CidadeData(stringConexao))
            {
                return data.Excluir(cidade);
            }
        }

        public Cidade Obtem(int id)
        {
            using (CidadeData data = new CidadeData(stringConexao))
            {
                return data.Obtem(id);
            }
        }

        public List<Cidade> Listar()
        {
            using (CidadeData data = new CidadeData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
