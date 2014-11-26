using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class AgendamentoServicoModel
    {
        private string stringConexao;

        public AgendamentoServicoModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(AgendamentoServico agendamentoservico)
        {
            using (AgendamentoServicoData data = new AgendamentoServicoData(stringConexao))
            {
                return data.Inserir(agendamentoservico);
            }
        }

        public bool Editar(AgendamentoServico agendamentoservico)
        {
            using (AgendamentoServicoData data = new AgendamentoServicoData(stringConexao))
            {
                return data.Editar(agendamentoservico);
            }
        }

        public bool Excluir(AgendamentoServico agendamentoservico)
        {
            using (AgendamentoServicoData data = new AgendamentoServicoData(stringConexao))
            {
                return data.Excluir(agendamentoservico);
            }
        }

        public AgendamentoServico Obtem(int numero,int id)
        {
            using (AgendamentoServicoData data = new AgendamentoServicoData(stringConexao))
            {
                return data.Obtem(numero, id);
            }
        }

        public List<AgendamentoServico> Listar()
        {
            using (AgendamentoServicoData data = new AgendamentoServicoData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
