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
    /// Lógica de interacción para MantenedorPedidos.xaml
    /// </summary>
    public partial class MantenedorPedidos : UserControl
    {
        readonly CN_RS_DOCTO objeto_CN_RS_DOCTO = new CN_RS_DOCTO();
        readonly CN_RS_DET_DOCTO objeto_CN_RS_DET_DOCTO = new CN_RS_DET_DOCTO();
        readonly CE_RS_DET_DOCTO objeto_CE_RS_DET_DOCTO = new CE_RS_DET_DOCTO();
        readonly CN_RS_ESTADO objeto_CN_RS_ESTADO = new CN_RS_ESTADO();
        readonly CE_RS_ESTADO objeto_CE_RS_ESTADO = new CE_RS_ESTADO();


        public MantenedorPedidos()
        {
            InitializeComponent();
            CargarDatosPedidos();
            
        }

        void CargarDatosPedidos()
        {
            GridDatos.ItemsSource = objeto_CN_RS_DOCTO.CargarDatosPedidos().DefaultView;
        }

        private void BtnRetroceder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id_detalle = int.Parse(((Button)sender).CommandParameter.ToString());
                int id_estado_detalle = objeto_CN_RS_DET_DOCTO.Consultar(id_detalle).CE_RS_ESTADO_RSES_ID;
                var estadoObjeto = objeto_CN_RS_ESTADO.ObtenerRSES_DESCRIPCION(id_estado_detalle);
                string estado_string = estadoObjeto.CE_RSES_DESCRIPCION;


                if (estado_string == "En preparacion")
                {
                    int id_estado = objeto_CN_RS_ESTADO.ObtenerRSES_ID("En cola");
                    objeto_CN_RS_DET_DOCTO.ActualizarEstadoDetalleDocto(id_detalle, id_estado);
                }
                if (estado_string == "Preparado")
                {
                    int id_estado = objeto_CN_RS_ESTADO.ObtenerRSES_ID("En preparacion");
                    objeto_CN_RS_DET_DOCTO.ActualizarEstadoDetalleDocto(id_detalle, id_estado);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                CargarDatosPedidos();
            }
        }

        private void BtnAvanzar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id_detalle = int.Parse(((Button)sender).CommandParameter.ToString());
                int id_estado_detalle = objeto_CN_RS_DET_DOCTO.Consultar(id_detalle).CE_RS_ESTADO_RSES_ID;
                var estadoObjeto = objeto_CN_RS_ESTADO.ObtenerRSES_DESCRIPCION(id_estado_detalle);
                string estado_string = estadoObjeto.CE_RSES_DESCRIPCION;

                if (estado_string == "En cola")
                {
                    int id_estado = objeto_CN_RS_ESTADO.ObtenerRSES_ID("En preparacion");
                    objeto_CN_RS_DET_DOCTO.ActualizarEstadoDetalleDocto(id_detalle, id_estado);
                }
                if (estado_string == "En preparacion")
                {
                    int id_estado = objeto_CN_RS_ESTADO.ObtenerRSES_ID("Preparado");
                    objeto_CN_RS_DET_DOCTO.ActualizarEstadoDetalleDocto(id_detalle, id_estado);
                }
                if (estado_string == "Preparado")
                {
                    string message = "Confirme entrega del pedido:";
                    System.Windows.Forms.MessageBoxButtons buttons = System.Windows.Forms.MessageBoxButtons.YesNo;
                    System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show(message, null, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        int id_estado = objeto_CN_RS_ESTADO.ObtenerRSES_ID("Entregado");
                        objeto_CN_RS_DET_DOCTO.ActualizarEstadoDetalleDocto(id_detalle, id_estado);
                    }
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {
                CargarDatosPedidos();
            }
        }

        private void ActualizarEstadoPedido(int id_detalle,int id_estado)
        {
            try
            {
                objeto_CN_RS_DET_DOCTO.ActualizarEstadoDetalleDocto(id_detalle,id_estado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
