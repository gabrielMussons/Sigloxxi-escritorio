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

namespace CapaDePresentacion.ViewsCocina
{
    /// <summary>
    /// Lógica de interacción para CRUDReceta.xaml
    /// </summary>
    public partial class CRUDCarta : Page
    {
        //--------------------------------------------------------------------

        #region VARIABLES
        readonly CE_RS_DOCTO objeto_CE_RS_DOCTO = new CE_RS_DOCTO();
        readonly CN_RS_DOCTO objeto_CN_RS_DOCTO = new CN_RS_DOCTO();
        readonly CE_RS_DET_DOCTO objeto_CE_RS_DET_DOCTO = new CE_RS_DET_DOCTO();
        readonly CN_RS_DET_DOCTO objeto_CN_RS_DET_DOCTO = new CN_RS_DET_DOCTO();
        readonly CE_RS_UN_MEDIDA objeto_CE_UN_MEDIDA = new CE_RS_UN_MEDIDA();
        readonly CN_RS_UN_MEDIDA objeto_CN_UN_MEDIDA = new CN_RS_UN_MEDIDA();
        readonly CN_RS_PLATO objeto_CN_RS_PLATO = new CN_RS_PLATO();
        readonly CE_RS_PLATO objeto_CE_RS_PLATO = new CE_RS_PLATO();
        readonly CE_RS_ESTADO objeto_CE_RS_ESTADO = new CE_RS_ESTADO();
        readonly CN_RS_ESTADO objeto_CN_RS_ESTADO = new CN_RS_ESTADO();
        readonly CE_RS_ENTIDAD objeto_CE_RS_ENTIDAD = new CE_RS_ENTIDAD();
        readonly CN_RS_ENTIDAD objeto_CN_RS_ENTIDAD = new CN_RS_ENTIDAD();
        readonly CE_RS_TIPO_DOCUMENTO objeto_CE_RS_TIPO_DOCUMENTO = new CE_RS_TIPO_DOCUMENTO();
        readonly CN_RS_TIPO_DOCUMENTO objeto_CN_RS_TIPO_DOCUMENTO = new CN_RS_TIPO_DOCUMENTO();



        Dictionary<int, int> DetalleCarta = new Dictionary<int, int>();

        public int id_carta;
        public int id_entidad;
        #endregion

        //--------------------------------------------------------------------

        #region INICIALIZACION
        public CRUDCarta()
        {
            InitializeComponent();
            CargarCbxEstado();
            CargarDatosPlatos();
            DetalleCarta.Clear();
            

        }
        #endregion

        //--------------------------------------------------------------------

        #region BOTON CREAR
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Crear();
                try
                {
                    CrearDetalle(DetalleCarta);
                }
                catch (Exception ex)
                {
                    objeto_CE_RS_DOCTO.CE_RSD_ID = objeto_CN_RS_DOCTO.ObtenerUltimoRegistro().CE_RSD_ID;
                    objeto_CN_RS_DOCTO.Eliminar(objeto_CE_RS_DOCTO);
                    throw ex;
                }
                Content = new MantenedorCarta();
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
                Content = new MantenedorCarta();
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
            Content = new MantenedorCarta();
        }
        #endregion

        #region BOTON REGRESAR
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new MantenedorCarta();
        }


        #endregion

        //--------------------------------------------------------------------

        #region CARGAR DATOS GRID
        void CargarDatosPlatos()
        {
            
            GridDatos.ItemsSource = objeto_CN_RS_PLATO.CargarPlatos(txtBuscarPlato.Text.ToString()).DefaultView;
        }
        #endregion

        #region CONSULTAR
        public void Consultar()
        {

            var carta = objeto_CN_RS_DOCTO.Consultar(id_carta);

            string estado = objeto_CN_RS_ESTADO.ObtenerRSES_DESCRIPCION(carta.CE_RS_ESTADO_RSES_ID).CE_RSES_DESCRIPCION;

            string nombre_solicitante= objeto_CN_RS_ENTIDAD.Consultar(carta.CE_RS_ENTIDAD_RSE_ID).CE_RSE_NOMBRE+" "+objeto_CN_RS_ENTIDAD.Consultar(carta.CE_RS_ENTIDAD_RSE_ID).CE_RSE_AP_PAT;

            txtIdCarta.Text =(carta.CE_RSD_ID).ToString();
            txtFecha.Text = carta.CE_RSD_FECHA_HORA.ToShortDateString();
            txtNombreSolicitante.Text = nombre_solicitante;
            txtObservaciones.Text = carta.CE_RSD_OBS.ToString();
            cbxEstado.Text = estado;
        }

        #endregion

        #region CARGAR CBX ESTADO
        private void CargarCbxEstado()
        {
            List<string> lista = objeto_CN_RS_ESTADO.ListarRSES_DESCRIPCION();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].ToUpper() == "SOLICITADO" )
                {
                    cbxEstado.Items.Add(lista[i]);
                }
                
            }
        }
        #endregion
        
        #region CREAR
        private void Crear()
        {
            try
            {
                objeto_CE_RS_DOCTO.CE_RSD_FECHA_HORA = DateTime.Parse(txtFecha.Text);
                objeto_CE_RS_DOCTO.CE_RSD_OBS = txtObservaciones.Text;
                objeto_CE_RS_DOCTO.CE_RS_ENTIDAD_RSE_ID = id_entidad;
                objeto_CE_RS_DOCTO.CE_RS_TIPO_DOCUMENTO_RSTD_ID = objeto_CN_RS_TIPO_DOCUMENTO.ObtenerRSTD_ID("Carta");
                objeto_CE_RS_DOCTO.CE_RS_ESTADO_RSES_ID = objeto_CN_RS_ESTADO.ObtenerRSES_ID(cbxEstado.Text);
                objeto_CN_RS_DOCTO.Insertar(objeto_CE_RS_DOCTO);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region CREAR DETALLE
        private void CrearDetalle(Dictionary<int, int> Detalle)
        {
            try
            {
                foreach (var plato in Detalle)
                {
                    objeto_CE_RS_DET_DOCTO.CE_RSDET_EGRESO = plato.Value;
                    objeto_CE_RS_DET_DOCTO.CE_RS_PLATO_RSPL_ID = plato.Key;
                    objeto_CE_RS_DET_DOCTO.CE_RS_TIPO_DOCUMENTO_RSTD_ID = objeto_CN_RS_TIPO_DOCUMENTO.ObtenerRSTD_ID("Carta");
                    objeto_CE_RS_DET_DOCTO.CE_RS_ESTADO_RSES_ID = objeto_CN_RS_ESTADO.ObtenerRSES_ID("Solicitado");
                    objeto_CE_RS_DET_DOCTO.CE_RS_DOCTO_RSD_ID = objeto_CN_RS_DOCTO.ObtenerUltimoRegistro().CE_RSD_ID;

                    objeto_CN_RS_DET_DOCTO.Insertar(objeto_CE_RS_DET_DOCTO);
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
                objeto_CE_RS_DOCTO.CE_RSD_ID = int.Parse(txtIdCarta.Text);
                objeto_CE_RS_DOCTO.CE_RSD_FECHA_HORA = DateTime.Parse(txtFecha.Text);
                objeto_CE_RS_DOCTO.CE_RSD_OBS = txtObservaciones.Text;
                objeto_CE_RS_DOCTO.CE_RS_ENTIDAD_RSE_ID = id_entidad;
                objeto_CE_RS_DOCTO.CE_RS_TIPO_DOCUMENTO_RSTD_ID = objeto_CN_RS_TIPO_DOCUMENTO.ObtenerRSTD_ID("Carta");
                objeto_CE_RS_DOCTO.CE_RS_ESTADO_RSES_ID = objeto_CN_RS_ESTADO.ObtenerRSES_ID(cbxEstado.Text);

                objeto_CN_RS_DOCTO.Actualizar(objeto_CE_RS_DOCTO);
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
                objeto_CE_RS_DOCTO.CE_RSD_ID = id_carta;
                objeto_CN_RS_DOCTO.Eliminar(objeto_CE_RS_DOCTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        private void BtnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            int id_plato = int.Parse(((Button)sender).CommandParameter.ToString());
            if (DetalleCarta.ContainsKey(id_plato))
            {
                DetalleCarta[id_plato] = DetalleCarta[id_plato] + 1;
                Console.WriteLine(DetalleCarta[id_plato]);
                this.ToolTip = (DetalleCarta[id_plato]).ToString();
                txtCantidadPlatos.Text = (DetalleCarta[id_plato]).ToString();

            }
            else
            {
                DetalleCarta.Add(id_plato, +1);
                Console.WriteLine(DetalleCarta[id_plato]);
                txtCantidadPlatos.Text = (DetalleCarta[id_plato]).ToString();

            }

        }

        private void BtnEliminarProducto_Click(object sender, RoutedEventArgs e)
        {
            int id_plato = int.Parse(((Button)sender).CommandParameter.ToString());
            if (DetalleCarta.ContainsKey(id_plato))
            {
                if (DetalleCarta[id_plato] == 1)
                {
                    DetalleCarta.Remove(id_plato);
                    txtCantidadPlatos.Text = "0";

                }
                else
                {
                    DetalleCarta[id_plato] = DetalleCarta[id_plato] - 1;
                    Console.WriteLine(DetalleCarta[id_plato]);
                    txtCantidadPlatos.Text = (DetalleCarta[id_plato]).ToString();
                }
            }
        }

        private void TxtBuscarProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarDatosPlatos();
        }
    }
}
