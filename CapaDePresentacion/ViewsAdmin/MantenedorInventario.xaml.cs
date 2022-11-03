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

namespace CapaDePresentacion.ViewsAdmin
{
    /// <summary>
    /// Lógica de interacción para MantenedorInventario.xaml
    /// </summary>
    public partial class MantenedorInventario : UserControl
    {
        public MantenedorInventario()
        {
            InitializeComponent();
        }

        

        private void BtnNuevoProducto_Click(object sender, RoutedEventArgs e)
        {
            CRUDInventario ventana = new CRUDInventario();
            FrameAgregarProducto.SetValue(Panel.ZIndexProperty, 0);
            ventana.BtnEliminar.IsEnabled = false;
            ventana.BtnActualizar.IsEnabled = false;
            FrameAgregarProducto.Content = ventana;
            btnNuevoProducto.IsEnabled = false;
        }
    }
}
