using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio.Seguridad.Usuario;

namespace Servicio.Seguridad.AccesoControles
{
    public static class AccesoControlesServicio
    {
        private static Form _formulario;

        public static void TieneAcceso(string nombreUsuario, object obj)
        {            
            if (obj is Form)
            {
                foreach (var ctrol in ((Form)obj).Controls)
                {
                    _formulario = ((Form)obj);
                    TieneAcceso(nombreUsuario, ctrol);
                }
            }

            if (obj is Panel)
            {
                foreach (var ctrol in ((Panel)obj).Controls)
                {
                    TieneAcceso(nombreUsuario, ctrol);
                }
            }

            if (obj is TabControl)
            {
                foreach (var ctrol in ((TabControl)obj).Controls)
                {
                    TieneAcceso(nombreUsuario, ctrol);
                }
            }

            if (obj is TabPage)
            {
                foreach (var ctrol in ((TabPage)obj).Controls)
                {
                    TieneAcceso(nombreUsuario, ctrol);
                }
            }

            if (obj is ToolStrip)
            {
                foreach (var ctrol in ((ToolStrip)obj).Items)
                {
                    TieneAcceso(nombreUsuario, ctrol);
                }
            }

            if (obj is Button)
            {
                ActivarControl(((Button)obj), nombreUsuario);
            }

            if (obj is ToolStripButton)
            {
                ActivarControl(((ToolStripButton)obj), nombreUsuario);
            }
        }

        private static void ActivarControl(Button boton, string nombreUsuario)
        {
            boton.Enabled = TieneAccesoAlControl(nombreUsuario, boton.Name);
        }

        private static void ActivarControl(ToolStripButton boton, string nombreUsuario)
        {
            boton.Enabled = TieneAccesoAlControl(nombreUsuario,boton.Name);
        }

        private static bool TieneAccesoAlControl(string nombreUsuario, string nombreControl)
        {
            try
            {
                if (nombreUsuario == ConstantesSeguridad.UsuarioAdministrador)
                    return true;

                using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    return _contexto.Perfiles
                        .Any(x => x.Usuarios.Any(u => u.Nombre == nombreUsuario)
                        && x.Controles.Any(c => c.Formulario.Descripcion == _formulario.Name
                        && c.Descripcion == nombreControl));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
