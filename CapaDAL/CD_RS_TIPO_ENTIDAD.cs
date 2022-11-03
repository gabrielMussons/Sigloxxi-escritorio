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
    public class CD_RS_TIPO_ENTIDAD
    {
        readonly CD_ConexionBD con = new CD_ConexionBD();
        readonly CE_RS_TIPO_ENTIDAD ce_rs_tipo_entidad = new CE_RS_TIPO_ENTIDAD();

        #region OBTENER RSES_ID        
        public int ObtenerRSTE_ID(string rste_descripcion)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_OBTENER_RSTE_ID",
                CommandType = CommandType.StoredProcedure
            };


            cmd.Parameters.Add("v_rste_descripcion", rste_descripcion);
            cmd.Parameters.Add("v_rste_id", OracleDbType.Int32, ParameterDirection.Output);

            cmd.ExecuteNonQuery();

            string valor = cmd.Parameters["v_rste_id"].Value.ToString();

            int v_rste_id = int.Parse(valor);

            cmd.Parameters.Clear();
            con.CerrarConexion();

            return v_rste_id;
        }
        #endregion

        #region OBTENER RSES_DESCRIPCION
        public CE_RS_TIPO_ENTIDAD ObtenerRSTE_DESCRIPCION(int rste_id)
        {
            OracleCommand cmd = new OracleCommand("SELECT RSTE_DESCRIPCION FROM RS_TIPO_ENTIDAD WHERE RSTE_ID=" + rste_id, con.AbrirConexion());
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];

            ce_rs_tipo_entidad.CE_RSTE_DESCRIPCION = Convert.ToString(row[0]);
            ce_rs_tipo_entidad.CE_RSTE_ID = rste_id;

            cmd.Parameters.Clear();
            con.CerrarConexion();

            return ce_rs_tipo_entidad;
        }

        #endregion

        #region LISTAR RSES_DESCRIPCION
        public List<string> ListarRSTE_DESCRIPCION()
        {
            OracleCommand cmd = new OracleCommand("SELECT RSTE_DESCRIPCION FROM RS_TIPO_ENTIDAD", con.AbrirConexion());
            OracleDataReader rdr = cmd.ExecuteReader();
            List<string> lista_rste_descripcion = new List<string>();
            while (rdr.Read())
            {
                lista_rste_descripcion.Add(Convert.ToString(rdr["RSTE_DESCRIPCION"]));
            }

            con.CerrarConexion();

            return lista_rste_descripcion;

        }


        #endregion



    }
}
