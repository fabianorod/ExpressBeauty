using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;


namespace ProjetoBackEnd.Data
{
    public class UFData : Conexao
    {

        public UFData(string stringConexao)
            : base(stringConexao) { }

        public bool Inserir(UF uf)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand(); 
                Cmd.Connection = Cnn;
                Cmd.CommandText = 
                    @"insert into ufs values (@sigla, @nome);";

                Cmd.Parameters.AddWithValue("@sigla", uf.Sigla);
                Cmd.Parameters.AddWithValue("@nome", uf.Nome);            
             
                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Editar(UF uf)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"update ufs set sigla = @sigla nome = @nome where sigla = @sigla;";

                Cmd.Parameters.AddWithValue("@sigla", uf.Sigla);
                Cmd.Parameters.AddWithValue("@nome", uf.Nome);
                Cmd.Parameters.AddWithValue("@sigla", uf.Sigla);
                

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public bool Excluir(UF uf)
        {
            bool ok = false;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"delete from ufs where sigla = @sigla;";

                Cmd.Parameters.AddWithValue("@sigla", uf.Sigla);

                Cmd.ExecuteNonQuery();

                ok = true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ok;
        }

        public UF Obtem(string sigla)
        {
            UF uf = null;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from ufs where sigla = @sigla;";

                Cmd.Parameters.AddWithValue("@sigla", sigla);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    uf = new UF();

                    uf.Sigla = Dr.GetString(0);
                    uf.Nome = Dr.GetString(1);
                   
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return uf;
        }

        public List<UF> Listar()
        {
            List<UF> lista = null;

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from ufs;";

                Dr = Cmd.ExecuteReader();

                lista = new List<UF>();

                while (Dr.Read())
                {
                    UF uf = new UF();

                    uf.Sigla = Dr.GetString(0);
                    uf.Nome = Dr.GetString(1);

                    lista.Add(uf);
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
