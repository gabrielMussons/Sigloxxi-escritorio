﻿using System;
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
                cmd.Parameters.Add("V_RSD_HORA_ENTREGA", OracleDbType.Date).Value = RS_DOCTO.CE_RSD_HORA_ENTREGA;
                cmd.Parameters.Add("V_RSD_PROPINA", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_PROPINA;
                cmd.Parameters.Add("V_RSD_TOTAL", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_TOTAL;
                cmd.Parameters.Add("V_RSD_OBS", OracleDbType.Varchar2).Value = RS_DOCTO.CE_RSD_OBS;
                cmd.Parameters.Add("V_RS_TIPO_DOCUMENTO_RSTD_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_TIPO_DOCUMENTO_RSTD_ID;
                cmd.Parameters.Add("V_RS_DET_DOCTO_RSDET_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_DET_DOCTO_RSDET_ID;
                cmd.Parameters.Add("V_RS_ENTIDAD_RSE_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_ENTIDAD_RSE_ID;
                cmd.Parameters.Add("V_RS_MESA_RSM_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_MESA_RSM_ID;
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

                ce_rs_docto.CE_RSD_ID = Convert.ToInt32(row[0]);
                ce_rs_docto.CE_RSD_DSCTO = Convert.ToInt32(row[1]);
                ce_rs_docto.CE_RSD_FECHA_HORA = Convert.ToDateTime(row[2]);
                ce_rs_docto.CE_RSD_HORA_ENTREGA = Convert.ToDateTime(row[3]);
                ce_rs_docto.CE_RSD_PROPINA = Convert.ToInt32(row[4]);
                ce_rs_docto.CE_RSD_TOTAL = Convert.ToInt32(row[5]);
                ce_rs_docto.CE_RSD_OBS = Convert.ToString(row[6]);
                ce_rs_docto.CE_RS_TIPO_DOCUMENTO_RSTD_ID = Convert.ToInt32(row[7]);
                ce_rs_docto.CE_RS_DET_DOCTO_RSDET_ID = Convert.ToInt32(row[8]);
                ce_rs_docto.CE_RS_ENTIDAD_RSE_ID = Convert.ToInt32(row[9]);
                ce_rs_docto.CE_RS_MESA_RSM_ID = Convert.ToInt32(row[10]);
                ce_rs_docto.CE_RS_ESTADO_RSES_ID = Convert.ToInt32(row[7]);
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
                cmd.Parameters.Add("V_RSD_DSCTO", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_ID;
                cmd.Parameters.Add("V_RSD_DSCTO", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_DSCTO;
                cmd.Parameters.Add("V_RSD_FECHA_HORA", OracleDbType.Date).Value = RS_DOCTO.CE_RSD_FECHA_HORA;
                cmd.Parameters.Add("V_RSD_HORA_ENTREGA", OracleDbType.Date).Value = RS_DOCTO.CE_RSD_HORA_ENTREGA;
                cmd.Parameters.Add("V_RSD_PROPINA", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_PROPINA;
                cmd.Parameters.Add("V_RSD_TOTAL", OracleDbType.Int32).Value = RS_DOCTO.CE_RSD_TOTAL;
                cmd.Parameters.Add("V_RSD_OBS", OracleDbType.Varchar2).Value = RS_DOCTO.CE_RSD_OBS;
                cmd.Parameters.Add("V_RS_TIPO_DOCUMENTO_RSTD_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_TIPO_DOCUMENTO_RSTD_ID;
                cmd.Parameters.Add("V_RS_DET_DOCTO_RSDET_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_DET_DOCTO_RSDET_ID;
                cmd.Parameters.Add("V_RS_ENTIDAD_RSE_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_ENTIDAD_RSE_ID;
                cmd.Parameters.Add("V_RS_MESA_RSM_ID", OracleDbType.Int32).Value = RS_DOCTO.CE_RS_MESA_RSM_ID;
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

        #region OBTENER DATATABLE
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

        #region ACTUALIZAR ESTADO DETALLE PEDIDO
        public void CD_ACTUALIZAR_ESTADO_DET_PED(int id_detalle)
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
        #region RETRASAR ESTADO DETALLE PEDIDO
        public void CD_RETRASAR_ESTADO_DET_PED(int id_detalle)
        {
            OracleCommand cmd = new OracleCommand
            {
                Connection = con.AbrirConexion(),
                CommandText = "retrasar_estado_detalle_docto",
                CommandType = CommandType.StoredProcedure,
            };
            try
            {
                cmd.Parameters.Add("V_RSDET_ID", id_detalle);
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