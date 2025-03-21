using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class PlataformaNegocio
    {
        public List<Plataforma> Listar()
        {
            List<Plataforma> lista = new List<Plataforma>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Id, Descripcion from TiposEdicion;";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Plataforma aux = new Plataforma();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.terminarConexion();
            }
        }
    }

}
