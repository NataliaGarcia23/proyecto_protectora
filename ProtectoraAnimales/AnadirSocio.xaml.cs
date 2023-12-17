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
    /// Lógica de interacción para AnadirSocio.xaml
    /// </summary>
    /// 
    public partial class AnadirSocio : Window
    {
        private IForm _caller;
        private Uri foto;
        public AnadirSocio(IForm caller)
        {
            InitializeComponent();
            cbForma.Items.Add("bizum");
            cbForma.Items.Add("paypal");
            cbForma.Items.Add("transferencia");
            _caller = caller;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de añadir un nuevo socio a la protectora?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _caller.añadirSocio(txtDNI.Text, txtCorreo.Text, txtTelefono.Text, txtNombre.Text, txtApellido.Text, foto,
                txtCuenta.Text, cbForma.Text, txtCuantia.Text);
                this.Close();
            }
            else
            {
                this.Close();
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Rellena las diferentes casillas con las información de un nuevo socio", "Ayuda");
        }

        private void btnFotoSocio_Click(object sender, RoutedEventArgs e)
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
    }
}
