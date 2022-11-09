using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    public class CN_RS_IMPUESTO
    {
        #region VARIABLES
        CD_RS_IMPUESTO cd_rs_impuesto = new CD_RS_IMPUESTO();
        #endregion

        #region OBTENER RSES_ID
        public int ObtenerRSI_ID(string rsi_descripcion)
        {
            return cd_rs_impuesto.ObtenerRSI_ID(rsi_descripcion);
        }
        #endregion

        #region OBTENER RSI_DESCRIPCION
        public CE_RS_IMPUESTO ObtenerRSI_DESCRIPCION(int rsi_id)
        {
            return cd_rs_impuesto.ObtenerRSI_DESCRIPCION(rsi_id);
        }
        #endregion

        #region LISTAR RSI_DESCRIPCION
        public List<string> ListarRSI_DESCRIPCION()
        {
            return cd_rs_impuesto.ListarRSI_DESCRIPCION();
        }
        #endregion
    }
}
