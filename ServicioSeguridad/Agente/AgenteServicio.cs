using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Servicio.RecursoHumano.Agente.DTOs;

namespace Servicio.RecursoHumano.Agente
{
    public class AgenteServicio : IAgenteServicio
    {
        public void Eliminar(long id)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _agenteEliminar = _context.Agentes.Find(id);

                    if (_agenteEliminar == null) throw new Exception("No se encontro el agente.");

                    _context.Agentes.Remove(_agenteEliminar);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void Insertar(string legajo, string apellido, string nombre, string dni, string telefono, string celular, string mail, bool visualizar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _agenteNuevo = new AccesoDatos.Agente();

                    _agenteNuevo.Legajo = legajo;
                    _agenteNuevo.Apellido = apellido;
                    _agenteNuevo.Nombre = nombre;
                    _agenteNuevo.DNI = dni;
                    _agenteNuevo.Telefono = telefono;
                    _agenteNuevo.Celular = celular;
                    _agenteNuevo.Mail = mail;
                    _agenteNuevo.Visualizar = visualizar;

                    _context.Agentes.Add(_agenteNuevo);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Modificar(long id, string legajo, string apellido, string nombre, string dni, string telefono, string celular, string mail, bool visualizar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _agenteModificar = _context.Agentes.Find(id);

                    if (_agenteModificar == null) throw new Exception("No se encontro el agente.");
                    
                    _agenteModificar.Legajo = legajo;
                    _agenteModificar.Apellido = apellido;
                    _agenteModificar.Nombre = nombre;
                    _agenteModificar.DNI = dni;
                    _agenteModificar.Telefono = telefono;
                    _agenteModificar.Celular = celular;
                    _agenteModificar.Mail = mail;
                    _agenteModificar.Visualizar = visualizar;

                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AgenteDTO> ObtenerPorFiltro(string cadenaBuscar)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _agentes = _context.Agentes
                        .AsNoTracking()
                        .Where(x => x.Apellido.Contains(cadenaBuscar)
                        || x.Nombre.Contains(cadenaBuscar)
                        || x.DNI == cadenaBuscar
                        || x.Legajo == cadenaBuscar
                        || x.SubSectores.Any(s => s.Descripcion.Contains(cadenaBuscar)))
                        .Select(x => new AgenteDTO
                        {
                            Id = x.Id,
                            Apellido = x.Apellido,
                            DNI = x.DNI,
                            Nombre = x.Nombre,
                            Legajo = x.Legajo,
                            Mail = x.Mail,
                            Celular = x.Celular,
                           Telefono = x.Telefono,
                           Visualizar = x.Visualizar ? "SI" : "NO"
                        })
                        .ToList();

                    return _agentes;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AccesoDatos.Agente ObtenerPorId(long id)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _agente = _context.Agentes.Find(id);

                    if (_agente == null) throw new Exception("No se encontro el agente");

                    return _agente;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AgenteDTO> ObtenerTodo()
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _agentes = _context.Agentes
                        .AsNoTracking()
                        .Select(x => new AgenteDTO
                        {
                            Id = x.Id,
                            Apellido = x.Apellido,
                            DNI = x.DNI,
                            Nombre = x.Nombre,
                            Legajo = x.Legajo,
                            Mail = x.Mail,
                            Celular = x.Celular,
                            Telefono = x.Telefono,
                            Visualizar = x.Visualizar ? "SI" : "NO"
                        })
                        .ToList();

                    return _agentes;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerificarSiExiste(long? id, string legajo)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    if (id.HasValue)
                    {
                        return _context.Agentes.Any(x => x.Id != id.Value && x.Legajo == legajo);
                    }
                    else
                    {
                        return _context.Agentes.Any(x => x.Legajo == legajo);
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
