using AccesoDatos;
using Servicio.RecursoHumano.SubSector.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.SubSector
{
    public class SubSectorServicio : ISubSectorServicio
    {
        public void Eliminar(long id)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _subSectorEliminar = _context.SubSectores.Find(id);

                    if (_subSectorEliminar == null) throw new Exception("No se encontro el Sub-Sector.");

                    _context.SubSectores.Remove(_subSectorEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insertar(long sectorId, int codigo, string descripcion, string abreviatura)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _subSectorNuevo = new AccesoDatos.SubSector();

                    _subSectorNuevo.SectorId = sectorId;
                    _subSectorNuevo.Codigo = codigo;
                    _subSectorNuevo.Descripcion = descripcion;
                    _subSectorNuevo.Abreviatura = abreviatura;

                    _context.SubSectores.Add(_subSectorNuevo);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Modificar(long id, long sectorId, int codigo, string descripcion, string abreviatura)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _subSectorModificar = _context.SubSectores.Find(id);

                    if (_subSectorModificar == null) throw new Exception("No se encontro el Sub-Sector.");

                    _subSectorModificar.SectorId = sectorId;
                    _subSectorModificar.Codigo = codigo;
                    _subSectorModificar.Descripcion = descripcion;
                    _subSectorModificar.Abreviatura = abreviatura;

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SubSectorDTO> ObtenerPorFiltro(string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {

                    int _codigo = -1;
                    int.TryParse(cadenaBuscar, out _codigo);

                    var _subSectores = _context.SubSectores
                        .AsNoTracking()
                        .Where(x => x.Descripcion.Contains(cadenaBuscar)
                        || x.Codigo == _codigo
                        || x.Sector.Descripcion.Contains(cadenaBuscar))
                        .Select(x => new SubSectorDTO
                        {
                            Id = x.Id,
                            Codigo = x.Codigo,
                            Descripcion = x.Descripcion,
                            Abreviatura = x.Abreviatura,
                            Sector = x.Sector.Descripcion,
                            SectorId = x.SectorId, 
                            CantidadAgentes = x.Agentes.Count()
                        })
                        .ToList();

                    return _subSectores;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SubSectorDTO> ObtenerPorFiltro(long sectorId, string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {

                    int _codigo = -1;
                    int.TryParse(cadenaBuscar, out _codigo);

                    var _subSectores = _context.SubSectores
                        .AsNoTracking()
                        .Where(x => x.SectorId == sectorId
                                    && (x.Descripcion.Contains(cadenaBuscar)
                                        || x.Codigo == _codigo
                                        || x.Sector.Descripcion.Contains(cadenaBuscar)))
                        .Select(x => new SubSectorDTO
                        {
                            Id = x.Id,
                            Codigo = x.Codigo,
                            Descripcion = x.Descripcion,
                            Abreviatura = x.Abreviatura,
                            Sector = x.Sector.Descripcion,
                            SectorId = x.SectorId,
                            CantidadAgentes = x.Agentes.Count()
                        })
                        .ToList();

                    return _subSectores;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AccesoDatos.SubSector ObtenerPorId(long id)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {

                    var subSector = _context.SubSectores.Find(id);

                    if (subSector == null) throw new Exception("No se encontro el Sub.Sector");

                    return subSector;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ObtenerSiguienteNroCodigo()
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    return _context.SubSectores.Any()
                        ? _context.SubSectores.Max(x => x.Codigo) + 1
                        : 1;                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SubSectorDTO> ObtenerTodo()
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {

                    var _subSector = _context.SubSectores
                        .AsNoTracking()
                        .Select(x => new SubSectorDTO
                        {
                            Id = x.Id,
                            Codigo = x.Codigo,
                            Descripcion = x.Descripcion,
                            Abreviatura = x.Abreviatura,
                            Sector = x.Sector.Descripcion,
                            SectorId = x.SectorId,
                            CantidadAgentes = x.Agentes.Count()
                        })
                        .ToList();

                    return _subSector;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SubSectorDTO> ObtenerTodo(long sectorId)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {

                    var _subSector = _context.SubSectores
                        .AsNoTracking()
                        .Where(x=>x.SectorId == sectorId)
                        .Select(x => new SubSectorDTO
                        {
                            Id = x.Id,
                            Codigo = x.Codigo,
                            Descripcion = x.Descripcion,
                            Abreviatura = x.Abreviatura,
                            Sector = x.Sector.Descripcion,
                            SectorId = x.SectorId,
                            CantidadAgentes = x.Agentes.Count()
                        })
                        .ToList();

                    return _subSector;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerificarSiExiste(long? id, long sectorId, int codigo, string descripcion, string abreviatura)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    if (id.HasValue)
                    {
                        return _context.SubSectores.Any(x => x.Id != id && x.SectorId == sectorId && (x.Codigo == codigo || x.Descripcion == descripcion || x.Abreviatura == abreviatura));
                    }
                    else
                    {
                        return _context.SubSectores.Any(x => x.Codigo == codigo || x.Descripcion == descripcion || x.Abreviatura == abreviatura);
                    }                
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
