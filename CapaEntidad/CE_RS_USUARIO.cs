using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_USUARIO
    {
        private int _CE_RSU_ID;
        private string _CE_RSU_USUARIO;
        private string _CE_RSU_PASS;
        private int _CE_RS_ENTIDAD_RSE_ID;

        public int CE_RSU_ID
        {
            get => _CE_RSU_ID;
            set => _CE_RSU_ID = value;
        }

        public string CE_RSU_USUARIO
        {
            get => _CE_RSU_USUARIO;
            set => _CE_RSU_USUARIO = value;
        }

        public string CE_RSU_PASS
        {
            get => _CE_RSU_PASS;
            set => _CE_RSU_PASS = value;
        }

        public int CE_RS_ENTIDAD_RSE_ID
        {
            get => _CE_RS_ENTIDAD_RSE_ID;
            set => _CE_RS_ENTIDAD_RSE_ID = value;
        }
    }
}
