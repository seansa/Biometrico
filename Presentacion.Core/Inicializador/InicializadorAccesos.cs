using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Core.Inicializador
{
    public static class InicializadorAccesos
    {
        public static void CargarAccesos(ref Dictionary<TipoAcceso, string> diccionario)
        {
            diccionario.Add(TipoAcceso.Entrada, "Entrada");
            diccionario.Add(TipoAcceso.SalidaParcial, "Salida Parcial");
            diccionario.Add(TipoAcceso.EntradaParacial, "Entrada Parcial");
            diccionario.Add(TipoAcceso.Salida, "Salida");
        }
    }
}
