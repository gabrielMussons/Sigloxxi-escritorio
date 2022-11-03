using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_ENTIDAD
    {
        private int _CE_RSE_ID;
        private string _CE_RSE_RUT;
        private string _CE_RSE_NOMBRE;
        private string _CE_RSE_RAZON_SOCIAL;
        private string _CE_RSE_AP_PAT;
        private string _CE_RSE_AP_MAT;
        private string _CE_RSE_TELEFONO;
        private string _CE_RSE_EMAIL;
        private string _CE_RSE_DIRECCION;
        private int _CE_RS_TIPO_ENTIDAD_RSTE_ID;
        private int _CE_RS_COMUNA_RSC_ID;
        private int _CE_RS_ESTADO_RSES_ID;
        private byte[] _CE_RSE_IMAGEN;

        public int CE_RSE_ID
        {
            get => _CE_RSE_ID;
            set => _CE_RSE_ID = value;
        }

        public string CE_RSE_RUT
        {
            get => _CE_RSE_RUT;
            set => _CE_RSE_RUT = value;
        }

        public string CE_RSE_NOMBRE
        { 
            get => _CE_RSE_NOMBRE;
            set => _CE_RSE_NOMBRE = value;
        }

        public string CE_RSE_RAZON_SOCIAL
        { 
            get => _CE_RSE_RAZON_SOCIAL;
            set => _CE_RSE_RAZON_SOCIAL = value;
        }

        public string CE_RSE_AP_PAT
        { 
            get => _CE_RSE_AP_PAT;
            set => _CE_RSE_AP_PAT = value;
        }

        public string CE_RSE_AP_MAT
        { 
            get => _CE_RSE_AP_MAT;
            set => _CE_RSE_AP_MAT = value;
        }

        public string CE_RSE_TELEFONO
        { 
            get => _CE_RSE_TELEFONO;
            set => _CE_RSE_TELEFONO = value;
        }

        public string CE_RSE_EMAIL
        { 
            get => _CE_RSE_EMAIL;
            set => _CE_RSE_EMAIL = value;
        }

        public string CE_RSE_DIRECCION
        { 
            get => _CE_RSE_DIRECCION;
            set => _CE_RSE_DIRECCION = value;
        }

        public int CE_RS_TIPO_ENTIDAD_RSTE_ID
        { 
            get => _CE_RS_TIPO_ENTIDAD_RSTE_ID;
            set => _CE_RS_TIPO_ENTIDAD_RSTE_ID = value;
        }

        public int CE_RS_COMUNA_RSC_ID
        { 
            get => _CE_RS_COMUNA_RSC_ID;
            set => _CE_RS_COMUNA_RSC_ID = value;
        }

        public int CE_RS_ESTADO_RSES_ID
        { 
            get => _CE_RS_ESTADO_RSES_ID;
            set => _CE_RS_ESTADO_RSES_ID = value;
        }

        public byte[] CE_RSE_IMAGEN
        {
            get => _CE_RSE_IMAGEN;
            set => _CE_RSE_IMAGEN = value;
        }
    }
}
