using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectoraAnimales
{
    class Perro
    {
        public string nombre { set; get; }
        public string sexo { set; get; }
        public string peso { set; get; }
        public string raza { set; get; }
        public string edad { set; get; }
        public Uri foto { set; get; }
        public string descripcion { set; get; }
        public Uri foto_padrino { set; get; }
        public string DNI_padrino { set; get; }
        public string nombre_padrino { set; get; }
        public string apellido_padrino { set; get; }
        public string estado { set; get; }
        public Perro(string Nombre, string Sexo, string
        Peso, string Raza, string Edad, Uri Foto, string Descripcion, Uri foto_p, string DNI_p, string Nombre_p, string Apellido_p, string Estado)
        {
            nombre = Nombre;
            sexo = Sexo;
            peso = Peso;
            raza = Raza;
            edad = Edad;
            foto = Foto;
            descripcion = Descripcion;
            foto_padrino = foto_p;
            DNI_padrino = DNI_p;
            nombre_padrino = Nombre_p;
            apellido_padrino = Apellido_p;
            estado = Estado;
        }
    }
}
