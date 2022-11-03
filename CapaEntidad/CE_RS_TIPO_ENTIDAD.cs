using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_TIPO_ENTIDAD
    {
        private int _CE_RSTE_ID;
        private string _CE_RSTE_DESCRIPCION;

        public int CE_RSTE_ID
        {
            get => _CE_RSTE_ID;
            set => _CE_RSTE_ID = value;
        }

        public string CE_RSTE_DESCRIPCION
        {
            get => _CE_RSTE_DESCRIPCION;
            set => _CE_RSTE_DESCRIPCION = value;
        }
    }
}
