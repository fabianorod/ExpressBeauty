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
                painelLogado.Visible = !painelLogado.Visible;//false;
            }
            else
            {
                painel.Visible = !painel.Visible;
                painelLogado.Visible = !painelLogado.Visible;

                lblUsuario.Text = cliente.Nome;
            }


        }
    }
}