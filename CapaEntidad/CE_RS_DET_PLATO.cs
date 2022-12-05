using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_RS_DET_PLATO
    {
        private int _RSDPL_ID;
        private double _RSDPL_CANTIDAD;
        private int _RS_PRODUCTO_RSP_ID;
        private int _RS_PLATO_RSPL_ID;

        public int RSDPL_ID { get => _RSDPL_ID; set => _RSDPL_ID = value; }
        public double RSDPL_CANTIDAD { get => _RSDPL_CANTIDAD; set => _RSDPL_CANTIDAD = value; }
        public int RS_PRODUCTO_RSP_ID { get => _RS_PRODUCTO_RSP_ID; set => _RS_PRODUCTO_RSP_ID = value; }
        public int RS_PLATO_RSPL_ID { get => _RS_PLATO_RSPL_ID; set => _RS_PLATO_RSPL_ID = value; }
    }
}
