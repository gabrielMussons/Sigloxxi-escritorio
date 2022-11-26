using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_DET_DOCTO
    {
        private int _CE_RSDET_ID;
        private int _CE_RSDET_INGRESO;
        private int _CE_RSDET_EGRESO;
        private int _CE_RS_PRODUCTO_RSP_ID;
        private int _CE_RS_BODEGA_RSB_ID;
        private int _CE_RS_PLATO_RSPL_ID;
        private int _CE_RS_TIPO_DOCUMENTO_RSTD_ID;
        private int _CE_RS_ESTADO_RSES_ID;
        private int _CE_RS_DOCTO_RSD_ID;

        public int CE_RSDET_ID { get => _CE_RSDET_ID; set => _CE_RSDET_ID = value; }
        public int CE_RSDET_INGRESO { get => _CE_RSDET_INGRESO; set => _CE_RSDET_INGRESO = value; }
        public int CE_RSDET_EGRESO { get => _CE_RSDET_EGRESO; set => _CE_RSDET_EGRESO = value; }
        public int CE_RS_PRODUCTO_RSP_ID { get => _CE_RS_PRODUCTO_RSP_ID; set => _CE_RS_PRODUCTO_RSP_ID = value; }
        public int CE_RS_BODEGA_RSB_ID { get => _CE_RS_BODEGA_RSB_ID; set => _CE_RS_BODEGA_RSB_ID = value; }
        public int CE_RS_PLATO_RSPL_ID { get => _CE_RS_PLATO_RSPL_ID; set => _CE_RS_PLATO_RSPL_ID = value; }
        public int CE_RS_TIPO_DOCUMENTO_RSTD_ID { get => _CE_RS_TIPO_DOCUMENTO_RSTD_ID; set => _CE_RS_TIPO_DOCUMENTO_RSTD_ID = value; }
        public int CE_RS_ESTADO_RSES_ID { get => _CE_RS_ESTADO_RSES_ID; set => _CE_RS_ESTADO_RSES_ID = value; }
        public int CE_RS_DOCTO_RSD_ID { get => _CE_RS_DOCTO_RSD_ID; set => _CE_RS_DOCTO_RSD_ID = value; }
    }
}
