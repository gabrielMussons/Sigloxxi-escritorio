using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_COMUNA
    {
        private int _CE_RSC_ID;
        private string _CE_RSC_DESCRIPCION;

        public int CE_RSC_ID
        {
            get => _CE_RSC_ID;
            set => _CE_RSC_ID = value;
        }
        public string CE_RSC_DESCRIPCION
        {
            get => _CE_RSC_DESCRIPCION;
            set => _CE_RSC_DESCRIPCION = value;
        }
    }
}
