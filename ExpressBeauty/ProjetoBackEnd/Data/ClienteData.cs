using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;

namespace ProjetoBackEnd.Data
{
    class ClienteData : PessoaData
    {

        private string strCnn;

        public ClienteData(string stringConexao)
            : base(stringConexao)
        {
            strCnn = stringConexao;
        }

        

        public Cliente Obtem(int pessoa)
        {
            Cliente cliente = null;
            PessoaData pessoaData = new PessoaData(strCnn);
            CepData cepData = new CepData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, cliente c where p.id = c.pessoa_id and p.id = @id;";

                Cmd.Parameters.AddWithValue("@pessoa_id", pessoa);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    cliente = new Cliente();

                    cliente.Id = Dr.GetInt32(0);
                    cliente.Nome = Dr.GetString(1);
                    cliente.Cpf = Dr.GetString(2);
                    cliente.Idade = Dr.GetInt32(3);
                    cliente.Logradouro = Dr.GetString(4);
                    cliente.Cep = cepData.Obtem(Dr.GetString(5));
                    cliente.Status = Dr.GetInt32(8);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return cliente;
        }

        public List<Cliente> Listar()
        {
            List<Cliente> lista = null;
            PessoaData pessoaData = new PessoaData(strCnn);
            CepData cepData = new CepData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, cliente c where p.id = c.pessoa_id;";

                Dr = Cmd.ExecuteReader();

                lista = new List<Cliente>();

                while (Dr.Read())
                {
                    Cliente cliente = new Cliente();


                    cliente.Id = Dr.GetInt32(0);
                    cliente.Nome = Dr.GetString(1);
                    cliente.Cpf = Dr.GetString(2);
                    cliente.Idade = Dr.GetInt32(3);
                    cliente.Logradouro = Dr.GetString(4);
                    cliente.Cep = cepData.Obtem(Dr.GetString(5));
                    cliente.Status = Dr.GetInt32(8);

                    lista.Add(cliente);
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

