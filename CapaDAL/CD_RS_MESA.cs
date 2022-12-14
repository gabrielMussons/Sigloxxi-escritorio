using Oracle.DataAccess.Client;
using System.Data;
using CapaEntidad;
using System;

namespace CapaDAL
{
    public class CD_RS_MESA
    {
        //---------------------------------------------------------------------

        #region VARIABLES
        private readonly CD_ConexionBD con = new CD_ConexionBD();
        private readonly CE_RS_MESA ce_rs_mesa = new CE_RS_MESA();
        #endregion

        //---------------------------------------------------------------------

        #region CREAR RS_MESA
        public void CD_INSERTAR(CE_RS_MESA RS_MESA)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_INSERTAR_RS_MESA",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("v_rsm_descripcion", OracleDbType.Varchar2).Value = RS_MESA.CE_RSM_DESCRIPCION;
                if (RS_MESA.CE_RS_ENTIDAD_RSE_ID == 0)
                {
                    cmd.Parameters.Add("v_rs_entidad_rse_id", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("v_rs_entidad_rse_id", OracleDbType.Varchar2).Value = RS_MESA.CE_RS_ENTIDAD_RSE_ID;
                }
                cmd.Parameters.Add("v_rs_estado_rses_id", OracleDbType.Int32).Value = RS_MESA.CE_RS_ESTADO_RSES_ID;
                cmd.Parameters.Add("v_rsm_sillas", OracleDbType.Int32).Value = RS_MESA.CE_RSM_SILLAS;

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

        #region CONSULTAR RS_MESA
        public CE_RS_MESA CD_CONSULTAR(int rsm_id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_MESA WHERE RSM_ID =" + rsm_id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_mesa.CE_RSM_ID = Convert.ToInt32(row[0]);
                ce_rs_mesa.CE_RSM_DESCRIPCION = Convert.ToString(row[1]);
                try
                {
                    ce_rs_mesa.CE_RS_ENTIDAD_RSE_ID = Convert.ToInt32(row[2]);
                    ce_rs_mesa.CE_RS_ESTADO_RSES_ID = Convert.ToInt32(row[3]);
                    ce_rs_mesa.CE_RSM_SILLAS = Convert.ToInt32(row[4]);
                }
                catch (Exception)
                {
                    ce_rs_mesa.CE_RS_ESTADO_RSES_ID = Convert.ToInt32(row[3]);
                    ce_rs_mesa.CE_RSM_SILLAS = Convert.ToInt32(row[4]);

                }
                con.CerrarConexion();
                return ce_rs_mesa;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }         
            
        }
        #endregion

        #region ACTUALIZAR RS_MESA
        public void CD_ACTUALIZAR(CE_RS_MESA RS_MESA)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ACTUALIZAR_RS_MESA",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("v_rsm_id", OracleDbType.Int32).Value = RS_MESA.CE_RSM_ID;
                cmd.Parameters.Add("v_rsm_descripcion", OracleDbType.Varchar2).Value = RS_MESA.CE_RSM_DESCRIPCION;
                if (RS_MESA.CE_RS_ENTIDAD_RSE_ID==0)
                {
                    cmd.Parameters.Add("v_rs_entidad_rse_id", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("v_rs_entidad_rse_id", OracleDbType.Varchar2).Value = RS_MESA.CE_RS_ENTIDAD_RSE_ID;
                }
                cmd.Parameters.Add("v_rs_estado_rses_id", OracleDbType.Int32).Value = RS_MESA.CE_RS_ESTADO_RSES_ID;
                cmd.Parameters.Add("v_rsm_sillas", OracleDbType.Int32).Value = RS_MESA.CE_RSM_SILLAS;

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
        public void CD_ELIMINAR_RS_MESA(CE_RS_MESA ce_rs_mesa)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ELIMINAR_RS_MESA",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("v_rsm_id", ce_rs_mesa.CE_RSM_ID);
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

        #region CARGAR DATOS VISTA MANTENEDOR MESAS
        public DataTable CargarMesas()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_MESA JOIN RS_ESTADO ON RS_MESA.RS_ESTADO_RSES_ID = RS_ESTADO.RSES_ID " +
                    "ORDER BY RSM_ID", con.AbrirConexion());
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

        #region ACTUALIZAR RS_MESA.RS_ENTIDAD_RSE_ID
        public void CD_LIBERAR_MESAS_ID_CLIENTE(int rse_id)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ACTUALIZAR_RS_MESA_ID_ENTIDAD",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {                
                cmd.Parameters.Add("v_rse_id", OracleDbType.Int32).Value = rse_id;
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


    }
}
