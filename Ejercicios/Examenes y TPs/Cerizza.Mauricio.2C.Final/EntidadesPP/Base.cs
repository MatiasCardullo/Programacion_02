using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EntidadesPP
{
    public abstract class Base
    {
        private static int subversion;
        private static int version;
        
        public string Version
        {
            get
            {
                return Base.version.ToString();
            }
            set
            {
                int nuevoValor;
                if (int.TryParse(value, out nuevoValor))
                {
                    Base.version = nuevoValor;
                }
            }
        }       

        public abstract string VersionFull { get; }

        static Base()
        {
            Base.version = 1;
            Base.subversion = 0;
        }

        public Base(int version, int subversion)
        {
            Base.version = version;
            Base.subversion = subversion;
        }

        protected virtual string MostrarVersion()
        {
            return String.Format("{0}.{1}", Base.version, Base.subversion);        
        }

        public static string operator ~(Base b)
        {
            return String.Format("{0}.{1}", Base.subversion, Base.version);  
        }

        public override int GetHashCode()
        {
            return (Base.version + Base.subversion);
        }

        
        static bool GuardarDatos<T>(T dato)
            where T : Base
        {
            SqlConnection cn = null;
            SqlCommand cmd;
            bool retorno = false;
            try
            {
                cn = new SqlConnection(@"Data Source=LAB3PC01\SQLEXPRESS;Initial Catalog=final-20171207;Integrated Security=True");
                cn.Open();
                cmd = new SqlCommand("INSERT INTO dbo.Datos(version,subversion) VALUES (" + version.ToString() + "," + subversion.ToString() + ")", cn);
                cmd.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn != null)
                    cn.Close();                
            }
            return retorno;
        }

        static Queue<T> LeerDatos<T>()
            where T : Base
        {
            Queue<T> cola = new Queue<T>();
            SqlConnection cn = null;
            SqlCommand cmd;
            SqlDataReader dr;
            bool retorno = false;
            try
            {
                cn = new SqlConnection(@"Data Source=LAB3PC01\SQLEXPRESS;Initial Catalog=final-20171207;Integrated Security=True");
                cn.Open();
                cmd = new SqlCommand("SELECT version,subversion,revision FROM dbo.Datos");
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DerivadaUno d = new DerivadaUno(int.Parse(dr["version"].ToString()), int.Parse(dr["subversion"].ToString()), int.Parse(dr["revision"].ToString()));
                    //cola.Enqueue(d);
                }
                retorno = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cn != null)
                    cn.Close();
            }
            return cola;
        }

        void EjecutarEvento(List<Base> list)
        {
            foreach (Base b in list)
            {
                Base.GuardarDatos<Base>(b);

            }
        }
    }
}
