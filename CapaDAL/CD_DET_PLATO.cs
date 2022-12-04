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
    public class CD_DET_PLATO
    {
        //---------------------------------------------------------------------

        #region VARIABLES
        private readonly CD_ConexionBD con = new CD_ConexionBD();
        private readonly CE_RS_DET_PLATO ce_rs_det_plato = new CE_RS_DET_PLATO();
        #endregion

        //---------------------------------------------------------------------

        #region CREAR 
        public void CD_INSERTAR(CE_RS_DET_PLATO RS_DET_PLATO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_INSERTAR_RS_DET_PLATO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSDPL_CANTIDAD", OracleDbType.Int32).Value = RS_DET_PLATO.RSDPL_CANTIDAD;
                cmd.Parameters.Add("V_RS_PRODUCTO_RSP_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RS_PRODUCTO_RSP_ID;
                cmd.Parameters.Add("V_RS_PLATO_RSPL_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RS_PLATO_RSPL_ID;
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
        public CE_RS_DET_PLATO CD_CONSULTAR(int id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_DET_PLATO WHERE RSDPL_ID =" + id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_det_plato.RSDPL_ID = Convert.ToInt32(row[0]);
                ce_rs_det_plato.RSDPL_CANTIDAD = Convert.ToInt32(row[1]);
                ce_rs_det_plato.RS_PRODUCTO_RSP_ID = Convert.ToInt32(row[2]);
                ce_rs_det_plato.RS_PLATO_RSPL_ID = Convert.ToInt32(row[3]);
                con.CerrarConexion();
                return ce_rs_det_plato;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion

        #region ACTUALIZAR 
        public void CD_ACTUALIZAR(CE_RS_DET_PLATO RS_DET_PLATO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ACTUALIZAR_RS_DET_PLATO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSDPL_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RSDPL_ID;
                cmd.Parameters.Add("V_RSDPL_CANTIDAD", OracleDbType.Int32).Value = RS_DET_PLATO.RSDPL_CANTIDAD;
                cmd.Parameters.Add("V_RS_PRODUCTO_RSP_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RS_PRODUCTO_RSP_ID;
                cmd.Parameters.Add("V_RS_PLATO_RSPL_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RS_PLATO_RSPL_ID;
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
        public void CD_ELIMINAR(CE_RS_DET_PLATO RS_DET_PLATO)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ELIMINAR_RS_DET_PLATO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSDPL_ID", RS_DET_PLATO.RSDPL_ID);
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

        #region CARGAR DATOS DETALLE PLATO FILTRADO SEGUN ID
        public DataTable CargarDetPlato(int id_plato)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("" +
                    "select " +
                    "rs_det_plato.rsdpl_id as ID_DETALLE," +
                    "rs_producto.rsp_descripcion as INSUMO," +
                    "rs_producto.rsp_pcompra as P_COMPRA," +
                    "rs_det_plato.rsdpl_cantidad as CANTIDAD," +
                    "rs_un_medida.rsum_descripcion as MEDIDA" +
                    " from rs_det_plato " +
                    "join rs_producto on rs_producto.rsp_id = rs_det_plato.rs_producto_rsp_id " +
                    "join rs_un_medida on rs_producto.rs_un_medida_rsum_id = rs_un_medida.rsum_id " +
                    "where rs_plato_rspl_id = "+id_plato, con.AbrirConexion());
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

        #region CARGAR DATOS LISTA
        public DataTable CargarDetPlatoCarta(int id_plato, int cantidad_platos_carta)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("select rs_producto.rsp_descripcion as PRODUCTO,(rs_det_plato.rsdpl_cantidad) * "+cantidad_platos_carta+" as CANT_SOLICITADO," +
                    "rs_producto.rsp_stock as STOCK_ACTUAL , rs_producto.rsp_id as ID_PRODUCTO FROM RS_DET_PLATO join rs_producto on rs_det_plato.rs_producto_rsp_id = rs_producto.rsp_id " +
                    "JOIN rs_plato on rs_det_plato.rs_plato_rspl_id = rs_plato.rspl_id where rs_det_plato.rs_plato_rspl_id ="+id_plato, con.AbrirConexion());
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

        #region CONSULTAR PRODUCTO DET PLATO SEGUN ID PLATO Y ID PRODUCTO
        public CE_RS_DET_PLATO ConsultarProductoDetPlato(int id_plato, int id_producto)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("" +
                    "select * " +
                    "from rs_det_plato where rs_plato_rspl_id = "+id_plato +
                    " and rs_producto_rsp_id = "+id_producto, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_det_plato.RSDPL_ID = Convert.ToInt32(row[0]);
                ce_rs_det_plato.RSDPL_CANTIDAD = Convert.ToInt32(row[1]);
                ce_rs_det_plato.RS_PRODUCTO_RSP_ID = Convert.ToInt32(row[2]);
                ce_rs_det_plato.RS_PLATO_RSPL_ID = Convert.ToInt32(row[3]);
                con.CerrarConexion();
                return ce_rs_det_plato;
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
