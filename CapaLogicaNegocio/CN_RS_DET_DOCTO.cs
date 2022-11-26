using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDAL;
using System.Data;

namespace CapaLogicaNegocio
{
    public class CN_RS_DET_DOCTO
    {
        //---------------------------------------------------------------

        #region VARIABLES
        private readonly CD_RS_DET_DOCTO objDatos = new CD_RS_DET_DOCTO();
        private readonly CE_RS_DET_DOCTO objEntidad = new CE_RS_DET_DOCTO();
        #endregion
        //DETALLE PLATO
        //---------------------------------------------------------------

       

        #region ACTUALIZAR ESTADO DETALLE CARTA
        public void ActualizarEstadoDetalleCarta(int id_detalle, int id_estado)
        {
            try
            {
                objDatos.CD_ACTUALIZAR_ESTADO_DET_CARTA(id_detalle,id_estado);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region CONSULTAR
        public CE_RS_DET_DOCTO Consultar(int id)
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


        //---------------------------------------------------------------

        #region DATOS TABLA VISTA 
        public DataTable CargarDetalleCarta(int id_docto)
        {
            return objDatos.CargarDetalleCarta(id_docto);
        }
        #endregion

        #region Obtener Ingreso y egreso detalle plato carta
        public CE_RS_DET_DOCTO ObtenerIngresoEgresoDetPlatoCarta(int id_plato, int id_carta)
        {
            try
            {
                return objDatos.ObtenerIngresoEgresoDetPlatoCarta(id_plato, id_carta);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        #endregion


    }
}

