using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.RecursoHumano.AgenteSubSector.DTOs;

namespace Servicio.RecursoHumano.AgenteSubSector
{
    public class AgenteSubSectorServicio : IAgenteSubSectorServicio
    {
        public void AsignarAgentes(List<long> AgentesIds, long subSectorId)
        {
            using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
            {
                try
                {
                    var _subSector = _contexto.SubSectores.Find(subSectorId);

                    foreach (var agenteId in AgentesIds)
                    {
                        var _agente = _contexto.Agentes.Find(agenteId);

                        _subSector.Agentes.Add(_agente);
                    }

                    _contexto.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<AgenteSubSectorDTO> ObtenerAgentesAsignados(long subSectorId, string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var resultado = _context.SubSectores
                        .Find(subSectorId)
                        .Agentes
                        .Where(x => x.Apellido.Contains(cadenaBuscar)
                        || x.Nombre.Contains(cadenaBuscar)
                        || x.Legajo == cadenaBuscar
                        || x.DNI == cadenaBuscar)
                        .Select(x => new AgenteSubSectorDTO
                        {
                            AgenteId = x.Id,
                            Legajo = x.Legajo,
                            ApyNom = x.Apellido + " " + x.Nombre,
                            Dni = x.DNI,                            
                        }).ToList();

                    return resultado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AgenteSubSectorDTO> ObtenerAgentesNoAsignados(long subSectorId, string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var resultadoAsignados = _context.SubSectores
                        .Find(subSectorId)
                        .Agentes
                        .ToList();

                    var resultadoAgentes = _context.Agentes.ToList();

                    var resultado = resultadoAgentes.Except(resultadoAsignados);

                    return resultado
                        .Where(x => x.Apellido.Contains(cadenaBuscar)
                        || x.Nombre.Contains(cadenaBuscar)
                        || x.Legajo == cadenaBuscar
                        || x.DNI == cadenaBuscar)
                        .Select(x => new AgenteSubSectorDTO
                        {
                            AgenteId = x.Id,
                            Legajo = x.Legajo,
                            ApyNom = x.Apellido + " " + x.Nombre,
                            Dni = x.DNI,
                        }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void QuitarAgentes(List<long> AgentesIds, long subSectorId)
        {
            try
            {
                using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _subSector = _contexto.SubSectores.Find(subSectorId);

                    foreach (var agenteId in AgentesIds)
                    {
                        var _agente = _contexto.Agentes.Find(agenteId);

                        _subSector.Agentes.Remove(_agente);
                    }

                    _contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
