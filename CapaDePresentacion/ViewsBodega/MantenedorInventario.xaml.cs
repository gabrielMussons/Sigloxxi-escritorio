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
    /// Lógica de interacción para MantenedorInventario.xaml
    /// </summary>
    public partial class MantenedorInventario : UserControl
    {
        readonly CN_RS_PRODUCTO objeto_CN_RS_PRODUCTO = new CN_RS_PRODUCTO();
        readonly CRUDInventario ventanaCRUDInventario = new CRUDInventario();
        readonly ReposicionStock ventanaReposicion = new ReposicionStock();

        public MantenedorInventario()
        {
            InitializeComponent();
            try
            {
                CargarListaProductos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        void CargarListaProductos()
        {
            try
            {
                GridDatos.ItemsSource = objeto_CN_RS_PRODUCTO.CargarListaProducto(txtBuscar.Text.ToString()).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        //-------------------------------------------------------------------------------------
        public void InhabilitarCamposCRUD(CRUDInventario ventana)
        {

            ventana.txtIdProducto.IsEnabled = false;
            ventana.txtDescripcion.IsEnabled = false;
            ventana.txtPCompra.IsEnabled = false;
            ventana.txtPVenta.IsEnabled = false;
            ventana.txtStockMax.IsEnabled = false;
            ventana.txtStockMin.IsEnabled = false;
            ventana.cbxBodega.IsEnabled = false;
            ventana.cbxImpuesto.IsEnabled = false;
            ventana.cbxUnidadMedida.IsEnabled = false;

        }

        private void BtnNuevoProducto_Click(object sender, RoutedEventArgs e)
        {
            FrameAgregarProducto.SetValue(Panel.ZIndexProperty, 0);

            ventanaCRUDInventario.BtnEliminar.IsEnabled = false;
            ventanaCRUDInventario.BtnActualizar.IsEnabled = false;

            FrameAgregarProducto.Content = ventanaCRUDInventario;
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            String dato = (((Button)sender).CommandParameter).ToString();
            int id_producto = int.Parse(dato);
            FrameAgregarProducto.SetValue(Panel.ZIndexProperty, 0);

            ventanaCRUDInventario.id_producto = id_producto;
            ventanaCRUDInventario.Consultar();

            FrameAgregarProducto.Content = ventanaCRUDInventario;
            ventanaCRUDInventario.Titulo.Text = "Consulta producto";

            ventanaCRUDInventario.BtnActualizar.IsEnabled = false;
            ventanaCRUDInventario.BtnEliminar.IsEnabled = false;
            ventanaCRUDInventario.BtnCrear.IsEnabled = false;

            InhabilitarCamposCRUD(ventanaCRUDInventario);

        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            String dato = (((Button)sender).CommandParameter).ToString();
            int id_producto = int.Parse(dato);
            FrameAgregarProducto.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDInventario.Titulo.Text = "Modificar producto";

            ventanaCRUDInventario.BtnCrear.IsEnabled = false;
            ventanaCRUDInventario.BtnEliminar.IsEnabled = false;

            ventanaCRUDInventario.id_producto = id_producto;
            ventanaCRUDInventario.Consultar();

            FrameAgregarProducto.Content = ventanaCRUDInventario;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            String dato = (((Button)sender).CommandParameter).ToString();
            int id_producto = int.Parse(dato);
            FrameAgregarProducto.SetValue(Panel.ZIndexProperty, 0);
            ventanaCRUDInventario.Titulo.Text = "Eliminar producto";
            ventanaCRUDInventario.BtnCrear.IsEnabled = false;
            ventanaCRUDInventario.BtnActualizar.IsEnabled = false;
            InhabilitarCamposCRUD(ventanaCRUDInventario);
            ventanaCRUDInventario.id_producto = id_producto;
            ventanaCRUDInventario.Consultar();
            FrameAgregarProducto.Content = ventanaCRUDInventario;
        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarListaProductos();
        }

        private void BtnReponer_Click(object sender, RoutedEventArgs e)
        {
            String dato = (((Button)sender).CommandParameter).ToString();
            int id_producto = int.Parse(dato);
            FrameAgregarProducto.SetValue(Panel.ZIndexProperty, 0);
            ventanaReposicion.txtIdProducto.IsEnabled = false;
            ventanaReposicion.txtStockMax.IsEnabled = false;
            ventanaReposicion.txtDescripcion.IsEnabled = false;
            ventanaReposicion.txtStock.IsEnabled = false;
            ventanaReposicion.id_producto = id_producto;
            ventanaReposicion.Consultar();

            FrameAgregarProducto.Content = ventanaReposicion;
        }

        private void BtnRetirar_Click(object sender, RoutedEventArgs e)
        {
            String dato = (((Button)sender).CommandParameter).ToString();
            int id_producto = int.Parse(dato);
            FrameAgregarProducto.SetValue(Panel.ZIndexProperty, 0);
            ventanaReposicion.txtIdProducto.IsEnabled = false;
            ventanaReposicion.txtStockMax.IsEnabled = false;
            ventanaReposicion.txtDescripcion.IsEnabled = false;
            ventanaReposicion.txtStock.IsEnabled = false;
            ventanaReposicion.id_producto = id_producto;
            ventanaReposicion.Consultar();
            ventanaReposicion.lblCantidad.Text = "Cantidad de egreso";
            ventanaReposicion.Titulo.Text = "Retiro de insumos";

            FrameAgregarProducto.Content = ventanaReposicion;
        }
    }
}

