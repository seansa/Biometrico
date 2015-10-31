using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicio.Seguridad.PerfilUsuario.DTOs;

namespace Servicio.Seguridad.PerfilUsuario
{
    public class PerfilUsuarioServicio : IPerfilUsuarioServicio
    {
        public void AsignarUsuarios(List<long> usuarioIds, long perfilId)
        {
            using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
            {
                try
                {
                    var _perfil = _contexto.Perfiles.Find(perfilId);

                    foreach (var usuarioId in usuarioIds)
                    {
                        var _usuario = _contexto.Usuarios.Find(usuarioId);

                        _perfil.Usuarios.Add(_usuario);
                    }

                    _contexto.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }                
            }
        }

        public IEnumerable<PerfilUsuarioDTO> ObtenerUsuariosAsignados(long perfilId, string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var resultado = _context.Perfiles
                        .Find(perfilId)
                        .Usuarios
                        .Where(x => x.Nombre.Contains(cadenaBuscar)
                        || x.Agente.Legajo == cadenaBuscar
                        || x.Agente.Apellido.Contains(cadenaBuscar)
                        || x.Agente.Nombre.Contains(cadenaBuscar))
                        .Select(x => new PerfilUsuarioDTO
                        {
                            UsuarioId = x.Id,
                            ApyNom = x.Agente.Apellido + " " + x.Agente.Nombre,
                            Dni = x.Agente.DNI,
                            Legajo = x.Agente.Legajo,
                            NombreUsuario = x.Nombre,
                            EstaBloqueado = x.EstaBloqueado ? "SI" : "NO"
                        }).ToList();

                    return resultado;
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public IEnumerable<PerfilUsuarioDTO> ObtenerUsuariosNoAsignados(long perfilId, string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var resultadoAsignados = _context.Perfiles
                        .Find(perfilId)
                        .Usuarios
                        .ToList();

                    var resultadoUsuarios = _context.Usuarios.ToList();

                    var resultado = resultadoUsuarios.Except(resultadoAsignados);

                    return resultado
                        .Where(x => x.Nombre.Contains(cadenaBuscar)
                        || x.Agente.Legajo == cadenaBuscar
                        || x.Agente.Apellido.Contains(cadenaBuscar)
                        || x.Agente.Nombre.Contains(cadenaBuscar))
                        .Select(x => new PerfilUsuarioDTO
                        {
                            UsuarioId = x.Id,
                            ApyNom = x.Agente.Apellido + " " + x.Agente.Nombre,
                            Dni = x.Agente.DNI,
                            Legajo = x.Agente.Legajo,
                            NombreUsuario = x.Nombre,
                            EstaBloqueado = x.EstaBloqueado ? "SI" : "NO"
                        }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void QuitarUsuarios(List<long> usuarioIds, long perfilId)
        {
            try
            {
                using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _perfil = _contexto.Perfiles.Find(perfilId);

                    foreach (var usuarioId in usuarioIds)
                    {
                        var _usuario = _contexto.Usuarios.Find(usuarioId);

                        _perfil.Usuarios.Remove(_usuario);
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
