﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ProjetoBackEnd.Data
{
    public class Conexao : IDisposable
    {
        public SqlConnection Cnn { get; set; }
        public SqlCommand Cmd { get; set; }
        public SqlDataReader Dr { get; set; } 

        public Conexao(string stringConexao)
        {
            Cnn = new SqlConnection();
            Cnn.ConnectionString = stringConexao;
            Cnn.Open();
        }

        public void Dispose()
        {
            try
            {
                Cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
    

