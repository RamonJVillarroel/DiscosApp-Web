using System;
using System.Collections.Generic;
using System.Xml.Linq;
using dominio;
namespace negocio
{
    public class DiscoNegocio
    {
        public List<Disco> Listar(string id="")
        {
            List<Disco> lista = new List<Disco>();
            
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT d.Id, titulo, FechaLanzamiento,CantidadCanciones,UrlImagenTapa, e.Descripcion as Genero, e.Id as IdGenero, TE.Descripcion AS PLATAFORMA, TE.Id as IdPlataforma, Activo  FROM DISCOS as D inner join ESTILOS as e on d.IdEstilo=e.Id INNER JOIN TIPOSEDICION AS TE on d.IdTipoEdicion = TE.Id";
                if (id != "") {
                    consulta += " and d.Id = " + id;
                }
                datos.setearConsulta(consulta);
                //datos.setearProcedure("storedListar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.IdDisco = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["titulo"];
                    aux.CantidadDeCanciones = (int)datos.Lector["CantidadCanciones"];
                    aux.fechaDeLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                  
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                    {
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];
                    }
                    //Se le tiene que crear una instancia porque si no se crea una referencia nula
                    aux.Genero = new Genero();
                    aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Genero.Id = (int)datos.Lector["IdGenero"];
                    aux.Plataforma = new Plataforma();
                    aux.Plataforma.Descripcion = (string)datos.Lector["Plataforma"];
                    aux.Plataforma.Id = (int)datos.Lector["IdPlataforma"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    // aux.fechaDeLanzamiento = (string)lector["FechaLanzamiento"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                datos.terminarConexion();
            }
        }
        public void agregar(Disco NuevoDisco)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //para insertar datos se puede hacer de esta forma
                string consulta = "INSERT INTO DISCOS(Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion, Activo)VALUES('" + NuevoDisco.Nombre + "',@Lanzamiento," + NuevoDisco.CantidadDeCanciones + ",'" + NuevoDisco.UrlImagenTapa + "', @IdEstilo, @IdTipoEdicion,1)";
                datos.setearParametro("@Lanzamiento", NuevoDisco.fechaDeLanzamiento);
                datos.setearParametro("@IdEstilo", NuevoDisco.Genero.Id);
                datos.setearParametro("@IdTipoEdicion", NuevoDisco.Plataforma.Id);
                datos.setearConsulta(consulta);
                //importante para poder ejecutar datos de añadido
                datos.ejecutarAccion();
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
        public void modificar(Disco disco) {
           // AccesoDatos accesoDatos = new AccesoDatos;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update DISCOS SET Titulo=@titulo,CantidadCanciones=@canciones, UrlImagenTapa=@img, IdEstilo=@Idgenero, IdTipoEdicion=@IdPlataforma WHERE id=@IdDisco;");
                datos.setearParametro("@titulo", disco.Nombre);
                datos.setearParametro("@canciones", disco.CantidadDeCanciones);
                datos.setearParametro("@img", disco.UrlImagenTapa);
                datos.setearParametro("@Idgenero", disco.Genero.Id);
                datos.setearParametro("@IdPlataforma", disco.Plataforma.Id);
                datos.setearParametro("@IdDisco", disco.IdDisco);
                //importante para poder ejecutar datos
                datos.ejecutarAccion();
            }
            catch (Exception ex) { throw  ex; }
            finally { datos.terminarConexion(); }
        }
        public void eliminar(int idDisco)
        {
            try {
                AccesoDatos datos = new AccesoDatos();

                datos.setearConsulta("delete from DISCOS where id=@IdDisco;");
                datos.setearParametro("@IdDisco", idDisco);
                datos.ejecutarAccion();


            }
            catch (Exception ex) { throw ex; }  


        }
        public void eliminarLogico(int idDisco, bool activar=false)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();

                datos.setearConsulta("update DISCOS set Activo = @activo where id = @idDisco");
                datos.setearParametro("@IdDisco", idDisco);
                datos.setearParametro("@activo", activar);
                datos.ejecutarAccion();


            }
            catch (Exception ex) { throw ex; }

            
        }
        public List<Disco> filtrar(string campo, string criterio, string filtro)
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT d.Id, titulo, CantidadCanciones,UrlImagenTapa, e.Descripcion as Genero, e.Id as IdGenero, TE.Descripcion AS PLATAFORMA, TE.Id as IdPlataforma FROM DISCOS as D inner join ESTILOS as e on d.IdEstilo=e.Id INNER JOIN TIPOSEDICION AS TE on d.IdTipoEdicion = TE.Id AND d.Activo=1 AND";
                if (campo == "cantidad de canciones")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += " CantidadCanciones > " + filtro;
                            break;
                        case "Menor a":
                            consulta += " CantidadCanciones < " + filtro;
                            break;
                        default:
                            consulta += " CantidadCanciones = " + filtro;
                            break;
                    }
                }
                else if (campo == "Titulo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " titulo like '"+filtro+"%'";
                            break;
                        case "Termina con":
                            consulta += " titulo like '%"+filtro+"'";
                            break;
                        default:
                            consulta += " titulo like '%"+filtro+"%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += " TE.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += " TE.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += " TE.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.IdDisco = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["titulo"];
                    aux.CantidadDeCanciones = (int)datos.Lector["CantidadCanciones"];
                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];

                    aux.Plataforma = new Plataforma();
                    aux.Plataforma.Id = (int)datos.Lector["IdPlataforma"];
                    aux.Plataforma.Descripcion = (string)datos.Lector["PLATAFORMA"];
                    aux.Genero = new Genero();
                    aux.Genero.Id = (int)datos.Lector["IdGenero"];
                    aux.Genero.Descripcion = (string)datos.Lector["Genero"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
