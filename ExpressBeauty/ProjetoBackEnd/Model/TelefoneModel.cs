using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class TelefoneModel
    {
        private string stringConexao;

        public TelefoneModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(Telefone telefone)
        {
            using (TelefoneData data = new TelefoneData(stringConexao))
            {
                return data.Inserir(telefone);
            }
        }

        public bool Editar(Telefone telefone)
        {
            using (TelefoneData data = new TelefoneData(stringConexao))
            {
                return data.Editar(telefone);
            }
        }

        public bool Excluir(Telefone telefone)
        {
            using (TelefoneData data = new TelefoneData(stringConexao))
            {
                return data.Excluir(telefone);
            }
        }

        public Telefone Obtem(int id)
        {
            using (TelefoneData data = new TelefoneData(stringConexao))
            {
                return data.Obtem(id);
            }
        }

        public List<Telefone> Listar()
        {
            using (TelefoneData data = new TelefoneData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
