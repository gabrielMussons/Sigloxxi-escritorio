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
    public class CD_RS_PLATO
    {
        //---------------------------------------------------------------------

        #region VARIABLES
        private readonly CD_ConexionBD con = new CD_ConexionBD();
        private readonly CE_RS_PLATO ce_rs_plato = new CE_RS_PLATO();
        #endregion

        //---------------------------------------------------------------------

        #region CREAR RS_PLATO
        public void CD_INSERTAR(CE_RS_PLATO RS_PLATO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_INSERTAR_RS_PLATO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSPL_DESCRIPCION", OracleDbType.Varchar2).Value = RS_PLATO.RSPL_DESCRIPCION;
                cmd.Parameters.Add("V_RSPL_PVENTA", OracleDbType.Int32).Value = RS_PLATO.RSPL_PVENTA;
                cmd.Parameters.Add("V_RSPL_OBS", OracleDbType.Varchar2).Value = RS_PLATO.RSPL_OBS;
                cmd.Parameters.Add("V_RS_UN_MEDIDA_RSUM_ID", OracleDbType.Int32).Value = RS_PLATO.RS_UN_MEDIDA_RSUM_ID;
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

        #region CONSULTAR RS_PLATO
        public CE_RS_PLATO CD_CONSULTAR(int id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_PLATO WHERE RSPL_ID =" + id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_plato.RSPL_ID = Convert.ToInt32(row[0]);
                ce_rs_plato.RSPL_DESCRIPCION = Convert.ToString(row[1]);
                ce_rs_plato.RSPL_PVENTA = Convert.ToInt32(row[2]);
                try
                {
                    ce_rs_plato.RSPL_OBS = Convert.ToString(row[3]);
                    ce_rs_plato.RS_UN_MEDIDA_RSUM_ID = Convert.ToInt32(row[4]);
                }
                catch (Exception)
                {
                    ce_rs_plato.RS_UN_MEDIDA_RSUM_ID = Convert.ToInt32(row[4]);
                    ce_rs_plato.RSPL_OBS = Convert.ToString(row[3]);
                    

                }
                con.CerrarConexion();
                return ce_rs_plato;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion

        #region ACTUALIZAR RS_PLATO
        public void CD_ACTUALIZAR(CE_RS_PLATO RS_PLATO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ACTUALIZAR_RS_PLATO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSPL_ID", OracleDbType.Int32).Value = RS_PLATO.RSPL_ID;
                cmd.Parameters.Add("V_RSPL_DESCRIPCION", OracleDbType.Varchar2).Value = RS_PLATO.RSPL_DESCRIPCION;
                cmd.Parameters.Add("V_RSPL_PVENTA", OracleDbType.Int32).Value = RS_PLATO.RSPL_PVENTA;
                cmd.Parameters.Add("V_RSPL_OBS", OracleDbType.Varchar2).Value = RS_PLATO.RSPL_OBS;
                cmd.Parameters.Add("V_RS_UN_MEDIDA_RSUM_ID", OracleDbType.Int32).Value = RS_PLATO.RS_UN_MEDIDA_RSUM_ID;
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
        public void CD_ELIMINAR(CE_RS_PLATO ce_rs_plato)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ELIMINAR_RS_PLATO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSPL_ID", ce_rs_plato.RSPL_ID);
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
        public DataTable CargarPlatos()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_PLATO JOIN RS_UN_MEDIDA ON rs_un_medida.rsum_id = rs_plato.rs_un_medida_rsum_id " +
                    "ORDER BY RSPL_ID", con.AbrirConexion());
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
        public int ObtenerRSPL_ID(string rspl_descripcion)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_OBTENER_RSPL_ID",
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                cmd.Parameters.Add("v_rspl_descripcion", rspl_descripcion);
                cmd.Parameters.Add("v_rspl_id", OracleDbType.Int32, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                string valor = cmd.Parameters["v_rspl_id"].Value.ToString();
                int v_rspl_id = int.Parse(valor);
                cmd.Parameters.Clear();
                con.CerrarConexion();
                return v_rspl_id;
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

