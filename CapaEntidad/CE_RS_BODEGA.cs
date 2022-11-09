using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_BODEGA
    {
        private int _CE_RSB_ID;
        private string _CE_RSB_DESCRIPCION;

        public int CE_RSB_ID
        {
            get => _CE_RSB_ID;
            set => _CE_RSB_ID = value;
        }
        public string CE_RSB_DESCRIPCION
        {
            get => _CE_RSB_DESCRIPCION;
            set => _CE_RSB_DESCRIPCION = value;
        }
    }
}
