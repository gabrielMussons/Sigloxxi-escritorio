using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_IMPUESTO
    {
        private int _CE_RSI_ID;
        private string _CE_RSI_DESCRIPCION;
        private int _CE_RSI_PORCENTAJE;

        public int CE_RSI_ID
        {
            get => _CE_RSI_ID;
            set => _CE_RSI_ID = value;
        }
        public string CE_RSI_DESCRIPCION 
        { 
            get => _CE_RSI_DESCRIPCION; 
            set => _CE_RSI_DESCRIPCION = value; 
        }
        public int CE_RSI_PORCENTAJE 
        { 
            get => _CE_RSI_PORCENTAJE; 
            set => _CE_RSI_PORCENTAJE = value; 
        }
    }
}
