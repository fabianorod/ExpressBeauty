﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;

namespace ProjetoBackEnd.Data
{
    class AgendamentoServicoData : Conexao
    {

        private string strCnn;

        public AgendamentoServicoData(string stringConexao)
            : base(stringConexao)
        {
            strCnn = stringConexao;
        }

        public bool Inserir(AgendamentoServico agendamentoservico)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText =
                    @"insert into agendamentos_servicos values (@agendamento_numero, @servico_id);";

                Cmd.Parameters.AddWithValue("@agendamento_numero", agendamentoservico.Agendamento);
                Cmd.Parameters.AddWithValue("@servico_id", agendamentoservico.Servicos);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Editar(AgendamentoServico agendamentoservico)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"update agendamentos_servicos set agendamento_numero = @agendamento_numero, servico_id where agendamento_numero = @agendamento_numero, servico_id";

                Cmd.Parameters.AddWithValue("@agendamento_numero", agendamentoservico.Agendamento);
                Cmd.Parameters.AddWithValue("@servico_id", agendamentoservico.Servicos);
                Cmd.Parameters.AddWithValue("@agendamento_numero", agendamentoservico.Agendamento);
                Cmd.Parameters.AddWithValue("@servico_id", agendamentoservico.Servicos);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Excluir(AgendamentoServico agendamentoservico)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"delete from agendamentos_servicos where agendamento_numero = @agendamento_numero, servico_id;";

                Cmd.Parameters.AddWithValue("@agendamento_numero", agendamentoservico.Agendamento);
                Cmd.Parameters.AddWithValue("@servico_id", agendamentoservico.Servicos);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public AgendamentoServico Obtem(int numero, int id)
        {
            AgendamentoServico agendamentoservico = null;
            AgendamentoData agendamentoData = new AgendamentoData(strCnn);
            ServicosData servicoData = new ServicosData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from agendamentos_servicos where agendamento_numero = @agendamento_numero;";

                Cmd.Parameters.AddWithValue("@agendamento_numero", numero);
                Cmd.Parameters.AddWithValue("@servico_id", id);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    agendamentoservico = new AgendamentoServico();

                    agendamentoservico.Agendamento = agendamentoData.Obtem(Dr.GetInt32(0));
                    agendamentoservico.Servicos = servicoData.Obtem(Dr.GetInt32(1));
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return agendamentoservico;
        }

        public List<AgendamentoServico> Listar()
        {
            List<AgendamentoServico> lista = null;
            AgendamentoData agendamentoData = new AgendamentoData(strCnn);
            ServicosData servicoData = new ServicosData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from agendamentos_servicos;";

                Dr = Cmd.ExecuteReader();

                lista = new List<AgendamentoServico>();

                while (Dr.Read())
                {
                    AgendamentoServico agendamentoservico = new AgendamentoServico();


                    agendamentoservico.Agendamento = agendamentoData.Obtem(Dr.GetInt32(0));
                    agendamentoservico.Servicos = servicoData.Obtem(Dr.GetInt32(1));

                    lista.Add(agendamentoservico);
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
