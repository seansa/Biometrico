using AccesoDatos;
using Servicio.RecursoHumano.NovedadAgente.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.NovedadAgente
{
    public class NovedadAgenteServicio : INovedadAgenteServicio
    {
        public void Insertar(NovedadAgenteDTO novedadAgente)
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    var _novedad = new Novedad()
                    {
                        AgenteId=novedadAgente.AngenteId,
                        TipoNovedadId=novedadAgente.TipoNovedadId,
                        FechaDesde=novedadAgente.FechaDesde,
                        FechaHasta=novedadAgente.FechaHasta,
                        HoraDesde=novedadAgente.HoraDesde,
                        HoraHasta=novedadAgente.HoraHasta,
                        Observacion=novedadAgente.Observacion
                        

                    };
                    _context.Novedades.Add(_novedad);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<NovedadAgenteDTO> ObtenerPorId(long IdAgente)
        {
            using (var _context = new AccesoDatos.ModeloBometricoContainer())
            {
                var resultado = _context.Agentes
                    .Find(IdAgente)
                    .Novedades
                    .Select(novedad => new NovedadAgenteDTO()
                    {
                        Id = novedad.Id,
                        AngenteId = novedad.Id,
                        TipoNovedadId = novedad.TipoNovedadId,
                        FechaDesde = novedad.FechaDesde,
                        FechaHasta = novedad.FechaHasta,
                        HoraDesde = novedad.HoraDesde,
                        HoraHasta = novedad.HoraHasta,
                        Observacion = novedad.Observacion
                    }).ToList();

                return resultado;
            }
        }
    }
}
