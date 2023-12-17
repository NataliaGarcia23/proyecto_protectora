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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ProtectoraAnimales
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            // se hará la comprobación al pulsar el "Enter"
            if (e.Key == Key.Return)
            {
                lblEstado.Content = "Se pulsó el enter ";
                if (!String.IsNullOrEmpty(txtUsuario.Text)
                && ComprobarEntrada(txtUsuario.Text, usuario,
                txtUsuario, imgCheckUsuario))
                {
                    // habilitar entrada de contraseña y pasarle el foco
                    passContrasena.IsEnabled = true;
                    passContrasena.Focus();
                    // deshabilitar entrada de login
                    txtUsuario.IsEnabled = false;
                }
            }
        }

        private void diseñoPrincipal_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            lblEstado.Content = "Coordenadas del click: (" + p.X + ", " + p.Y + ")";
        }

        private void passContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            lblEstado.Content = "Has pulsado la tecla <<" + e.Key.ToString() + ">>";
            passContrasena.Background = Brushes.White;
            if (ComprobarEntrada(passContrasena.Password, password,
            passContrasena, imgCheckContrasena))
                btnLogin.Focus();
        }

        private string usuario = "nacho";
        private string password = "natalia";
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // La comprobación ya lleva implícita que las entradas
            // estén vacías
            if (ComprobarEntrada(txtUsuario.Text, usuario,
            txtUsuario, imgCheckUsuario)
            &&
            ComprobarEntrada(passContrasena.Password, password,
            passContrasena, imgCheckContrasena))
            {
                //Application.Current.Shutdown();
                Window ventana = new Listas("Usuario: "+ txtUsuario.Text + ", contraseña: "+ passContrasena.Password);
                ventana.Show();
            }
        }
        private BitmapImage imagCheck = new BitmapImage(new Uri("/imagenes/check.png", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("/imagenes/cross.png", UriKind.Relative));
        private Boolean ComprobarUsuario(string user)
        {
            Boolean valido = false;
            txtUsuario.BorderThickness = new Thickness(2);
            if (user.Equals(usuario))
            {
                // borde y background en verde
                txtUsuario.BorderBrush = Brushes.Green;
                txtUsuario.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de usuario --> check
                imgCheckUsuario.Source = imagCheck;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                txtUsuario.BorderBrush = Brushes.Red;
                // imagen al lado de la entrada de usuario --> cross
                imgCheckUsuario.Source = imagCross;
                valido = false;
            }
            return valido;
        }
        private Boolean ComprobarPassword(string pass)
        {
            Boolean valido = false;
            passContrasena.BorderThickness = new Thickness(2);
            if (pass.Equals(password))
            {
                // borde y background en verde
                passContrasena.BorderBrush = Brushes.Green;
                passContrasena.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de password --> check
                imgCheckContrasena.Source = imagCheck;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                passContrasena.BorderBrush = Brushes.Red;
                // imagen al lado de la entrada de password --> cross
                imgCheckContrasena.Source = imagCross;
                valido = false;
            }
            return valido;
        }
        private Boolean ComprobarEntrada(string valorIntroducido, string valorValido,
Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
            componenteEntrada.BorderThickness = new Thickness(2);
            if (valorIntroducido.Equals(valorValido))
            {
                // borde y background en verde
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de usuario --> check
                imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                componenteEntrada.BorderBrush = Brushes.Red;
                // imagen al lado de la entrada de usuario --> cross
                imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }
        private String mensajeAyuda = "Introduzca usuario (nacho) y contraseña (natalia) para acceder a la aplicación pulsando el botón verde."; 
        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(mensajeAyuda, "Ayuda");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Gracias por usar nuestra aplicación...", "Despedida");
        }

    }
}
