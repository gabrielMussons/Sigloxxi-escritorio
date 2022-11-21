using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Oracle.DataAccess.Client;

namespace CapaDAL
{
    public class CD_RS_PRODUCTO
    {
        //---------------------------------------------------------------------

        #region VARIABLES
        private readonly CD_ConexionBD con = new CD_ConexionBD();
        private readonly CE_RS_PRODUCTO ce_rs_producto = new CE_RS_PRODUCTO();
        #endregion

        //---------------------------------------------------------------------

        #region CREAR 
        public void CD_INSERTAR(CE_RS_PRODUCTO RS_PRODUCTO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_INSERTAR_RS_PRODUCTO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSP_DESCRIPCION", OracleDbType.Varchar2).Value = RS_PRODUCTO.CE_RSP_DESCRIPCION;
                cmd.Parameters.Add("V_RSP_PCOMPRA", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RSP_PCOMPRA;
                cmd.Parameters.Add("V_RSP_PVENTA", OracleDbType.Int32).Value = RS_PRODUCTO.RSP_PVENTA;
                cmd.Parameters.Add("V_RSP_STOCK_MIN", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RSP_STOCK_MIN;
                cmd.Parameters.Add("V_RSP_STOCK_MAX", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RSP_STOCK_MAX;
                cmd.Parameters.Add("V_RS_UN_MEDIDA_RSUM_ID", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RS_UN_MEDIDA_RSUM_ID;
                cmd.Parameters.Add("V_RS_BODEGA_RSB_ID", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RS_BODEGA_RSB_ID;
                cmd.Parameters.Add("V_RS_IMPUESTO_RSI_ID", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RS_IMPUESTO_RSI_ID;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                cmd.Parameters.Clear();
                con.CerrarConexion();
                throw ex;
            }
        }
        #endregion

        #region CONSULTAR 
        public CE_RS_PRODUCTO CD_CONSULTAR(int id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_PRODUCTO WHERE RSP_ID =" + id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_producto.CE_RSP_ID = Convert.ToInt32(row[0]);
                ce_rs_producto.CE_RSP_DESCRIPCION = Convert.ToString(row[1]);
                ce_rs_producto.CE_RSP_PCOMPRA = Convert.ToInt32(row[2]);
                ce_rs_producto.RSP_PVENTA = Convert.ToInt32(row[3]);
                ce_rs_producto.CE_RSP_STOCK_MIN = Convert.ToInt32(row[4]);
                ce_rs_producto.CE_RSP_STOCK_MAX = Convert.ToInt32(row[5]);
                ce_rs_producto.CE_RS_UN_MEDIDA_RSUM_ID = Convert.ToInt32(row[6]);
                ce_rs_producto.CE_RS_BODEGA_RSB_ID = Convert.ToInt32(row[7]);
                ce_rs_producto.CE_RS_IMPUESTO_RSI_ID = Convert.ToInt32(row[8]);
                /*if ((row[12]) != null)
                {
                    ce_rs_producto.CE_RSP_IMAGEN = (byte[])row[12];
                }*/
                con.CerrarConexion();
                return ce_rs_producto;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion

        #region ACTUALIZAR 
        public void CD_ACTUALIZAR(CE_RS_PRODUCTO RS_PRODUCTO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ACTUALIZAR_RS_PRODUCTO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSP_ID", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RSP_ID;
                cmd.Parameters.Add("V_RSP_DESCRIPCION", OracleDbType.Varchar2).Value = RS_PRODUCTO.CE_RSP_DESCRIPCION;
                cmd.Parameters.Add("V_RSP_PCOMPRA", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RSP_PCOMPRA;
                cmd.Parameters.Add("V_RSP_PVENTA", OracleDbType.Int32).Value = RS_PRODUCTO.RSP_PVENTA;
                cmd.Parameters.Add("V_RSP_STOCK_MIN", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RSP_STOCK_MIN;
                cmd.Parameters.Add("V_RSP_STOCK_MAX", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RSP_STOCK_MAX;
                cmd.Parameters.Add("V_RS_UN_MEDIDA_RSUM_ID", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RS_UN_MEDIDA_RSUM_ID;
                cmd.Parameters.Add("V_RS_BODEGA_RSB_ID", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RS_BODEGA_RSB_ID;
                cmd.Parameters.Add("V_RS_IMPUESTO_RSI_ID", OracleDbType.Int32).Value = RS_PRODUCTO.CE_RS_IMPUESTO_RSI_ID;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                cmd.Parameters.Clear();
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion

        #region ELIMINAR
        public void CD_ELIMINAR(CE_RS_PRODUCTO ce_rs_producto)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ELIMINAR_RS_PRODUCTO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("v_rsp_id", ce_rs_producto.CE_RSP_ID);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                cmd.Parameters.Clear();
                con.CerrarConexion();
                throw ex;
            }


        }
        #endregion

        //---------------------------------------------------------------------

        #region CARGAR DATOS Y BUSCAR VISTA MANTENEDOR PRODUCTOS
        public DataTable CargarListaProducto(string texto)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_PRODUCTO " +
                    "JOIN RS_IMPUESTO ON rs_producto.rs_impuesto_rsi_id = rs_impuesto.rsi_id " +
                    "JOIN RS_UN_MEDIDA ON rs_producto.rs_un_medida_rsum_id = rs_un_medida.rsum_id " +
                    "JOIN RS_BODEGA ON rs_bodega.rsb_id = rs_producto.rs_bodega_rsb_id WHERE RSP_ID LIKE '" + texto + "%'" + " OR RSP_DESCRIPCION LIKE '" + texto + "%'" + " ORDER BY RSP_ID", con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                con.CerrarConexion();

                return dt;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }
        }
        #endregion

        #region CARGAR DATOS Y BUSCAR VISTA MANTENEDOR PRODUCTOS
        public DataTable CargarListaProductoCritico(string texto)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_PRODUCTO " +
                    "JOIN RS_IMPUESTO ON rs_producto.rs_impuesto_rsi_id = rs_impuesto.rsi_id " +
                    "JOIN RS_UN_MEDIDA ON rs_producto.rs_un_medida_rsum_id = rs_un_medida.rsum_id " +
                    "JOIN RS_BODEGA ON rs_bodega.rsb_id = rs_producto.rs_bodega_rsb_id WHERE RSP_ID LIKE '" + texto + "%'" + " OR RSP_DESCRIPCION LIKE '" + texto + "%'" + " ORDER BY RSP_ID", con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                con.CerrarConexion();

                return dt;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }
        }
        #endregion

        #region OBTENER ID 
        public int ObtenerRSP_ID(string rsp_descripcion)
        {
            try
            {
                OracleCommand cmd = new OracleCommand()
                {
                    Connection = con.AbrirConexion(),
                    CommandText = "SP_OBTENER_RSP_ID",
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("v_rsp_descripcion", rsp_descripcion);
                cmd.Parameters.Add("v_rsp_id", OracleDbType.Int32, ParameterDirection.Output);

                cmd.ExecuteNonQuery();

                string valor = cmd.Parameters["v_rsp_id"].Value.ToString();

                int id = int.Parse(valor);

                cmd.Parameters.Clear();
                con.CerrarConexion();

                return id;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion
    }
}
