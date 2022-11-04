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
    public class CD_RS_ENTIDAD
    {
        //---------------------------------------------------------------------

        #region VARIABLES
        private readonly CD_ConexionBD con = new CD_ConexionBD();
        private readonly CE_RS_ENTIDAD ce_rs_entidad = new CE_RS_ENTIDAD();
        #endregion

        //---------------------------------------------------------------------

        #region CREAR RS_ENTIDAD
        public void CD_INSERTAR(CE_RS_ENTIDAD RS_ENTIDAD)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_INSERTAR_RS_ENTIDAD",
                CommandType = CommandType.StoredProcedure,
            };
            
            try
            {
                cmd.Parameters.Add("V_RSE_RUT", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_RUT;
                cmd.Parameters.Add("V_RSE_NOMBRE", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_NOMBRE;
                cmd.Parameters.Add("V_RSE_RAZON_SOCIAL", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_RAZON_SOCIAL;
                cmd.Parameters.Add("V_RSE_AP_PAT", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_AP_PAT;
                cmd.Parameters.Add("V_RSE_AP_MAT", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_AP_MAT;
                cmd.Parameters.Add("V_RSE_TELEFONO", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_TELEFONO;
                cmd.Parameters.Add("V_RSE_EMAIL", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_EMAIL;
                cmd.Parameters.Add("V_RSE_DIRECCION", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_DIRECCION;
                cmd.Parameters.Add("V_RS_TIPO_ENTIDAD_RSTE_ID", OracleDbType.Int32).Value = RS_ENTIDAD.CE_RS_TIPO_ENTIDAD_RSTE_ID;
                cmd.Parameters.Add("V_RS_COMUNA_RSC_ID", OracleDbType.Int32).Value = RS_ENTIDAD.CE_RS_COMUNA_RSC_ID;
                cmd.Parameters.Add("V_RS_ESTADO_RSES_ID", OracleDbType.Int32).Value = RS_ENTIDAD.CE_RS_ESTADO_RSES_ID;
                cmd.Parameters.Add("V_RSE_IMAGEN", OracleDbType.Blob).Value = RS_ENTIDAD.CE_RSE_IMAGEN;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error al insertar entidad."+Environment.NewLine+ex.Message.ToString(),ex);
            }
            
            cmd.Parameters.Clear();
            con.CerrarConexion();

        }
        #endregion

        #region CONSULTAR RS_ENTIDAD
        public CE_RS_ENTIDAD CD_CONSULTAR(int rse_id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_ENTIDAD WHERE RSE_ID =" + rse_id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_entidad.CE_RSE_ID = Convert.ToInt32(row[0]);
                ce_rs_entidad.CE_RSE_RUT = Convert.ToString(row[1]);
                ce_rs_entidad.CE_RSE_NOMBRE = Convert.ToString(row[2]);
                ce_rs_entidad.CE_RSE_RAZON_SOCIAL = Convert.ToString(row[3]);
                ce_rs_entidad.CE_RSE_AP_PAT = Convert.ToString(row[4]);
                ce_rs_entidad.CE_RSE_AP_MAT = Convert.ToString(row[5]);
                ce_rs_entidad.CE_RSE_TELEFONO = Convert.ToString(row[6]);
                ce_rs_entidad.CE_RSE_EMAIL = Convert.ToString(row[7]);
                ce_rs_entidad.CE_RSE_DIRECCION = Convert.ToString(row[8]);
                ce_rs_entidad.CE_RS_TIPO_ENTIDAD_RSTE_ID = Convert.ToInt32(row[9]);
                ce_rs_entidad.CE_RS_COMUNA_RSC_ID = Convert.ToInt32(row[10]);
                ce_rs_entidad.CE_RS_ESTADO_RSES_ID = Convert.ToInt32(row[11]);
                if (ce_rs_entidad.CE_RSE_IMAGEN != null)
                {
                    ce_rs_entidad.CE_RSE_IMAGEN = (byte[])row[12];
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            con.CerrarConexion();
            return ce_rs_entidad;

        }
        #endregion

        #region ACTUALIZAR RS_ENTIDAD
        public void CD_ACTUALIZAR(CE_RS_ENTIDAD RS_ENTIDAD)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ACTUALIZAR_RS_ENTIDAD",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSE_RUT", OracleDbType.Int32).Value = RS_ENTIDAD.CE_RSE_ID;
                cmd.Parameters.Add("V_RSE_RUT", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_RUT;
                cmd.Parameters.Add("V_RSE_NOMBRE", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_NOMBRE;
                cmd.Parameters.Add("V_RSE_RAZON_SOCIAL", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_RAZON_SOCIAL;
                cmd.Parameters.Add("V_RSE_AP_PAT", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_AP_PAT;
                cmd.Parameters.Add("V_RSE_AP_MAT", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_AP_MAT;
                cmd.Parameters.Add("V_RSE_TELEFONO", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_TELEFONO;
                cmd.Parameters.Add("V_RSE_EMAIL", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_EMAIL;
                cmd.Parameters.Add("V_RSE_DIRECCION", OracleDbType.Varchar2).Value = RS_ENTIDAD.CE_RSE_DIRECCION;
                cmd.Parameters.Add("V_RS_TIPO_ENTIDAD_RSTE_ID", OracleDbType.Int32).Value = RS_ENTIDAD.CE_RS_TIPO_ENTIDAD_RSTE_ID;
                cmd.Parameters.Add("V_RS_COMUNA_RSC_ID", OracleDbType.Int32).Value = RS_ENTIDAD.CE_RS_COMUNA_RSC_ID;
                cmd.Parameters.Add("V_RS_ESTADO_RSES_ID", OracleDbType.Int32).Value = RS_ENTIDAD.CE_RS_ESTADO_RSES_ID;
                cmd.Parameters.Add("V_RSE_IMAGEN", OracleDbType.Blob).Value = RS_ENTIDAD.CE_RSE_IMAGEN;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar entidad." + Environment.NewLine + ex.Message.ToString(), ex); 
            }
            cmd.Parameters.Clear();
            con.CerrarConexion();
        }
        #endregion

        #region ELIMINAR
        public void CD_ELIMINAR(CE_RS_ENTIDAD ce_rs_entidad)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ELIMINAR_RS_ENTIDAD",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("v_rse_id", ce_rs_entidad.CE_RSE_ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar entidad." + Environment.NewLine + ex.Message.ToString(), ex);
            }
            cmd.Parameters.Clear();
            con.CerrarConexion();

        }

        #endregion

        //---------------------------------------------------------------------

        #region CARGAR DATOS VISTA MANTENEDOR CLIENTES
        public DataTable CargarEntidad()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_ENTIDAD JOIN RS_TIPO_ENTIDAD ON " +
                    "rs_tipo_entidad.rste_id = rs_entidad.rs_tipo_entidad_rste_id JOIN RS_COMUNA ON rs_comuna.rsc_id = rs_entidad.rs_comuna_rsc_id " +
                    "JOIN RS_ESTADO ON rs_estado.rses_id = rs_entidad.rs_estado_rses_id " +
                    "LEFT JOIN RS_USUARIO ON rs_usuario.RS_ENTIDAD_RSE_ID = rs_entidad.rse_id ORDER BY RSE_ID", con.AbrirConexion());
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

                throw ex;
            }
            
        }
        #endregion

        #region OBTENER ID RS_ENTIDAD
        public int ObtenerRSE_ID(string rse_rut)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_OBTENER_RSE_ID",
                CommandType = CommandType.StoredProcedure
            };


            cmd.Parameters.Add("v_rse_rut", rse_rut);
            cmd.Parameters.Add("v_rse_id", OracleDbType.Int32, ParameterDirection.Output);

            cmd.ExecuteNonQuery();

            string valor = cmd.Parameters["v_rse_id"].Value.ToString();

            int v_rse_id = int.Parse(valor);

            cmd.Parameters.Clear();
            con.CerrarConexion();

            return v_rse_id;
        }
        #endregion

    }
}
