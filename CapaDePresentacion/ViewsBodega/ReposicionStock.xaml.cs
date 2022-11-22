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
                int total = int.Parse(txtStock.Text.ToString()) + int.Parse(txtIngreso.Text.ToString());
                if (total <= int.Parse(txtStockMax.Text))
                {
                    if (int.Parse(txtIngreso.Text)>0)
                    {
                        Actualizar();
                        MessageBox.Show("Stock repuesto correctamente.");
                        Content = new MantenedorInventario();
                    }
                    else
                    {
                        MessageBox.Show("El ingreso debe ser mayor a 0.");
                    }
                    
                }
                else
                {
                    MessageBox.Show("La cantidad total no puede superar el stock máximo.");
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void Actualizar()
        {
            try
            {

                int nuevo_stock = int.Parse(txtIngreso.Text) + int.Parse(txtStock.Text);
                objeto_CE_RS_PRODUCTO.CE_RSP_STOCK = nuevo_stock;
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
