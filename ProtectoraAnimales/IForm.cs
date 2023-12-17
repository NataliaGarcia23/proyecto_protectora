
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProtectoraAnimales
{
    public interface IForm
    {
        void añadirSocio(string DNI, string correo, string telefono, string nombre, string apellido, Uri foto, string cuenta, string forma, string cuantia);
        void añadirPerro(string nombre, string sexo, string peso, string raza, string edad, Uri foto, string descripcion, Uri foto_padrino, string DNI_padrino, string nombre_padrino, string apellido_padrino);
        void cambiarTexto(string DNI, string correo, string telefono, string nombre, string apellido, Uri foto, Uri zona);
    }
}
