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
            Telefone telefone = null;
            Email email = null;
            PessoaData pessoaData = new PessoaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, clientes c where p.id = c.pessoa_id and p.id = @pessoa_id";

                Cmd.Parameters.AddWithValue("@pessoa_id", pessoa);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    cliente = new Cliente();
                    telefone = new Telefone();
                    email = new Email();

                    cliente.Id = Dr.GetInt32(0);
                    cliente.Nome = Dr.GetString(1);
                    cliente.Cpf = Dr.GetString(2);
                    cliente.DataNascimento = Dr.GetDateTime(4);
                    cliente.Logradouro = Dr.GetString(5);
                    cliente.NomeUsuario = Dr.GetString(6);
                    cliente.Senha = Dr.GetString(7);
                    cliente.Sexo = Dr.GetInt32(8);
                    cliente.Cep = Dr.GetString(3);
                    cliente.CidadeId = Dr.GetInt32(9);
                    cliente.Status = Dr.GetInt32(11);

                    //codigo para obter telefone
                    TelefoneData tData = new TelefoneData(strCnn);
                    cliente.Telefones = tData.ListarPorPessoa(pessoa);

                    //codigo para obter email
                    EmailData eData = new EmailData(strCnn);
                    cliente.Emails = eData.ListarPorPessoa(pessoa);

                }
            }



            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return cliente;
        }

        public Cliente Obtem(string nome, string senha)
        {
            Cliente cliente = null;
            //Telefone telefone = null;
            //Email email = null;
            PessoaData pessoaData = new PessoaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, clientes c where p.id = c.pessoa_id and p.nome_usuario = @nome_usuario and p.senha = @senha";

                Cmd.Parameters.AddWithValue("@nome_usuario", nome);
                Cmd.Parameters.AddWithValue("@senha", senha);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    cliente = new Cliente();
                    //telefone = new Telefone();
                    //email = new Email();

                    cliente.Id = Dr.GetInt32(0);
                    cliente.Nome = Dr.GetString(1);
                    cliente.Cpf = Dr.GetString(2);
                    cliente.DataNascimento = Dr.GetDateTime(4);
                    cliente.Logradouro = Dr.GetString(5);
                    cliente.NomeUsuario = Dr.GetString(6);
                    cliente.Senha = Dr.GetString(7);
                    cliente.Sexo = Dr.GetInt32(8);
                    cliente.Cep = Dr.GetString(3);
                    cliente.CidadeId = Dr.GetInt32(9);
                    cliente.Status = Dr.GetInt32(11);

                    //codigo para obter telefone
                    //TelefoneData tData = new TelefoneData(strCnn);
                    //cliente.Telefones = tData.ListarPorPessoa(cliente.Id);
                    ////codigo para obter email

                    //EmailData eData = new EmailData(strCnn);
                    //cliente.Emails = eData.ListarPorPessoa(cliente.Id);

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

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, clientes c where p.id = c.pessoa_id";

                Dr = Cmd.ExecuteReader();

                lista = new List<Cliente>();

                while (Dr.Read())
                {
                    Cliente cliente = new Cliente();
                    Telefone telefone = new Telefone();
                    Email email = new Email();

                    cliente.Id = Dr.GetInt32(0);
                    cliente.Nome = Dr.GetString(1);
                    cliente.Cpf = Dr.GetString(2);
                    cliente.Cep = Dr.GetString(3);
                    cliente.DataNascimento = Dr.GetDateTime(4);
                    cliente.Logradouro = Dr.GetString(5);
                    cliente.NomeUsuario = Dr.GetString(6);
                    cliente.Senha = Dr.GetString(7);
                    cliente.Sexo = Dr.GetInt32(8);                    
                    cliente.Status = Dr.GetInt32(9);

                    //codigo para obter telefone
                    TelefoneData tData = new TelefoneData(strCnn);
                    cliente.Telefones = tData.ListarPorPessoa(cliente.Id);
                    //codigo para obter email

                    EmailData eData = new EmailData(strCnn);
                    cliente.Emails = eData.ListarPorPessoa(cliente.Id);

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

