using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_PLATO
    {
        private int _RSPL_ID;
        private string _RSPL_DESCRIPCION;
        private int _RSPL_PVENTA;
        private string _RSPL_OBS;
        private int _RS_UN_MEDIDA_RSUM_ID;
        private byte[] _CE_RSPL_IMAGEN;

        public int RSPL_ID { get => _RSPL_ID; set => _RSPL_ID = value; }
        public string RSPL_DESCRIPCION { get => _RSPL_DESCRIPCION; set => _RSPL_DESCRIPCION = value; }
        public int RSPL_PVENTA { get => _RSPL_PVENTA; set => _RSPL_PVENTA = value; }
        public string RSPL_OBS { get => _RSPL_OBS; set => _RSPL_OBS = value; }
        public int RS_UN_MEDIDA_RSUM_ID { get => _RS_UN_MEDIDA_RSUM_ID; set => _RS_UN_MEDIDA_RSUM_ID = value; }
        public byte[] CE_RSPL_IMAGEN { get => _CE_RSPL_IMAGEN; set => _CE_RSPL_IMAGEN = value; }
    }
}
