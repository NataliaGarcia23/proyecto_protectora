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
    /// Lógica de interacción para AnadirPerro.xaml
    /// </summary>
    public partial class AnadirPerro : Window
    {
        private IForm _caller;
        private Uri foto;
        private Uri fotoPadrino;
        public AnadirPerro(IForm caller)
        {
            _caller = caller;
            InitializeComponent();
            cbRaza.Items.Add("Pastor Alemán");
            cbRaza.Items.Add("Caniche");
            cbRaza.Items.Add("Labrador");
            cbRaza.Items.Add("Bulldog");
            cbRaza.Items.Add("Pitbull");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Rellena las diferentes casillas con las información de un nuevo perro y su padrino si lo tuviese", "Ayuda");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de añadir un nuevo perro a la protectora?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _caller.añadirPerro(txtNombre.Text, txtSexo.Text, txtPeso.Text, cbRaza.Text, txtEdad.Text,
                    foto, txtDescripcion.Text, fotoPadrino, txtDNI_p.Text, txtNombre_p.Text, txtApellido_p.Text);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void btnFotoPerro_Click(object sender, RoutedEventArgs e)
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

        private void btnFotoPadrino_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new Uri(abrirDialog.FileName,
                    UriKind.Absolute);
                    fotoPadrino = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }
    }
}
