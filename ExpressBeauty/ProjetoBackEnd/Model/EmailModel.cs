using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Data;

namespace ProjetoBackEnd.Model
{
    public class EmailModel
    {
        private string stringConexao;

        public EmailModel(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }

        public bool Inserir(Email email)
        {
            using (EmailData data = new EmailData(stringConexao))
            {
                return data.Inserir(email);
            }
        }

        public bool Editar(Email email)
        {
            using (EmailData data = new EmailData(stringConexao))
            {
                return data.Editar(email);
            }
        }

        public bool Excluir(Email email)
        {
            using (EmailData data = new EmailData(stringConexao))
            {
                return data.Excluir(email);
            }
        }

        public Email Obtem(int id)
        {
            using (EmailData data = new EmailData(stringConexao))
            {
                return data.Obtem(id);
            }
        }

        public List<Email> Listar()
        {
            using (EmailData data = new EmailData(stringConexao))
            {
                return data.Listar();
            }
        }
    }
}
