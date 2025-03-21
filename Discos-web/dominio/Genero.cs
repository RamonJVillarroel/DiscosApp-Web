using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Genero
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //cuando hago una combinacion de tablas se debe sobreescribir el metodo tostring
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
