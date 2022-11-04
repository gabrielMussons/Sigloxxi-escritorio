using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace CapaDAL
{
    public class CD_ConexionBD
    {
        
        private readonly OracleConnection con = new OracleConnection(StaticClass.connectionString);

        public OracleConnection AbrirConexion()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return con;
            }
            catch (Exception ex)
            {

                throw new Exception("No se puede establecer conexión con el servidor.",ex);
            }
            
        }

        public OracleConnection CerrarConexion()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return con;
            }
            catch (Exception ex)
            {

                throw new Exception("No se puede terminar conexión con el servidor.", ex); ;
            }
            
        }
    }
}
