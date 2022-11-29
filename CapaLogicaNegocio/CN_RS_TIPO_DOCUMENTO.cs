using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDAL;

namespace CapaLogicaNegocio
{
    public class CN_RS_TIPO_DOCUMENTO
    {

        #region VARIABLES
        CD_RS_TIPO_DOCUMENTO cd_rs_tipo_documento = new CD_RS_TIPO_DOCUMENTO();
        #endregion

        #region OBTENER RSTE_ID
        public int ObtenerRSTD_ID(string rstd_descripcion)
        {
            try
            {
                return cd_rs_tipo_documento.ObtenerRSTD_ID(rstd_descripcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        #endregion

        #region OBTENER RSTD_DESCRIPCION
        public CE_RS_TIPO_DOCUMENTO ObtenerRSTD_DESCRIPCION(int rste_id)
        {
            try
            {
                return cd_rs_tipo_documento.ObtenerRSTD_DESCRIPCION(rste_id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        #endregion

        #region LISTAR RSTD_DESCRIPCION
        public List<string> ListarRSTE_DESCRIPCION()
        {
            try
            {
                return cd_rs_tipo_documento.ListarRSTD_DESCRIPCION();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
