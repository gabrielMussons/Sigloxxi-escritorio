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
    public class CD_RS_UN_MEDIDA
    {
        readonly CD_ConexionBD con = new CD_ConexionBD();
        readonly CE_RS_UN_MEDIDA ce_rs_un_medida = new CE_RS_UN_MEDIDA();

        #region OBTENER RSUM_ID        
        public int ObtenerRSUM_ID(string rsum_descripcion)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_OBTENER_RSUM_ID",
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                cmd.Parameters.Add("v_rsum_descripcion", rsum_descripcion);
                cmd.Parameters.Add("v_rsum_id", OracleDbType.Int32, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                string valor = cmd.Parameters["v_rsum_id"].Value.ToString();
                int v_id = int.Parse(valor);
                cmd.Parameters.Clear();
                con.CerrarConexion();
                return v_id;
            }
            catch (Exception ex)
            {
                cmd.Parameters.Clear();
                con.CerrarConexion();
                throw ex;
            }
        }
        #endregion

        #region OBTENER RSUM_DESCRIPCION
        public CE_RS_UN_MEDIDA ObtenerRSUM_DESCRIPCION(int id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT RSUM_DESCRIPCION FROM RS_UN_MEDIDA WHERE RSUM_ID=" + id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                ce_rs_un_medida.CE_RSUM_DESCRIPCION = Convert.ToString(row[0]);
                ce_rs_un_medida.CE_RSUM_ID = id;
                cmd.Parameters.Clear();
                con.CerrarConexion();
                return ce_rs_un_medida;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion

        #region LISTAR RSUM_DESCRIPCION
        public List<string> ListarRSUM_DESCRIPCION()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT RSUM_DESCRIPCION FROM RS_UN_MEDIDA", con.AbrirConexion());
                OracleDataReader rdr = cmd.ExecuteReader();
                List<string> lista = new List<string>();
                while (rdr.Read())
                {
                    lista.Add(Convert.ToString(rdr["RSUM_DESCRIPCION"]));
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
