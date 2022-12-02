using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDAL;
using CapaEntidad;

namespace CapaLogicaNegocio
{
    public class CN_RS_DOCTO
    {
        //---------------------------------------------------------------

        #region VARIABLES
        private readonly CD_RS_DOCTO objDatos = new CD_RS_DOCTO();
        private readonly CE_RS_DOCTO objEntidad = new CE_RS_DOCTO();
        #endregion

        //---------------------------------------------------------------

        #region CONSULTAR 
        public CE_RS_DOCTO Consultar(int id)
        {

            try
            {
                return objDatos.CD_CONSULTAR(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region INSERTAR 
        public void Insertar(CE_RS_DOCTO rs_docto)
        {

            try
            {
                objDatos.CD_INSERTAR(rs_docto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ELIMINAR 
        public void Eliminar(CE_RS_DOCTO rs_docto)
        {

            try
            {
                objDatos.CD_ELIMINAR(rs_docto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region ACTUALIZAR 
        public void Actualizar(CE_RS_DOCTO rs_docto)
        {
            try
            {
                objDatos.CD_ACTUALIZAR(rs_docto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        #endregion

        //---------------------------------------------------------------

        #region DATOS PEDIDOS 
        public DataTable CargarDatosPedidos()
        {
            return objDatos.CargarPedidos();
        }
        #endregion
        #region DATOS CARTA 
        public DataTable CargarDatosCarta()
        {
            return objDatos.CargarCarta();
        }
        #endregion

        #region DATOS BOLETAS 
        public DataTable CargarListaBoletas()
        {
            return objDatos.CargarBoletas();
        }
        #endregion
        #region DATOS DETALE BOLETA
        public DataTable CargarListaDetalleBoleta(int id_boleta)
        {
            return objDatos.CargarDetalleBoleta(id_boleta);
        }
        #endregion
        #region DATOS TOTAL BOLETA
        public DataTable CargarListaTotalBoleta(int id_boleta)
        {
            return objDatos.CargarTotalBoleta(id_boleta);
        }
        #endregion
        #region DATOS VENTAS DIA
        public DataTable CargarDTTotalVentasDia(string fecha)
        {
            return objDatos.CargarDTTotlaVentasDia(fecha);
        }
        #endregion
        #region DATOS VENTAS MES
        public DataTable CargarDTTotalVentasMes(string fecha)
        {
            return objDatos.CargarDTTotlaVentasMes(fecha);
        }
        #endregion
        #region DATOS VENTAS AÑO
        public DataTable CargarDTTotalVentasAnio(string fecha)
        {
            return objDatos.CargarDTTotlaVentasAnio(fecha);
        }
        #endregion


        #region OBTENER ULTIMO REGISTRO 
        public CE_RS_DOCTO ObtenerUltimoRegistro()
        {
            try
            {
                return objDatos.ObtenerUltimoRegistro();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion


    }
}
