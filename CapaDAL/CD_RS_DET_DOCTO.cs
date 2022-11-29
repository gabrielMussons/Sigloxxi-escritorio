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
    public class CD_RS_DET_DOCTO
    {
        //---------------------------------------------------------------------

        #region VARIABLES
        private readonly CD_ConexionBD con = new CD_ConexionBD();
        private readonly CE_RS_DET_DOCTO ce_rs_det_docto = new CE_RS_DET_DOCTO();
        #endregion

        //---------------------------------------------------------------------
        #region CREAR 
        public void CD_INSERTAR(CE_RS_DET_DOCTO RS_DET_DOCTO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_INSERTAR_RS_DET_DOCTO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                if (RS_DET_DOCTO.CE_RSDET_INGRESO !=0)
                {
                    cmd.Parameters.Add("V_RSDET_INGRESO", OracleDbType.Int32).Value = RS_DET_DOCTO.CE_RSDET_INGRESO;
                }
                else
                {
                    cmd.Parameters.Add("V_RSDET_INGRESO", OracleDbType.Int32).Value = null;
                }
                if (RS_DET_DOCTO.CE_RSDET_EGRESO != 0)
                {
                    cmd.Parameters.Add("V_RSDET_EGRESO", OracleDbType.Int32).Value = RS_DET_DOCTO.CE_RSDET_EGRESO;
                }
                else
                {
                    cmd.Parameters.Add("V_RSDET_EGRESO", OracleDbType.Int32).Value = null;
                }
                if (RS_DET_DOCTO.CE_RS_PRODUCTO_RSP_ID != 0)
                {
                    cmd.Parameters.Add("V_RS_PRODUCTO_RSP_ID", OracleDbType.Int32).Value = RS_DET_DOCTO.CE_RS_PRODUCTO_RSP_ID;
                }
                else
                {
                    cmd.Parameters.Add("V_RS_PRODUCTO_RSP_ID", OracleDbType.Int32).Value = null;
                }
                if (RS_DET_DOCTO.CE_RS_BODEGA_RSB_ID != 0)
                {
                    cmd.Parameters.Add("V_RS_BODEGA_RSB_ID", OracleDbType.Int32).Value = RS_DET_DOCTO.CE_RS_BODEGA_RSB_ID;
                }
                else
                {
                    cmd.Parameters.Add("V_RS_BODEGA_RSB_ID", OracleDbType.Int32).Value = null;
                }
                if (RS_DET_DOCTO.CE_RS_PLATO_RSPL_ID != 0)
                {
                    cmd.Parameters.Add("V_RS_PLATO_RSPL_ID", OracleDbType.Int32).Value = RS_DET_DOCTO.CE_RS_PLATO_RSPL_ID;
                }
                else
                {
                    cmd.Parameters.Add("V_RS_PLATO_RSPL_ID", OracleDbType.Int32).Value = null;
                }
                
                cmd.Parameters.Add("V_RS_TIPO_DOCUMENTO_RSTD_ID", OracleDbType.Int32).Value = RS_DET_DOCTO.CE_RS_TIPO_DOCUMENTO_RSTD_ID;
                cmd.Parameters.Add("V_RS_ESTADO_RSES_ID", OracleDbType.Int32).Value = RS_DET_DOCTO.CE_RS_ESTADO_RSES_ID;
                cmd.Parameters.Add("V_RS_DOCTO_RSD_ID", OracleDbType.Int32).Value = RS_DET_DOCTO.CE_RS_DOCTO_RSD_ID;


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
        public CE_RS_DET_DOCTO CD_CONSULTAR(int id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_DET_DOCTO WHERE RSDET_ID =" + id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_det_docto.CE_RSDET_ID = Convert.ToInt32(row[0]);
                if (row[1] != DBNull.Value)
                {
                    ce_rs_det_docto.CE_RSDET_INGRESO = Convert.ToInt32(row[1]);
                }
                if (row[2] != DBNull.Value)
                {
                    ce_rs_det_docto.CE_RSDET_EGRESO = Convert.ToInt32(row[2]);
                }
                if (row[3] != DBNull.Value)
                {
                    ce_rs_det_docto.CE_RS_PRODUCTO_RSP_ID = Convert.ToInt32(row[3]);
                }
                if (row[4] != DBNull.Value)
                {
                    ce_rs_det_docto.CE_RS_BODEGA_RSB_ID = Convert.ToInt32(row[4]);
                }
                if (row[5] != DBNull.Value)
                {
                    ce_rs_det_docto.CE_RS_PLATO_RSPL_ID = Convert.ToInt32(row[5]);
                }
                if (row[6] != DBNull.Value)
                {
                    ce_rs_det_docto.CE_RS_TIPO_DOCUMENTO_RSTD_ID = Convert.ToInt32(row[6]);
                }
                if (row[7] != DBNull.Value)
                {
                    ce_rs_det_docto.CE_RS_ESTADO_RSES_ID = Convert.ToInt32(row[7]);
                }
                if (row[8] != DBNull.Value)
                {
                    ce_rs_det_docto.CE_RS_DOCTO_RSD_ID = Convert.ToInt32(row[8]);
                }


                con.CerrarConexion();
                return ce_rs_det_docto;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion




        //---------------------------------------------------------------------
        #region Obtener ingreso e egreso detalle documento 
        public CE_RS_DET_DOCTO ObtenerIngresoEgresoDetPlatoCarta(int id_plato, int id_carta)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT RS_DET_DOCTO.RSDET_INGRESO,RS_DET_DOCTO.RSDET_EGRESO FROM RS_DET_DOCTO WHERE RS_PLATO_RSPL_ID =" + id_plato + " and RS_DOCTO_RSD_ID =" + id_carta, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                if (row[0] != DBNull.Value )
                {
                    ce_rs_det_docto.CE_RSDET_INGRESO = Convert.ToInt32(row[0]);
                }
                if (row[1] != DBNull.Value )
                {
                    ce_rs_det_docto.CE_RSDET_EGRESO = Convert.ToInt32(row[1]);
                }

                con.CerrarConexion();
                return ce_rs_det_docto;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion


        #region OBTENER DETALLE CARTA
        public DataTable CargarDetalleCarta(int id_docto)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("select rs_det_docto.rsdet_id as ID_DET_CARTA, rs_plato.rspl_descripcion as PLATO, rs_det_docto.rsdet_egreso as CANTIDAD," +
                    " rs_estado.rses_descripcion as ESTADO,rs_det_docto.rs_plato_rspl_id as ID_PLATO from rs_det_docto join rs_plato on rs_det_docto.rs_plato_rspl_id = rs_plato.rspl_id join rs_estado on rs_det_docto.rs_estado_rses_id" +
                    " = rs_estado.rses_id join rs_docto on rs_det_docto.rs_docto_rsd_id = rs_docto.rsd_id where rs_docto.rsd_id = "+id_docto, con.AbrirConexion());
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


        #region ACTUALIZAR ESTADO DETALLE DOCTO
        public void CD_ACTUALIZAR_ESTADO_DET_DOCTO(int id_detalle, int id_estado)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "actualizar_estado_detalle_docto",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSDET_ID", id_detalle);
                cmd.Parameters.Add("V_RSES_ID", id_estado);
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




    }
}
