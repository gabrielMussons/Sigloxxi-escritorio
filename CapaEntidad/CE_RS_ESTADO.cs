using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_ESTADO
    {
        private int _CE_RSES_ID;
        private string _CE_RSES_DESCRIPCION;

        public int CE_RSES_ID
        {
            get => _CE_RSES_ID;
            set => _CE_RSES_ID = value;
        }

        public string CE_RSES_DESCRIPCION
        {
            get => _CE_RSES_DESCRIPCION;
            set => _CE_RSES_DESCRIPCION = value;
        }
    }
}
