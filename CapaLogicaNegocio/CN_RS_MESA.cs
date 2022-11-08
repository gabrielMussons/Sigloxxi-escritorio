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
    public class CN_RS_MESA
    {
        //---------------------------------------------------------------

        #region VARIABLES
        private readonly CD_RS_MESA objDatos = new CD_RS_MESA();
        private readonly CE_RS_MESA objEntidad = new CE_RS_MESA();
        #endregion

        //---------------------------------------------------------------

        #region CONSULTAR RS_MESA
        public CE_RS_MESA Consultar(int rsm_id)
        {
            
            try
            {
                return objDatos.CD_CONSULTAR(rsm_id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region INSERTAR RS_MESA
        public void Insertar(CE_RS_MESA rs_mesa)
        {
            
            try
            {
                objDatos.CD_INSERTAR(rs_mesa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ELIMINAR RS_MESA
        public void Eliminar(CE_RS_MESA rs_mesa)
        {
            
            try
            {
                objDatos.CD_ELIMINAR_RS_MESA(rs_mesa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ACTUALIZAR RS_MESA
        public void Actualizar(CE_RS_MESA rs_mesa)
        {
            try
            {
                objDatos.CD_ACTUALIZAR(rs_mesa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        #endregion

        //---------------------------------------------------------------

        #region DATOS TABLA VISTA MANTENEDOR MESAS
        public DataTable CargarMesas()
        {
            return objDatos.CargarMesas();
        }
        #endregion

        #region ACTUALIZAR RS_MESA.RS_ENTIDAD_RSE_ID
        public void LiberarMesasIdCliente(int rse_id)
        {
            objDatos.CD_LIBERAR_MESAS_ID_CLIENTE(rse_id);
        }
        #endregion

    }
}
