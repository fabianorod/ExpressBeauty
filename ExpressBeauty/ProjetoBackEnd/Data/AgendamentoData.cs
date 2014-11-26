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
                    @"insert into agendamentos values (@data_inicial, @data_final, @horario, @status, @cliente_id, @profissional_id);";

                Cmd.Parameters.AddWithValue("@data_inicial", agendamento.DataInicial);
                Cmd.Parameters.AddWithValue("@data_final", agendamento.DataFinal);
                Cmd.Parameters.AddWithValue("@horario", agendamento.Horario);
                Cmd.Parameters.AddWithValue("@status", agendamento.Status);
                Cmd.Parameters.AddWithValue("@cliente_id", agendamento.Cliente);
                Cmd.Parameters.AddWithValue("@profissional_id", agendamento.Profissional);

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
                    @"update agendamentos set data_inicial = @data_inicial, data_final = @data_final, horario = @horario, status = @status, 
                       cliente = @cliente_id, profissional_id = @profissional_id where numero = @numero";

                Cmd.Parameters.AddWithValue("@data_inicial", agendamento.DataInicial);
                Cmd.Parameters.AddWithValue("@data_final", agendamento.DataFinal);
                Cmd.Parameters.AddWithValue("@horario", agendamento.Horario);
                Cmd.Parameters.AddWithValue("@status", agendamento.Status);
                Cmd.Parameters.AddWithValue("@cliente_id", agendamento.Cliente);
                Cmd.Parameters.AddWithValue("@profissional_id", agendamento.Profissional);
                Cmd.Parameters.AddWithValue("@numero", agendamento.Numero);

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
                    @"delete from agendamentos where pessoa_id = @pessoa_id;";

               // Cmd.Parameters.AddWithValue("@pessoa_id", agendamento.Pessoa);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public Agendamento Obtem(int numero)
        {
            Agendamento agendamento = null;
            ClienteData clienteData = new ClienteData(strCnn);
            ProfissionalBelezaData pbelezaData = new ProfissionalBelezaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from agendamentos where numero = @numero;";

                Cmd.Parameters.AddWithValue("@numero", numero);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    agendamento = new Agendamento();

                    agendamento.Numero = Dr.GetInt32(0);
                    agendamento.DataInicial = Dr.GetDateTime(1);
                    agendamento.DataFinal = Dr.GetDateTime(2);
                    agendamento.Horario = Dr.GetDateTime(3);
                    agendamento.Status = Dr.GetInt32(4);
                    agendamento.Cliente = clienteData.Obtem(Dr.GetInt32(6));
                    agendamento.Profissional = pbelezaData.Obtem(Dr.GetInt32(7));
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
            ProfissionalBelezaData pbelezaData = new ProfissionalBelezaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from agendamentos;";

                Dr = Cmd.ExecuteReader();

                lista = new List<Agendamento>();

                while (Dr.Read())
                {
                    Agendamento agendamento = new Agendamento();


                    agendamento.Numero = Dr.GetInt32(0);
                    agendamento.DataInicial = Dr.GetDateTime(1);
                    agendamento.DataFinal = Dr.GetDateTime(2);
                    agendamento.Horario = Dr.GetDateTime(3);
                    agendamento.Status = Dr.GetInt32(4);
                    agendamento.Cliente = clienteData.Obtem(Dr.GetInt32(6));
                    agendamento.Profissional = pbelezaData.Obtem(Dr.GetInt32(7));

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


