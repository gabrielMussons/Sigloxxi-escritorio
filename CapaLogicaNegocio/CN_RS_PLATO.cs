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
    public class CN_RS_PLATO
    {
        //---------------------------------------------------------------

        #region VARIABLES
        private readonly CD_RS_PLATO objDatos = new CD_RS_PLATO();
        private readonly CE_RS_PLATO objEntidad = new CE_RS_PLATO();
        #endregion

        //---------------------------------------------------------------

        #region CONSULTAR 
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

        #region INSERTAR 
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

        #region ELIMINAR 
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

        #region ACTUALIZAR 
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
