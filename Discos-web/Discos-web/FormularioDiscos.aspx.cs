﻿using System;
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
                    //Configuracion Inicial
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
                //Configuracion para Editar disco puede ir fuera del postback recordarle que no sea un postback a la hora de modificar
                if (Request.QueryString["IdDisco"] != null && !IsPostBack)
                {
                    DiscoNegocio discoNegocio = new DiscoNegocio();
                    var id = Request.QueryString["IdDisco"];
                    int.Parse(id);
                    List<Disco> Lista1Disco = discoNegocio.Listar(id);

                    Disco DiscoSeleccionado = Lista1Disco[0];
                    txtTitulo.Text = DiscoSeleccionado.Nombre;
                    txtFechaLanzamiento.SelectedDate = DiscoSeleccionado.fechaDeLanzamiento;
                    var canciones = DiscoSeleccionado.CantidadDeCanciones;
                    txtCanciones.Text = canciones.ToString();
                    ddlPlataforma.SelectedValue = DiscoSeleccionado.Plataforma.Id.ToString();
                    ddlGenero.SelectedValue = DiscoSeleccionado.Genero.Id.ToString();
                    txtUrlImg.Text = DiscoSeleccionado.UrlImagenTapa.ToString();                    
                    txtUrlImg_TextChanged(sender, e);



                }

            }
            catch (Exception ex){ }

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
                //modificar discos
                if (Request.QueryString["IdDisco"] !=null)
                {
                    var id = Request.QueryString["IdDisco"];
                    int idDisco = int.Parse(id);
                    NuevoDisco.IdDisco = idDisco;
                    discoNegocio.modificar(NuevoDisco);
                }
                else
                {
                    discoNegocio.agregar(NuevoDisco);
                }
                Response.Redirect("DiscosList.aspx",false);
            }
            catch(Exception ex)
            {

            }
        }
    }
}