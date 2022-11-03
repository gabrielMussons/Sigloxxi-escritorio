using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Lógica de interacción para MantenedorReservas.xaml
    /// </summary>
    public partial class MantenedorReservas : UserControl
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);

        public MantenedorReservas()
        {
            InitializeComponent();

            probar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CRUDReserva ventana = new CRUDReserva();
            FrameAgregarReserva.SetValue(Panel.ZIndexProperty, 0);
            ventana.BtnEliminar.IsEnabled = false;
            ventana.BtnActualizar.IsEnabled = false;
            FrameAgregarReserva.Content = ventana;
            btnNuevaReserva.IsEnabled = false;
        }
        public void probar() {
            
            con.Open();
            if (con.State==System.Data.ConnectionState.Open)
            {
                MessageBox.Show("conectado");
            }
            else
            {
                MessageBox.Show("no se pudo conectar");
            }
            con.Close();
            
            

        }
    }
}
