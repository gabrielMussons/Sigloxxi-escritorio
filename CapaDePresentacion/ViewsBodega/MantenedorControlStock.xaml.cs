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
using CapaLogicaNegocio;

namespace CapaDePresentacion.ViewsBodega
{
    /// <summary>
    /// Lógica de interacción para MantenedorControlStock.xaml
    /// </summary>
    public partial class MantenedorControlStock : UserControl
    {
        private CN_RS_PRODUCTO objeto_CN_RS_PRODUCTO = new CN_RS_PRODUCTO();

        public MantenedorControlStock()
        {
            InitializeComponent();
            CargarListaProductoCritico();
        }

        void CargarListaProductoCritico()
        {
            try
            {
                GridDatos.ItemsSource = objeto_CN_RS_PRODUCTO.CargarListaProductoCritico(txtBuscar.Text.ToString()).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarListaProductoCritico();
        }

        private void BtnGenerarSolicitud_Click(object sender, RoutedEventArgs e)
        {
            SolicitudStock.GetInstance().Show();
            SolicitudStock.GetInstance().Activate();
            
        }
    }
}
