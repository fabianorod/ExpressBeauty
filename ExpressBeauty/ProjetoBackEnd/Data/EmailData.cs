using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;


namespace ProjetoBackEnd.Data
{
    class EmailData : Conexao
    {

        private string strCnn;

        public EmailData(string stringConexao)
            : base(stringConexao) {
                strCnn = stringConexao;
        }

        public bool Inserir(Email email)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand(); 
                Cmd.Connection = Cnn;
                Cmd.CommandText = 
                    @"insert into emails values (@endereco);";

                Cmd.Parameters.AddWithValue("@endereco", email.Endereco);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Editar(Email email)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"update emails set endereco = @endereco where pessoa_id = @pessoa_id;";

                Cmd.Parameters.AddWithValue("@endereco", email.Endereco);
                Cmd.Parameters.AddWithValue("@pessoa_id", email.Pessoa);
                

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Excluir(Email email)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"delete from emails where pessoa_id = @pessoa_id;";

                Cmd.Parameters.AddWithValue("@pessoa_id", email.Endereco);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public Email Obtem(int pessoa)
        {
            Email email = null;
            PessoaData pessoaData = new PessoaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from emails where pessoa_id = @pessoa_id;";

                Cmd.Parameters.AddWithValue("@pessoa_id", pessoa);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    email = new Email();

                    email.Endereco = Dr.GetString(0);
                    
                    //email.Pessoa = pessoaData.Obtem(Dr.GetInt32(1));
                    
                    
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return email;
        }

        public List<Email> Listar()
        {
            List<Email> lista = null;
            PessoaData pessoaData = new PessoaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from emails;";

                Dr = Cmd.ExecuteReader();

                lista = new List<Email>();

                while (Dr.Read())
                {
                    Email email = new Email();

                    email.Endereco = Dr.GetString(0);

                    //email.Pessoa = pessoaData.Obtem(Dr.GetInt32(1));

                    lista.Add(email);
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
