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
    public class CD_RS_DOCTO
    {
        //---------------------------------------------------------------------

        #region VARIABLES
        private readonly CD_ConexionBD con = new CD_ConexionBD();
        private readonly CE_RS_DOCTO ce_rs_docto = new CE_RS_DOCTO();
        #endregion

        //---------------------------------------------------------------------

        #region CREAR 
        public void CD_INSERTAR(CE_RS_DOCTO RS_DOCTO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_INSERTAR_RS_DOCTO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                
                cmd.Parameters.Add("V_RSD_DSCTO", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_DSCTO;
                cmd.Parameters.Add("V_RSD_FECHA_HORA", OracleDbType.Date).Value = RS_DOCTO.CE_RSD_FECHA_HORA;
                if (RS_DOCTO.CE_RSD_HORA_ENTREGA.ToShortDateString() == DateTime.MinValue.ToShortDateString())
                {
                    cmd.Parameters.Add("V_RSD_HORA_ENTREGA", OracleDbType.Date).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("V_RSD_HORA_ENTREGA", OracleDbType.Date).Value = RS_DOCTO.CE_RSD_HORA_ENTREGA;
                }
                cmd.Parameters.Add("V_RSD_PROPINA", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_PROPINA;
                cmd.Parameters.Add("V_RSD_TOTAL", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_TOTAL;
                cmd.Parameters.Add("V_RSD_OBS", OracleDbType.Varchar2).Value = RS_DOCTO.CE_RSD_OBS;
                cmd.Parameters.Add("V_RS_TIPO_DOCUMENTO_RSTD_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_TIPO_DOCUMENTO_RSTD_ID;
                cmd.Parameters.Add("V_RS_ENTIDAD_RSE_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_ENTIDAD_RSE_ID;
                if (RS_DOCTO.CE_RS_MESA_RSM_ID != 0)
                {
                    cmd.Parameters.Add("V_RS_MESA_RSM_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_MESA_RSM_ID;
                }
                else
                {
                    cmd.Parameters.Add("V_RS_MESA_RSM_ID", OracleDbType.Int32).Value = null;
                }
                cmd.Parameters.Add("V_RS_ESTADO_RSES_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_ESTADO_RSES_ID;

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
        public CE_RS_DOCTO CD_CONSULTAR(int id)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT * FROM RS_DOCTO WHERE RSD_ID =" + id, con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                if (row[0] != DBNull.Value)
                {
                    ce_rs_docto.CE_RSD_ID = Convert.ToInt32(row[0]);
                }
                if (row[1] != DBNull.Value)
                {
                    ce_rs_docto.CE_RSD_DSCTO = Convert.ToInt32(row[1]);
                }
                if (row[2] != DBNull.Value)
                {
                    ce_rs_docto.CE_RSD_FECHA_HORA = Convert.ToDateTime(row[2]);
                }
                if (row[3] != DBNull.Value)
                {
                    ce_rs_docto.CE_RSD_HORA_ENTREGA = Convert.ToDateTime(row[3]);
                }
                if (row[4] != DBNull.Value)
                {
                    ce_rs_docto.CE_RSD_PROPINA = Convert.ToInt32(row[4]);
                }
                if (row[5] != DBNull.Value)
                {
                    ce_rs_docto.CE_RSD_TOTAL = Convert.ToInt32(row[5]);
                }
                if (row[6] != DBNull.Value)
                {
                    ce_rs_docto.CE_RSD_OBS = Convert.ToString(row[6]);
                }
                if (row[7] != DBNull.Value)
                {
                    ce_rs_docto.CE_RS_TIPO_DOCUMENTO_RSTD_ID = Convert.ToInt32(row[7]);
                }
                if (row[8] != DBNull.Value)
                {
                    ce_rs_docto.CE_RS_ENTIDAD_RSE_ID = Convert.ToInt32(row[8]);
                }
                if (row[9] != DBNull.Value)
                {
                    ce_rs_docto.CE_RS_MESA_RSM_ID = Convert.ToInt32(row[9]);
                }
                if (row[10] != DBNull.Value)
                {
                    ce_rs_docto.CE_RS_ESTADO_RSES_ID = Convert.ToInt32(row[10]);
                }
                
                
                con.CerrarConexion();
                return ce_rs_docto;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }

        }
        #endregion

        #region ACTUALIZAR
        public void CD_ACTUALIZAR(CE_RS_DOCTO RS_DOCTO)
        {
            OracleCommand cmd = new OracleCommand()
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ACTUALIZAR_RS_DOCTO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSD_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_ID;
                cmd.Parameters.Add("V_RSD_DSCTO", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_DSCTO;
                cmd.Parameters.Add("V_RSD_FECHA_HORA", OracleDbType.Date).Value = RS_DOCTO.CE_RSD_FECHA_HORA;
                if (RS_DOCTO.CE_RSD_HORA_ENTREGA.ToShortDateString() == DateTime.MinValue.ToShortDateString())
                {
                    cmd.Parameters.Add("V_RSD_HORA_ENTREGA", OracleDbType.Date).Value = null;
                }
                else
                {
                    cmd.Parameters.Add("V_RSD_HORA_ENTREGA", OracleDbType.Date).Value = RS_DOCTO.CE_RSD_HORA_ENTREGA;
                }
                cmd.Parameters.Add("V_RSD_PROPINA", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_PROPINA;
                cmd.Parameters.Add("V_RSD_TOTAL", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_TOTAL;
                cmd.Parameters.Add("V_RSD_OBS", OracleDbType.Varchar2).Value = RS_DOCTO.CE_RSD_OBS;
                cmd.Parameters.Add("V_RS_TIPO_DOCUMENTO_RSTD_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_TIPO_DOCUMENTO_RSTD_ID;
                cmd.Parameters.Add("V_RS_ENTIDAD_RSE_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_ENTIDAD_RSE_ID;
                if (RS_DOCTO.CE_RS_MESA_RSM_ID!=0)
                {
                    cmd.Parameters.Add("V_RS_MESA_RSM_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_MESA_RSM_ID;
                }
                else
                {
                    cmd.Parameters.Add("V_RS_MESA_RSM_ID", OracleDbType.Int32).Value = null;
                }
                cmd.Parameters.Add("V_RS_ESTADO_RSES_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_ESTADO_RSES_ID;

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
        public void CD_ELIMINAR(CE_RS_DOCTO RS_DOCTO)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "SP_ELIMINAR_RS_DOCTO",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSD_ID", RS_DOCTO.CE_RSD_ID);
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
        #region OBTENER ULTIMO REGISTRO
        public CE_RS_DOCTO ObtenerUltimoRegistro() {
            try
            {
                OracleCommand cmd = new OracleCommand("select rsd_id  from rs_docto where rsd_id =(select max(rsd_id)from rs_docto) ", con.AbrirConexion());
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt;
                dt = ds.Tables[0];
                DataRow row = dt.Rows[0];

                ce_rs_docto.CE_RSD_ID = Convert.ToInt32(row[0]);
                con.CerrarConexion();
                return ce_rs_docto;
            }
            catch (Exception ex)
            {
                con.CerrarConexion();
                throw ex;
            }
        }
        #endregion

        #region OBTENER DATATABLE PEDIDOS
        public DataTable CargarPedidos()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("select rs_docto.rsd_id,rs_plato.rspl_descripcion,rs_entidad.rse_nombre,rs_docto.rs_mesa_rsm_id,rs_estado.rses_descripcion,rs_det_docto.rsdet_id " +
                    "from rs_docto join rs_entidad on rs_docto.rs_entidad_rse_id = rs_entidad.rse_id " +
                    "join rs_det_docto on rs_docto.rsd_id = rs_det_docto.rs_docto_rsd_id " +
                    "join rs_plato on rs_det_docto.rs_plato_rspl_id = rs_plato.rspl_id " +
                    "join rs_estado on rs_det_docto.rs_estado_rses_id = rs_estado.rses_id " +
                    "where rs_det_docto.rs_estado_rses_id = 61 or rs_det_docto.rs_estado_rses_id = 62 " +
                    "or rs_det_docto.rs_estado_rses_id = 63 order by rs_det_docto.rs_estado_rses_id desc", con.AbrirConexion());
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

        #region OBTENER DATATABLE CARTA
        public DataTable CargarCarta()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("Select rs_docto.rsd_id as ID_CARTA,(TO_CHAR(rs_docto.rsd_fecha_hora, 'DD-MM-YY')) as FECHA_SOLICITUD,rs_docto.rsd_obs as OBSERVACIONES," +
                    "rs_entidad.rse_nombre as NOMBRE_SOLIC,rs_estado.rses_descripcion as ESTADO FROM RS_DOCTO JOIN RS_ENTIDAD " +
                    "ON rs_docto.rs_entidad_rse_id = rs_entidad.rse_id JOIN RS_ESTADO on rs_docto.rs_estado_rses_id = rs_estado.rses_id JOIN RS_TIPO_DOCUMENTO " +
                    "on rs_docto.rs_tipo_documento_rstd_id = rs_tipo_documento.rstd_id WHERE upper(rs_tipo_documento.rstd_descripcion) = 'CARTA' order by FECHA_SOLICITUD desc"
                    /*" AND rs_docto.rsd_fecha_hora >= (TO_CHAR(SYSDATE, 'DD-MM-YY')) "*/, con.AbrirConexion());
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

        #region OBTENER DATATABLE BOLETAS
        public DataTable CargarBoletas()
        {
            try
            {
                OracleCommand cmd = new OracleCommand("select rs_det_docto.rs_docto_rsd_id as ID_BOLETA," +
                    " rs_docto.rsd_fecha_hora as FECHA, sum(rs_det_docto.rsdet_egreso) as CANT_ITEMS, SUM" +
                    "(rs_plato.rspl_pventa * rs_det_docto.rsdet_egreso) as TOTAL, rs_estado.rses_descripcion as" +
                    " ESTADO, rs_entidad.rse_nombre as NOMBRE_CLIENTE, rs_entidad.rse_ap_pat as APELLIDO_PAT," +
                    " rs_entidad.rse_rut as RUT_CLIENTE from rs_det_docto join rs_plato on rs_det_docto.rs_plato_rspl_id " +
                    "= rs_plato.rspl_id join rs_tipo_documento on rs_det_docto.rs_tipo_documento_rstd_id = rs_tipo_documento.rstd_id " +
                    "join rs_docto on rs_det_docto.rs_docto_rsd_id = rs_docto.rsd_id join rs_estado on " +
                    "rs_docto.rs_estado_rses_id = rs_estado.rses_id join rs_entidad on rs_docto.rs_entidad_rse_id = " +
                    "rs_entidad.rse_id where upper(rs_tipo_documento.rstd_descripcion) = 'BOLETA' and rs_docto.rs_estado_rses_id = " +
                    "1 group by rs_det_docto.rs_docto_rsd_id, rs_docto.rsd_fecha_hora, rs_estado.rses_descripcion, rs_entidad.rse_nombre, " +
                    "rs_entidad.rse_ap_pat, rs_entidad.rse_rut ", con.AbrirConexion());
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

        #region OBTENER DATATABLE DETALLE BOLETAS
        public DataTable CargarDetalleBoleta(int id_boleta)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("select rs_det_docto.rs_docto_rsd_id as ID_BOLETA, " +
                    "rs_plato.rspl_descripcion as PLATO, rs_det_docto.rsdet_egreso as CANTIDAD, " +
                    "rs_plato.rspl_pventa as PRECIO_UNITARIO from rs_det_docto join rs_plato " +
                    "on rs_det_docto.rs_plato_rspl_id = rs_plato.rspl_id join rs_tipo_documento " +
                    "on rs_det_docto.rs_tipo_documento_rstd_id = rs_tipo_documento.rstd_id " +
                    "where upper(rs_tipo_documento.rstd_descripcion) = 'BOLETA' and rs_det_docto.rs_docto_rsd_id = "+ id_boleta, con.AbrirConexion());
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

        #region OBTENER DATATABLE TOTAL BOLETA
        public DataTable CargarTotalBoleta(int id_boleta)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("select rs_det_docto.rs_docto_rsd_id as ID_BOLETA," +
                    " rs_docto.rsd_fecha_hora as FECHA, sum(rs_det_docto.rsdet_egreso) as CANT_ITEMS, SUM" +
                    "(rs_plato.rspl_pventa * rs_det_docto.rsdet_egreso) as TOTAL, rs_estado.rses_descripcion as" +
                    " ESTADO, rs_entidad.rse_nombre as NOMBRE_CLIENTE, rs_entidad.rse_ap_pat as APELLIDO_PAT," +
                    " rs_entidad.rse_rut as RUT_CLIENTE from rs_det_docto join rs_plato on rs_det_docto.rs_plato_rspl_id " +
                    "= rs_plato.rspl_id join rs_tipo_documento on rs_det_docto.rs_tipo_documento_rstd_id = rs_tipo_documento.rstd_id " +
                    "join rs_docto on rs_det_docto.rs_docto_rsd_id = rs_docto.rsd_id join rs_estado on " +
                    "rs_docto.rs_estado_rses_id = rs_estado.rses_id join rs_entidad on rs_docto.rs_entidad_rse_id = " +
                    "rs_entidad.rse_id where upper(rs_tipo_documento.rstd_descripcion) = 'BOLETA' and rs_docto.rsd_id ="+id_boleta +
                    " group by rs_det_docto.rs_docto_rsd_id, rs_docto.rsd_fecha_hora, rs_estado.rses_descripcion, rs_entidad.rse_nombre, " +
                    "rs_entidad.rse_ap_pat, rs_entidad.rse_rut ", con.AbrirConexion());
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
