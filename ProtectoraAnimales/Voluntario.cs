using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectoraAnimales
{
    public class Voluntario
    {
        public string DNI { set; get; }
        public string correo { set; get; }
        public string telefono { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public Uri foto { set; get; }
        public Uri zona { set; get; }
        public Voluntario(string dni, string Correo, string Telefono, string
        Nombre, string Apellido, Uri Foto, Uri Zona)
        {
            DNI = dni;
            correo = Correo;
            foto = Foto;
            nombre = Nombre;
            apellido = Apellido;
            telefono = Telefono;
            zona = Zona;
        }
    }
}
