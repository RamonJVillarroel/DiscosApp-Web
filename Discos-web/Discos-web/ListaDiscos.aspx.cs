using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Discos_web
{
    public partial class ListaDiscos : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            dgvListadoDisco.DataSource = negocio.Listar();
            dgvListadoDisco.DataBind();
             

        }

        protected void dgvListadoDisco_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListadoDisco.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioDiscos.aspx?IdDisco=" + id);
        }
    }
}