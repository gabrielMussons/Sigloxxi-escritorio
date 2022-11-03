using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    public class CN_RS_COMUNA
    {
        #region VARIABLES
        CD_RS_COMUNA cd_rs_comuna = new CD_RS_COMUNA();
        #endregion

        #region OBTENER RSC_ID
        public int ObtenerRSC_ID(string rsc_descripcion)
        {
            return cd_rs_comuna.ObtenerRSC_ID(rsc_descripcion);
        }
        #endregion

        #region OBTENER RSC_DESCRIPCION
        public CE_RS_COMUNA ObtenerRSC_DESCRIPCION(int rsc_id)
        {
            return cd_rs_comuna.ObtenerRSC_DESCRIPCION(rsc_id);
        }
        #endregion

        #region LISTAR RSC_DESCRIPCION
        public List<string> ListarRSC_DESCRIPCION()
        {
            return cd_rs_comuna.ListarRSTE_DESCRIPCION();
        }
        #endregion

    }
}
