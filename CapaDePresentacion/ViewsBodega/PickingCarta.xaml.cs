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

namespace CapaDePresentacion.ViewsBodega
{
    /// <summary>
    /// Lógica de interacción para PickingCarta.xaml
    /// </summary>
    public partial class PickingCarta : Page
    {
        CN_RS_DET_DOCTO objetoCNDetalleDocto = new CN_RS_DET_DOCTO();
        CE_RS_DET_DOCTO objetoCEDetalleDocto = new CE_RS_DET_DOCTO();
        CN_RS_DET_PLATO objetoCNDetPlato = new CN_RS_DET_PLATO();
        CE_RS_DET_PLATO objetoCEDetPlato = new CE_RS_DET_PLATO();
        CN_RS_PLATO objetoCNPlato = new  CN_RS_PLATO();
        CE_RS_PLATO objetoCEPlato = new CE_RS_PLATO();
        CE_RS_ESTADO objetoCEEstado = new CE_RS_ESTADO();
        CN_RS_ESTADO objetoCNEstado = new CN_RS_ESTADO();

        readonly ReposicionStock ventanaReposicion = new ReposicionStock();

        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static PickingCarta ventana;

        //2.Creamos un metodo para obtener la instancia
        public static PickingCarta GetInstance()
        {

            if (ventana == null)
            {
                ventana = new PickingCarta();
            }
            return ventana;

        }
        #endregion

        public PickingCarta()
        {
            InitializeComponent();
            
            
        }
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new GestionCarta();
        }
        public void CargarDetalleCarta(int id_carta)
        {
            try
            {
                GridDatos.ItemsSource = objetoCNDetalleDocto.CargarDetalleCarta(id_carta).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public void CargarDetallePlatoCarta(int id_plato,int cantidad_platos_carta)
        {
            try
            {
                GridDetallePlato.ItemsSource = objetoCNDetPlato.CargarDetPlatoCarta(id_plato,cantidad_platos_carta).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public void CargarDetallePlato(int id_plato)
        {
            try
            {
                GridDetallePlato.ItemsSource = objetoCNDetPlato.CargarDetPlatos(id_plato).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public int id_carta;

        private void BtnPrepararInsumos_Click(object sender, RoutedEventArgs e)
        {
            String dato = (((Button)sender).CommandParameter).ToString();
            int id_detalle = int.Parse(dato);
            objetoCEDetalleDocto = objetoCNDetalleDocto.Consultar(id_detalle);
            int id_plato = objetoCEDetalleDocto.CE_RS_PLATO_RSPL_ID;
            int id_estado_preparado = objetoCNEstado.ObtenerRSES_ID("Preparado");
            cantidad_platos_detalle_carta = objetoCNDetalleDocto.ObtenerIngresoEgresoDetPlatoCarta(id_plato, id_carta).CE_RSDET_EGRESO;
            CargarDetallePlatoCarta(id_plato, cantidad_platos_detalle_carta);

            if (objetoCEDetalleDocto.CE_RS_ESTADO_RSES_ID == id_estado_preparado)
            {
                GridDetallePlato.IsEnabled = false;
                MessageBox.Show("Los insumos ya han sido preparados.");
            }
            else
            {
                GridDetallePlato.IsEnabled = true;
            }
            
        }
        public int id_plato;
        public int cantidad_platos_detalle_carta;

        private void BtnRetirarInsumos_Click(object sender, RoutedEventArgs e)
        {
            var ventanaRetirar = RetirarInsumos.GetInstance();
            ventanaRetirar.Show();
            ventanaRetirar.Activate();
            ventanaRetirar.Content = ventanaReposicion;

            String dato = (((Button)sender).CommandParameter).ToString();
            int id_producto = int.Parse(dato);
            ventanaReposicion.txtIdProducto.IsEnabled = false;
            ventanaReposicion.txtStockMax.IsEnabled = false;
            ventanaReposicion.txtDescripcion.IsEnabled = false;
            ventanaReposicion.txtStock.IsEnabled = false;
            ventanaReposicion.id_producto = id_producto;
            ventanaReposicion.Consultar();
            ventanaReposicion.lblCantidad.Text = "Cantidad de egreso";
            ventanaReposicion.Titulo.Text = "Retiro de insumos";
            ventanaReposicion.BtnRegresar.IsEnabled = false;
            ventanaReposicion.BtnRegresar.Visibility = Visibility.Hidden;
            ventanaReposicion.picking = true;
            ventanaReposicion.txtCantidad.Text = "";
            ventanaRetirar.id_plato = id_plato;
            ventanaRetirar.cantidad_platos_carta = cantidad_platos_detalle_carta;
            ventanaRetirar.ventanaPicking = this;
            

        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String dato = (((Button)sender).CommandParameter).ToString();
                int id_detalle = int.Parse(dato);
                int id_plato = objetoCNDetalleDocto.Consultar(id_detalle).CE_RS_PLATO_RSPL_ID;
                int id_estado = objetoCNEstado.ObtenerRSES_ID("Preparado");
                cantidad_platos_detalle_carta = objetoCNDetalleDocto.ObtenerIngresoEgresoDetPlatoCarta(id_plato, id_carta).CE_RSDET_EGRESO;
                if (objetoCNDetalleDocto.Consultar(id_detalle).CE_RS_ESTADO_RSES_ID!=id_estado)
                {
                    objetoCNDetalleDocto.ActualizarEstadoDetalleDocto(id_detalle, id_estado);
                    GridDetallePlato.IsEnabled = false;
                    
                }
                else
                {
                    GridDetallePlato.IsEnabled = false;
                    MessageBox.Show("Los insumos ya han sido preparados.");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

                CargarDetalleCarta(id_carta);
            }
            
        }
    }
}
