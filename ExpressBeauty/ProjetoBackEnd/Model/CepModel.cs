using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class CepModel
    {
        private string stringConexao;

        public CepModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(Cep cep)
        {
            using (CepData data = new CepData(stringConexao))
            {
                return data.Inserir(cep);
            }
        }

        public bool Editar(Cep cep)
        {
            using (CepData data = new CepData(stringConexao))
            {
                return data.Editar(cep);
            }
        }

        public bool Excluir(Cep cep)
        {
            using (CepData data = new CepData(stringConexao))
            {
                return data.Excluir(cep);
            }
        }

        public Cep Obtem(string numero)
        {
            using (CepData data = new CepData(stringConexao))
            {
                return data.Obtem(numero);
            }
        }

        public List<Cep> Listar()
        {
            using (CepData data = new CepData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
