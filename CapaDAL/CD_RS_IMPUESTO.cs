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
    public class CD_RS_IMPUESTO
    {
        readonly CD_ConexionBD con = new CD_ConexionBD();
        readonly CE_RS_IMPUESTO ce_rs_impuesto = new CE_RS_IMPUESTO();

        #region OBTENER RSI_ID        
        public int ObtenerRSI_ID(string rsi_descripcion)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_OBTENER_RSI_ID",
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                cmd.Parameters.Add("v_rsi_descripcion", rsi_descripcion);
                cmd.Parameters.Add("v_rsi_id", OracleDbType.Int32, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                string valor = cmd.Parameters["v_rsi_id"].Value.ToString();
                int v_rsi_id = int.Parse(valor);
                cmd.Parameters.Clear();
                con.CerrarConexion();
                return v_rsi_id;
            }
            catch (Exception ex)
            {
                cmd.Parameters.Clear();
                con.CerrarConexion();
                throw ex;
            }
        }
        #endregion

        #region OBTENER RSI_DESCRIPCION
        public CE_RS_IMPUESTO ObtenerRSI_DESCRIPCION(int rsi_id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT RSI_DESCRIPCION FROM RS_IMPUESTO WHERE RSI_ID=" + rsi_id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                ce_rs_impuesto.CE_RSI_DESCRIPCION = Convert.ToString(row[0]);
                ce_rs_impuesto.CE_RSI_ID = rsi_id;
                cmd.Parameters.Clear();
                con.CerrarConexion();
                return ce_rs_impuesto;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }
            
        }
        #endregion

        #region LISTAR RSI_DESCRIPCION
        public List<string> ListarRSI_DESCRIPCION()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT RSI_DESCRIPCION FROM RS_IMPUESTO", con.AbrirConexion());
                OracleDataReader rdr = cmd.ExecuteReader();
                List<string> lista_rsi_descripcion = new List<string>();
                while (rdr.Read())
                {
                    lista_rsi_descripcion.Add(Convert.ToString(rdr["RSI_DESCRIPCION"]));
                }
                con.CerrarConexion();
                return lista_rsi_descripcion;
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
