using Servicio.Seguridad.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.AccesoFormulario
{
    public static class AccesoFormularioServicio
    {
        public static bool TienePermiso(string nombreFormulario, string nombreUsuario)
        {
            try
            {
                if (ConstantesSeguridad.UsuarioAdministrador == nombreUsuario)
                    return true;

                using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _formularios = _contexto.Perfiles.
                        Any((x => x.Formularios.Any(f => f.Descripcion == nombreFormulario)
                        && x.Usuarios.Any(u => u.Nombre == nombreUsuario)));
                    
                    return _formularios;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
