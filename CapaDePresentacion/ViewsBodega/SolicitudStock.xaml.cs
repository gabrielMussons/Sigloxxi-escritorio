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

namespace CapaDePresentacion.ViewsBodega
{
    /// <summary>
    /// Lógica de interacción para SolicitudStock.xaml
    /// </summary>
    public partial class SolicitudStock : MetroWindow
    {
        CN_RS_PRODUCTO objCNProducto = new CN_RS_PRODUCTO();

        public SolicitudStock()
        {
            InitializeComponent();
            CargarListaProductoCritico();
            txtFecha.Text = DateTime.Now.ToString();
        }
        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static SolicitudStock ventana;

        //2.Creamos un metodo para obtener la instancia
        public static SolicitudStock GetInstance()
        {

            if (ventana == null)
            {
                ventana = new SolicitudStock();
            }
            return ventana;

        }
        #endregion

        private void TxtMotivo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        void CargarListaProductoCritico()
        {
            try
            {
                GridDatos.ItemsSource = objCNProducto.CargarListaProductoCritico("").DefaultView;
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
        string aux;
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btnPrint.Visibility = Visibility.Hidden;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(GridContenido, "Nueva solicitud");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            finally {
                btnPrint.Visibility = Visibility.Visible;
            }
            
        }
    }
}
