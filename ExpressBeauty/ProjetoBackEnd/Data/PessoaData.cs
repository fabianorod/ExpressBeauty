using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjetoBackEnd.Data
{
    public class PessoaData : Conexao
    {
        private string strCnn;
        public PessoaData(string strConexao)
            : base(strConexao) { }

        public bool Inserir(Pessoa pessoa)
        {
            bool ok = false;
            SqlTransaction tran = null;

            try
            {
                //tran = Cnn.BeginTransaction();

                Cmd = new SqlCommand(); 
                Cmd.Connection = Cnn;

                tran = Cmd.Connection.BeginTransaction();
                Cmd.CommandText = 
                    @"insert into pessoas values (@nome, @cpf, @idade, @logradouro, @sexo, @cep_numero);";

                Cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                Cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                Cmd.Parameters.AddWithValue("@idade", pessoa.Idade);
                Cmd.Parameters.AddWithValue("@logradouro", pessoa.Logradouro);
                Cmd.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                Cmd.Parameters.AddWithValue("@cep_numero", pessoa.Cep);

                pessoa.Id = Convert.ToInt32(Cmd.ExecuteScalar());

                if (pessoa is Cliente)
                {
                    Cliente cliente = pessoa as Cliente;
                    Cmd.CommandText = @"insert into clientes values (@id, @status)";

                    Cmd.Parameters.AddWithValue("@id", cliente.Id);
                    Cmd.Parameters.AddWithValue("@status", cliente.Status);

                    Cmd.ExecuteNonQuery();
                }
                else if (pessoa is ProfissionalBeleza)
                {
                    ProfissionalBeleza pbeleza = pessoa as ProfissionalBeleza;
                    Cmd.CommandText = @"insert into profissionaisbeleza values (@salario, @status)";

                    Cmd.Parameters.AddWithValue("@id", pbeleza.Id);
                    Cmd.Parameters.AddWithValue("@salario", pbeleza.Salario);
                    Cmd.Parameters.AddWithValue("@status", pbeleza.Status);

                    Cmd.ExecuteNonQuery();
                }

                tran.Commit();
                ok = true;
            }

            catch (Exception e)
            {
                tran.Rollback();
            }

            return ok;
        }

        public bool Editar(Pessoa pessoa)
        {
            bool ok = false;
            SqlTransaction tran = null;

            try
            {
                tran = Cnn.BeginTransaction();
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.Transaction = tran;

                Cmd.CommandText =
                    @"update pessoas set nome = @nome, cpf = @cpf, idade = @idade, logradouro = @logradouro, sexo = @sexo, 
                          cep_numero = @cep_numero where id = @id;";

                Cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                Cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                Cmd.Parameters.AddWithValue("@idade", pessoa.Idade);
                Cmd.Parameters.AddWithValue("@logradouro", pessoa.Logradouro);
                Cmd.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                Cmd.Parameters.AddWithValue("@cep_numero", pessoa.Cep);
                Cmd.Parameters.AddWithValue("@id", pessoa.Id);


                if (pessoa is Cliente)
                {
                    Cliente cliente = pessoa as Cliente;

                    Cmd.CommandText = @"update clientes set id = @id, status = @status where id = @pessoa_id";

                    Cmd.Parameters.AddWithValue("@id", cliente.Id);
                    Cmd.Parameters.AddWithValue("@status", cliente.Status);

                    Cmd.ExecuteNonQuery();

                }
                else if (pessoa is ProfissionalBeleza)
                {
                    ProfissionalBeleza pbeleza = pessoa as ProfissionalBeleza;

                    Cmd.CommandText = @"update profissionaisbeleza set id = @id, salario = @salario, status = @status where id = @pessoa_id";

                    Cmd.Parameters.AddWithValue("@id", pbeleza.Id);
                    Cmd.Parameters.AddWithValue("@salario", pbeleza.Salario);
                    Cmd.Parameters.AddWithValue("@status", pbeleza.Status);
                }

                tran.Commit();
                ok = true;
            }

            catch (Exception e)
            {
                tran.Rollback();
            }

            return ok;
        }

        public bool Excluir(Pessoa pessoa)
        {
            bool ok = false;

            SqlTransaction tran = null;
            try
            {
                tran = Cnn.BeginTransaction();
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.Transaction = tran;

                if (pessoa is Cliente)
                {
                    Cmd.CommandText = @"delete from clientes where id = @id";
                }
                else if (pessoa is ProfissionalBeleza)
                {
                    Cmd.CommandText = @"delete from profissionaisbeleza where id = @id";
                }

                Cmd.Parameters.AddWithValue("@id", pessoa.Id);
                Cmd.ExecuteNonQuery();

                Cmd.CommandText = @"delete from pessoas where id = @pessoa_id";
                Cmd.Parameters.AddWithValue("@pessoa_id", pessoa.Id);

                Cmd.ExecuteNonQuery();

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

    }

 }