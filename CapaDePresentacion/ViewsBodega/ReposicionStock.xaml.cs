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
    /// Lógica de interacción para ReposicionStock.xaml
    /// </summary>
    public partial class ReposicionStock : Page
    {
        CN_RS_PRODUCTO objeto_CN_RS_PRODUCTO = new CN_RS_PRODUCTO();
        CE_RS_PRODUCTO objeto_CE_RS_PRODUCTO = new CE_RS_PRODUCTO();

        public ReposicionStock()
        {
            InitializeComponent();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new MantenedorInventario();
            MantenedorInventario ventana = new MantenedorInventario();
        }
        public int id_producto;

        #region CONSULTAR

        public void Consultar()
        {
            try
            {
                objeto_CE_RS_PRODUCTO = objeto_CN_RS_PRODUCTO.Consultar(id_producto);

               

                txtIdProducto.Text = id_producto.ToString();
                txtDescripcion.Text = objeto_CE_RS_PRODUCTO.CE_RSP_DESCRIPCION;
                txtStockMax.Text = objeto_CE_RS_PRODUCTO.CE_RSP_STOCK_MAX.ToString();
                txtStock.Text = objeto_CE_RS_PRODUCTO.CE_RSP_STOCK.ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int cantidad = int.Parse(txtCantidad.Text);
                int stock = int.Parse(txtStock.Text);
                int stockmax = int.Parse(txtStockMax.Text);

                if (lblCantidad.Text.ToString()=="Cantidad de egreso")
                {
                    if (cantidad<=stock && cantidad>0)
                    {
                        ActualizarRetiro();
                        MessageBox.Show("Stock actualizado correctamente.");
                        Content = new MantenedorInventario();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad de egreso no puede ser mayor al stock ni menor a 1.");
                    }
                    
                }
                else
                {
                    if (cantidad >= 1 && (cantidad+stock)<=stockmax)
                    {
                        ActualizarReposicion();
                        MessageBox.Show("Stock actualizado correctamente.");
                        Content = new MantenedorInventario();
                    }
                    else
                    {
                        MessageBox.Show("El total no puede superar el stock máx y la cantidad de ingreso no puede ser menor a 1.");
                    }
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void ActualizarReposicion()
        {
            try
            {

                int nuevo_stock = int.Parse(txtCantidad.Text) + int.Parse(txtStock.Text);
                objeto_CE_RS_PRODUCTO.CE_RSP_STOCK = nuevo_stock;
                //objeto_CE_RS_PRODUCTO.CE_RSP_IMAGEN = data_imagen;

                objeto_CN_RS_PRODUCTO.Actualizar(objeto_CE_RS_PRODUCTO);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void ActualizarRetiro()
        {
            try
            {

                int nuevo_stock = int.Parse(txtStock.Text)-int.Parse(txtCantidad.Text);
                if (nuevo_stock==0)
                {
                    objeto_CE_RS_PRODUCTO.CE_RSP_STOCK = 0;
                }
                else
                {
                    objeto_CE_RS_PRODUCTO.CE_RSP_STOCK = nuevo_stock;
                }
                
                //objeto_CE_RS_PRODUCTO.CE_RSP_IMAGEN = data_imagen;

                objeto_CN_RS_PRODUCTO.Actualizar(objeto_CE_RS_PRODUCTO);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void TxtIngreso_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
