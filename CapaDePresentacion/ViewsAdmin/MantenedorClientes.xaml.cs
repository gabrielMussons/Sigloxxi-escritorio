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
            try
            {
                CargarDatosClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        void CargarDatosClientes() {
            try
            {
                GridDatos.ItemsSource = objeto_CN_RS_ENTIDAD.CargarClientes(txtBuscar.Text.ToString()).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }

        private void Button_Click_Agregar_Cliente(object sender, RoutedEventArgs e)
        {
            
            FrameAgregarCliente.SetValue(Panel.ZIndexProperty,0);

            ventanaCRUDCliente.BtnEliminar.IsEnabled = false;
            ventanaCRUDCliente.BtnActualizar.IsEnabled = false;
            ventanaCRUDCliente.BtnEliminarUsuario.IsEnabled = false;

            FrameAgregarCliente.Content = ventanaCRUDCliente;
            
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            String dato = (((Button)sender).CommandParameter).ToString();
            int idEntidad = int.Parse(dato);
            FrameAgregarCliente.SetValue(Panel.ZIndexProperty, 0);

            ventanaCRUDCliente.rse_id = idEntidad;
            ventanaCRUDCliente.Consultar();

            FrameAgregarCliente.Content = ventanaCRUDCliente;
            ventanaCRUDCliente.Titulo.Text = "Consulta";

            ventanaCRUDCliente.btnSeleccionarImagen.IsEnabled = false;
            ventanaCRUDCliente.BtnActualizar.IsEnabled = false;
            ventanaCRUDCliente.BtnEliminar.IsEnabled = false;
            ventanaCRUDCliente.BtnEliminarUsuario.IsEnabled = false;
            ventanaCRUDCliente.BtnCrear.IsEnabled = false;
            ventanaCRUDCliente.txtBtnEliminarUsuario.IsEnabled = false;

            InhabilitarCamposCRUD(ventanaCRUDCliente);
            
            
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            String ru = (((Button)sender).CommandParameter).ToString();
            int idEntidad = int.Parse(ru);
            

            FrameAgregarCliente.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDCliente.Titulo.Text = "Eliminar";

            ventanaCRUDCliente.BtnCrear.IsEnabled = false;
            ventanaCRUDCliente.BtnActualizar.IsEnabled = false;
            ventanaCRUDCliente.btnSeleccionarImagen.IsEnabled = false;

            InhabilitarCamposCRUD(ventanaCRUDCliente);

            ventanaCRUDCliente.rse_id = idEntidad;
            ventanaCRUDCliente.Consultar();
            FrameAgregarCliente.Content = ventanaCRUDCliente;
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            String ru = (((Button)sender).CommandParameter).ToString();
            int idEntidad = int.Parse(ru);
            FrameAgregarCliente.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDCliente.Titulo.Text = "Modificar";

            ventanaCRUDCliente.BtnCrear.IsEnabled = false;
            ventanaCRUDCliente.BtnEliminar.IsEnabled = false;
            ventanaCRUDCliente.BtnEliminarUsuario.IsEnabled = false;

            ventanaCRUDCliente.rse_id = idEntidad;
            ventanaCRUDCliente.Consultar();

            FrameAgregarCliente.Content = ventanaCRUDCliente;
        }

        public void InhabilitarCamposCRUD(CRUDCliente ventana) {
            
            ventana.txtRut.IsEnabled = false;
            ventana.txtNombre.IsEnabled = false;
            ventana.txtApellidoM.IsEnabled = false;
            ventana.txtApellidoP.IsEnabled = false;
            ventana.txtContrasenia.IsEnabled = false;
            ventana.txtEmail.IsEnabled = false;
            ventana.txtTelefono.IsEnabled = false;
            ventana.cbxTipoUsuario.IsEnabled = false;
            ventana.txtUsuario.IsEnabled = false;
            ventana.txtContrasenia.IsEnabled = false;
            ventana.txtDireccion.IsEnabled = false;
            ventana.cbxComuna.IsEnabled = false;
            ventana.cbxEstado.IsEnabled = false;
            ventana.txtRazonSocial.IsEnabled = false;
            
        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarDatosClientes();
        }
    }
}
