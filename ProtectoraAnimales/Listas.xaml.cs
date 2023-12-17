using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace ProtectoraAnimales
{
    /// <summary>
    /// Lógica de interacción para Listas.xaml
    /// </summary>
    public partial class Listas : Window, IForm
    {
        private List<Voluntario> listadoVoluntarios;
        private List<Socio> listadoSocios;
        private List<Perro> listadoPerros;
        private string User;
        public Listas(string user)
        {
            InitializeComponent();
            // Se cargarán los datos de prueba de un fichero XML
            listadoVoluntarios = CargarContenidoXML();
            listadoSocios = CargarContenidoXMLSocios();
            listadoPerros = CargarContenidoXMLPerros();
            // Indicar que el origen de datos del ListBox es listadoVoluntarios
            //DataContext = listadoVoluntarios;
            //DataContext = listadoSocios;
            User = user;
            lblUsuario.Content = user;
        }
        private List<Perro> CargarContenidoXMLPerros()
        {
            List<Perro> listado = new List<Perro>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Perros.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoPerro = new Perro("", "", "", "", "", null, "", null, "", "", "", "");
                nuevoPerro.nombre = node.Attributes["nombre"].Value;
                nuevoPerro.sexo = node.Attributes["sexo"].Value;
                nuevoPerro.foto = new Uri(node.Attributes["foto"].Value, UriKind.Relative);
                nuevoPerro.peso = node.Attributes["peso"].Value;
                nuevoPerro.edad = node.Attributes["edad"].Value;
                nuevoPerro.raza = node.Attributes["raza"].Value;
                nuevoPerro.descripcion = node.Attributes["descripcion"].Value;
                nuevoPerro.DNI_padrino = node.Attributes["DNI_p"].Value;
                nuevoPerro.nombre_padrino = node.Attributes["nombre_p"].Value;
                nuevoPerro.apellido_padrino = node.Attributes["apellido_p"].Value;
                nuevoPerro.foto_padrino = new Uri(node.Attributes["foto_p"].Value, UriKind.Relative);
                if (nuevoPerro.DNI_padrino == "" && nuevoPerro.nombre_padrino == "" && nuevoPerro.apellido_padrino == "")
                {
                    nuevoPerro.estado = "No apadrinado";
                }
                else
                {
                    nuevoPerro.estado = "Apadrinado";
                }
                listado.Add(nuevoPerro);
            }
            return listado;
        }
        private List<Socio> CargarContenidoXMLSocios()
        {
            List<Socio> listado = new List<Socio>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Socios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoSocio = new Socio("", "", "", "", "", null, "", "", "");
                nuevoSocio.DNI = node.Attributes["DNI"].Value;
                nuevoSocio.correo = node.Attributes["correo"].Value;
                nuevoSocio.telefono = node.Attributes["telefono"].Value;
                nuevoSocio.nombre = node.Attributes["nombre"].Value;
                nuevoSocio.apellido = node.Attributes["apellido"].Value;
                nuevoSocio.foto = new Uri(node.Attributes["foto"].Value, UriKind.Relative);
                nuevoSocio.cuenta = node.Attributes["cuenta"].Value;
                nuevoSocio.forma = node.Attributes["forma"].Value;
                nuevoSocio.cuantia = node.Attributes["cuantia"].Value;
                listado.Add(nuevoSocio);
            }
            return listado;
        }
        private List<Voluntario> CargarContenidoXML()
        {
            List<Voluntario> listado = new List<Voluntario>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("Datos/Voluntarios.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoVoluntario = new Voluntario("", "", "", "", "", null,null);
                nuevoVoluntario.DNI = node.Attributes["DNI"].Value;
                nuevoVoluntario.correo = node.Attributes["correo"].Value;
                nuevoVoluntario.telefono = node.Attributes["telefono"].Value;
                nuevoVoluntario.nombre = node.Attributes["nombre"].Value;
                nuevoVoluntario.apellido = node.Attributes["apellido"].Value;
                nuevoVoluntario.foto = new Uri(node.Attributes["foto"].Value, UriKind.Relative);
                nuevoVoluntario.zona = new Uri(node.Attributes["zona"].Value, UriKind.Relative);
                listado.Add(nuevoVoluntario);
            }
            return listado;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void miEliminarItemLB_Click(object sender, RoutedEventArgs e)
        {
            listadoVoluntarios.RemoveAt(lstListaVoluntarios.SelectedIndex);
            lstListaVoluntarios.Items.Refresh();
        }
        #region IForm Members
        public void cambiarTexto(string DNI, string correo, string telefono, string nombre, string apellido, Uri foto, Uri zona)
        {
            //txtprueba.Text = text;
            var nuevoVoluntario = new Voluntario("", "", "", "", "", null, null);
            nuevoVoluntario.DNI = DNI;
            nuevoVoluntario.correo = correo;
            nuevoVoluntario.telefono = telefono;
            nuevoVoluntario.nombre = nombre;
            nuevoVoluntario.apellido = apellido;
            nuevoVoluntario.foto = foto;
            nuevoVoluntario.zona = zona;
            listadoVoluntarios.Add(nuevoVoluntario);
            lstListaVoluntarios.Items.Refresh();

        }
        #endregion
        private void miAniadirItemLB_Click(object sender, RoutedEventArgs e)
        {
            AnadirVoluntario a = new AnadirVoluntario(this);
            a.ShowDialog();
            
        }

        private void miEliminarItemLBSocios_Click(object sender, RoutedEventArgs e)
        {
            listadoSocios.RemoveAt(lstListaSocios.SelectedIndex);
            lstListaSocios.Items.Refresh();
        }

        private void miAniadirItemLBSocios_Click(object sender, RoutedEventArgs e)
        {
            AnadirSocio a = new AnadirSocio(this);
            a.ShowDialog();
        }
        #region IForm Members
        public void añadirSocio(string DNI, string correo, string telefono, string nombre, string apellido, Uri foto, string cuenta, string forma, string cuantia)
        {
            //txtprueba.Text = text;
            var nuevoSocio = new Socio("", "", "", "", "", null, "", "", "");
            nuevoSocio.DNI = DNI;
            nuevoSocio.correo = correo;
            nuevoSocio.telefono = telefono;
            nuevoSocio.nombre = nombre;
            nuevoSocio.apellido = apellido;
            nuevoSocio.foto = foto;
            nuevoSocio.cuenta = cuenta;
            nuevoSocio.cuantia = cuantia;
            nuevoSocio.forma = forma;
            listadoSocios.Add(nuevoSocio);
            lstListaSocios.Items.Refresh();

        }
        #endregion
        #region IForm Members
        public void añadirPerro(string nombre, string sexo, string peso, string raza, string edad, Uri foto, string descripcion, Uri foto_padrino, string DNI_padrino, string nombre_padrino, string apellido_padrino)
        {
            //txtprueba.Text = text;
            var nuevoPerro = new Perro("", "", "", "", "", null, "", null, "", "", "", "");
            nuevoPerro.nombre = nombre;
            nuevoPerro.sexo = sexo;
            nuevoPerro.peso = peso;
            nuevoPerro.raza = raza;
            nuevoPerro.edad = edad;
            nuevoPerro.foto = foto;
            nuevoPerro.descripcion = descripcion;
            nuevoPerro.foto_padrino = foto_padrino;
            nuevoPerro.DNI_padrino = DNI_padrino;
            nuevoPerro.apellido_padrino = apellido_padrino;
            nuevoPerro.nombre_padrino = nombre_padrino;
            if (nuevoPerro.DNI_padrino == "" && nuevoPerro.nombre_padrino == "" && nuevoPerro.apellido_padrino == "")
            {
                nuevoPerro.estado = "No apadrinado";
            }
            else
            {
                nuevoPerro.estado = "Apadrinado";
            }
            listadoPerros.Add(nuevoPerro);
            lstListaPerros.Items.Refresh();
        }
        #endregion
        private void tcPestanas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tcPestanas.SelectedIndex == 0)
            {
                DataContext = listadoPerros;
            }
            else if (tcPestanas.SelectedIndex == 1)
            {
                DataContext = listadoSocios;
            }
            else if (tcPestanas.SelectedIndex == 2)
            {
                DataContext = listadoVoluntarios;
            }
        }

        private void miAniadirItemLBPerros_Click(object sender, RoutedEventArgs e)
        {
            AnadirPerro a = new AnadirPerro(this);
            a.ShowDialog();
        }
        private void miEliminarItemLBPerros_Click(object sender, RoutedEventArgs e)
        {
            listadoPerros.RemoveAt(lstListaPerros.SelectedIndex);
            lstListaPerros.Items.Refresh();
        }

    }
}
