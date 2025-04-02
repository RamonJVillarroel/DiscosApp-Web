using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace Discos_web
{
    public partial class FormularioDiscos : System.Web.UI.Page
    {
        public string imgDisco { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    //Para poder seleccionar elemendos recuerda hacer lo siguiente
                    PlataformaNegocio negocioPlataforma = new PlataformaNegocio();
                    List<Plataforma> listaPlataforma = new List<Plataforma>();
                    GenerosNegocio negocioGenero = new GenerosNegocio();
                    List<Genero> listaGenero = new List<Genero>();


                    ddlPlataforma.DataSource = negocioPlataforma.Listar();
                    ddlPlataforma.DataValueField = "Id";
                    ddlPlataforma.DataTextField = "Descripcion";
                    ddlGenero.DataSource = negocioGenero.Listar();
                    ddlGenero.DataValueField = "Id";
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataBind();
                    ddlPlataforma.DataBind();
                }
            }catch (Exception ex){ }

        }

        protected void txtUrlImg_TextChanged(object sender, EventArgs e)
        {
            imgDisco = txtUrlImg.Text;
        }

        protected void btnSubmitDisco_Click(object sender, EventArgs e)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
           
            try {
                Disco NuevoDisco = new Disco();
                NuevoDisco.Nombre = txtTitulo.Text;
                //Calendar causa postbac ver como manejarlo....
                //La fecha esta llegando con el Calendar pero no se esta mandando a la DB ver como trabajar con fechas en web
                NuevoDisco.fechaDeLanzamiento= txtFechaLanzamiento.SelectedDate;
                NuevoDisco.CantidadDeCanciones = int.Parse(txtCanciones.Text);
                NuevoDisco.UrlImagenTapa = txtUrlImg.Text;
                //La forma para instanciar objetos a usar cosas especificas deberia ser asi
                NuevoDisco.Plataforma= new Plataforma();
                NuevoDisco.Plataforma.Id = int.Parse(ddlPlataforma.SelectedValue);
                NuevoDisco.Genero = new Genero();
                NuevoDisco.Genero.Id = int.Parse(ddlGenero.SelectedValue);
                discoNegocio.agregar(NuevoDisco);
                Response.Redirect("DiscosList.aspx");
            }
            catch(Exception ex)
            {

            }
        }
    }
}