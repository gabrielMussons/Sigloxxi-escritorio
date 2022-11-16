using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_DOCTO
    {
        private int _CE_RSD_ID;
        private int _CE_RSD_DSCTO;
        private DateTime _CE_RSD_FECHA_HORA;
        private DateTime _CE_RSD_HORA_ENTREGA;
        private int _CE_RSD_PROPINA;
        private int _CE_RSD_TOTAL;
        private string _CE_RSD_OBS;
        private int _CE_RS_TIPO_DOCUMENTO_RSTD_ID;
        private int _CE_RS_DET_DOCTO_RSDET_ID;
        private int _CE_RS_ENTIDAD_RSE_ID;
        private int _CE_RS_MESA_RSM_ID;
        private int _CE_RS_ESTADO_RSES_ID;

        public int CE_RSD_ID { get => _CE_RSD_ID; set => _CE_RSD_ID = value; }
        public int CE_RSD_DSCTO { get => _CE_RSD_DSCTO; set => _CE_RSD_DSCTO = value; }
        public DateTime CE_RSD_FECHA_HORA { get => _CE_RSD_FECHA_HORA; set => _CE_RSD_FECHA_HORA = value; }
        public DateTime CE_RSD_HORA_ENTREGA { get => _CE_RSD_HORA_ENTREGA; set => _CE_RSD_HORA_ENTREGA = value; }
        public int CE_RSD_PROPINA { get => _CE_RSD_PROPINA; set => _CE_RSD_PROPINA = value; }
        public int CE_RSD_TOTAL { get => _CE_RSD_TOTAL; set => _CE_RSD_TOTAL = value; }
        public string CE_RSD_OBS { get => _CE_RSD_OBS; set => _CE_RSD_OBS = value; }
        public int CE_RS_TIPO_DOCUMENTO_RSTD_ID { get => _CE_RS_TIPO_DOCUMENTO_RSTD_ID; set => _CE_RS_TIPO_DOCUMENTO_RSTD_ID = value; }
        public int CE_RS_DET_DOCTO_RSDET_ID { get => _CE_RS_DET_DOCTO_RSDET_ID; set => _CE_RS_DET_DOCTO_RSDET_ID = value; }
        public int CE_RS_ENTIDAD_RSE_ID { get => _CE_RS_ENTIDAD_RSE_ID; set => _CE_RS_ENTIDAD_RSE_ID = value; }
        public int CE_RS_MESA_RSM_ID { get => _CE_RS_MESA_RSM_ID; set => _CE_RS_MESA_RSM_ID = value; }
        public int CE_RS_ESTADO_RSES_ID { get => _CE_RS_ESTADO_RSES_ID; set => _CE_RS_ESTADO_RSES_ID = value; }
    }
}
