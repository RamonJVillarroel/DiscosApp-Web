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
    public partial class FormularioLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            UserNegocio userNegocio = new UserNegocio();
            try
            {
               
                usuario.Nombre = txtUser.Text;
                usuario.pass = txtPass.Text;
                if (userNegocio.Login(usuario)==true)
                {
                     Session.Add("User", usuario);
                     Response.Redirect("ListaDiscos.aspx", false);
                }
                else
                {
                    Session.Add("error", "usuario o pass no ok");
                    Response.Redirect("Error.aspx",false);    
                 }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
            
        }
    }
}