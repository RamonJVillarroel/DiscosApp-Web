using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disco
    {

        public int IdDisco { get; set; }
        public string Nombre { get; set; }

        public DateTime fechaDeLanzamiento { get; set; }
        public int CantidadDeCanciones { get; set; }

        public string UrlImagenTapa { get; set; }

        public Genero Genero { get; set; }

        public Plataforma Plataforma { get; set; }

        public bool Activo { get; set; }
    }
}
