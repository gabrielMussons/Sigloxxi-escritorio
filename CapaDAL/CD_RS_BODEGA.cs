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
    public class CD_RS_BODEGA
    {
        readonly CD_ConexionBD con = new CD_ConexionBD();
        readonly CE_RS_BODEGA ce_rs_bodega = new CE_RS_BODEGA();

        #region OBTENER RSB_ID        
        public int ObtenerRSB_ID(string descripcion)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_OBTENER_RSB_ID",
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                cmd.Parameters.Add("v_rsb_descripcion", descripcion);
                cmd.Parameters.Add("v_rsb_id", OracleDbType.Int32, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                string valor = cmd.Parameters["v_rsb_id"].Value.ToString();
                int id = int.Parse(valor);
                cmd.Parameters.Clear();
                con.CerrarConexion();
                return id;
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
        public CE_RS_BODEGA ObtenerRSB_DESCRIPCION(int id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT RSB_DESCRIPCION FROM RS_BODEGA WHERE RSB_ID=" + id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                ce_rs_bodega.CE_RSB_DESCRIPCION = Convert.ToString(row[0]);
                ce_rs_bodega.CE_RSB_ID = id;
                cmd.Parameters.Clear();
                con.CerrarConexion();
                return ce_rs_bodega;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion

        #region LISTAR RSB_DESCRIPCION
        public List<string> ListarRSB_DESCRIPCION()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT RSB_DESCRIPCION FROM RS_BODEGA", con.AbrirConexion());
                OracleDataReader rdr = cmd.ExecuteReader();
                List<string> lista = new List<string>();
                while (rdr.Read())
                {
                    lista.Add(Convert.ToString(rdr["RSB_DESCRIPCION"]));
                }
                con.CerrarConexion();
                return lista;
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
