using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class ClienteModel
    {
        private string stringConexao;

        public ClienteModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(Cliente cliente)
        {
            using (ClienteData data = new ClienteData(stringConexao))
            {
                return data.Inserir(cliente);
            }
        }

        public bool Editar(Cliente cliente)
        {
            using (ClienteData data = new ClienteData(stringConexao))
            {
                return data.Editar(cliente);
            }
        }

        public bool Excluir(Cliente cliente)
        {
            using (ClienteData data = new ClienteData(stringConexao))
            {
                return data.Excluir(cliente);
            }
        }

        public Cliente Obtem(int id)
        {
            using (ClienteData data = new ClienteData(stringConexao))
            {
                return data.Obtem(id);
            }
        }

        public List<Cliente> Listar()
        {
            using (ClienteData data = new ClienteData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
