using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class GenerosNegocio
    {
        public List<Genero> Listar()
        {
            List<Genero> lista = new List<Genero>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Id, Descripcion from Estilos;";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Genero aux = new Genero();
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
