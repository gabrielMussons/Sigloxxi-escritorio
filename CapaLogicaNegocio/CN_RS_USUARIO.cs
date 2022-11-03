using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaEntidad;
namespace CapaLogicaNegocio
{
    public class CN_RS_USUARIO
    {
        //---------------------------------------------------------------

        #region VARIABLES
        private readonly CD_RS_USUARIO objDAL = new CD_RS_USUARIO();
        private readonly CE_RS_USUARIO objEntidad = new CE_RS_USUARIO();
        #endregion

        //---------------------------------------------------------------

        #region CONSULTAR RS_USUARIO
        public CE_RS_USUARIO Consultar(int rs_entidad_rse_id)
        {
            return objDAL.CD_CONSULTAR(rs_entidad_rse_id);
        }
        #endregion

        #region INSERTAR RS_USUARIO
        public void Insertar(CE_RS_USUARIO rs_usuario)
        {
            objDAL.CD_INSERTAR(rs_usuario);
        }
        #endregion

        #region ELIMINAR RS_USUARIO
        public void Eliminar(CE_RS_USUARIO rs_usuario)
        {
            objDAL.CD_ELIMINAR(rs_usuario);
        }
        #endregion

        #region ACTUALIZAR RS_USUARIO
        public void Actualizar(CE_RS_USUARIO rs_usuario)
        {
            objDAL.CD_ACTUALIZAR(rs_usuario);
        }
        #endregion

        //---------------------------------------------------------------
    }
}
