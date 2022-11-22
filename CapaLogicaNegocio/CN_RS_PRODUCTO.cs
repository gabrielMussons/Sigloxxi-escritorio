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
    public class CN_RS_PRODUCTO
    {
        #region VARIABLES
        private readonly CD_RS_PRODUCTO objDatos = new CD_RS_PRODUCTO();
        private readonly CE_RS_PRODUCTO objEntidad = new CE_RS_PRODUCTO();
        #endregion

        //---------------------------------------------------------------

        #region CONSULTAR 
        public CE_RS_PRODUCTO Consultar(int id)
        {
            return objDatos.CD_CONSULTAR(id);
        }
        #endregion

        #region INSERTAR 
        public void Insertar(CE_RS_PRODUCTO producto)
        {
            objDatos.CD_INSERTAR(producto);
        }
        #endregion

        #region ELIMINAR 
        public void Eliminar(CE_RS_PRODUCTO producto)
        {
            objDatos.CD_ELIMINAR(producto);
        }
        #endregion

        #region ACTUALIZAR 
        public void Actualizar(CE_RS_PRODUCTO producto)
        {
            objDatos.CD_ACTUALIZAR(producto);
        }
        #endregion

        //---------------------------------------------------------------

        #region DATOS TABLA VISTA MANTENEDOR PRODUCTO
        public DataTable CargarListaProducto(string texto)
        {
            try 
            {
                return objDatos.CargarListaProducto(texto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region DATOS TABLA VISTA MANTENEDOR CONTROL STOCK
        public DataTable CargarListaProductoCritico(string texto)
        {
            try
            {
                return objDatos.CargarListaProductoCritico(texto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region OBTENER 
        public int ObtenerRSP_ID(string v_rsp_descripcion)
        {
            return objDatos.ObtenerRSP_ID(v_rsp_descripcion);
        }
        #endregion
    }
}
