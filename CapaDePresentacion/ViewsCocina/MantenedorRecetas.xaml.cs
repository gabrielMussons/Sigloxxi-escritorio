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
    public partial class MantenedorRecetas : UserControl
    {
        readonly CN_RS_PLATO objeto_CN_RS_PLATO = new CN_RS_PLATO();
        readonly CRUDReceta ventanaCRUDReceta = new CRUDReceta();

        public MantenedorRecetas()
        {
            InitializeComponent();
            CargarDatosPlatos();
        }

        void CargarDatosPlatos()
        {
            GridDatos.ItemsSource = objeto_CN_RS_PLATO.CargarPlatos().DefaultView;
        }

        //---------------------------------------------------------------------------------------------------------------


        private void BtnAgregarNuevo_Click(object sender, RoutedEventArgs e)
        {
            FrameGestionReceta.SetValue(Panel.ZIndexProperty, 0);

            ventanaCRUDReceta.BtnEliminar.IsEnabled = false;
            ventanaCRUDReceta.BtnActualizar.IsEnabled = false;

            FrameGestionReceta.Content = ventanaCRUDReceta;
            btnAgregarNuevo.IsEnabled = false;
        }
        
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            int id_plato = int.Parse(((Button)sender).CommandParameter.ToString());
            FrameGestionReceta.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDReceta.Titulo.Text = "Consulta plato";

            ventanaCRUDReceta.BtnCrear.IsEnabled = false;
            ventanaCRUDReceta.BtnActualizar.IsEnabled = false;
            ventanaCRUDReceta.BtnEliminar.IsEnabled = false;
            //ventanaCRUDReceta.btnSeleccionarImagen.IsEnabled = false;

            DeshabilitarInput();

            ventanaCRUDReceta.id_plato = id_plato;

            ventanaCRUDReceta.Consultar();

            FrameGestionReceta.Content = ventanaCRUDReceta;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id_plato = int.Parse(((Button)sender).CommandParameter.ToString());

            FrameGestionReceta.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDReceta.Titulo.Text = "Eliminar plato";

            ventanaCRUDReceta.BtnCrear.IsEnabled = false;
            ventanaCRUDReceta.BtnActualizar.IsEnabled = false;
            //ventanaCRUDReceta.btnSeleccionarImagen.IsEnabled = false;

            DeshabilitarInput();

            ventanaCRUDReceta.id_plato = id_plato;
            ventanaCRUDReceta.Consultar();
            FrameGestionReceta.Content = ventanaCRUDReceta;

        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            int id_plato = int.Parse(((Button)sender).CommandParameter.ToString());

            FrameGestionReceta.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDReceta.Titulo.Text = "Modificar plato";

            ventanaCRUDReceta.BtnCrear.IsEnabled = false;
            ventanaCRUDReceta.BtnEliminar.IsEnabled = false;

            ventanaCRUDReceta.id_plato = id_plato;
            ventanaCRUDReceta.Consultar();
            FrameGestionReceta.Content = ventanaCRUDReceta;

        }
        private void DeshabilitarInput()
        {
            ventanaCRUDReceta.txtIdPlato.IsEnabled = false;
            ventanaCRUDReceta.txtDescripcion.IsEnabled = false;
            ventanaCRUDReceta.txtPVenta.IsEnabled = false;
            ventanaCRUDReceta.txtObservaciones.IsEnabled = false;
            ventanaCRUDReceta.cbxUnidadMedida.IsEnabled = false;
            ventanaCRUDReceta.GridDatos.IsEnabled = false;
        }

       
    }
}
