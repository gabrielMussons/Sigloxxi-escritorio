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

namespace CapaDePresentacion.ViewsCocina
{
    /// <summary>
    /// Lógica de interacción para MantenedorRecetas.xaml
    /// </summary>
    public partial class MantenedorCarta : UserControl
    {
        readonly CN_RS_DOCTO objeto_CN_RS_DOCTO = new CN_RS_DOCTO();
        readonly CRUDCarta ventanaCRUDCarta = new CRUDCarta();

        public CE_RS_ENTIDAD entidad = new CE_RS_ENTIDAD();

        public MantenedorCarta()
        {
            InitializeComponent();
            CargarDatosCarta();
            entidad=MenuCocina.GetInstance().entidad;
        }

        void CargarDatosCarta()
        {
            GridDatos.ItemsSource = objeto_CN_RS_DOCTO.CargarDatosCarta().DefaultView;
        }

        #region SINGLETON 
        //PATRON SINGLETON
        //1.Creamos una variable estatica de la ventana
        public static MantenedorCarta ventana;

        //2.Creamos un metodo para obtener la instancia
        public static MantenedorCarta GetInstance()
        {

            if (ventana == null)
            {
                ventana = new MantenedorCarta();
            }
            return ventana;

        }
        #endregion
        //---------------------------------------------------------------------------------------------------------------



        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            int id_carta = int.Parse(((Button)sender).CommandParameter.ToString());
            FrameAgregarCarta.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDCarta.Titulo.Text = "Consulta carta";

            ventanaCRUDCarta.BtnCrear.IsEnabled = false;
            ventanaCRUDCarta.BtnActualizar.IsEnabled = false;
            ventanaCRUDCarta.BtnEliminar.IsEnabled = false;
            DeshabilitarInput();

            ventanaCRUDCarta.Titulo.Text = "Consulta plato";
            ventanaCRUDCarta.BtnCrear.IsEnabled = false;
            ventanaCRUDCarta.BtnActualizar.IsEnabled = false;
            ventanaCRUDCarta.BtnEliminar.IsEnabled = false;
            DeshabilitarInput();
            ventanaCRUDCarta.id_carta = id_carta;
            ventanaCRUDCarta.id_entidad = entidad.CE_RSE_ID;
            ventanaCRUDCarta.GridDatos2.Columns[3].Visibility = Visibility.Hidden;
            ventanaCRUDCarta.txtCantidad3.Visibility = Visibility.Visible;
            ventanaCRUDCarta.Consultar();
            FrameAgregarCarta.Content = ventanaCRUDCarta;


        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id_carta = int.Parse(((Button)sender).CommandParameter.ToString());
            FrameAgregarCarta.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDCarta.Titulo.Text = "Eliminar carta";

            ventanaCRUDCarta.BtnCrear.IsEnabled = false;
            ventanaCRUDCarta.BtnActualizar.IsEnabled = false;
            ventanaCRUDCarta.GridDatos2.Columns[3].Visibility = Visibility.Hidden;
            ventanaCRUDCarta.txtCantidad3.Visibility = Visibility.Visible;
            ventanaCRUDCarta.id_entidad = entidad.CE_RSE_ID;
            DeshabilitarInput();

            ventanaCRUDCarta.id_carta = id_carta;
            ventanaCRUDCarta.Consultar();
            FrameAgregarCarta.Content = ventanaCRUDCarta;

        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            int id_carta = int.Parse(((Button)sender).CommandParameter.ToString());

            FrameAgregarCarta.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDCarta.Titulo.Text = "Modificar carta";
            ventanaCRUDCarta.BtnCrear.IsEnabled = false;
            ventanaCRUDCarta.BtnEliminar.IsEnabled = false;
            
            ventanaCRUDCarta.txtCantidad.Visibility = Visibility.Hidden;
            ventanaCRUDCarta.txtCantidad2.Visibility = Visibility.Hidden;
            ventanaCRUDCarta.id_entidad = entidad.CE_RSE_ID;
            ventanaCRUDCarta.id_carta = id_carta;
            ventanaCRUDCarta.Consultar();
            FrameAgregarCarta.Content = ventanaCRUDCarta;

        }
        private void DeshabilitarInput()
        {
            ventanaCRUDCarta.txtIdCarta.IsEnabled = false;
            ventanaCRUDCarta.txtFecha.IsEnabled = false;
            ventanaCRUDCarta.txtNombreSolicitante.IsEnabled = false;
            ventanaCRUDCarta.txtObservaciones.IsEnabled = false;
            ventanaCRUDCarta.cbxEstado.IsEnabled = false;
            ventanaCRUDCarta.GridDatos.IsEnabled = false;
            ventanaCRUDCarta.txtCantidad.IsEnabled = false;
            ventanaCRUDCarta.txtBuscarPlato.IsEnabled = false;
            ventanaCRUDCarta.GridDatos.IsEnabled = false;
        }



        private void BtnAgregarNuevo_Click(object sender, RoutedEventArgs e)
        {
            FrameAgregarCarta.SetValue(Panel.ZIndexProperty, 0);

            ventanaCRUDCarta.BtnEliminar.IsEnabled = false;
            ventanaCRUDCarta.BtnActualizar.IsEnabled = false;
            ventanaCRUDCarta.txtIdCarta.Visibility = Visibility.Hidden;
            ventanaCRUDCarta.lblIdCarta.Visibility = Visibility.Hidden;
            ventanaCRUDCarta.txtNombreSolicitante.Text = entidad.CE_RSE_NOMBRE + " " + entidad.CE_RSE_AP_PAT;
            ventanaCRUDCarta.id_entidad = entidad.CE_RSE_ID;
            ventanaCRUDCarta.txtFecha.Text = DateTime.Now.ToShortDateString();

            FrameAgregarCarta.Content = ventanaCRUDCarta;
            btnAgregarNuevo.IsEnabled = false;
        }
    }
}
