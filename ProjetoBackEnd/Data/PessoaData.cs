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
        private string stringConexao;
        public PessoaData(string strConexao)
            : base(strConexao) {
                stringConexao = strConexao;
        }

        public bool Inserir(Pessoa pessoa)
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
                    @"insert into pessoas values (@nome, @cpf, @cep, @datanascimento, @logradouro, @nome_usuario, @senha, @sexo, @cidade_id); " +"select @@IDENTITY from pessoas";

                Cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                Cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                Cmd.Parameters.AddWithValue("@cep", pessoa.Cep);
                Cmd.Parameters.AddWithValue("@datanascimento", pessoa.DataNascimento);
                Cmd.Parameters.AddWithValue("@logradouro", pessoa.Logradouro);
                Cmd.Parameters.AddWithValue("@nome_usuario", pessoa.NomeUsuario);
                Cmd.Parameters.AddWithValue("@senha", pessoa.Senha);
                Cmd.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                Cmd.Parameters.AddWithValue("@cidade_id", pessoa.CidadeId);
                

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
                    Cmd.CommandText = @"insert into profissionaisbeleza values (@id, @salario, @tipo_permicao)";

                    Cmd.Parameters.AddWithValue("@id", pbeleza.Id);
                    Cmd.Parameters.AddWithValue("@salario", pbeleza.Salario);
                    Cmd.Parameters.AddWithValue("@tipo_permicao", pbeleza.TipoPermicao);

                    Cmd.ExecuteNonQuery();
                }

                //codigo para inserir telefone
                int i = 0;

                foreach (Telefone tel in pessoa.Telefones)
                {

                        Cmd.CommandText =
                            @"insert into telefones values 
                            (@pessoa_id"+i+", @numero" + i +
                            ", @tipo" + i + ")";

                        Cmd.Parameters.AddWithValue("@pessoa_id"+i, pessoa.Id);
                        Cmd.Parameters.AddWithValue("@numero" + i, tel.Numero);
                        Cmd.Parameters.AddWithValue("@tipo" + i, tel.Tipo);

                        Cmd.ExecuteNonQuery();

                        i++;
                    
                }
                //codigo para inserir email

                foreach (Email em in pessoa.Emails)
                {
                    Cmd.CommandText =
                           @"insert into emails values 
                            (@pessoa_id" + i + ", @endereco" + i +")";

                    Cmd.Parameters.AddWithValue("@pessoa_id" + i, pessoa.Id);
                    Cmd.Parameters.AddWithValue("@endereco" + i, em.Endereco);

                    Cmd.ExecuteNonQuery();

                    i++;
                }

                tran.Commit();
                ok = true;
            }

            catch (Exception e)
            {
                tran.Rollback();
                Console.WriteLine(e.Message);
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
                    @"update pessoas set nome = @nome, cpf = @cpf, cep = @cep, idade = @idade, logradouro = @logradouro, nome_usuario = @usuario, senha = @senha, 
                        sexo = @sexo where id = @id";

                Cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                Cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                Cmd.Parameters.AddWithValue("@datanascimento", pessoa.DataNascimento);
                Cmd.Parameters.AddWithValue("@logradouro", pessoa.Logradouro);
                Cmd.Parameters.AddWithValue("@nome_usuario", pessoa.NomeUsuario);
                Cmd.Parameters.AddWithValue("@senha", pessoa.Senha);
                Cmd.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                Cmd.Parameters.AddWithValue("@cep", pessoa.Cep);

               
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

                    Cmd.CommandText = @"update profissionaisbeleza set id = @id, salario = @salario, tipo_permicao = @tipo_permicao,
                         where id = @pessoa_id";

                    Cmd.Parameters.AddWithValue("@id", pbeleza.Id);
                    Cmd.Parameters.AddWithValue("@tipo_permicao", pbeleza.TipoPermicao);
                }

                

                //codigo para editar telefone
                TelefoneData tData = new TelefoneData(stringConexao);
                foreach (Telefone tel in pessoa.Telefones)
                {
                    tData.Editar(tel);
                }
                //codigo para editar email

                EmailData eData = new EmailData(stringConexao);
                foreach (Email em in pessoa.Emails)
                {
                    eData.Editar(em);
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
                    Cmd.CommandText = @"delete from clientes where pessoa_id = @id";
                }
                else if (pessoa is ProfissionalBeleza)
                {
                    Cmd.CommandText = @"delete from profissionaisbeleza where pessoa_id = @id";
                }

                Cmd.Parameters.AddWithValue("@id", pessoa.Id);
                Cmd.ExecuteNonQuery();

                Cmd.CommandText = @"delete from pessoas where id = @pessoa_id";
                Cmd.Parameters.AddWithValue("@pessoa_id", pessoa.Id);

                Cmd.ExecuteNonQuery();

                //codigo para excluir telefone
                TelefoneData tData = new TelefoneData(stringConexao);
                foreach (Telefone tel in pessoa.Telefones)
                {
                    tData.Excluir(tel);
                }
                //codigo para editar email

                EmailData eData = new EmailData(stringConexao);
                foreach (Email em in pessoa.Emails)
                {
                    eData.Excluir(em);
                }

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