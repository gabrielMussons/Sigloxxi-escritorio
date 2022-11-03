using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_MESA
    {
        private int _CE_RSM_ID;
        private string _CE_RSM_DESCRIPCION;
        private int _CE_RS_ENTIDAD_RSE_ID;
        private int _CE_RS_ESTADO_RSES_ID;
        private int _CE_RSM_SILLAS;


        public int CE_RSM_ID
        {
            get => _CE_RSM_ID;
            set => _CE_RSM_ID = value;
        }

        public string CE_RSM_DESCRIPCION
        {
            get => _CE_RSM_DESCRIPCION;
            set => _CE_RSM_DESCRIPCION = value;
        }

        public int CE_RS_ENTIDAD_RSE_ID
        {
            get => _CE_RS_ENTIDAD_RSE_ID;
            set => _CE_RS_ENTIDAD_RSE_ID = value;
        }

        public int CE_RS_ESTADO_RSES_ID
        {
            get => _CE_RS_ESTADO_RSES_ID;
            set => _CE_RS_ESTADO_RSES_ID = value;
        }

        public int CE_RSM_SILLAS
        {
            get => _CE_RSM_SILLAS;
            set => _CE_RSM_SILLAS = value;
        }

        
        #region METODOS RS_MESA
        
        #endregion


    }
}
