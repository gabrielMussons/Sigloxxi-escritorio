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
    public class CD_RS_COMUNA
    {
        readonly CD_ConexionBD con = new CD_ConexionBD();
        readonly CE_RS_COMUNA ce_rs_comuna = new CE_RS_COMUNA();

        #region OBTENER RSC_ID        
        public int ObtenerRSC_ID(string rsc_descripcion)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_OBTENER_RSC_ID",
                CommandType = CommandType.StoredProcedure
            };


            cmd.Parameters.Add("v_rsc_descripcion", rsc_descripcion);
            cmd.Parameters.Add("v_rsc_id", OracleDbType.Int32, ParameterDirection.Output);

            cmd.ExecuteNonQuery();

            string valor = cmd.Parameters["v_rsc_id"].Value.ToString();

            int v_rsc_id = int.Parse(valor);

            cmd.Parameters.Clear();
            con.CerrarConexion();

            return v_rsc_id;
        }
        #endregion

        #region OBTENER RSC_DESCRIPCION
        public CE_RS_COMUNA ObtenerRSC_DESCRIPCION(int rsc_id)
        {
            OracleCommand cmd = new OracleCommand("SELECT RSC_DESCRIPCION FROM RS_COMUNA WHERE RSC_ID=" + rsc_id, con.AbrirConexion());
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];

            ce_rs_comuna.CE_RSC_DESCRIPCION = Convert.ToString(row[0]);
            ce_rs_comuna.CE_RSC_ID = rsc_id;

            cmd.Parameters.Clear();
            con.CerrarConexion();

            return ce_rs_comuna;
        }

        #endregion

        #region LISTAR RSC_DESCRIPCION
        public List<string> ListarRSTE_DESCRIPCION()
        {
            OracleCommand cmd = new OracleCommand("SELECT RSC_DESCRIPCION FROM RS_COMUNA", con.AbrirConexion());
            OracleDataReader rdr = cmd.ExecuteReader();
            List<string> lista_rsc_descripcion = new List<string>();
            while (rdr.Read())
            {
                lista_rsc_descripcion.Add(Convert.ToString(rdr["RSC_DESCRIPCION"]));
            }

            con.CerrarConexion();

            return lista_rsc_descripcion;

        }


        #endregion


    }
}
