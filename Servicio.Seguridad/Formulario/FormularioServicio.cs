using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Servicio.Seguridad.Formulario.DTOs;
using System.Transactions;
using AccesoDatos;

namespace Servicio.Seguridad.Formulario
{
    public class FormularioServicio : IFormularioServicio
    {
        public void Eliminar(List<long> formulariosIds)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var formularioId in formulariosIds)
                    {
                        using (var _context = new AccesoDatos.ModeloBometricoContainer())
                        {
                            var _formulario = _context.Formularios.Find(formularioId);

                            if (_formulario == null) throw new Exception("no se encontro el formulario");

                            _context.Formularios.Remove(_formulario);
                            _context.SaveChanges();
                        }
                    }

                    tran.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Insertar(List<FormularioDTO> listaFormularios)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var _formularioDTO in listaFormularios.Where(x=>x.EstaEnBase =="NO"))
                    {
                        using (var _context = new AccesoDatos.ModeloBometricoContainer())
                        {
                            var _formularioNuevo = new AccesoDatos.Formulario();

                            _formularioNuevo.Codigo = _formularioDTO.Codigo;
                            _formularioNuevo.Descripcion = _formularioDTO.Descripcion;
                            _formularioNuevo.DescripcionCompleta = _formularioDTO.DescripcionCompleta;

                            _context.Formularios.Add(_formularioNuevo);
                            _context.SaveChanges();
                        }
                    }

                    tran.Complete();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<FormularioDTO> ObtenerPorFiltro(List<Assembly> listaAssemblys, string cadenaBuscar)
        {
            var listarFormularios = new List<FormularioDTO>();

            using (var _context = new AccesoDatos.ModeloBometricoContainer())
            {
                var _formulariosEnBaseDatos = _context.Formularios
                    .AsNoTracking()
                    .ToList();

                foreach (var ass in listaAssemblys.AsParallel())
                {
                    foreach (Type t in ass.GetTypes())
                    {
                        if (!t.Name[0].ToString().Equals("_")) continue;

                        var _formularioDTONuevo = new FormularioDTO();
                                                
                        _formularioDTONuevo.Codigo = t.Name.Substring(1, 5);
                        _formularioDTONuevo.Descripcion = t.Name;
                        _formularioDTONuevo.DescripcionCompleta = t.FullName;

                        var formularioBD = _formulariosEnBaseDatos
                            .FirstOrDefault(x => x.DescripcionCompleta == t.FullName);

                        _formularioDTONuevo.EstaEnBase = formularioBD != null ? "SI" : "NO";
                        _formularioDTONuevo.Id = formularioBD != null ? formularioBD.Id : (long?)null;

                        listarFormularios.Add(_formularioDTONuevo);
                    }
                }
            }

            return listarFormularios
                .Where(x => x.Codigo == cadenaBuscar
                || x.Descripcion.Contains(cadenaBuscar)
                || x.DescripcionCompleta.Contains(cadenaBuscar))
                .OrderBy(x => x.Codigo)
                .ToList();
        }

        public AccesoDatos.Formulario ObtenerPorNombre(string nombreFormularioCompleto)
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _formulario =
                        _context.Formularios.AsNoTracking().FirstOrDefault(x => x.DescripcionCompleta == nombreFormularioCompleto);

                    if(_formulario == null) throw  new Exception("No se encontro el Formulario: " + nombreFormularioCompleto);

                    return _formulario;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<AccesoDatos.Formulario> ObtenerTodo()
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    return _context.Formularios.AsNoTracking().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerificarSiSeCargaronFormularios()
        {
            try
            {
                using (var _context = new AccesoDatos.ModeloBometricoContainer())
                {
                    return _context.Formularios.Any();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
