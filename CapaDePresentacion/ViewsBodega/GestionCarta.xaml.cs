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
using CapaEntidad;

namespace CapaDePresentacion.ViewsBodega
{
    /// <summary>
    /// Lógica de interacción para GestionCarta.xaml
    /// </summary>
    public partial class GestionCarta : UserControl
    {
        CN_RS_DOCTO objetoCnDocto = new CN_RS_DOCTO();
        PickingCarta ventanaPickingCarta = new PickingCarta();


        public GestionCarta()
        {
            InitializeComponent();
            CargarListaCarta();
        }

        private void BtnPreparar_Click(object sender, RoutedEventArgs e)
        {
            
            String dato = (((Button)sender).CommandParameter).ToString();
            int id_carta = int.Parse(dato);
            FrameAgregarProducto.SetValue(Panel.ZIndexProperty, 0);

            ventanaPickingCarta.CargarDetalleCarta(id_carta);

            FrameAgregarProducto.Content = ventanaPickingCarta;
            ventanaPickingCarta.id_carta = id_carta;
          


        }

        void CargarListaCarta()
        {
            try
            {
                GridDatos.ItemsSource = objetoCnDocto.CargarDatosCarta().DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
