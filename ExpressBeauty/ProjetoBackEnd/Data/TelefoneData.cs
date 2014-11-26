using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;


namespace ProjetoBackEnd.Data
{
    class TelefoneData : Conexao
    {

        private string strCnn;

        public TelefoneData(string stringConexao)
            : base(stringConexao)
        {
            strCnn = stringConexao;
        }

        public bool Inserir(Telefone telefone)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;
                Cmd.CommandText =
                    @"insert into telefones values (@numero, @ddd);";

                Cmd.Parameters.AddWithValue("@numero", telefone.Numero);
                Cmd.Parameters.AddWithValue("@ddd", telefone.Ddd);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Editar(Telefone telefone)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"update telefones set numero = @numero, ddd = @ddd where pessoa_id = @pessoa_id";

                Cmd.Parameters.AddWithValue("@numero", telefone.Numero);
                Cmd.Parameters.AddWithValue("@ddd", telefone.Ddd);
                Cmd.Parameters.AddWithValue("@pessoa_id", telefone.Pessoa);


                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Excluir(Telefone telefone)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"delete from telefones where pessoa_id = @pessoa_id;";

                Cmd.Parameters.AddWithValue("@pessoa_id", telefone.Pessoa);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public Telefone Obtem(int pessoa)
        {
            Telefone telefone = null;
            PessoaData pessoaData = new PessoaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from telefones where pessoa_id = @pessoa_id;";

                Cmd.Parameters.AddWithValue("@pessoa_id", pessoa);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    telefone = new Telefone();

                    //telefone.Pessoa = pessoaData.Obtem(Dr.GetString(0));

                    telefone.Numero = Dr.GetString(1);
                    telefone.Ddd = Dr.GetString(2);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return telefone;
        }

        public List<Telefone> Listar()
        {
            List<Telefone> lista = null;
            PessoaData pessoaData = new PessoaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from telefones;";

                Dr = Cmd.ExecuteReader();

                lista = new List<Telefone>();

                while (Dr.Read())
                {
                    Telefone telefone = new Telefone();

                    //telefone.Pessoa = pessoaData.Obtem(Dr.GetInt32(0));

                    telefone.Numero = Dr.GetString(1);
                    telefone.Ddd = Dr.GetString(2);

                    lista.Add(telefone);
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

