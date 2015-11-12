using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Core.Acces
{
    public interface IAccesoServicio
    {
        void Insertar(long agenteId, DateTime fechaHora, TipoAcceso tipoAcceso, string nroReloj);
        bool VerificarNoEsteRegistrado(long agenteId, DateTime fechaHora, TipoAcceso tipoAcceso, string nroReloj);
        bool VerificarTipoAccesoCorrecto(long agenteId, DateTime fechaHora, TipoAcceso tipoAcceso, string nroReloj);
    }

}
