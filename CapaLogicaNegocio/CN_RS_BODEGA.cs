using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    public class CN_RS_BODEGA
    {
        #region VARIABLES
        CD_RS_BODEGA cd_rs_bodega = new CD_RS_BODEGA();
        #endregion

        #region OBTENER RSB_ID
        public int ObtenerRSB_ID(string descripcion)
        {
            return cd_rs_bodega.ObtenerRSB_ID(descripcion);
        }
        #endregion

        #region OBTENER RSB_DESCRIPCION
        public CE_RS_BODEGA ObtenerRSB_DESCRIPCION(int id)
        {
            return cd_rs_bodega.ObtenerRSB_DESCRIPCION(id);
        }
        #endregion

        #region LISTAR RSB_DESCRIPCION
        public List<string> ListarRSB_DESCRIPCION()
        {
            return cd_rs_bodega.ListarRSB_DESCRIPCION();
        }
        #endregion

    }
}
