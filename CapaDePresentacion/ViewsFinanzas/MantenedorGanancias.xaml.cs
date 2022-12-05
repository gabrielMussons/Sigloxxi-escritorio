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
using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaDePresentacion.ViewsFinanzas
{
    /// <summary>
    /// Lógica de interacción para MantenedorGanancias.xaml
    /// </summary>
    public partial class MantenedorGanancias : UserControl
    {
        CN_RS_DOCTO objCNDocto = new CN_RS_DOCTO();
        string fecha;

        public MantenedorGanancias()
        {
            InitializeComponent();

           
        }

        private void CargarDTDia(string fecha)
        {
            GriDatosMes.Visibility = Visibility.Hidden;
            GriDatosAnio.Visibility = Visibility.Hidden;
            GridDatosDia.Visibility = Visibility.Visible;
            GridDatosDia.ItemsSource = (objCNDocto.CargarDTTotalVentasDia(fecha)).DefaultView;
        }
        private void CargarDTMes(string fecha)
        {
            GridDatosDia.Visibility = Visibility.Hidden;
            GriDatosAnio.Visibility = Visibility.Hidden;
            GriDatosMes.Visibility = Visibility.Visible;            
            GriDatosMes.ItemsSource = (objCNDocto.CargarDTTotalVentasMes(fecha)).DefaultView;
        }
        private void CargarDTAnio(string fecha)
        {
            GridDatosDia.Visibility = Visibility.Hidden;
            GriDatosMes.Visibility = Visibility.Hidden;
            GriDatosAnio.Visibility = Visibility.Visible;
            GriDatosAnio.ItemsSource = (objCNDocto.CargarDTTotalVentasAnio(fecha)).DefaultView;
        }

        private void RbtDia_Checked(object sender, RoutedEventArgs e)
        {
            if (fecha==null)
            {
                MessageBox.Show("Seleccione una fecha.");
            }
            else
            {
                CargarDTDia(fecha);
            }
            

        }

        private void RdbMes_Checked(object sender, RoutedEventArgs e)
        {
            if (fecha == null)
            {
                MessageBox.Show("Seleccione una fecha.");
            }
            else
            {
                string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                CargarDTMes(fecha1);
            }

        }

        private void DpFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fecha=((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
            if (rbtDia.IsChecked==true)
            {
                CargarDTDia(fecha);
            }
            if (rdbMes.IsChecked == true)
            {
                string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                CargarDTMes(fecha1);
            }
            if (rbtAnio.IsChecked == true)
            {
                string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                CargarDTAnio(fecha1);
            }

        }

        private void RbtAnio_Checked(object sender, RoutedEventArgs e)
        {
            if (fecha == null)
            {
                MessageBox.Show("Seleccione una fecha.");
            }
            else
            {
                string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                CargarDTAnio(fecha1);
            }
        }
    }
}
