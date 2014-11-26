using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class ServicosModel
    {
        private string stringConexao;

        public ServicosModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(Servicos servico)
        {
            using (ServicosData data = new ServicosData(stringConexao))
            {
                return data.Inserir(servico);
            }
        }

        public bool Editar(Servicos servico)
        {
            using (ServicosData data = new ServicosData(stringConexao))
            {
                return data.Editar(servico);
            }
        }

        public bool Excluir(Servicos servico)
        {
            using (ServicosData data = new ServicosData(stringConexao))
            {
                return data.Excluir(servico);
            }
        }

        public Servicos Obtem(int id)
        {
            using (ServicosData data = new ServicosData(stringConexao))
            {
                return data.Obtem(id);
            }
        }

        public List<Servicos> Listar()
        {
            using (ServicosData data = new ServicosData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
