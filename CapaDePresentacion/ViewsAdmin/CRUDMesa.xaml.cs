﻿using System;
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

namespace CapaDePresentacion.ViewsAdmin
{
    /// <summary>
    /// Lógica de interacción para CRUDMesa.xaml
    /// </summary>
    public partial class CRUDMesa : Page
    {
        //--------------------------------------------------------------------

        #region VARIABLES
        readonly CE_RS_MESA objeto_CE_RS_MESA = new CE_RS_MESA();
        readonly CN_RS_MESA objeto_CN_RS_MESA = new CN_RS_MESA();
        readonly CN_RS_ESTADO objeto_CN_RS_ESTADO = new CN_RS_ESTADO();

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

            Crear();
            Content = new MantenedorMesas();
        }

        #endregion

        #region BOTON ACTUALIZAR
        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
            Content = new MantenedorMesas();
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
            txtIdEntidad.Text = x.CE_RS_ENTIDAD_RSE_ID.ToString();
            

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
            int entidad = 82;

            objeto_CE_RS_MESA.CE_RSM_DESCRIPCION = txtDescripcion.Text;
            objeto_CE_RS_MESA.CE_RS_ENTIDAD_RSE_ID = entidad;
            objeto_CE_RS_MESA.CE_RS_ESTADO_RSES_ID = rses_id;
            objeto_CE_RS_MESA.CE_RSM_SILLAS = int.Parse(txtSillas.Text);


            try
            {
                objeto_CN_RS_MESA.Insertar(objeto_CE_RS_MESA);
                MessageBox.Show("Creado correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al Agregar");
            }
        }
        #endregion

        #region ACTUALIZAR
        private void Actualizar()
        {
            int rses_id = objeto_CN_RS_ESTADO.ObtenerRSES_ID(cbxEstado.Text);
            int idEntidad = 82;
            int id = 101;

            objeto_CE_RS_MESA.CE_RSM_ID = rsm_id;
            objeto_CE_RS_MESA.CE_RSM_DESCRIPCION = txtDescripcion.Text;
            objeto_CE_RS_MESA.CE_RS_ENTIDAD_RSE_ID = idEntidad;
            objeto_CE_RS_MESA.CE_RS_ESTADO_RSES_ID = rses_id;
            objeto_CE_RS_MESA.CE_RSM_SILLAS = int.Parse(txtSillas.Text);

            try
            {
                objeto_CN_RS_MESA.Actualizar(objeto_CE_RS_MESA);
                MessageBox.Show("Actualizado correctamente");
            }
            catch (Exception)
            {

                MessageBox.Show("Error al actualizar");
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
