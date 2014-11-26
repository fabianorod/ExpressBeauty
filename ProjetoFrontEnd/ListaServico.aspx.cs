using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using ProjetoBackEnd.Model;
using ProjetoBackEnd.Entity;

namespace ProjetoFrontEnd
{
    public partial class ListaServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;

            ServicosModel model = new ServicosModel(stringConexao);

            listaServico.DataSource = model.Listar();
            listaServico.DataBind();
        }
        }
    }
