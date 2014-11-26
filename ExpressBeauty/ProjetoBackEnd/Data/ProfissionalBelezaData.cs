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
            PessoaData pessoaData = new PessoaData(strCnn);
            CepData cepData = new CepData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, profissionisbeleza pb where p.id = v.pessoa_id and p.id = @id;";

                Cmd.Parameters.AddWithValue("@pessoa_id", pessoa);

                Dr = Cmd.ExecuteReader();

                if (Dr.Read())
                {
                    pbeleza = new ProfissionalBeleza();

                    pbeleza.Id = Dr.GetInt32(0);
                    pbeleza.Nome = Dr.GetString(1);
                    pbeleza.Cpf = Dr.GetString(2);
                    pbeleza.Idade = Dr.GetInt32(3);
                    pbeleza.Logradouro = Dr.GetString(4);
                    pbeleza.Cep = cepData.Obtem(Dr.GetString(5));
                    pbeleza.Salario = Dr.GetDecimal(7);
                    pbeleza.Status = Dr.GetInt32(8);
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
            CepData cepData = new CepData(strCnn);

            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = Cnn;

                Cmd.CommandText =
                    @"select * from pessoas p, profissionisbeleza pb where p.id = v.pessoa_id";

                Dr = Cmd.ExecuteReader();

                lista = new List<ProfissionalBeleza>();

                while (Dr.Read())
                {
                    ProfissionalBeleza pbeleza = new ProfissionalBeleza();


                    pbeleza.Id = Dr.GetInt32(0);
                    pbeleza.Nome = Dr.GetString(1);
                    pbeleza.Cpf = Dr.GetString(2);
                    pbeleza.Idade = Dr.GetInt32(3);
                    pbeleza.Logradouro = Dr.GetString(4);
                    pbeleza.Cep = cepData.Obtem(Dr.GetString(5));
                    pbeleza.Salario = Dr.GetDecimal(7);
                    pbeleza.Status = Dr.GetInt32(8);

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


