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
using System.Threading;
using Microsoft.Win32;
using System.IO;

namespace CapaDePresentacion.ViewsCocina
{
    /// <summary>
    /// Lógica de interacción para CRUDReceta.xaml
    /// </summary>
    public partial class CRUDReceta : Page
    {
        //--------------------------------------------------------------------

        #region VARIABLES
        readonly CE_RS_DET_PLATO objeto_CE_RS_DET_PLATO = new CE_RS_DET_PLATO();
        readonly CE_RS_PLATO objeto_CE_RS_PLATO = new CE_RS_PLATO();
        readonly CE_RS_UN_MEDIDA objeto_CE_UN_MEDIDA = new CE_RS_UN_MEDIDA();
        readonly CN_RS_DET_PLATO objeto_CN_RS_DET_PLATO = new CN_RS_DET_PLATO();
        readonly CN_RS_PLATO objeto_CN_RS_PLATO = new CN_RS_PLATO();
        readonly CN_RS_UN_MEDIDA objeto_CN_UN_MEDIDA = new CN_RS_UN_MEDIDA();
        readonly CN_RS_PRODUCTO obj_CN_RS_PRODUCTO = new CN_RS_PRODUCTO();
        readonly CE_RS_PRODUCTO obj_CE_RS_PRODUCTO = new CE_RS_PRODUCTO();

        public CE_RS_USUARIO usuario = new CE_RS_USUARIO();
        public CE_RS_ENTIDAD entidad = new CE_RS_ENTIDAD();
        public CE_RS_TIPO_ENTIDAD tipo_entidad = new CE_RS_TIPO_ENTIDAD();

        Dictionary<int, int> DetalleReceta = new Dictionary<int, int>();

        public int id_plato;
        #endregion

        //--------------------------------------------------------------------

        #region INICIALIZACION
        public CRUDReceta()
        {
            InitializeComponent();
            CargarCbxUnidadMedida();
            CargarDatosProductos();
            DetalleReceta.Clear();
            
        }
        #endregion

        //--------------------------------------------------------------------

        #region BOTON CREAR
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Crear();
                CrearDetalle(DetalleReceta, txtDescripcion.Text);
                Content = new MantenedorRecetas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion

        #region BOTON ACTUALIZAR
        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Actualizar();
                Content = new MantenedorRecetas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion

        #region BOTON ELIMINAR
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Eliminar();
            Content = new MantenedorRecetas();
        }
        #endregion

        #region BOTON REGRESAR
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new MantenedorRecetas();
        }


        #endregion

        //--------------------------------------------------------------------

        #region CARGAR DATOS GRID PRODUCTO
        void CargarDatosProductos()
        {
            
            GridDatos.ItemsSource = obj_CN_RS_PRODUCTO.CargarListaProducto(txtBuscarProducto.Text.ToString()).DefaultView;
        }
        #endregion 
        #region CARGAR DATOS GRID DETALLE
        void CargarDetPlato(int id_plato)
        {
            try
            {
                GridDatos2.ItemsSource = objeto_CN_RS_DET_PLATO.CargarDetPlatos(id_plato).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        #endregion 



        #region CONSULTAR
        public void Consultar()
        {

            var plato = objeto_CN_RS_PLATO.Consultar(id_plato);

            var unidad_medida = objeto_CN_UN_MEDIDA.ObtenerRSUM_DESCRIPCION(plato.RS_UN_MEDIDA_RSUM_ID);
            cbxUnidadMedida.Text = unidad_medida.CE_RSUM_DESCRIPCION;
            txtIdPlato.Text = plato.RSPL_ID.ToString();
            txtDescripcion.Text = plato.RSPL_DESCRIPCION.ToString();
            txtObservaciones.Text = plato.RSPL_OBS.ToString();
            txtPVenta.Text = plato.RSPL_PVENTA.ToString();
            CargarDetPlato(plato.RSPL_ID);
            if (plato.CE_RSPL_IMAGEN != null)
            {
                ImageSourceConverter img = new ImageSourceConverter();
                imagenProducto.Source = (ImageSource)img.ConvertFrom(plato.CE_RSPL_IMAGEN);
            }

        }

        #endregion

        #region CARGAR CBX 
        private void CargarCbxUnidadMedida()
        {
            List<string> lista = objeto_CN_UN_MEDIDA.ListarRSUM_DESCRIPCION();
            for (int i = 0; i < lista.Count; i++)
            {
                cbxUnidadMedida.Items.Add(lista[i]);
            }
        }
        #endregion

        #region CREAR
        private void Crear()
        {
            try
            {
                objeto_CE_RS_PLATO.RSPL_DESCRIPCION = txtDescripcion.Text.ToString();
                objeto_CE_RS_PLATO.RSPL_PVENTA = int.Parse(txtPVenta.Text);
                objeto_CE_RS_PLATO.RSPL_OBS = txtObservaciones.Text.ToString();
                objeto_CE_RS_PLATO.RS_UN_MEDIDA_RSUM_ID = objeto_CN_UN_MEDIDA.ObtenerRSUM_ID(cbxUnidadMedida.Text);
                objeto_CE_RS_PLATO.CE_RSPL_IMAGEN = data_imagen;
                objeto_CN_RS_PLATO.Insertar(objeto_CE_RS_PLATO);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region CREAR DETALLE
        private void CrearDetalle(Dictionary<int,int> Detalle, string NombrePlato)
        {
            try
            {
                foreach (var producto in Detalle)
                {
                    objeto_CE_RS_DET_PLATO.RSDPL_CANTIDAD = producto.Value;
                    objeto_CE_RS_DET_PLATO.RS_PLATO_RSPL_ID = objeto_CN_RS_PLATO.ObtenerRSPL_ID(NombrePlato);
                    objeto_CE_RS_DET_PLATO.RS_PRODUCTO_RSP_ID = producto.Key;
                    objeto_CN_RS_DET_PLATO.Insertar(objeto_CE_RS_DET_PLATO);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        #endregion

        #region ACTUALIZAR
        private void Actualizar()
        {
            try
            {
                objeto_CE_RS_PLATO.RSPL_ID = id_plato;
                objeto_CE_RS_PLATO.RSPL_DESCRIPCION = txtDescripcion.Text.ToString();
                objeto_CE_RS_PLATO.RSPL_PVENTA = int.Parse(txtPVenta.Text);
                objeto_CE_RS_PLATO.RSPL_OBS = txtObservaciones.Text.ToString();
                objeto_CE_RS_PLATO.RS_UN_MEDIDA_RSUM_ID = objeto_CN_UN_MEDIDA.ObtenerRSUM_ID(cbxUnidadMedida.Text);
                objeto_CE_RS_PLATO.CE_RSPL_IMAGEN = data_imagen;
                objeto_CN_RS_PLATO.Actualizar(objeto_CE_RS_PLATO);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ELIMINAR
        private void Eliminar()
        {
            try
            {
                objeto_CE_RS_PLATO.RSPL_ID = id_plato;
                objeto_CN_RS_PLATO.Eliminar(objeto_CE_RS_PLATO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        private void BtnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            
            int id_producto = int.Parse(((Button)sender).CommandParameter.ToString());
            if (txtCantidad2.Text!="")
            {
                if (DetalleReceta.ContainsKey(id_producto))
                {
                    if (int.Parse(txtCantidad2.Text)==0)
                    {
                        DetalleReceta.Remove(id_producto);
                        txtCantidad.Text = "0";
                        txtCantidad2.Text = "";
                    }
                    else
                    {
                        if (int.Parse(txtCantidad2.Text)>=1)
                        {
                            DetalleReceta[id_producto] = int.Parse(txtCantidad2.Text);
                            txtCantidad.Text = (DetalleReceta[id_producto]).ToString();
                            txtCantidad2.Text = "";
                        }
                    }
                    
                }
                else
                {
                    DetalleReceta.Add(id_producto, int.Parse(txtCantidad2.Text));
                    txtCantidad.Text = (DetalleReceta[id_producto]).ToString();
                    txtCantidad2.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar la cantidad deseada.");
            }
        }

        private void BtnConsultarCant_Click(object sender, RoutedEventArgs e)
        {
            int id_producto = int.Parse(((Button)sender).CommandParameter.ToString());
            if (DetalleReceta.ContainsKey(id_producto))
            {
                txtCantidad.Text = (DetalleReceta[id_producto]).ToString();
            }
            else
            {
                txtCantidad.Text = "0";
            }
        }

        private void TxtBuscarProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarDatosProductos();
        }

        #region SUBIR IMAGEN
        byte[] data_imagen;
        private void SubirImagen()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                data_imagen = new byte[fs.Length];
                fs.Read(data_imagen, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                imagenProducto.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
                fs.Dispose();
            }
        }
        #endregion

        private void BtnSeleccionarImagen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SubirImagen();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
