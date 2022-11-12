using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    public class CN_RS_DET_PLATO
    {
        //---------------------------------------------------------------

        #region VARIABLES
        private readonly  objDatos = new CD_RS_PLATO();
        private readonly CE_RS_PLATO objEntidad = new CE_RS_PLATO();
        #endregion

        //---------------------------------------------------------------

        #region CONSULTAR RS_PRODUCTO
        public CE_RS_PLATO Consultar(int id)
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

        #region INSERTAR RS_MESA
        public void Insertar(CE_RS_PLATO rs_plato)
        {

            try
            {
                objDatos.CD_INSERTAR(rs_plato);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ELIMINAR RS_MESA
        public void Eliminar(CE_RS_PLATO rs_plato)
        {

            try
            {
                objDatos.CD_ELIMINAR(rs_plato);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ACTUALIZAR RS_MESA
        public void Actualizar(CE_RS_PLATO rs_plato)
        {
            try
            {
                objDatos.CD_ACTUALIZAR(rs_plato);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        //---------------------------------------------------------------

        #region DATOS TABLA VISTA MANTENEDOR MESAS
        public DataTable CargarPlatos()
        {
            return objDatos.CargarPlatos();
        }
        #endregion
    }
}
