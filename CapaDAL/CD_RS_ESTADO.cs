using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using Oracle.DataAccess.Client;
using System.Data;

namespace CapaDAL
{
    public class CD_RS_ESTADO
    {
        readonly CD_ConexionBD con = new CD_ConexionBD();
        readonly CE_RS_ESTADO ce_rs_estado = new CE_RS_ESTADO();

        #region OBTENER RSES_ID        
        public int ObtenerRSES_ID(string rses_descripcion)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_OBTENER_RSES_ID",
                CommandType = CommandType.StoredProcedure
            };

            
            cmd.Parameters.Add("v_rses_descripcion", rses_descripcion);
            cmd.Parameters.Add("v_rses_id", OracleDbType.Int32,ParameterDirection.Output);
            
            cmd.ExecuteNonQuery();

            string valor = cmd.Parameters["v_rses_id"].Value.ToString();

            int v_rses_id = int.Parse(valor);

            cmd.Parameters.Clear();
            con.CerrarConexion();
            
            return v_rses_id;
        }
        #endregion

        #region OBTENER RSES_DESCRIPCION
        public CE_RS_ESTADO ObtenerRSES_DESCRIPCION(int rses_id)
        {
            OracleCommand cmd = new OracleCommand("SELECT RSES_DESCRIPCION FROM RS_ESTADO WHERE RSES_ID="+rses_id, con.AbrirConexion());
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];

            ce_rs_estado.CE_RSES_DESCRIPCION = Convert.ToString(row[0]);
            ce_rs_estado.CE_RSES_ID = rses_id;

            cmd.Parameters.Clear();
            con.CerrarConexion();

            return ce_rs_estado;
        }
        #endregion

        #region LISTAR RSES_DESCRIPCION
        public List<string> ListarRSES_DESCRIPCION()
        {
            OracleCommand cmd = new OracleCommand("SELECT RSES_DESCRIPCION FROM RS_ESTADO",con.AbrirConexion());
            OracleDataReader rdr = cmd.ExecuteReader();
            List<string> lista_rses_descripcion = new List<string>();
            while (rdr.Read())
            {
                lista_rses_descripcion.Add(Convert.ToString(rdr["RSES_DESCRIPCION"]));
            }

            con.CerrarConexion();

            return lista_rses_descripcion;

        }
        #endregion
    }
}
