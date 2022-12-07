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

namespace CapaDePresentacion.ViewsAdmin
{
    /// <summary>
    /// Lógica de interacción para MantenedorGanancias.xaml
    /// </summary>
    public partial class MantenedorReportes : UserControl
    {
        CN_RS_DOCTO objCNDocto = new CN_RS_DOCTO();
        string fecha;

        public MantenedorReportes()
        {
            InitializeComponent();


        }

        private void CargarDTDiaVentas(string fecha)
        {
            GriDatosMes.Visibility = Visibility.Hidden;
            GriDatosAnio.Visibility = Visibility.Hidden;
            GridDatosDia.Visibility = Visibility.Visible;
            GriDatosPlatos.Visibility = Visibility.Hidden;
            GriDatosClientesBoletas.Visibility = Visibility.Hidden;
            GriDatosDiasBoletas.Visibility = Visibility.Hidden;
            GridDatosDia.ItemsSource = (objCNDocto.CargarDTTotalVentasDia(fecha)).DefaultView;
        }
        private void CargarDTMesVentas(string fecha)
        {
            GridDatosDia.Visibility = Visibility.Hidden;
            GriDatosAnio.Visibility = Visibility.Hidden;
            GriDatosDiasBoletas.Visibility = Visibility.Hidden;
            GriDatosMes.Visibility = Visibility.Visible;
            GriDatosClientesBoletas.Visibility = Visibility.Hidden;
            GriDatosPlatos.Visibility = Visibility.Hidden;
            GriDatosMes.ItemsSource = (objCNDocto.CargarDTTotalVentasMes(fecha)).DefaultView;
        }
        private void CargarDTAnioVentas(string fecha)
        {
            GridDatosDia.Visibility = Visibility.Hidden;
            GriDatosMes.Visibility = Visibility.Hidden;
            GriDatosDiasBoletas.Visibility = Visibility.Hidden;
            GriDatosAnio.Visibility = Visibility.Visible;
            GriDatosPlatos.Visibility = Visibility.Hidden;
            GriDatosClientesBoletas.Visibility = Visibility.Hidden;
            GriDatosAnio.ItemsSource = (objCNDocto.CargarDTTotalVentasAnio(fecha)).DefaultView;
        }
        private void CargarDTPlatos(string formato_fecha, string fecha)
        {
            GriDatosMes.Visibility = Visibility.Hidden;
            GriDatosAnio.Visibility = Visibility.Hidden;
            GridDatosDia.Visibility = Visibility.Hidden;
            GriDatosDiasBoletas.Visibility = Visibility.Hidden;
            GriDatosPlatos.Visibility = Visibility.Visible;
            GriDatosClientesBoletas.Visibility = Visibility.Hidden;
            GriDatosPlatos.ItemsSource = objCNDocto.CargarReportePlatosBoletas(formato_fecha,fecha).DefaultView;
        }
        private void CargarDTDias(string formato_fecha, string fecha)
        {
            GriDatosMes.Visibility = Visibility.Hidden;
            GriDatosAnio.Visibility = Visibility.Hidden;
            GridDatosDia.Visibility = Visibility.Hidden;
            GriDatosPlatos.Visibility = Visibility.Hidden;
            GriDatosDiasBoletas.Visibility = Visibility.Visible;
            GriDatosClientesBoletas.Visibility = Visibility.Hidden;
            GriDatosDiasBoletas.ItemsSource = objCNDocto.CargarReporteDiasBoletas(formato_fecha, fecha).DefaultView;
        }
        private void CargarDTClientes(string formato_fecha, string fecha)
        {
            GriDatosMes.Visibility = Visibility.Hidden;
            GriDatosAnio.Visibility = Visibility.Hidden;
            GridDatosDia.Visibility = Visibility.Hidden;
            GriDatosPlatos.Visibility = Visibility.Hidden;
            GriDatosDiasBoletas.Visibility = Visibility.Hidden;
            GriDatosClientesBoletas.Visibility = Visibility.Visible;
            

            GriDatosClientesBoletas.ItemsSource = objCNDocto.CargarReporteClientesBoletas(formato_fecha, fecha).DefaultView;
        }

        string objeto="";

        private void RbtDia_Checked(object sender, RoutedEventArgs e)
        {
            if (objeto=="")
            {
                MessageBox.Show("Debes seleccionar un objeto de medición.");
            }
            else
            {
                if (objeto == "VENTAS")
                {
                    if (fecha == null)
                    {
                        MessageBox.Show("Seleccione una fecha.");
                    }
                    else
                    {
                        CargarDTDiaVentas(fecha);
                    }
                }
                else
                {
                    if (objeto=="PLATOS")
                    {
                        if (fecha == null)
                        {
                            MessageBox.Show("Seleccione una fecha.");
                        }
                        else
                        {
                            CargarDTPlatos("DD/MM/YY",fecha);
                        }
                    }
                    else
                    {
                        if (objeto == "DIAS")
                        {
                            if (fecha == null)
                            {
                                MessageBox.Show("Seleccione una fecha.");
                            }
                            else
                            {
                                CargarDTDias("DD/MM/YY", fecha);
                            }
                        }
                        else
                        {
                            if (objeto == "CLIENTES")
                            {
                                if (fecha == null)
                                {
                                    MessageBox.Show("Seleccione una fecha.");
                                }
                                else
                                {
                                    CargarDTClientes("DD/MM/YY", fecha);
                                }
                            }
                        }
                    }

                }

            }
            
            


        }

        private void RdbMes_Checked(object sender, RoutedEventArgs e)
        {
            if (objeto == "")
            {
                MessageBox.Show("Debes seleccionar un objeto de medición.");
            }
            else
            {
                if (objeto == "VENTAS")
                {
                    if (fecha == null)
                    {
                        MessageBox.Show("Seleccione una fecha.");
                    }
                    else
                    {
                        string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                        CargarDTMesVentas(fecha1);
                    }
                }
                else
                {
                    if (objeto == "PLATOS")
                    {
                        if (fecha == null)
                        {
                            MessageBox.Show("Seleccione una fecha.");
                        }
                        else
                        {
                            string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                            CargarDTPlatos("MM/YYYY", fecha1);
                        }
                    }
                    else
                    {
                        if (objeto == "DIAS")
                        {
                            if (fecha == null)
                            {
                                MessageBox.Show("Seleccione una fecha.");
                            }
                            else
                            {
                                string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                                CargarDTDias("MM/YYYY", fecha1);
                            }
                        }
                        else
                        {
                            if (objeto == "CLIENTES")
                            {
                                if (fecha == null)
                                {
                                    MessageBox.Show("Seleccione una fecha.");
                                }
                                else
                                {
                                    string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                                    CargarDTClientes("MM/YYYY", fecha1);
                                }
                            }
                        }
                    }

                }
            }
            

        }

        private void RbtAnio_Checked(object sender, RoutedEventArgs e)
        {
            if (objeto == "")
            {
                MessageBox.Show("Debes seleccionar un objeto de medición.");
            }
            else
            {
                if (objeto == "VENTAS")
                {
                    if (fecha == null)
                    {
                        MessageBox.Show("Seleccione una fecha.");
                    }
                    else
                    {
                        string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                        CargarDTAnioVentas(fecha1);
                    }
                }
                else
                {
                    if (objeto == "PLATOS")
                    {
                        if (fecha == null)
                        {
                            MessageBox.Show("Seleccione una fecha.");
                        }
                        else
                        {
                            string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                            CargarDTPlatos("YYYY", fecha1);
                        }
                    }
                    else
                    {
                        if (objeto == "DIAS")
                        {
                            if (fecha == null)
                            {
                                MessageBox.Show("Seleccione una fecha.");
                            }
                            else
                            {
                                string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                                CargarDTDias("YYYY", fecha1);
                            }
                        }
                        else
                        {
                            if (objeto == "CLIENTES")
                            {
                                if (fecha == null)
                                {
                                    MessageBox.Show("Seleccione una fecha.");
                                }
                                else
                                {
                                    string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                                    CargarDTClientes("YYYY", fecha1);
                                }
                            }
                        }
                    }

                }
            }
            
        }

        private void DpFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
            if (rbtAnio.IsChecked==false && rbtDia.IsChecked==false && rdbMes.IsChecked==false)
            {
                MessageBox.Show("Seleccione dia , mes o año.");
            }
            else
            {
                fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
                if (objeto == "VENTAS")
                {
                    if (rbtDia.IsChecked == true)
                    {
                        fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
                        CargarDTDiaVentas(fecha);
                    }
                    if (rdbMes.IsChecked == true)
                    {
                        string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                        CargarDTMesVentas(fecha1);
                    }
                    if (rbtAnio.IsChecked == true)
                    {
                        string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                        CargarDTAnioVentas(fecha1);
                    }
                }
                else
                {
                    if (objeto == "DIAS")
                    {
                        if (rbtDia.IsChecked == true)
                        {
                            fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
                            CargarDTDias("DD/MM/YY", fecha);
                        }
                        if (rdbMes.IsChecked == true)
                        {
                            string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                            CargarDTDias("MM/YY", fecha1);
                        }
                        if (rbtAnio.IsChecked == true)
                        {
                            string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                            CargarDTDias("YYYY", fecha1);
                        }
                    }
                    else
                    {
                        if (objeto == "CLIENTES")
                        {
                            if (rbtDia.IsChecked == true)
                            {
                                fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
                                CargarDTClientes("DD/MM/YY", fecha);
                            }
                            if (rdbMes.IsChecked == true)
                            {
                                string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                                CargarDTClientes("MM/YY", fecha1);
                            }
                            if (rbtAnio.IsChecked == true)
                            {
                                string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                                CargarDTClientes("YYYY", fecha1);
                            }
                        }
                        else
                        {
                            if (objeto == "PLATOS")
                            {
                                if (rbtDia.IsChecked == true)
                                {
                                    fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
                                    CargarDTPlatos("DD/MM/YY", fecha);
                                }
                                if (rdbMes.IsChecked == true)
                                {
                                    string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                                    CargarDTPlatos("MM/YY", fecha1);
                                }
                                if (rbtAnio.IsChecked == true)
                                {
                                    string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                                    CargarDTPlatos("YYYY", fecha1);
                                }
                            }
                        }
                    }
                }
            }
            
            
            

        }

        private void BtnCliente_Click(object sender, RoutedEventArgs e)
        {
            objeto = "CLIENTES";
            if (dpFecha.SelectedDate.ToString() == "" || dpFecha.SelectedDate.ToString() == null)
            {
                MessageBox.Show("Seleccione fecha");
            }
            else
            {
                if (rbtDia.IsChecked == true)
                {
                    fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
                    CargarDTClientes("DD/MM/YY", fecha);
                }
                if (rdbMes.IsChecked == true)
                {
                    string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                    CargarDTClientes("MM/YY", fecha1);
                }
                if (rbtAnio.IsChecked == true)
                {
                    string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                    CargarDTClientes("YYYY", fecha1);
                }
            }
        }

        private void BtnDias_Click(object sender, RoutedEventArgs e)
        {
            objeto = "DIAS";
            if (dpFecha.SelectedDate.ToString() == "" || dpFecha.SelectedDate.ToString() == null)
            {
                MessageBox.Show("Seleccione fecha");
            }
            else
            {
                if (rbtDia.IsChecked == true)
                {
                    fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
                    CargarDTDias("DD/MM/YY", fecha);
                }
                if (rdbMes.IsChecked == true)
                {
                    string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                    CargarDTDias("MM/YY", fecha1);
                }
                if (rbtAnio.IsChecked == true)
                {
                    string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                    CargarDTDias("YYYY", fecha1);
                }
            }
        }

        private void BtnVentas_Click(object sender, RoutedEventArgs e)
        {
            objeto = "VENTAS";
            if (dpFecha.SelectedDate.ToString() == "" || dpFecha.SelectedDate.ToString() == null)
            {
                MessageBox.Show("Seleccione fecha");
            }
            else
            {
                if (rbtDia.IsChecked == true)
                {
                    fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
                    CargarDTDiaVentas(fecha);
                }
                if (rdbMes.IsChecked == true)
                {
                    string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                    CargarDTMesVentas( fecha1);
                }
                if (rbtAnio.IsChecked == true)
                {
                    string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                    CargarDTAnioVentas(fecha1);
                }
            }
        }

        private void BtnPlatos_Click(object sender, RoutedEventArgs e)
        {
            objeto = "PLATOS";
            if (dpFecha.SelectedDate.ToString()=="" || dpFecha.SelectedDate.ToString() == null)
            {
                MessageBox.Show("Seleccione fecha");
            }
            else
            {
                if (rbtDia.IsChecked == true)
                {
                    fecha = ((dpFecha.SelectedDate.Value).ToString("dd/MM/yy"));
                    CargarDTPlatos("DD/MM/YY", fecha);
                }
                if (rdbMes.IsChecked == true)
                {
                    string fecha1 = dpFecha.SelectedDate.Value.ToString("MM/yyyy");
                    CargarDTPlatos("MM/YY", fecha1);
                }
                if (rbtAnio.IsChecked == true)
                {
                    string fecha1 = dpFecha.SelectedDate.Value.ToString("yyyy");
                    CargarDTPlatos("YYYY", fecha1);
                }
            }
            
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnPrint.Visibility = Visibility.Hidden;
                btnCliente.Visibility = Visibility.Hidden;
                btnDias.Visibility = Visibility.Hidden;
                btnPlatos.Visibility = Visibility.Hidden;
                btnVentas.Visibility = Visibility.Hidden;
                
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(GridMantenedorInventario, "Nuevo reporte");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                btnPrint.Visibility = Visibility.Visible;
                btnCliente.Visibility = Visibility.Visible;
                btnDias.Visibility = Visibility.Visible;
                btnPlatos.Visibility = Visibility.Visible;
                btnVentas.Visibility = Visibility.Visible;
                btnPrint.Visibility = Visibility.Visible;

            }
        }
    }
}
