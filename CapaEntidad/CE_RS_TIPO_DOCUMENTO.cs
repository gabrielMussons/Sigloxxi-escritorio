using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_TIPO_DOCUMENTO
    {
        private int _CE_RSTD_ID;
        private string _CE_RSTD_DESCRIPCION;
        private int _CE_RSTD_FOLIO;

        public int CE_RSTD_ID { get => _CE_RSTD_ID; set => _CE_RSTD_ID = value; }
        public string CE_RSTD_DESCRIPCION { get => _CE_RSTD_DESCRIPCION; set => _CE_RSTD_DESCRIPCION = value; }
        public int CE_RSTD_FOLIO { get => _CE_RSTD_FOLIO; set => _CE_RSTD_FOLIO = value; }
    }
}
