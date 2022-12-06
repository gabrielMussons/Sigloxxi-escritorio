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

        #region CARGAR DATOS GRID DETALLE CARTA
        void CargarDetCarta(int id_carta)
        {
            try
            {
                GridDatos2.ItemsSource = objeto_CN_RS_DET_DOCTO.CargarDetalleCarta(id_carta).DefaultView;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region CARGAR DATOS GRID
        void CargarDatosPlatos()
        {
            GridDatos.ItemsSource = objeto_CN_RS_PLATO.CargarPlatos(txtBuscarPlato.Text.ToString()).DefaultView;
        }
        #endregion
        //--------------------------------------------------------------------

        #region BOTON CREAR
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Crear();
                CrearDetalle(DetalleCarta);
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
                if (DetalleCarta.Count != 0)
                {
                    CrearDetalle(DetalleCarta);
                    Actualizar();
                    MessageBox.Show("Carta actualizada,platos nuevos agregados.");
                    CargarDetCarta(id_carta);
                    DetalleCarta.Clear();
                    ControlesModoDet();

                }
                else
                {
                    Actualizar();
                    MessageBox.Show("Carta actualizada.");
                    Content = new MantenedorCarta();
                }
            }
            catch (Exception ex)
            {
                Content = new MantenedorCarta();
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
            CargarDetCarta(carta.CE_RSD_ID);
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

        #region CONSULTAR DETALLE CARTA
        public bool ExistePlatoEnDetalleCarta(int id_carta, int id_plato)
        {

            try
            {
                var det = objeto_CN_RS_DET_DOCTO.ConsultarPlatoDetCarta(id_carta, id_plato);
                return true;
            }
            catch (Exception)
            {
                return false;

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
                    objeto_CE_RS_DET_DOCTO.CE_RS_DOCTO_RSD_ID = id_carta;

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


        //------------------ELEMENTOS--GRIDS---------------------------------------------------------


       

        #region BTN GRID AGREGAR PRODUCTO
        private void BtnAgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            if (txtCantidad2.Text != "")
            {
                if (int.TryParse(txtCantidad2.Text, out int cantidad))
                {
                    int id_plato = int.Parse(((Button)sender).CommandParameter.ToString());
                    if (ExistePlatoEnDetalleCarta(id_carta, id_plato) == false)
                    {
                        if (DetalleCarta.ContainsKey(id_plato))
                        {
                            if (cantidad <= 0)
                            {
                                DetalleCarta.Remove(id_plato);
                                txtCantidad.Text = "0";
                                txtCantidad2.Text = "";
                            }
                            else
                            {
                                DetalleCarta[id_plato] = cantidad;
                                txtCantidad.Text = (DetalleCarta[id_plato]).ToString();
                                txtCantidad2.Text = "";
                            }

                        }
                        else
                        {
                            if (cantidad <= 0)
                            {
                                txtCantidad.Text = "0";
                                txtCantidad2.Text = "";
                            }
                            else
                            {
                                DetalleCarta.Add(id_plato, cantidad);
                                txtCantidad.Text = (DetalleCarta[id_plato]).ToString();
                                txtCantidad2.Text = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Producto ya existe en la receta.");
                    }
                }
                else
                {
                    MessageBox.Show("Solo puedes ingresar numeros enteros y decimales , estos deben separarse con una coma. Ej:(2,25)");
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar la cantidad deseada.");
            }
        }

        #endregion

        #region BTN GRID CONSULTAR CANT PRODUCTO
        private void BtnConsultarCant_Click(object sender, RoutedEventArgs e)
        {
            int id_plato = int.Parse(((Button)sender).CommandParameter.ToString());
            if (DetalleCarta.ContainsKey(id_plato))
            {
                txtCantidad.Text = (DetalleCarta[id_plato]).ToString();
            }
            else
            {
                txtCantidad.Text = "0";
            }
        }
        #endregion

        #region BTN GRID MODIFICAR DETALLE PLATO
        private void BtnModificarDet_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (txtCantidad3.Text != "")
                {
                    int id_det = int.Parse(((Button)sender).CommandParameter.ToString());
                    if ((txtCantidad3.Text).Contains(".") == false && int.TryParse(txtCantidad3.Text, out int cantidad) == true)
                    {
                        if (cantidad > 0)
                        {
                            var det = objeto_CN_RS_DET_DOCTO.Consultar(id_det);
                            det.CE_RSDET_EGRESO = cantidad;
                            objeto_CN_RS_DET_DOCTO.Actualizar(det);
                            CargarDetCarta(id_carta);
                            txtCantidad3.Text = "";
                            MessageBox.Show("Detalle modificado.");
                        }
                        else
                        {
                            MessageBox.Show("El valor debe ser mayor a 0, si desea puede eliminar este producto de la lista.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Solo puede ingresar numeros enteros.");
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar un valor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region BTN GRID ELIMINAR DETALLE PLATO
        private void BtnEliminarDet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id_det = int.Parse(((Button)sender).CommandParameter.ToString());
                objeto_CE_RS_DET_DOCTO.CE_RSDET_ID = id_det;
                objeto_CN_RS_DET_DOCTO.Eliminar(objeto_CE_RS_DET_DOCTO);
                MessageBox.Show("Plato eliminado de la carta.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Content = new MantenedorRecetas();
            }
            finally
            {
                CargarDetCarta(id_carta);
            }
        }
        #endregion




        private void TxtBuscarProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarDatosPlatos();
        }



        private void BtnAgregarNuevos_Click(object sender, RoutedEventArgs e)
        {
            ControlesModoPlatos();
        }


        private void ControlesModoDet()
        {
            BtnAgregarNuevos.Visibility = Visibility.Visible;
            BtnAgregarNuevos.IsEnabled = true;
            txtBuscarPlato.IsEnabled = false;
            txtBuscarPlato.Visibility = Visibility.Hidden;
            txtCantidad.IsEnabled = false;
            txtCantidad.Visibility = Visibility.Hidden;
            txtCantidad2.IsEnabled = false;
            txtCantidad2.Visibility = Visibility.Hidden;
            GridDatos.IsEnabled = false;
            GridDatos2.IsEnabled = true;
            txtCantidad3.IsEnabled = true;
            txtCantidad3.Visibility = Visibility.Visible;
            txtCantidad.Text = "";
            txtCantidad2.Text = "";
        }

        private void ControlesModoPlatos()
        {
            DetalleCarta.Clear();
            txtCantidad3.IsEnabled = false;
            txtCantidad3.Visibility = Visibility.Hidden;
            BtnAgregarNuevos.Visibility = Visibility.Hidden;
            BtnAgregarNuevos.IsEnabled = false;
            txtBuscarPlato.IsEnabled = true;
            txtBuscarPlato.Visibility = Visibility.Visible;
            txtCantidad.IsEnabled = true;
            txtCantidad.Visibility = Visibility.Visible;
            txtCantidad2.IsEnabled = true;
            txtCantidad2.Visibility = Visibility.Visible;
            GridDatos.IsEnabled = true;
            GridDatos2.IsEnabled = false;
            txtCantidad3.Text = "";
        }

    }
}
