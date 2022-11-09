using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDAL;

namespace CapaLogicaNegocio
{
    public class CN_RS_UN_MEDIDA
    {
        #region VARIABLES
        CD_RS_UN_MEDIDA cd_rs_un_medida = new CD_RS_UN_MEDIDA();
        #endregion

        #region OBTENER RSUM_ID
        public int ObtenerRSUM_ID(string descripcion)
        {
            return cd_rs_un_medida.ObtenerRSUM_ID(descripcion);
        }
        #endregion

        #region OBTENER RSI_DESCRIPCION
        public CE_RS_UN_MEDIDA ObtenerRSUM_DESCRIPCION(int id)
        {
            return cd_rs_un_medida.ObtenerRSUM_DESCRIPCION(id);
        }
        #endregion

        #region LISTAR RSUM_DESCRIPCION
        public List<string> ListarRSUM_DESCRIPCION()
        {
            return cd_rs_un_medida.ListarRSUM_DESCRIPCION();
        }
        #endregion
    }
}
