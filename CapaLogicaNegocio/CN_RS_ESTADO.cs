using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    public class CN_RS_ESTADO
    {
        #region VARIABLES
        CD_RS_ESTADO cd_rs_estado = new CD_RS_ESTADO();
        #endregion

        #region OBTENER RSES_ID
        public int ObtenerRSES_ID(string rses_descripcion)
        {
            return cd_rs_estado.ObtenerRSES_ID(rses_descripcion);
        }
        #endregion

        #region OBTENER RSES_DESCRIPCION
        public CE_RS_ESTADO ObtenerRSES_DESCRIPCION(int rses_id)
        {
            return cd_rs_estado.ObtenerRSES_DESCRIPCION(rses_id);
        }
        #endregion

        #region LISTAR RSES_DESCRIPCION
        public List<string> ListarRSES_DESCRIPCION()
        {
            return cd_rs_estado.ListarRSES_DESCRIPCION();
        }
        #endregion
    }
}
