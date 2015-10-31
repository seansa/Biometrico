using System;
using System.Collections.Generic;
using AccesoDatos;
using System.Linq;
using Servicio.RecursoHumano.Sector.DTOs;

namespace Servicio.RecursoHumano.Sector
{
    public class SectorServicio : ISectorServicio
    {
        public void Eliminar(long id)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _sectorEliminar = _context.Sectores.Find(id);

                    if (_sectorEliminar == null) throw new Exception("No se encontro el Sector.");

                    _context.Sectores.Remove(_sectorEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void Insertar(int codigo, string descripcion)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _sectorNuevo = new AccesoDatos.Sector();

                    _sectorNuevo.Codigo = codigo;
                    _sectorNuevo.Descripcion = descripcion;

                    _context.Sectores.Add(_sectorNuevo);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Modificar(long id, int codigo, string descripcion)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _sectorModificar = _context.Sectores.Find(id);

                    if (_sectorModificar == null) throw new Exception("No se encontro el Sector.");

                    _sectorModificar.Codigo = codigo;
                    _sectorModificar.Descripcion = descripcion;

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SectorDTO> ObtenerPorFiltro(string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {

                    int _codigo = -1;
                    int.TryParse(cadenaBuscar, out _codigo);

                    var _sectores = _context.Sectores
                        .AsNoTracking()
                        .Where(x => x.Descripcion.Contains(cadenaBuscar)
                        || x.Codigo == _codigo)
                        .Select(x => new SectorDTO
                        {
                            Id = x.Id,
                            Codigo = x.Codigo,
                            Descripcion = x.Descripcion,
                            CantidadSubGrupos = x.SubSectores.Count()
                        })
                        .ToList();

                    return _sectores;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AccesoDatos.Sector ObtenerPorId(long id)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {

                    var _sector = _context.Sectores.Find(id);

                    if (_sector == null) throw new Exception("No se encontro el Sector");

                    return _sector;
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
                    return _context.Sectores.Any()
                        ? _context.Sectores.Max(x => x.Codigo) + 1
                        : 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SectorDTO> ObtenerTodo()
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {

                    var _subSector = _context.Sectores
                        .AsNoTracking()
                        .Select(x => new SectorDTO
                        {
                            Id = x.Id,
                            Codigo = x.Codigo,
                            Descripcion = x.Descripcion,
                            CantidadSubGrupos = x.SubSectores.Count()
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


        public bool VerificarSiExiste(long? id, int codigo, string descripcion)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    if (id.HasValue)
                    {
                        return _context.Sectores.Any(x => x.Id != id && (x.Codigo == codigo || x.Descripcion == descripcion));
                    }
                    else
                    {
                        return _context.Sectores.Any(x => x.Codigo == codigo || x.Descripcion == descripcion);
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
