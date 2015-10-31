using Servicio.Seguridad.PerfilControles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.PerfilControles
{
    public class PerfilControlServicio : IPerfilControlServicio
    {
        public void AsignarControles(List<long> ControlIds, long perfilId)
        {
            using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
            {
                try
                {
                    var _perfil = _contexto.Perfiles.Find(perfilId);

                    foreach (var ControlId in ControlIds)
                    {
                        var _Control = _contexto.Controles.Find(ControlId);

                        _perfil.Controles.Add(_Control);
                    }

                    _contexto.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<PerfilControlDTO> ObtenerControlesAsignados(long perfilId, string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var resultado = _context.Perfiles
                        .Find(perfilId)
                        .Controles
                        .Where(x => x.Descripcion.Contains(cadenaBuscar)
                        || x.Formulario.Descripcion.Contains(cadenaBuscar))
                        .Select(x => new PerfilControlDTO
                        {
                            ControlId = x.Id,
                            Descripcion = x.Descripcion,
                            Formulario = x.Formulario.Descripcion,
                            Item = false
                        }).ToList();

                    return resultado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IEnumerable<PerfilControlDTO> ObtenerControlesNoAsignados(long perfilId, string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var resultadoAsignados = _context.Perfiles
                        .Find(perfilId)
                        .Controles
                        .ToList();

                    var resultadoControls = _context.Controles.ToList();

                    var resultado = resultadoControls.Except(resultadoAsignados);

                    return resultado
                        .Where(x => x.Descripcion.Contains(cadenaBuscar)
                        || x.Formulario.Descripcion.Contains(cadenaBuscar))
                        .Select(x => new PerfilControlDTO
                        {
                            ControlId = x.Id,
                            Descripcion = x.Descripcion,
                            Formulario = x.Formulario.Descripcion,
                            Item = false
                        }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void QuitarControles(List<long> ControlIds, long perfilId)
        {
            try
            {
                using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _perfil = _contexto.Perfiles.Find(perfilId);

                    foreach (var ControlId in ControlIds)
                    {
                        var _Control = _contexto.Controles.Find(ControlId);

                        _perfil.Controles.Remove(_Control);
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
