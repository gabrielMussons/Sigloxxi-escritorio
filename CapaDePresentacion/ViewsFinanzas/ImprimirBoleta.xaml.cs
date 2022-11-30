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
using CapaLogicaNegocio;
using MahApps.Metro.Controls;

namespace CapaDePresentacion.ViewsFinanzas
{
    /// <summary>
    /// Lógica de interacción para SolicitudStock.xaml
    /// </summary>
    public partial class ImprimirBoleta : MetroWindow
    {
        CN_RS_DOCTO objCNDocto = new CN_RS_DOCTO();
        public int id_boleta;

        public ImprimirBoleta()
        {
            InitializeComponent();
            CargarListaDetalleBoleta(id_boleta);
            CargarListaTotalBoleta(id_boleta);
            lblNroBoleta.Content = id_boleta;
        }
        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static ImprimirBoleta ventana;

        //2.Creamos un metodo para obtener la instancia
        public static ImprimirBoleta GetInstance()
        {

            if (ventana == null)
            {
                ventana = new ImprimirBoleta();
            }
            return ventana;

        }
        #endregion

        private void TxtMotivo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void CargarListaDetalleBoleta(int id_boleta)
        {
            try
            {
                GridDatos.ItemsSource = objCNDocto.CargarListaDetalleBoleta(id_boleta).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void CargarListaTotalBoleta(int id_boleta)
        {
            try
            {
                GridTotal.ItemsSource = objCNDocto.CargarListaTotalBoleta(id_boleta).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            ventana = null;
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnPrint.Visibility = Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(GridContenido, "Imprimir boleta");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                btnPrint.Visibility = Visibility.Visible;

            }

        }
    }
}
