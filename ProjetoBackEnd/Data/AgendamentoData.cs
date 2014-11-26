using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;

namespace ProjetoBackEnd.Data
{
    class AgendamentoData : Conexao
    {

        private string strCnn;

        public AgendamentoData(string stringConexao)
            : base(stringConexao)
        {
            strCnn = stringConexao;
        }

        public bool Inserir(Agendamento agendamento)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText =
                    @"insert into agendamentos values (@data_agendamento, @data_realizacao, @horario, @status, @cliente_id)";

                Cmd.Parameters.AddWithValue("@data_agendamento", agendamento.DataAgendamento);
                Cmd.Parameters.AddWithValue("@data_realizacao", agendamento.DataRealizacao);
                Cmd.Parameters.AddWithValue("@horario", agendamento.Horario);
                Cmd.Parameters.AddWithValue("@status", agendamento.Status);
                Cmd.Parameters.AddWithValue("@cliente_id", agendamento.Cliente);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Editar(Agendamento agendamento)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"update agendamentos set data_agendamento = @data_agendamento, data_realizacao = @data_realizacao, horario = @horario, status = @status, 
                       cliente = @cliente_id where id = @id";

                Cmd.Parameters.AddWithValue("@data_agendamento", agendamento.DataAgendamento);
                Cmd.Parameters.AddWithValue("@data_final", agendamento.DataRealizacao);
                Cmd.Parameters.AddWithValue("@horario", agendamento.Horario);
                Cmd.Parameters.AddWithValue("@status", agendamento.Status);
                Cmd.Parameters.AddWithValue("@cliente_id", agendamento.Cliente);
                Cmd.Parameters.AddWithValue("@id", agendamento.Id);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Excluir(Agendamento agendamento)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"delete from agendamentos where id = @id";

                Cmd.Parameters.AddWithValue("@id", agendamento.Id);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public Agendamento Obtem(int id)
        {
            Agendamento agendamento = null;
            ClienteData clienteData = new ClienteData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from agendamentos where id = @id";

                Cmd.Parameters.AddWithValue("@id", id);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    agendamento = new Agendamento();

                    agendamento.Id = Dr.GetInt32(0);
                    agendamento.DataAgendamento = Dr.GetDateTime(1);
                    agendamento.DataRealizacao = Dr.GetDateTime(2);
                    agendamento.Horario = Dr.GetDateTime(3);
                    agendamento.Status = Dr.GetInt32(4);
                    agendamento.Cliente = clienteData.Obtem(Dr.GetInt32(6));
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return agendamento;
        }

        public List<Agendamento> Listar()
        {
            List<Agendamento> lista = null;
            ClienteData clienteData = new ClienteData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from agendamentos";

                Dr = Cmd.ExecuteReader();

                lista = new List<Agendamento>();

                while (Dr.Read())
                {
                    Agendamento agendamento = new Agendamento();


                    agendamento.Id = Dr.GetInt32(0);
                    agendamento.DataAgendamento = Dr.GetDateTime(1);
                    agendamento.DataRealizacao = Dr.GetDateTime(2);
                    agendamento.Horario = Dr.GetDateTime(3);
                    agendamento.Status = Dr.GetInt32(4);
                    agendamento.Cliente = clienteData.Obtem(Dr.GetInt32(6));

                    lista.Add(agendamento);
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


