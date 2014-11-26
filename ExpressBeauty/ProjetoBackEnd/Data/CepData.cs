using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;

namespace ProjetoBackEnd.Data
{
    class CepData: Conexao
    {

        private string strCnn;

        public CepData(string stringConexao)
            : base(stringConexao) {
                strCnn = stringConexao;
        }

        public bool Inserir(Cep cep)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand(); 
                Cmd.Connection = Cnn;
                Cmd.CommandText = 
                    @"insert into ceps values (@numero, @cidade_id);";

                Cmd.Parameters.AddWithValue("@numero", cep.Numero);
                Cmd.Parameters.AddWithValue("@cidade_id", cep.Cidade);
             
                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Editar(Cep cep)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"update ceps set numero = @numero, cidade_id = @cidade_id where numero = @numero;";

                Cmd.Parameters.AddWithValue("@numero", cep.Numero);
                Cmd.Parameters.AddWithValue("@cidade_id", cep.Cidade);
                Cmd.Parameters.AddWithValue("@numero", cep.Numero);
                

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Excluir(Cep cep)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"delete from ceps where numero = @numero;";

                Cmd.Parameters.AddWithValue("@numero", cep.Numero);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public Cep Obtem(string numero)
        {
            Cep cep = null;
            CidadeData cidadeData = new CidadeData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from ceps where numero = @numero;";

                Cmd.Parameters.AddWithValue("@numero", numero);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    cep = new Cep();

                    cep.Numero = Dr.GetString(0);
                    cep.Cidade = cidadeData.Obtem(Dr.GetInt32(1));
                   
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return cep;
        }

        public List<Cep> Listar()
        {
            List<Cep> lista = null;
            CidadeData cidadeData = new CidadeData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from ceps;";

                Dr = Cmd.ExecuteReader();

                lista = new List<Cep>();

                while (Dr.Read())
                {
                    Cep cep = new Cep();

                    cep.Numero = Dr.GetString(0);
                    cep.Cidade = cidadeData.Obtem(Dr.GetInt32(1));

                    lista.Add(cep);
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