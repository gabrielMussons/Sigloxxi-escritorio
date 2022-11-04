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
    public class CN_RS_ENTIDAD
    {
        #region VARIABLES
        private readonly CD_RS_ENTIDAD objDatos = new CD_RS_ENTIDAD();
        private readonly CE_RS_ENTIDAD objEntidad = new CE_RS_ENTIDAD();
        #endregion

        //---------------------------------------------------------------

        #region CONSULTAR RS_MESA
        public CE_RS_ENTIDAD Consultar(int rse_id)
        {
            return objDatos.CD_CONSULTAR(rse_id);
        }
        #endregion

        #region INSERTAR RS_MESA
        public void Insertar(CE_RS_ENTIDAD rs_entidad)
        {
            objDatos.CD_INSERTAR(rs_entidad);
        }
        #endregion

        #region ELIMINAR RS_MESA
        public void Eliminar(CE_RS_ENTIDAD rs_entidad)
        {
            objDatos.CD_ELIMINAR(rs_entidad);
        }
        #endregion

        #region ACTUALIZAR RS_MESA
        public void Actualizar(CE_RS_ENTIDAD rs_entidad)
        {
            objDatos.CD_ACTUALIZAR(rs_entidad);
        }
        #endregion

        //---------------------------------------------------------------

        #region DATOS TABLA VISTA MANTENEDOR CLIENTES
        public DataTable CargarClientes()
        {
            try
            {
                return objDatos.CargarEntidad();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region OBTENER RSE_ID
        public int ObtenerRSE_ID(string v_rse_rut)
        {
            return objDatos.ObtenerRSE_ID(v_rse_rut);
        }
        #endregion
    }
}
