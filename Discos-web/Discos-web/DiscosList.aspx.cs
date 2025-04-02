using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Discos_web
{
    public partial class DiscosList : System.Web.UI.Page
    {
        public List<Disco> ListaDiscos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            ListaDiscos = negocio.Listar();
            //Grid view con tablas
            //dgvDiscos.DataSource = negocio.Listar();
            //dgvDiscos.DataBind();
            //listado con foreach

        }
    }
}