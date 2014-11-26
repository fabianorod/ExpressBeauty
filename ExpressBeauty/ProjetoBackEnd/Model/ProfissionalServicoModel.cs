using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class ProfissionalServicoModel
    {
        private string stringConexao;

        public ProfissionalServicoModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(ProfissionalServico profissionalservico)
        {
            using (ProfissionalServicoData data = new ProfissionalServicoData(stringConexao))
            {
                return data.Inserir(profissionalservico);
            }
        }

        public bool Editar(ProfissionalServico profissionalservico)
        {
            using (ProfissionalServicoData data = new ProfissionalServicoData(stringConexao))
            {
                return data.Editar(profissionalservico);
            }
        }

        public bool Excluir(ProfissionalServico profissionalservico)
        {
            using (ProfissionalServicoData data = new ProfissionalServicoData(stringConexao))
            {
                return data.Excluir(profissionalservico);
            }
        }

        public ProfissionalServico Obtem(int pid, int sid)
        {
            using (ProfissionalServicoData data = new ProfissionalServicoData(stringConexao))
            {
                return data.Obtem(pid, sid);
            }
        }

        public List<ProfissionalServico> Listar()
        {
            using (ProfissionalServicoData data = new ProfissionalServicoData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
