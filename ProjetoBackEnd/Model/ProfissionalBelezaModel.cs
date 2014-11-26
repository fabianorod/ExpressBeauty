using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class ProfissionalBelezaModel
    {
        private string stringConexao;

        public ProfissionalBelezaModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(ProfissionalBeleza pbeleza)
        {
            using (ProfissionalBelezaData data = new ProfissionalBelezaData(stringConexao))
            {
                return data.Inserir(pbeleza);
            }
        }

        public bool Editar(ProfissionalBeleza pbeleza)
        {
            using (ProfissionalBelezaData data = new ProfissionalBelezaData(stringConexao))
            {
                return data.Editar(pbeleza);
            }
        }

        public bool Excluir(ProfissionalBeleza pbeleza)
        {
            using (ProfissionalBelezaData data = new ProfissionalBelezaData(stringConexao))
            {
                return data.Excluir(pbeleza);
            }
        }

        public ProfissionalBeleza Obtem(int id)
        {
            using (ProfissionalBelezaData data = new ProfissionalBelezaData(stringConexao))
            {
                return data.Obtem(id);
            }
        }

        public ProfissionalBeleza Obtem(string nome, string senha)
        {
            using (ProfissionalBelezaData data = new ProfissionalBelezaData(stringConexao))
            {
                return data.Obtem(nome, senha);
            }
        }

        public List<ProfissionalBeleza> Listar()
        {
            using (ProfissionalBelezaData data = new ProfissionalBelezaData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
