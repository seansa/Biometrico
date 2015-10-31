using Servicio.Seguridad.Usuario.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System;

namespace Servicio.Seguridad.Usuario
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly AccesoDatos.ModeloBometricoContainer contexto;

        public ServicioUsuario()
        {
            this.contexto = new AccesoDatos.ModeloBometricoContainer();
        }

        public IEnumerable<UsuarioDTO> ObtenerPorFiltro(string cadenaBuscar)
        {
            var resultado = contexto.Agentes
                .AsNoTracking()
                .Where(x => x.Apellido.Contains(cadenaBuscar)
                || x.Nombre.Contains(cadenaBuscar)
                || x.Legajo == cadenaBuscar
                || x.SubSectores.Any(s => s.Descripcion.Contains(cadenaBuscar)))
                .Select(x => new UsuarioDTO
                {
                    Id = x.Usuarios.Any() ? x.Usuarios.FirstOrDefault().Id : (long?)null,
                    AgenteId = x.Id,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    Legajo = x.Legajo,
                    Usuario = x.Usuarios.Any() ? x.Usuarios.FirstOrDefault().Nombre : "NO ASIGNADO",
                    Item = false,
                    EstaBloqueado = x.Usuarios.Any(u => u.EstaBloqueado)
                }).ToList();
                
            return resultado;
        }

        public AccesoDatos.Usuario ObtenerPorNombre(string nombreUsuario)
        {
            return contexto.Usuarios.FirstOrDefault(x => x.Nombre == nombreUsuario);
        }

        public bool CrearUsuarios(List<UsuarioDTO> listaAgentes)
        {
            var esOperacionCompleta = false;

            using (var contexto = new AccesoDatos.ModeloBometricoContainer())
            {
                using (var tran = new TransactionScope())
                {
                    try
                    {
                        foreach (var agente in listaAgentes.Where(x => x.Item
                            && x.Usuario == "NO ASIGNADO").ToList())
                        {
                            var nombreUsuario = ObtenerNombreUsuario(agente);

                            contexto.Usuarios.Add(new AccesoDatos.Usuario
                            {
                                AgenteId = agente.AgenteId,
                                EstaBloqueado = false,
                                Nombre = nombreUsuario,
                                Password = ConstantesSeguridad.PasswordPorDefecto()
                            });

                            if (!esOperacionCompleta)
                                esOperacionCompleta = true;
                        }

                        contexto.SaveChanges();

                        tran.Complete();                        
                    }
                    catch
                    {
                        esOperacionCompleta = false;
                        throw;
                    }
                }
            }

            return esOperacionCompleta;
        }

        private string ObtenerNombreUsuario(UsuarioDTO agente)
        {
            int _cantidadCaracteres = 1;
            int _contador = 1;

            var _nombreUsuario = string.Format("{0}{1}",
                    agente.Nombre.Trim().Substring(0, _cantidadCaracteres),
                    agente.Apellido.Trim()).ToUpper();

            using (var contexto = new AccesoDatos.ModeloBometricoContainer())
            {
                while (contexto.Usuarios
                    .Any(x=>x.Nombre == _nombreUsuario))
                {
                    _cantidadCaracteres++;

                    if (_cantidadCaracteres <= 
                        (agente.Nombre.Trim() + agente.Apellido.Trim()).Length)
                    {
                        _nombreUsuario = string.Format("{0}{1}", 
                            agente.Nombre.Trim().Substring(0, _cantidadCaracteres), 
                            agente.Apellido.Trim()).ToUpper();
                    }
                    else
                    {
                        _nombreUsuario = (agente.Nombre.Trim()
                            + agente.Apellido.Trim()
                            + _contador.ToString()).ToUpper();

                        _contador++;
                    }
                }
            }

            return _nombreUsuario;
        }

        public void BloquearUsuario(List<UsuarioDTO> listaUsuarios)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    using (var _context = new AccesoDatos.ModeloBometricoContainer())
                    {
                        foreach (var usuario in listaUsuarios
                            .Where(x => x.Item && x.Id.HasValue))
                        {
                            var usuarioBloquear = _context.Usuarios.Find(usuario.Id.Value);

                            usuarioBloquear.EstaBloqueado = !usuarioBloquear.EstaBloqueado;    
                                                                             
                        }

                        _context.SaveChanges();
                    }

                    tran.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void BloquearUsuario(string nombreUsuario)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    using (var _context = new AccesoDatos.ModeloBometricoContainer())
                    {
                        var usuarioBloquear = _context.Usuarios.FirstOrDefault(x => x.Nombre == nombreUsuario);

                        if (usuarioBloquear == null) throw new Exception("Ocurrio un error al bloquear el usuarios.");

                        usuarioBloquear.EstaBloqueado = !usuarioBloquear.EstaBloqueado;

                        _context.SaveChanges();
                    }

                    tran.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void ResetearPassword(List<UsuarioDTO> listaUsuarios)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    using (var _context = new AccesoDatos.ModeloBometricoContainer())
                    {
                        foreach (var usuario in listaUsuarios
                            .Where(x => x.Item && x.Id.HasValue))
                        {
                            var usuarioBloquear = _context.Usuarios.Find(usuario.Id.Value);

                            usuarioBloquear.Password = ConstantesSeguridad.PasswordPorDefecto();
                        }

                        _context.SaveChanges();
                    }

                    tran.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void CambiarPassword(long usuarioId, string passwordNuevo)
        {
            try
            {
                using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _usuario = _contexto.Usuarios.Find(usuarioId);

                    _usuario.Password = ConstantesSeguridad.EncriptarCadena(passwordNuevo);

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
