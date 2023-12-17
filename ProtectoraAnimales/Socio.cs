using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectoraAnimales
{
    class Socio
    {
        public string DNI { set; get; }
        public string correo { set; get; }
        public string telefono { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public Uri foto { set; get; }
        public string cuenta { set; get; }
        public string forma { set; get; }
        public string cuantia { set; get; }
        
        public Socio(string dni, string Correo, string Telefono, string
        Nombre, string Apellido, Uri Foto, string Cuenta, string Forma, string Cuantia)
        {
            DNI = dni;
            correo = Correo;
            foto = Foto;
            nombre = Nombre;
            apellido = Apellido;
            telefono = Telefono;
            cuenta = Cuenta;
            forma = Forma;
            cuantia = Cuantia;
        }
    }
}
