using Servicio.Seguridad.Controles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using AccesoDatos;
using Servicio.Seguridad.Formulario;

namespace Servicio.Seguridad.Controles
{
    public class ControlSistemaServicio : IControlSistemaServicio
    {
        public void Eliminar(List<long> controlIds)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var controlId in controlIds)
                    {
                        using (var _context = new AccesoDatos.ModeloBometricoContainer())
                        {
                            var _control = _context.Controles.Find(controlId);

                            if (_control == null) throw new Exception("no se encontro el Control");

                            _context.Controles.Remove(_control);
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

        public void Insertar(List<ControlSistemaDTO> listaControles)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    foreach (var _controlDTO in listaControles.Where(x => x.EstaEnBase == "NO"))
                    {
                        using (var _context = new AccesoDatos.ModeloBometricoContainer())
                        {
                            var _formulario = _context.Formularios.FirstOrDefault(x => x.Descripcion == _controlDTO.Formulario);

                            if (_formulario == null) throw new Exception("No se enncontro el formulario " + _controlDTO.Formulario);

                            var _controlNuevo = new AccesoDatos.Control();

                            _controlNuevo.Descripcion = _controlDTO.Descripcion;
                            _controlNuevo.FormularioId = _formulario.Id;

                            _context.Controles.Add(_controlNuevo);
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

        public IEnumerable<ControlSistemaDTO> ObtenerPorFiltro(List<Assembly> listaAssemblys, string cadenaBuscar)
        {
            var _listarControles = new List<ControlSistemaDTO>();
            var _formularioServicio = new FormularioServicio();

            var _listaFormularios = _formularioServicio.ObtenerTodo();

            using (var _context = new AccesoDatos.ModeloBometricoContainer())
            {
                var _controlesEnBaseDatos = _context.Controles
                    .AsNoTracking()
                    .ToList();

                foreach (var ass in listaAssemblys.AsParallel())
                {
                    foreach (Type t in ass.GetTypes())
                    {
                        if (!t.Name[0].ToString().Equals("_")) continue;

                        var _formulario = _listaFormularios.FirstOrDefault(x => x.DescripcionCompleta == t.FullName);

                        if (_formulario == null) throw new Exception("No se encontro el formulario");

                        var _formularioInstancia = (Form)ass.CreateInstance(t.FullName);

                        if (_formularioInstancia == null) throw new Exception("No se pudo crear el objeto formulario");

                        CargarListaControles(ref _listarControles, _controlesEnBaseDatos, _formulario, _formularioInstancia);
                    }
                }
            }

            return _listarControles
                .Where(x => x.Descripcion.Contains(cadenaBuscar))
                .OrderBy(x => x.Formulario)
                .ToList();
        }

        private void CargarListaControles(ref List<ControlSistemaDTO> listaControles, List<AccesoDatos.Control> listaControlesDB, AccesoDatos.Formulario formulario, object obj)
        {
            if (obj is Form)
            {
                foreach (var objCtrol in ((Form)obj).Controls.AsParallel())
                {
                    CargarListaControles(ref listaControles, listaControlesDB, formulario, objCtrol);
                }
            }

            if (obj is Panel)
            {
                foreach (var objCtrol in ((Panel)obj).Controls.AsParallel())
                {
                    CargarListaControles(ref listaControles, listaControlesDB, formulario, objCtrol);
                }
            }

            if (obj is ToolStrip)
            {
                foreach (var objCtrol in ((ToolStrip)obj).Items.AsParallel())
                {
                    CargarListaControles(ref listaControles, listaControlesDB, formulario, objCtrol);
                }
            }

            if (obj is TabControl)
            {
                foreach (var objCtrol in ((TabControl)obj).Controls.AsParallel())
                {
                    CargarListaControles(ref listaControles, listaControlesDB, formulario, objCtrol);
                }
            }

            if (obj is TabPage)
            {
                foreach (var objCtrol in ((TabPage)obj).Controls.AsParallel())
                {
                    CargarListaControles(ref listaControles, listaControlesDB, formulario, objCtrol);
                }
            }

            if (obj is Button)
            {
                var nuevoControl = new ControlSistemaDTO
                {
                    Id = listaControlesDB.Any(x =>
                            x.FormularioId == formulario.Id &&
                            x.Descripcion == ((Button)obj).Name)
                            ? listaControlesDB.FirstOrDefault(x => x.FormularioId == formulario.Id && x.Descripcion == ((Button)obj).Name).Id : (long?)null,
                    Descripcion = ((Button)obj).Name,
                    Formulario = formulario.Descripcion,
                    EstaEnBase = listaControlesDB.Any(
                        x =>
                            x.FormularioId == formulario.Id &&
                            x.Descripcion == ((Button)obj).Name)
                        ? "SI"
                        : "NO"
                };
                listaControles.Add(nuevoControl);
                return;
            }

            if (obj is ToolStripButton)
            {
                var nuevoControl = new ControlSistemaDTO
                {
                    Id = listaControlesDB.Any(x =>
                            x.FormularioId == formulario.Id &&
                            x.Descripcion == ((ToolStripButton)obj).Name)
                            ? listaControlesDB.FirstOrDefault(x => x.FormularioId == formulario.Id && x.Descripcion == ((ToolStripButton)obj).Name).Id : (long?)null,
                    Descripcion = ((ToolStripButton)obj).Name,
                    Formulario = formulario.Descripcion,
                    EstaEnBase = listaControlesDB.Any(
                        x =>
                            x.FormularioId == formulario.Id &&
                            x.Descripcion == ((ToolStripButton)obj).Name)
                        ? "SI"
                        : "NO"
                };

                listaControles.Add(nuevoControl);
                return;
            }
        }
    }
}
