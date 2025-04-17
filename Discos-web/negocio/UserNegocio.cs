using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UserNegocio
    {
        public bool Login(Usuarios usuario)
        {

            try {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("select Id, TipoUser From  Usuarios where Usuario=@user and Pass=@pass");
                datos.setearParametro("@user", usuario.Nombre);
                datos.setearParametro("@pass", usuario.pass);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    //usuario.Nombre = (string)datos.Lector["user"];
                    usuario.TipoUser = (int)(datos.Lector["TipoUser"]) == 2 ? TipoUser.Admin : TipoUser.User;//se debe hacer con ternario
                    return true;
                }
                return false;

            }
            catch (Exception EX) {
                throw EX;
            } finally {
                AccesoDatos datos = new AccesoDatos();
                datos.terminarConexion();

            }
           
        }


    }
}
