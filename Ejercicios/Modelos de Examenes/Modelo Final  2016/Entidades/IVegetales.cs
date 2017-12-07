using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    // Generar la interfaz pública IVegetales, con la firma del método MostrarDatos:string.
    // Implementar la interfaz en Fruta, Verdura y Carnibora. Siempre rehutilizar código.
    // Canasta sólo deberá aceptar tipos T que implementen la interfaz.
    // Sobrecargar ToString de canasta para mostrar todos los datos de los elementos de la lista.
    public interface IVegetales
    {
        string MostrarDatos();
    }
}
