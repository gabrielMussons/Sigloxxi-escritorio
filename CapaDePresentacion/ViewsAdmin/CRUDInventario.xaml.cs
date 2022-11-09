using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System;
using CapaLogicaNegocio;
using CapaEntidad;

namespace CapaDePresentacion.ViewsAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDInventario.xaml
    /// </summary>
    public partial class CRUDInventario : Page
    {
        #region VARIABLES
        readonly CE_RS_BODEGA objeto_CE_RS_BODEGA = new CE_RS_BODEGA();
        readonly CE_RS_IMPUESTO objeto_CE_RS_IMPUESTO = new CE_RS_IMPUESTO();
        readonly CE_RS_UN_MEDIDA objeto_CE_RS_UN_MEDIDA = new CE_RS_UN_MEDIDA();
        readonly CE_RS_PRODUCTO objeto_CE_RS_PRODUCTO = new CE_RS_PRODUCTO();
        readonly CN_RS_BODEGA objeto_CN_RS_BODEGA = new CN_RS_BODEGA();
        readonly CN_RS_IMPUESTO objeto_CN_RS_IMPUESTO = new CN_RS_IMPUESTO();
        readonly CN_RS_UN_MEDIDA objeto_CN_RS_UN_MEDIDA = new CN_RS_UN_MEDIDA();
        readonly CN_RS_PRODUCTO objeto_CN_RS_PRODUCTO = new CN_RS_PRODUCTO();


        byte[] data_imagen; // VARIABLE DE TIPO BYTE QUE CONTIENE EL FLUJO BINARIO DE LA IMAGEN SELECCIONADA POR EL USUARIO.

        public int id_producto;
        #endregion

        public CRUDInventario()
        {
            InitializeComponent();
            CargarCbxBodega();
            CargarCbxImpuesto();
            CargarCbxUnidadMedida();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new MantenedorInventario();
            MantenedorInventario ventana = new MantenedorInventario();
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Crear();
                MessageBox.Show("Registrado correctamente");
                Content = new MantenedorInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Actualizar();
                MessageBox.Show("Actualizado correctamente");
                Content = new MantenedorInventario();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Eliminar();
                
                Content = new MantenedorInventario();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

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
        //---------------------------------------------------------------------------------------
        #region SUBIR IMAGEN
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
                //imagenProducto.SetValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
                fs.Dispose();
            }
        }
        #endregion

        #region CONSULTAR
        public void Consultar()
        {
            try
            {
                var producto = objeto_CN_RS_PRODUCTO.Consultar(id_producto);


                var bodega = objeto_CN_RS_BODEGA.ObtenerRSB_DESCRIPCION(producto.CE_RS_BODEGA_RSB_ID);
                var un_medida = objeto_CN_RS_UN_MEDIDA.ObtenerRSUM_DESCRIPCION(producto.CE_RS_UN_MEDIDA_RSUM_ID);
                var impuesto = objeto_CN_RS_IMPUESTO.ObtenerRSI_DESCRIPCION(producto.CE_RS_IMPUESTO_RSI_ID);

                cbxBodega.Text = bodega.CE_RSB_DESCRIPCION;
                cbxImpuesto.Text = impuesto.CE_RSI_DESCRIPCION;
                cbxUnidadMedida.Text = un_medida.CE_RSUM_DESCRIPCION;

                txtIdProducto.Text = id_producto.ToString();
                txtDescripcion.Text=producto.CE_RSP_DESCRIPCION;
                txtPCompra.Text= producto.CE_RSP_PCOMPRA.ToString();
                txtPVenta.Text=producto.RSP_PVENTA.ToString();
                txtStockMax.Text=producto.CE_RSP_STOCK_MIN.ToString();
                txtStockMin.Text=producto.CE_RSP_STOCK_MAX.ToString();
               
                /*if (producto.IMAGEN != null)
                {
                    ImageSourceConverter img = new ImageSourceConverter();
                    im.Source = (ImageSource)img.ConvertFrom(x.CE_RSE_IMAGEN);
                }*/
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            
            
        }
        #endregion

        #region CARGAR CBX BODEGA
        private void CargarCbxBodega()
        {
            List<string> lista = objeto_CN_RS_BODEGA.ListarRSB_DESCRIPCION();
            for (int i = 0; i < lista.Count; i++)
            {
                cbxBodega.Items.Add(lista[i]);
            }
        }
        #endregion

        #region CARGAR CBX IMPUESTO
        private void CargarCbxImpuesto()
        {
            List<string> lista = objeto_CN_RS_IMPUESTO.ListarRSI_DESCRIPCION();
            for (int i = 0; i < lista.Count; i++)
            {
                cbxImpuesto.Items.Add(lista[i]);
            }
        }
        #endregion

        #region CARGAR CBX UNIDAD DE MEDIDA
        private void CargarCbxUnidadMedida()
        {
            List<string> lista = objeto_CN_RS_UN_MEDIDA.ListarRSUM_DESCRIPCION();
            for (int i = 0; i < lista.Count; i++)
            {
                cbxUnidadMedida.Items.Add(lista[i]);
            }
        }
        #endregion

        //------------------------------------------------------------------------------------------
        #region CREAR
        private void Crear()
        {
            try
            {
                int bodega = objeto_CN_RS_BODEGA.ObtenerRSB_ID(cbxBodega.Text);
                int impuesto= objeto_CN_RS_IMPUESTO.ObtenerRSI_ID(cbxImpuesto.Text);
                int unidad_medida= objeto_CN_RS_UN_MEDIDA.ObtenerRSUM_ID(cbxUnidadMedida.Text);

                objeto_CE_RS_PRODUCTO.CE_RSP_DESCRIPCION = txtDescripcion.Text;
                objeto_CE_RS_PRODUCTO.CE_RSP_PCOMPRA = int.Parse(txtPCompra.Text);
                objeto_CE_RS_PRODUCTO.CE_RSP_STOCK_MAX = int.Parse(txtStockMax.Text);
                objeto_CE_RS_PRODUCTO.CE_RSP_STOCK_MIN = int.Parse(txtStockMin.Text);
                objeto_CE_RS_PRODUCTO.RSP_PVENTA = int.Parse(txtPVenta.Text);
                objeto_CE_RS_PRODUCTO.CE_RS_BODEGA_RSB_ID = bodega;
                objeto_CE_RS_PRODUCTO.CE_RS_IMPUESTO_RSI_ID = impuesto;
                objeto_CE_RS_PRODUCTO.CE_RS_UN_MEDIDA_RSUM_ID = unidad_medida;
                //objeto_CE_RS_PRODUCTO.CE_RSP_IMAGEN = data_imagen;

                objeto_CN_RS_PRODUCTO.Insertar(objeto_CE_RS_PRODUCTO);
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

                int bodega = objeto_CN_RS_BODEGA.ObtenerRSB_ID(cbxBodega.Text);
                int impuesto = objeto_CN_RS_IMPUESTO.ObtenerRSI_ID(cbxImpuesto.Text);
                int unidad_medida = objeto_CN_RS_UN_MEDIDA.ObtenerRSUM_ID(cbxUnidadMedida.Text);

                objeto_CE_RS_PRODUCTO.CE_RSP_ID = id_producto;
                objeto_CE_RS_PRODUCTO.CE_RSP_DESCRIPCION = txtDescripcion.Text;
                objeto_CE_RS_PRODUCTO.CE_RSP_PCOMPRA = int.Parse(txtPCompra.Text);
                objeto_CE_RS_PRODUCTO.CE_RSP_STOCK_MAX = int.Parse(txtStockMax.Text);
                objeto_CE_RS_PRODUCTO.CE_RSP_STOCK_MIN = int.Parse(txtStockMin.Text);
                objeto_CE_RS_PRODUCTO.RSP_PVENTA = int.Parse(txtPVenta.Text);
                objeto_CE_RS_PRODUCTO.CE_RS_BODEGA_RSB_ID = bodega;
                objeto_CE_RS_PRODUCTO.CE_RS_IMPUESTO_RSI_ID = impuesto;
                objeto_CE_RS_PRODUCTO.CE_RS_UN_MEDIDA_RSUM_ID = unidad_medida;
                //objeto_CE_RS_PRODUCTO.CE_RSP_IMAGEN = data_imagen;

                objeto_CN_RS_PRODUCTO.Actualizar(objeto_CE_RS_PRODUCTO);

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
                string message = "Esta apunto de eliminar un producto." + Environment.NewLine + " Desea seguir ?";
                System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.YesNo;
                System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show(message, null, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    objeto_CE_RS_PRODUCTO.CE_RSP_ID = id_producto;
                    objeto_CN_RS_PRODUCTO.Eliminar(objeto_CE_RS_PRODUCTO);
                    
                }
                else
                {
                    Content = new MantenedorInventario();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
