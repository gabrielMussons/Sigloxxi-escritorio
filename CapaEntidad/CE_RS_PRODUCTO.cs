using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_PRODUCTO
    {
        private int _CE_RSP_ID;
        private string _CE_RSP_DESCRIPCION;
        private int _CE_RSP_PCOMPRA;
        private int _RSP_PVENTA;
        private int _CE_RSP_STOCK_MIN;
        private int _CE_RSP_STOCK_MAX;
        private int _CE_RS_UN_MEDIDA_RSUM_ID;
        private int _CE_RS_BODEGA_RSB_ID;
        private int _CE_RS_IMPUESTO_RSI_ID;
        private int _CE_RSP_STOCK;

        public int CE_RSP_ID
        {
            get => _CE_RSP_ID;
            set => _CE_RSP_ID = value;
        }
        public string CE_RSP_DESCRIPCION 
        { 
            get => _CE_RSP_DESCRIPCION; 
            set => _CE_RSP_DESCRIPCION = value; 
        }
        public int CE_RSP_PCOMPRA 
        { 
            get => _CE_RSP_PCOMPRA; 
            set => _CE_RSP_PCOMPRA = value; 
        }
        public int RSP_PVENTA 
        { 
            get => _RSP_PVENTA; 
            set => _RSP_PVENTA = value; 
        }
        public int CE_RSP_STOCK_MIN 
        { 
            get => _CE_RSP_STOCK_MIN; 
            set => _CE_RSP_STOCK_MIN = value; 
        }
        public int CE_RSP_STOCK_MAX 
        { 
            get => _CE_RSP_STOCK_MAX; 
            set => _CE_RSP_STOCK_MAX = value; 
        }
        public int CE_RS_UN_MEDIDA_RSUM_ID 
        { 
            get => _CE_RS_UN_MEDIDA_RSUM_ID; 
            set => _CE_RS_UN_MEDIDA_RSUM_ID = value; 
        }
        public int CE_RS_BODEGA_RSB_ID 
        { 
            get => _CE_RS_BODEGA_RSB_ID; 
            set => _CE_RS_BODEGA_RSB_ID = value; 
        }
        public int CE_RS_IMPUESTO_RSI_ID 
        { 
            get => _CE_RS_IMPUESTO_RSI_ID; 
            set => _CE_RS_IMPUESTO_RSI_ID = value; 
        }
        public int CE_RSP_STOCK { get => _CE_RSP_STOCK; set => _CE_RSP_STOCK = value; }
    }
}
