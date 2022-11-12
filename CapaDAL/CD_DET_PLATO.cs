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
    public class CD_DET_PLATO
    {
        //---------------------------------------------------------------------

        #region VARIABLES
        private readonly CD_ConexionBD con = new CD_ConexionBD();
        private readonly CE_RS_DET_PLATO ce_rs_det_plato = new CE_RS_DET_PLATO();
        #endregion

        //---------------------------------------------------------------------

        #region CREAR 
        public void CD_INSERTAR(CE_RS_DET_PLATO RS_DET_PLATO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_INSERTAR_RS_DET_PLATO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSDPL_CANTIDAD", OracleDbType.Int32).Value = RS_DET_PLATO.RSDPL_CANTIDAD;
                cmd.Parameters.Add("V_RS_PRODUCTO_RSP_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RS_PRODUCTO_RSP_ID;
                cmd.Parameters.Add("V_RS_PLATO_RSPL_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RS_PLATO_RSPL_ID;
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

        #region CONSULTAR 
        public CE_RS_DET_PLATO CD_CONSULTAR(int id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_DET_PLATO WHERE RSDPL_ID =" + id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_det_plato.RSDPL_ID = Convert.ToInt32(row[0]);
                ce_rs_det_plato.RSDPL_CANTIDAD = Convert.ToInt32(row[1]);
                ce_rs_det_plato.RS_PRODUCTO_RSP_ID = Convert.ToInt32(row[2]);
                ce_rs_det_plato.RS_PLATO_RSPL_ID = Convert.ToInt32(row[3]);
                con.CerrarConexion();
                return ce_rs_det_plato;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion

        #region ACTUALIZAR 
        public void CD_ACTUALIZAR(CE_RS_DET_PLATO RS_DET_PLATO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ACTUALIZAR_RS_DET_PLATO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSDPL_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RSDPL_ID;
                cmd.Parameters.Add("V_RSDPL_CANTIDAD", OracleDbType.Int32).Value = RS_DET_PLATO.RSDPL_CANTIDAD;
                cmd.Parameters.Add("V_RS_PRODUCTO_RSP_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RS_PRODUCTO_RSP_ID;
                cmd.Parameters.Add("V_RS_PLATO_RSPL_ID", OracleDbType.Int32).Value = RS_DET_PLATO.RS_PLATO_RSPL_ID;
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
        public void CD_ELIMINAR(CE_RS_DET_PLATO RS_DET_PLATO)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ELIMINAR_RS_DET_PLATO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSDPL_ID", RS_DET_PLATO.RSDPL_ID);
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

        #region CARGAR DATOS LISTA
        public DataTable CargarDetPlato(int id_plato)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_DET_PLATO" +
                    "WHERE RS_PLATO_RSPL_ID = "+id_plato+" ORDER BY RSDPL_ID", con.AbrirConexion());
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


    }
}
