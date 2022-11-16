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
        public DataTable CargarDatosDocto()
        {
            return objDatos.CargarDoctos();
        }
        #endregion
        
    }
}
