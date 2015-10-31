using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Seguridad.PerfilFormulario.DTOs;

namespace Servicio.Seguridad.PerfilFormulario
{
    public class PerfilFormularioServicio : IPerfilFormularioServicio
    {
        public void AsignarFormularios(List<long> FormularioIds, long perfilId)
        {
            using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
            {
                try
                {
                    var _perfil = _contexto.Perfiles.Find(perfilId);

                    foreach (var FormularioId in FormularioIds)
                    {
                        var _Formulario = _contexto.Formularios.Find(FormularioId);

                        _perfil.Formularios.Add(_Formulario);
                    }

                    _contexto.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<PerfilFormularioDTO> ObtenerFormulariosAsignados(long perfilId, string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var resultado = _context.Perfiles
                        .Find(perfilId)
                        .Formularios
                        .Where(x => x.Descripcion.Contains(cadenaBuscar)
                        || x.Codigo == cadenaBuscar
                        || x.DescripcionCompleta.Contains(cadenaBuscar))
                        .Select(x => new PerfilFormularioDTO
                        {
                            Item = false,
                            FormularioId = x.Id,
                            Descripcion = x.Descripcion,
                            DescripcionCompleta = x.DescripcionCompleta,
                        }).ToList();

                    return resultado;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PerfilFormularioDTO> ObtenerFormulariosNoAsignados(long perfilId, string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var resultadoAsignados = _context.Perfiles
                        .Find(perfilId)
                        .Formularios
                        .ToList();

                    var resultadoFormularios = _context.Formularios.ToList();

                    var resultado = resultadoFormularios.Except(resultadoAsignados);

                    return resultado
                        .Where(x => x.Descripcion.Contains(cadenaBuscar)
                        || x.Codigo == cadenaBuscar
                        || x.DescripcionCompleta.Contains(cadenaBuscar))
                        .Select(x => new PerfilFormularioDTO
                        {
                            Item = false,
                            FormularioId = x.Id,
                            Descripcion = x.Descripcion,
                            DescripcionCompleta = x.DescripcionCompleta,
                        }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void QuitarFormularios(List<long> FormularioIds, long perfilId)
        {
            try
            {
                using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _perfil = _contexto.Perfiles.Find(perfilId);

                    foreach (var FormularioId in FormularioIds)
                    {
                        var _Formulario = _contexto.Formularios.Find(FormularioId);

                        _perfil.Formularios.Remove(_Formulario);
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
