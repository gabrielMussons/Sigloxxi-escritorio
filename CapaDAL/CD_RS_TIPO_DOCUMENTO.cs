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
    public class CD_RS_TIPO_DOCUMENTO
    {
        readonly CD_ConexionBD con = new CD_ConexionBD();
        readonly CE_RS_TIPO_DOCUMENTO ce_rs_tipo_documento = new CE_RS_TIPO_DOCUMENTO();

        #region OBTENER ID        
        public int ObtenerRSTD_ID(string rstd_descripcion)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_OBTENER_RSTD_ID",
                CommandType = CommandType.StoredProcedure
            };


            cmd.Parameters.Add("v_rstd_descripcion", rstd_descripcion);
            cmd.Parameters.Add("v_rstd_id", OracleDbType.Int32, ParameterDirection.Output);

            cmd.ExecuteNonQuery();

            string valor = cmd.Parameters["v_rstd_id"].Value.ToString();

            int v_rstd_id = int.Parse(valor);

            cmd.Parameters.Clear();
            con.CerrarConexion();

            return v_rstd_id;
        }
        #endregion

        #region OBTENER DESCRIPCION
        public CE_RS_TIPO_DOCUMENTO ObtenerRSTD_DESCRIPCION(int rstd_id)
        {
            OracleCommand cmd = new OracleCommand("SELECT RSTD_DESCRIPCION FROM RS_TIPO_DOCUMENTO WHERE RSTD_ID=" + rstd_id, con.AbrirConexion());
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];

            ce_rs_tipo_documento.CE_RSTD_DESCRIPCION = Convert.ToString(row[0]);
            ce_rs_tipo_documento.CE_RSTD_ID = rstd_id;

            cmd.Parameters.Clear();
            con.CerrarConexion();

            return ce_rs_tipo_documento;
        }
        #endregion

        #region LISTAR DESCRIPCION
        public List<string> ListarRSTD_DESCRIPCION()
        {
            OracleCommand cmd = new OracleCommand("SELECT RSTD_DESCRIPCION FROM RS_TIPO_DOCUMENTO", con.AbrirConexion());
            OracleDataReader rdr = cmd.ExecuteReader();
            List<string> lista = new List<string>();
            while (rdr.Read())
            {
                lista.Add(Convert.ToString(rdr["RSTD_DESCRIPCION"]));
            }

            con.CerrarConexion();

            return lista;

        }
        #endregion

    }
}
