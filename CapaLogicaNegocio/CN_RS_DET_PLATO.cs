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
    public class CN_RS_DET_PLATO
    {
        //---------------------------------------------------------------

        #region VARIABLES
        private readonly  CD_DET_PLATO objDatos = new CD_DET_PLATO();
        private readonly CE_RS_PLATO objEntidad = new CE_RS_PLATO();
        #endregion
        //DETALLE PLATO
        //---------------------------------------------------------------

        #region CONSULTAR 
        public CE_RS_DET_PLATO Consultar(int id)
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
        public void Insertar(CE_RS_DET_PLATO det_plato)
        {

            try
            {
                objDatos.CD_INSERTAR(det_plato);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ELIMINAR RS_MESA
        public void Eliminar(CE_RS_DET_PLATO det_plato)
        {

            try
            {
                objDatos.CD_ELIMINAR(det_plato);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ACTUALIZAR 
        public void Actualizar(CE_RS_DET_PLATO det_plato)
        {
            try
            {
                objDatos.CD_ACTUALIZAR(det_plato);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        //---------------------------------------------------------------

        #region DATOS TABLA VISTA MANTENEDOR MESAS
        public DataTable CargarPlatos(int id_plato)
        {
            return objDatos.CargarDetPlato(id_plato);
        }
        #endregion
    }
}
