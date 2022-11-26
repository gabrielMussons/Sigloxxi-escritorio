using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    public class CN_RS_DOCTO
    {
        //---------------------------------------------------------------

        #region VARIABLES
        private readonly CD_RS_DOCTO objDatos = new CD_RS_DOCTO();
        private readonly CE_RS_DOCTO objEntidad = new CE_RS_DOCTO();
        #endregion

        //---------------------------------------------------------------

        #region CONSULTAR 
        public CE_RS_DOCTO Consultar(int id)
        {

            try
            {
                return objDatos.CD_CONSULTAR(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region INSERTAR 
        public void Insertar(CE_RS_DOCTO rs_docto)
        {

            try
            {
                objDatos.CD_INSERTAR(rs_docto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ELIMINAR 
        public void Eliminar(CE_RS_DOCTO rs_docto)
        {

            try
            {
                objDatos.CD_ELIMINAR(rs_docto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ACTUALIZAR 
        public void Actualizar(CE_RS_DOCTO rs_docto)
        {
            try
            {
                objDatos.CD_ACTUALIZAR(rs_docto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        //---------------------------------------------------------------

        #region DATOS TABLA 
        public DataTable CargarDatosPedidos()
        {
            return objDatos.CargarPedidos();
        }
        #endregion
        #region DATOS TABLA2 
        public DataTable CargarDatosCarta()
        {
            return objDatos.CargarCarta();
        }
        #endregion
        #region ACTUALIZAR ESTADO DETALLE PEDIDO
        public void ActualizarEstadoDetPedido(int id_detalle)
        {
            try
            {
                objDatos.CD_ACTUALIZAR_ESTADO_DET_PED(id_detalle);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region RETRASAR ESTADO DETALLE PEDIDO
        public void RetrasarEstadoDetPedido(int id_detalle)
        {
            try
            {
                objDatos.CD_RETRASAR_ESTADO_DET_PED(id_detalle);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
