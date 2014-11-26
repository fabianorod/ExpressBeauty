using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;

namespace ProjetoBackEnd.Data
{
    class CidadeData : Conexao
    {

        private string strCnn;

        public CidadeData(string stringConexao)
            : base(stringConexao) {
                strCnn = stringConexao;
        }

        public bool Inserir(Cidade cidade)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand(); 
                Cmd.Connection = Cnn;
                Cmd.CommandText = 
                    @"insert into cidades values (@nome, @uf_sigla);";

                Cmd.Parameters.AddWithValue("@nome", cidade.Nome);
                Cmd.Parameters.AddWithValue("@uf_sigla", cidade.Uf);
             
                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Editar(Cidade cidade)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"update cidades set nome = @nome, uf_sigla = @uf_sigla where id = @id;";

                Cmd.Parameters.AddWithValue("@nome", cidade.Nome);
                Cmd.Parameters.AddWithValue("@uf_sigla", cidade.Uf);
                Cmd.Parameters.AddWithValue("@id", cidade.Id);
                

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Excluir(Cidade cidade)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"delete from cidades where id = @id;";

                Cmd.Parameters.AddWithValue("@codigo", cidade.Id);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public Cidade Obtem(int id)
        {
            Cidade cidade = null;
            UFData ufData = new UFData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from cidades where id = @id;";

                Cmd.Parameters.AddWithValue("@id", id);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    cidade = new Cidade();

                    cidade.Id = Dr.GetInt32(0);
                    cidade.Nome = Dr.GetString(1);
                    cidade.Uf = ufData.Obtem(Dr.GetString(2));
                   
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return cidade;
        }

        public List<Cidade> Listar()
        {
            List<Cidade> lista = null;
            UFData ufData = new UFData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from cidades;";

                Dr = Cmd.ExecuteReader();

                lista = new List<Cidade>();

                while (Dr.Read())
                {
                    Cidade cidade = new Cidade();

                    cidade.Id = Dr.GetInt32(0);
                    cidade.Nome = Dr.GetString(1);
                    cidade.Uf = ufData.Obtem(Dr.GetString(2));

                    lista.Add(cidade);
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
