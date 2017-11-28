using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace EntidadesHechas
{
    public static class PaqueteDAO
    {
        static SqlConnection cn;
        static SqlCommand cmd;

        static PaqueteDAO()
        {
            cn = new SqlConnection(@"Data Source=LAB3PC02\SQLEXPRESS;Initial Catalog=correo-sp-2017;Integrated Security=True");            
        }

        public static bool Insertar(Paquete p)
        {
            bool auxReturn = false;
            try
            {                
                cmd = new SqlCommand("INSERT INTO dbo.Paquetes (direccionEntrega,trackingID,alumno) VALUES ('" + p.DireccionEntrega + "','" + p.TrackingID + "','Mauricio Cerizza 2C')", cn);
                cn.Open(); 
                cmd.ExecuteNonQuery(); //Hace que se ejecute la secuencia cmd.             
                auxReturn = true;
            }
            catch (Exception)
            {                
                throw;
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
            }
            return auxReturn;
        }
        
    }
}
