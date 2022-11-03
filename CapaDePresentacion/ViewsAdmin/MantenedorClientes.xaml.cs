using System;
using System.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Documents;
using System.Globalization;
using CapaLogicaNegocio;
using CapaEntidad;

namespace CapaDePresentacion.ViewsAdmin
{
    /// <summary>
    /// Lógica de interacción para MantenedorClientes.xaml
    /// </summary>
    public partial class MantenedorClientes : UserControl
    {
        readonly  CN_RS_ENTIDAD objeto_CN_RS_ENTIDAD = new CN_RS_ENTIDAD();
        readonly CRUDCliente ventanaCRUDCliente = new CRUDCliente();

        public MantenedorClientes()
        {
            InitializeComponent();
            CargarDatosClientes();
            
        }

        void CargarDatosClientes() {

            GridDatos.ItemsSource = objeto_CN_RS_ENTIDAD.CargarClientes().DefaultView;

        }

        private void Button_Click_Agregar_Cliente(object sender, RoutedEventArgs e)
        {
            CRUDCliente ventana = new CRUDCliente();
            FrameAgregarCliente.SetValue(Panel.ZIndexProperty,0);

            ventana.BtnEliminar.IsEnabled = false;
            ventana.BtnActualizar.IsEnabled = false;

            FrameAgregarCliente.Content = ventana;
            btnAgregarCliente.IsEnabled = false;
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            String dato = (((Button)sender).CommandParameter).ToString();
            int idEntidad = int.Parse(dato);
            FrameAgregarCliente.SetValue(Panel.ZIndexProperty, 0);

            ventanaCRUDCliente.rse_id = idEntidad;
            ventanaCRUDCliente.Consultar();

            FrameAgregarCliente.Content = ventanaCRUDCliente;
            ventanaCRUDCliente.Titulo.Text = "Consulta cliente";

            ventanaCRUDCliente.btnSeleccionarImagen.IsEnabled = false;
            ventanaCRUDCliente.BtnActualizar.IsEnabled = false;
            ventanaCRUDCliente.BtnEliminar.IsEnabled = false;
            ventanaCRUDCliente.BtnCrear.IsEnabled = false;

            InhabilitarCamposCRUD(ventanaCRUDCliente);
            
            
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            String ru = (((Button)sender).CommandParameter).ToString();
            int idEntidad = int.Parse(ru);
            CRUDCliente ventana = new CRUDCliente();
            

            FrameAgregarCliente.SetValue(Panel.ZIndexProperty, 0);
            ventana.Titulo.Text = "Eliminar cliente";

            ventana.BtnCrear.IsEnabled = false;
            ventana.BtnActualizar.IsEnabled = false;
            ventana.btnSeleccionarImagen.IsEnabled = false;

            InhabilitarCamposCRUD(ventana);

            ventana.rse_id = idEntidad;
            ventana.Consultar();
            FrameAgregarCliente.Content = ventana;
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            String ru = (((Button)sender).CommandParameter).ToString();
            int idEntidad = int.Parse(ru);
            CRUDCliente ventana = new CRUDCliente();
            FrameAgregarCliente.SetValue(Panel.ZIndexProperty, 0);
            ventana.Titulo.Text = "Modificar cliente";

            ventana.BtnCrear.IsEnabled = false;
            ventana.BtnEliminar.IsEnabled = false;

            ventana.rse_id = idEntidad;
            ventana.Consultar();

            FrameAgregarCliente.Content = ventana;
        }

        public void InhabilitarCamposCRUD(CRUDCliente ventana) {
            
            ventana.txtRut.IsEnabled = false;
            ventana.txtNombre.IsEnabled = false;
            ventana.txtApellidoM.IsEnabled = false;
            ventana.txtApellidoP.IsEnabled = false;
            ventana.txtContrasenia.IsEnabled = false;
            ventana.txtContrasenia2.IsEnabled = false;
            ventana.txtEmail.IsEnabled = false;
            ventana.txtTelefono.IsEnabled = false;
            ventana.cbxTipoUsuario.IsEnabled = false;
        }
    }
}
