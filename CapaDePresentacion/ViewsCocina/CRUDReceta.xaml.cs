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
    /// Lógica de interacción para CRUDReceta.xaml
    /// </summary>
    public partial class CRUDReceta : Page
    {
        //--------------------------------------------------------------------

        #region VARIABLES
        readonly CE_RS_DET_PLATO objeto_CE_RS_DET_PLATO = new CE_RS_DET_PLATO();
        readonly CE_RS_PLATO objeto_CE_RS_PLATO = new CE_RS_PLATO();
        readonly CE_RS_UN_MEDIDA objeto_CE_UN_MEDIDA = new CE_RS_UN_MEDIDA();
        readonly cndet objeto_CE_RS_DET_PLATO = new CE_RS_DET_PLATO();
        readonly CE_RS_PLATO objeto_CE_RS_PLATO = new CE_RS_PLATO();
        readonly CE_RS_UN_MEDIDA objeto_CE_UN_MEDIDA = new CE_RS_UN_MEDIDA();


        public int rsm_id;
        #endregion

        //--------------------------------------------------------------------

        #region INICIALIZACION
        public CRUDMesa()
        {
            InitializeComponent();
            CargarCbxEstado();


        }
        #endregion

        //--------------------------------------------------------------------

        #region BOTON CREAR
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Crear();
                Content = new MantenedorMesas();
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
                Content = new MantenedorMesas();
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
            Content = new MantenedorMesas();
        }
        #endregion

        #region BOTON REGRESAR
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Content = new MantenedorMesas();
        }


        #endregion

        //--------------------------------------------------------------------



        #region CONSULTAR
        public void Consultar()
        {

            var x = objeto_CN_RS_MESA.Consultar(rsm_id);

            var xx = objeto_CN_RS_ESTADO.ObtenerRSES_DESCRIPCION(x.CE_RS_ESTADO_RSES_ID);
            cbxEstado.Text = xx.CE_RSES_DESCRIPCION;

            txtIdMesa.Text = x.CE_RSM_ID.ToString();
            txtDescripcion.Text = x.CE_RSM_DESCRIPCION;
            txtSillas.Text = x.CE_RSM_SILLAS.ToString();
            if (x.CE_RS_ENTIDAD_RSE_ID != 0)
            {
                txtIdEntidad.Text = x.CE_RS_ENTIDAD_RSE_ID.ToString();

            }
        }

        #endregion

        #region CARGAR CBX ESTADO
        private void CargarCbxEstado()
        {
            List<string> lista_estados = objeto_CN_RS_ESTADO.ListarRSES_DESCRIPCION();
            for (int i = 0; i < lista_estados.Count; i++)
            {
                cbxEstado.Items.Add(lista_estados[i]);
            }
        }
        #endregion

        #region CREAR
        private void Crear()
        {
            int rses_id = objeto_CN_RS_ESTADO.ObtenerRSES_ID(cbxEstado.Text);

            objeto_CE_RS_MESA.CE_RSM_DESCRIPCION = txtDescripcion.Text;
            if (txtIdEntidad.Text != "")
            {
                objeto_CE_RS_MESA.CE_RS_ENTIDAD_RSE_ID = int.Parse(txtIdEntidad.Text);
            }
            objeto_CE_RS_MESA.CE_RS_ESTADO_RSES_ID = rses_id;
            objeto_CE_RS_MESA.CE_RSM_SILLAS = int.Parse(txtSillas.Text);
            try
            {
                objeto_CN_RS_MESA.Insertar(objeto_CE_RS_MESA);
                MessageBox.Show("Creado correctamente");
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
            int rses_id = objeto_CN_RS_ESTADO.ObtenerRSES_ID(cbxEstado.Text);

            objeto_CE_RS_MESA.CE_RSM_ID = rsm_id;
            objeto_CE_RS_MESA.CE_RSM_DESCRIPCION = txtDescripcion.Text;
            if (txtIdEntidad.Text != "")
            {
                objeto_CE_RS_MESA.CE_RS_ENTIDAD_RSE_ID = int.Parse(txtIdEntidad.Text);
            }
            objeto_CE_RS_MESA.CE_RS_ESTADO_RSES_ID = rses_id;
            objeto_CE_RS_MESA.CE_RSM_SILLAS = int.Parse(txtSillas.Text);

            try
            {
                objeto_CN_RS_MESA.Actualizar(objeto_CE_RS_MESA);
                MessageBox.Show("Actualizado correctamente");
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
            objeto_CE_RS_MESA.CE_RSM_ID = rsm_id;

            try
            {
                objeto_CN_RS_MESA.Eliminar(objeto_CE_RS_MESA);
                MessageBox.Show("Eliminado correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al eliminar");
            }
        }
        #endregion
    }
}
