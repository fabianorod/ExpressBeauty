using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;

namespace ProjetoBackEnd.Data
{
    class ProfissionalServicoData : Conexao
    {

        private string strCnn;

        public ProfissionalServicoData(string stringConexao)
            : base(stringConexao)
        {
            strCnn = stringConexao;
        }

        public bool Inserir(ProfissionalServico profissionalservico)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText =
                    @"insert into profissionais_servicos values (@profissional_id, @servico_id);";

                Cmd.Parameters.AddWithValue("@profissional_id", profissionalservico.Profissional);
                Cmd.Parameters.AddWithValue("@servico_id", profissionalservico.Servicos);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Editar(ProfissionalServico profissionalservico)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"update profissionais_servicos set profissional_id = @profissional_id, servico_id where profissional_id = @profissional_id, servico_id";

                Cmd.Parameters.AddWithValue("@profissional_id", profissionalservico.Profissional);
                Cmd.Parameters.AddWithValue("@servico_id", profissionalservico.Servicos);
                Cmd.Parameters.AddWithValue("@profissional_id", profissionalservico.Profissional);
                Cmd.Parameters.AddWithValue("@servico_id", profissionalservico.Servicos);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Excluir(ProfissionalServico profissionalservico)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"delete from profissionais_servicos where profissional_id = @profissional_id, servico_id;";

                Cmd.Parameters.AddWithValue("@profissional_id", profissionalservico.Profissional);
                Cmd.Parameters.AddWithValue("@servico_id", profissionalservico.Servicos);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public ProfissionalServico Obtem(int pid, int sid)
        {
            ProfissionalServico profissionalservico = null;
            ProfissionalBelezaData profissionalData = new ProfissionalBelezaData(strCnn);
            ServicosData servicoData = new ServicosData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from profissionais_servicos where profissional_id = @profissional_id;";

                Cmd.Parameters.AddWithValue("@profissional_id", pid);
                Cmd.Parameters.AddWithValue("@servico_id", sid);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    profissionalservico = new ProfissionalServico();

                    profissionalservico.Profissional = profissionalData.Obtem(Dr.GetInt32(0));
                    profissionalservico.Servicos = servicoData.Obtem(Dr.GetInt32(1));
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return profissionalservico;
        }

        public List<ProfissionalServico> Listar()
        {
            List<ProfissionalServico> lista = null;
            ProfissionalBelezaData profissionalData = new ProfissionalBelezaData(strCnn);
            ServicosData servicoData = new ServicosData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from profissionais_servicos;";

                Dr = Cmd.ExecuteReader();

                lista = new List<ProfissionalServico>();

                while (Dr.Read())
                {
                    ProfissionalServico profissionalservico = new ProfissionalServico();


                    profissionalservico.Profissional = profissionalData.Obtem(Dr.GetInt32(0));
                    profissionalservico.Servicos = servicoData.Obtem(Dr.GetInt32(1));

                    lista.Add(profissionalservico);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return lista;
        }
    }

}