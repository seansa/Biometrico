using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Servicio.Core.Acces
{
    public class AccesoServicio : IAccesoServicio
    {
        public void Insertar(long agenteId, DateTime fechaHora, TipoAcceso tipoAcceso, string nroReloj)
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    var _acceso = new AccesoDatos.Acceso();
                    _acceso.AgenteId = agenteId;
                    _acceso.FechaHora = fechaHora;
                    _acceso.TipoAcceso = tipoAcceso;
                    _acceso.NroReloj = nroReloj;
                    _context.Accesos.Add(_acceso);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool VerificarNoEsteRegistrado(long agenteId, DateTime fechaHora, TipoAcceso tipoAcceso, string nroReloj)
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    return _context.Accesos.Any(x => x.AgenteId == agenteId && x.FechaHora.ToShortDateString() == fechaHora.ToShortDateString() && x.TipoAcceso == tipoAcceso && x.NroReloj == nroReloj);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool VerificarTipoAccesoCorrecto(long agenteId, DateTime fechaHora, TipoAcceso tipoAcceso, string nroReloj)
        {
            throw new NotImplementedException();
        }
    }
}
