using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Lab_II
{
    class Grupo
    {
        public enum TipoManada {unica, mixta}
        private List<Mascota> manada;
        private string nombre;
        private static TipoManada tipo;

        #region Propiedades
        /// <summary>
        /// Propiedad de sólo escritura para establecer el tipo de manada.
        /// </summary>
        public TipoManada Tipo { set { Grupo.tipo = value; } }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de clase. Establece el tipo de manada como única.
        /// </summary>
        static Grupo()
        {
            Grupo.tipo = TipoManada.unica;
        }

        /// <summary>
        /// Constructor privado. El único que inicializa la lista de mascotas. 
        /// </summary>
        private Grupo()
        {
            this.manada = new List<Mascota>();
        }

        /// <summary>
        /// Constructor público.
        /// </summary>
        /// <param name="nombre">Nombre de la manada</param>
        public Grupo(string nombre):this()
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Constructor público. 
        /// </summary>
        /// <param name="nombre">Nombre de la manada</param>
        /// <param name="tipo">Tipo de manada</param>
        public Grupo(string nombre, TipoManada tipo):this(nombre)
        {
            this.Tipo = tipo;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Conversión implícita a string de la información de la manada completa.
        /// </summary>
        /// <param name="e">Grupo/Manada cuya información hay que convertir a formato string</param>
        public static implicit operator string(Grupo e)
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendFormat("**{0} {1}**", e.nombre, Grupo.tipo);
            datos.AppendLine("\nIntegrantes:");
            foreach(Mascota mascota in e.manada)
            {
                datos.AppendLine(mascota.ToString());
            }
            return datos.ToString();
        }

        /// <summary>
        /// Un grupo será igual a una mascota si esta forma parte de la lista.
        /// </summary>
        /// <param name="e">Grupo con la lista de mascotas.</param>
        /// <param name="j">Mascota a analizar si está en la lista.</param>
        /// <returns></returns>
        public static bool operator ==(Grupo e, Mascota j)
        {
            bool retorno = false;
            foreach (Mascota mascota in e.manada)
            {
                if (j.Equals(mascota))
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Un grupo será distinto a una mascota si esta NO forma parte de la lista.
        /// </summary>
        /// <param name="e">Grupo con la lista de mascotas.</param>
        /// <param name="j">Mascota a analizar si está en la lista.</param>
        /// <returns></returns>
        public static bool operator !=(Grupo e, Mascota j)
        { return !(e == j); }

        /// <summary>
        /// Si una mascota no forma parte de la lista, se la agregará.
        /// </summary>
        /// <param name="e">Grupo con la lista de mascotas.</param>
        /// <param name="j">Mascota a agregar a la lista.</param>
        /// <returns></returns>
        public static Grupo operator +(Grupo e, Mascota j)
        {
            if (e != j)
            {
                e.manada.Add(j);
            }
            return e;
        }

        /// <summary>
        /// Si una mascota forma parte de la lista, se la quitará.
        /// </summary>
        /// <param name="e">Grupo con la lista de mascotas.</param>
        /// <param name="j">Mascota a quitar de la lista.</param>
        /// <returns></returns>
        public static Grupo operator -(Grupo e, Mascota j)
        {
            if (e == j)
            {
                e.manada.Remove(j);
            }
            return e;
        }
        #endregion


    }
}
