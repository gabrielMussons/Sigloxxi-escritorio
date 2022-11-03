using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    public class CN_RS_TIPO_ENTIDAD
    {
        #region VARIABLES
        CD_RS_TIPO_ENTIDAD cd_rs_tipo_entidad = new CD_RS_TIPO_ENTIDAD();
        #endregion

        #region OBTENER RSTE_ID
        public int ObtenerRSTE_ID(string rste_descripcion)
        {
            return cd_rs_tipo_entidad.ObtenerRSTE_ID(rste_descripcion);
        }
        #endregion

        #region OBTENER RSTE_DESCRIPCION
        public CE_RS_TIPO_ENTIDAD ObtenerRSTE_DESCRIPCION(int rste_id)
        {
            return cd_rs_tipo_entidad.ObtenerRSTE_DESCRIPCION(rste_id);
        }
        #endregion

        #region LISTAR RSTE_DESCRIPCION
        public List<string> ListarRSTE_DESCRIPCION()
        {
            return cd_rs_tipo_entidad.ListarRSTE_DESCRIPCION();
        }
        #endregion
    }
}
