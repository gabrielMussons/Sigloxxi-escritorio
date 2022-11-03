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
            
            cmd.Parameters.Add("v_rsm_descripcion", OracleDbType.Varchar2).Value = RS_MESA.CE_RSM_DESCRIPCION;
            cmd.Parameters.Add("v_rs_entidad_rse_id", OracleDbType.Int32).Value = RS_MESA.CE_RS_ENTIDAD_RSE_ID;
            cmd.Parameters.Add("v_rs_estado_rses_id", OracleDbType.Int32).Value = RS_MESA.CE_RS_ESTADO_RSES_ID;
            cmd.Parameters.Add("v_rsm_sillas", OracleDbType.Int32).Value = RS_MESA.CE_RSM_SILLAS;

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.CerrarConexion();

        }
        #endregion

        #region CONSULTAR RS_MESA
        public CE_RS_MESA CD_CONSULTAR(int rsm_id)
        {
            OracleCommand cmd = new OracleCommand("SELECT * FROM RS_MESA WHERE RSM_ID ="+rsm_id, con.AbrirConexion());
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];

            ce_rs_mesa.CE_RSM_ID = Convert.ToInt32(row[0]);
            ce_rs_mesa.CE_RSM_DESCRIPCION = Convert.ToString(row[1]);
            ce_rs_mesa.CE_RS_ENTIDAD_RSE_ID = Convert.ToInt32(row[2]);
            ce_rs_mesa.CE_RS_ESTADO_RSES_ID = Convert.ToInt32(row[3]);
            ce_rs_mesa.CE_RSM_SILLAS = Convert.ToInt32(row[4]);

            con.CerrarConexion();

            return ce_rs_mesa;

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
            
            cmd.Parameters.Add("v_rsm_id", OracleDbType.Int32).Value = RS_MESA.CE_RSM_ID;
            cmd.Parameters.Add("v_rsm_descripcion", OracleDbType.Varchar2).Value = RS_MESA.CE_RSM_DESCRIPCION;
            cmd.Parameters.Add("v_rs_entidad_rse_id", OracleDbType.Int32).Value = RS_MESA.CE_RS_ENTIDAD_RSE_ID;
            cmd.Parameters.Add("v_rs_estado_rses_id", OracleDbType.Int32).Value = RS_MESA.CE_RS_ESTADO_RSES_ID;
            cmd.Parameters.Add("v_rsm_sillas", OracleDbType.Int32).Value = RS_MESA.CE_RSM_SILLAS;
            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.CerrarConexion();

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
            cmd.Parameters.Add("v_rsm_id",ce_rs_mesa.CE_RSM_ID);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.CerrarConexion();

        }

        #endregion

        //---------------------------------------------------------------------

        #region CARGAR DATOS VISTA MANTENEDOR MESAS
        public DataTable CargarMesas()
        {
            OracleCommand cmd = new OracleCommand("SELECT * FROM RS_MESA JOIN RS_ESTADO ON RS_MESA.RS_ESTADO_RSES_ID = RS_ESTADO.RSES_ID", con.AbrirConexion());
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            con.CerrarConexion();
            
            return dt; 
        }
        #endregion


    }
}
