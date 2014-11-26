using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using System.Data.SqlClient;

namespace ProjetoBackEnd.Data
{
    class ProfissionalBelezaData : PessoaData
    {

        private string strCnn;

        public ProfissionalBelezaData(string stringConexao)
            : base(stringConexao)
        {
            strCnn = stringConexao;
        }

        
        public ProfissionalBeleza Obtem(int pessoa)
        {
            ProfissionalBeleza pbeleza = null;
            Telefone telefone = null;
            Email email = null;
            PessoaData pessoaData = new PessoaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, profissionaisbeleza pb where p.id = pb.pessoa_id and p.id = @id";

                Cmd.Parameters.AddWithValue("@pessoa_id", pessoa);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    pbeleza = new ProfissionalBeleza();
                    telefone = new Telefone();
                    email = new Email();

                    pbeleza.Id = Dr.GetInt32(0);
                    pbeleza.Nome = Dr.GetString(1);
                    pbeleza.Cpf = Dr.GetString(2);
                    pbeleza.DataNascimento = Dr.GetDateTime(4);
                    pbeleza.Logradouro = Dr.GetString(5);
                    pbeleza.NomeUsuario = Dr.GetString(6);
                    pbeleza.Senha = Dr.GetString(7);
                    pbeleza.Sexo = Dr.GetInt32(8);
                    pbeleza.CidadeId = Dr.GetInt32(9);
                    pbeleza.Cep = Dr.GetString(3);
                    pbeleza.Salario = Dr.GetDecimal(11);
                    pbeleza.TipoPermicao = Dr.GetInt32(12);

                    //codigo para obter telefone
                    TelefoneData tData = new TelefoneData(strCnn);
                    //foreach (Telefone tel in pbeleza.Telefones)
                    //{
                    //    telefone.Pessoa = pbeleza;//pessoaData.Obtem(Dr.GetInt32(0));
                    //    telefone.Numero = Dr.GetString(1);
                    //}
                    //codigo para obter email

                    //recuperar telefones da pessoa
                    pbeleza.Telefones = tData.ListarPorPessoa(pessoa);


                    EmailData eData = new EmailData(strCnn);
                    //foreach (Email em in pbeleza.Emails)
                    //{
                    //    email.Endereco = Dr.GetString(0);
                    //}

                    pbeleza.Emails = eData.ListarPorPessoa(pessoa);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return pbeleza;
        }

        public ProfissionalBeleza Obtem(string nome, string senha)
        {
            ProfissionalBeleza pbeleza = null;
            Telefone telefone = null;
            Email email = null;
            PessoaData pessoaData = new PessoaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, profissionaisbeleza pb where p.id = pb.pessoa_id and p.nome = @nome and p.senha = @senha";

                Cmd.Parameters.AddWithValue("@nome", nome);
                Cmd.Parameters.AddWithValue("@senha", senha);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    pbeleza = new ProfissionalBeleza();
                    telefone = new Telefone();
                    email = new Email();

                    pbeleza.Id = Dr.GetInt32(0);
                    pbeleza.Nome = Dr.GetString(1);
                    pbeleza.Cpf = Dr.GetString(2);
                    pbeleza.DataNascimento = Dr.GetDateTime(4);
                    pbeleza.Logradouro = Dr.GetString(5);
                    pbeleza.NomeUsuario = Dr.GetString(6);
                    pbeleza.Senha = Dr.GetString(7);
                    pbeleza.Sexo = Dr.GetInt32(8);
                    pbeleza.CidadeId = Dr.GetInt32(9);
                    pbeleza.Cep = Dr.GetString(3);
                    pbeleza.Salario = Dr.GetDecimal(11);
                    pbeleza.TipoPermicao = Dr.GetInt32(12);

                    //codigo para obter telefone
                    TelefoneData tData = new TelefoneData(strCnn);
                    pbeleza.Telefones = tData.ListarPorPessoa(pbeleza.Id);

                    //codigo para obter email

                    EmailData eData = new EmailData(strCnn);
                    pbeleza.Emails = eData.ListarPorPessoa(pbeleza.Id);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return pbeleza;
        }


        public List<ProfissionalBeleza> Listar()
        {
            List<ProfissionalBeleza> lista = null;
            PessoaData pessoaData = new PessoaData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, profissionaisbeleza pb where p.id = pb.pessoa_id";

                Dr = Cmd.ExecuteReader();

                lista = new List<ProfissionalBeleza>();

                while (Dr.Read())
                {
                    ProfissionalBeleza pbeleza = new ProfissionalBeleza();
                    Telefone telefone = new Telefone();
                    Email email = new Email();

                    pbeleza.Id = Dr.GetInt32(0);
                    pbeleza.Nome = Dr.GetString(1);
                    pbeleza.Cpf = Dr.GetString(2);
                    pbeleza.Cep = Dr.GetString(3);
                    pbeleza.Logradouro = Dr.GetString(5);
                    pbeleza.NomeUsuario = Dr.GetString(6);
                    pbeleza.Senha = Dr.GetString(7);
                    pbeleza.Sexo = Dr.GetInt32(8);
                    pbeleza.DataNascimento = Convert.ToDateTime(Dr.GetDateTime(4));
                    pbeleza.CidadeId = Dr.GetInt32(9);
                    pbeleza.Salario = Dr.GetDecimal(11);
                    pbeleza.TipoPermicao = Dr.GetInt32(12);

                    //codigo para obter telefone
                    
                    
                    //TelefoneData tData = new TelefoneData(strCnn);
                    //foreach (Telefone tel in pbeleza.Telefones)
                    //pbeleza.Telefones = tData.ListarPorPessoa(pbeleza.Id);

                    //codigo para obter email

                    //EmailData eData = new EmailData(strCnn);
                    //foreach (Email em in pbeleza.Emails)
                    //pbeleza.Emails = eData.ListarPorPessoa(pbeleza.Id);
                    
                    lista.Add(pbeleza);
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


