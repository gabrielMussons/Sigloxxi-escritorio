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
            return objDatos.CD_CONSULTAR(rsm_id);
        }
        #endregion

        #region INSERTAR RS_MESA
        public void Insertar(CE_RS_MESA rs_mesa)
        {
            objDatos.CD_INSERTAR(rs_mesa);
        }
        #endregion

        #region ELIMINAR RS_MESA
        public void Eliminar(CE_RS_MESA rs_mesa)
        {
            objDatos.CD_ELIMINAR_RS_MESA(rs_mesa);
        }
        #endregion

        #region ACTUALIZAR RS_MESA
        public void Actualizar(CE_RS_MESA rs_mesa)
        {
            objDatos.CD_ACTUALIZAR(rs_mesa);
        }
        #endregion

        //---------------------------------------------------------------

        #region DATOS TABLA VISTA MANTENEDOR MESAS
        public DataTable CargarMesas()
        {
            return objDatos.CargarMesas();
        }
        #endregion

    }
}
