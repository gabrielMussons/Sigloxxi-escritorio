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

namespace CapaDePresentacion.ViewsAdmin
{
    /// <summary>
    /// Lógica de interacción para MantenedorMesas.xaml
    /// </summary>
    public partial class MantenedorMesas : UserControl
    {
        readonly CN_RS_MESA objeto_CN_RS_MESA = new CN_RS_MESA();
        readonly CRUDMesa ventanaCRUDMesa = new CRUDMesa();

        public MantenedorMesas()
        {
            InitializeComponent();
            CargarDatosMesas(txtBuscar.Text.ToString());
        }

        void CargarDatosMesas(string texto)
        {
            GridDatos.ItemsSource = objeto_CN_RS_MESA.CargarMesas(texto).DefaultView;
        }


        private void BtnAgregarMesa_Click(object sender, RoutedEventArgs e)
        {
            CRUDMesa ventana = new CRUDMesa();
            FrameAgregarMesa.SetValue(Panel.ZIndexProperty, 0);

            ventana.BtnEliminar.IsEnabled = false;
            ventana.BtnActualizar.IsEnabled = false;

            FrameAgregarMesa.Content = ventana;
            btnAgregarMesa.IsEnabled = false;
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            int rsm_id = int.Parse(((Button)sender).CommandParameter.ToString());
            FrameAgregarMesa.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDMesa.Titulo.Text = "Consulta mesa";

            ventanaCRUDMesa.BtnCrear.IsEnabled = false;
            ventanaCRUDMesa.BtnActualizar.IsEnabled = false;
            ventanaCRUDMesa.BtnEliminar.IsEnabled = false;
            ventanaCRUDMesa.btnSeleccionarImagen.IsEnabled = false;

            DeshabilitarInput();

            ventanaCRUDMesa.rsm_id = rsm_id;

            ventanaCRUDMesa.Consultar();

            FrameAgregarMesa.Content = ventanaCRUDMesa;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int rsm_id = int.Parse(((Button)sender).CommandParameter.ToString()); 

            FrameAgregarMesa.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDMesa.Titulo.Text = "Eliminar mesa";

            ventanaCRUDMesa.BtnCrear.IsEnabled = false;
            ventanaCRUDMesa.BtnActualizar.IsEnabled = false;
            ventanaCRUDMesa.btnSeleccionarImagen.IsEnabled = false;

            DeshabilitarInput();

            ventanaCRUDMesa.rsm_id = rsm_id;
            ventanaCRUDMesa.Consultar();
            FrameAgregarMesa.Content = ventanaCRUDMesa;

        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            int rsm_id = int.Parse(((Button)sender).CommandParameter.ToString());

            FrameAgregarMesa.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDMesa.Titulo.Text = "Modificar mesa";

            ventanaCRUDMesa.BtnCrear.IsEnabled = false;
            ventanaCRUDMesa.BtnEliminar.IsEnabled = false;
            
            ventanaCRUDMesa.rsm_id = rsm_id;
            ventanaCRUDMesa.Consultar();
            FrameAgregarMesa.Content = ventanaCRUDMesa;

        }
        private void DeshabilitarInput()
        {
            ventanaCRUDMesa.txtIdMesa.IsEnabled = false;
            ventanaCRUDMesa.txtIdEntidad.IsEnabled = false;
            ventanaCRUDMesa.txtSillas.IsEnabled = false;
            ventanaCRUDMesa.txtDescripcion.IsEnabled = false;
            ventanaCRUDMesa.cbxEstado.IsEnabled = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarDatosMesas(txtBuscar.Text.ToString());
        }
    }
}
