using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Entity;
using ProjetoBackEnd.Model;
using System.Configuration;

namespace ProjetoFrontEnd
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente cliente = Session["vendedor"] as Cliente;
            if (cliente == null)
            {
                painel.Visible = true;
                painelLogado.Visible = false;
            }
            else
            {
                painel.Visible = false;
                painelLogado.Visible = true;

                lblUsuario.Text = cliente.Nome;
            }
        }
            protected void btnEntrar_Click(object sender, EventArgs e)
            {
                string strCnn = ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString;

                ClienteModel model = new ClienteModel(strCnn);

                Cliente cliente = model.Obtem(txtUsuario.Text, txtSenha.Text);

                if (cliente != null)
                {
                    Session["cliente"] = cliente;
                    Response.Redirect("PaginaInicial.aspx");
                }
                else 
                {
                    lblErro.Text = "Erro! Senha ou usuário errado";
                }
            }
        }
    }
