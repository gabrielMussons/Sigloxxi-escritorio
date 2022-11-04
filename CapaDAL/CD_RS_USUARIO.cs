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
    public class CD_RS_USUARIO
    {
        //---------------------------------------------------------------------

        #region VARIABLES
        private readonly CD_ConexionBD con = new CD_ConexionBD();
        private readonly CE_RS_USUARIO ce_rs_usuario = new CE_RS_USUARIO();
        #endregion

        //---------------------------------------------------------------------

        #region CREAR RS_USUARIO
        public void CD_INSERTAR(CE_RS_USUARIO RS_USUARIO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_INSERTAR_RS_USUARIO",
                CommandType = CommandType.StoredProcedure,
            };

            try
            {
                cmd.Parameters.Add("v_rsu_usuario", OracleDbType.Varchar2).Value = RS_USUARIO.CE_RSU_USUARIO;
                cmd.Parameters.Add("v_rsu_pass", OracleDbType.Varchar2).Value = RS_USUARIO.CE_RSU_PASS;
                cmd.Parameters.Add("v_rs_entidad_rse_id", OracleDbType.Int32).Value = RS_USUARIO.CE_RS_ENTIDAD_RSE_ID;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al insertar usuario." + Environment.NewLine + ex.Message.ToString(), ex);
            }

            cmd.Parameters.Clear();
            con.CerrarConexion();

        }
        #endregion

        #region CONSULTAR RS_USUARIO
        public CE_RS_USUARIO CD_CONSULTAR(int rs_entidad_rse_id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_USUARIO WHERE RS_ENTIDAD_RSE_ID =" + rs_entidad_rse_id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_usuario.CE_RS_ENTIDAD_RSE_ID = Convert.ToInt32(row[0]);
                ce_rs_usuario.CE_RSU_USUARIO = Convert.ToString(row[1]);
                ce_rs_usuario.CE_RSU_PASS = Convert.ToString(row[2]);
                ce_rs_usuario.CE_RS_ENTIDAD_RSE_ID = Convert.ToInt32(row[3]);
            }
            catch (Exception ex)
            {

                throw new Exception("No registra usuario.");
            }
            con.CerrarConexion();
            return ce_rs_usuario;

        }
        #endregion

        #region ACTUALIZAR RS_USUARIO
        public void CD_ACTUALIZAR(CE_RS_USUARIO RS_USUARIO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ACTUALIZAR_RS_USUARIO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("v_rsu_usuario", OracleDbType.Varchar2).Value = RS_USUARIO.CE_RSU_USUARIO;
                cmd.Parameters.Add("v_rsu_pass", OracleDbType.Varchar2).Value = RS_USUARIO.CE_RSU_PASS;
                cmd.Parameters.Add("v_rs_entidad_rse_id", OracleDbType.Int32).Value = RS_USUARIO.CE_RS_ENTIDAD_RSE_ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al actualizar usuario." + Environment.NewLine + ex.Message.ToString(), ex);
            }
            cmd.Parameters.Clear();
            con.CerrarConexion();

        }
        #endregion

        #region ELIMINAR RS_USUARIO
        public void CD_ELIMINAR(CE_RS_USUARIO ce_rs_usuario)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ELIMINAR_RS_USUARIO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("v_rs_entidad_rse_id", ce_rs_usuario.CE_RS_ENTIDAD_RSE_ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar usuario." + Environment.NewLine + ex.Message.ToString(), ex);
            }
            cmd.Parameters.Clear();
            con.CerrarConexion();

        }

        #endregion

        //---------------------------------------------------------------------
    }
}
