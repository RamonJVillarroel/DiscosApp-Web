using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //creacion de mi propio tipo de datos
    public enum TipoUser
    {
        User = 0,
        Admin = 1,
    }
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string pass { get; set; }
        public TipoUser TipoUser { get; set; }
    
        
    }
}
