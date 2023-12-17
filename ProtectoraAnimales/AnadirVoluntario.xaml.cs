using Microsoft.Win32;
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

namespace ProtectoraAnimales
{
    /// <summary>
    /// Lógica de interacción para AnadirVoluntario.xaml
    /// </summary>
    public partial class AnadirVoluntario : Window
    {
        private IForm _caller;
        private Uri foto;
        private Uri fotoZona;
        public AnadirVoluntario(IForm caller)
        {
            InitializeComponent();
            _caller = caller;
        }
        public string dni;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de añadir un nuevo voluntario a la protectora?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _caller.cambiarTexto(txtDNI.Text, txtCorreo.Text, txtTelefono.Text, txtNombre.Text, txtApellido.Text, foto, fotoZona);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Rellena las diferentes casillas con las información de un nuevo voluntario", "Ayuda");
        }

        private void btnFotoVoluntario_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new Uri(abrirDialog.FileName,
                    UriKind.Absolute);
                    foto = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }

        private void btnFotoZona_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new Uri(abrirDialog.FileName,
                    UriKind.Absolute);
                    fotoZona = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }
    }
}
