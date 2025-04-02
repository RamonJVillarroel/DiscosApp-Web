using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    internal class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        //constructor
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta) {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura() {
            comando.Connection = conexion;
            try {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public void setearProcedure(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.CommandText = sp;
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                //para ejecutar query
                comando.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
        }
        public void terminarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
        //hacmos la linea de abajo para poder setear consultas con @ es decir por parametros
        public void setearParametro(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

    }
}
