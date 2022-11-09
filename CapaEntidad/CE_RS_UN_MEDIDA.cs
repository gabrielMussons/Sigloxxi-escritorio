using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_UN_MEDIDA
    {
        private int _CE_RSUM_ID;
        private string _CE_RSUM_DESCRIPCION;

        public int CE_RSUM_ID
        {
            get => _CE_RSUM_ID;
            set => _CE_RSUM_ID = value;
        }
        public string CE_RSUM_DESCRIPCION
        {
            get => _CE_RSUM_DESCRIPCION;
            set => _CE_RSUM_DESCRIPCION = value;
        }
    }
}
