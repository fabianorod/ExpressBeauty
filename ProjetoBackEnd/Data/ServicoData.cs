using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;


namespace ProjetoBackEnd.Data
{
    class ServicosData : Conexao
    {

        public ServicosData(string stringConexao)
            : base(stringConexao) { }

        public bool Inserir(Servicos servico)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand(); 
                Cmd.Connection = Cnn;
                Cmd.CommandText = 
                    @"insert into servicos values (@nome, @valor, @descricao)";

                Cmd.Parameters.AddWithValue("@nome", servico.Nome);
                Cmd.Parameters.AddWithValue("@valor", servico.Valor);
                Cmd.Parameters.AddWithValue("@descricao", servico.Descricao);            
             
                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Editar(Servicos servico)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"update servicos set nome = @nome, valor = @valor, descricao = @descricao where id = @id";

                Cmd.Parameters.AddWithValue("@nome", servico.Nome);
                Cmd.Parameters.AddWithValue("@valor", servico.Valor);
                Cmd.Parameters.AddWithValue("@descricao", servico.Descricao);
                Cmd.Parameters.AddWithValue("@id", servico.Id);
                

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Excluir(Servicos servico)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"delete from servicos where id = @id";

                Cmd.Parameters.AddWithValue("@id", servico.Id);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public Servicos Obtem(int id)
        {
            Servicos servico = null;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from servicos where id = @id";

                Cmd.Parameters.AddWithValue("@id", id);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    servico = new Servicos();

                    servico.Id = Dr.GetInt32(0);
                    servico.Nome = Dr.GetString(1);
                    servico.Valor = Dr.GetDecimal(2);
                    servico.Descricao = Dr.GetString(3);
                   
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return servico;
        }

        public List<Servicos> Listar()
        {
            List<Servicos> lista = null;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from servicos";

                Dr = Cmd.ExecuteReader();

                lista = new List<Servicos>();

                while (Dr.Read())
                {
                    Servicos servico = new Servicos();

                    servico.Id = Dr.GetInt32(0);
                    servico.Nome = Dr.GetString(1);
                    servico.Valor = Dr.GetDecimal(2);
                    servico.Descricao = Dr.GetString(3);

                    lista.Add(servico);
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
