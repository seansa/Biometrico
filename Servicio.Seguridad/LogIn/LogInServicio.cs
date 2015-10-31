using Servicio.Seguridad.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.LogIn
{
    public class LogInServicio : ILogInServicio
    {
        public bool VerificarIngreso(string nombreUsuario, string password)
        {
            using (var _context = new AccesoDatos.ModeloBometricoContainer())
            {
                var _password = Usuario.ConstantesSeguridad.EncriptarCadena(password);
                var resultado = _context.Usuarios
                    .Any(x => x.Nombre == nombreUsuario && x.Password == _password);

                return resultado;
            }
        }

        public bool VerificarIngresoAdministrador(string nombreUsuario, string password)
        {
            return nombreUsuario == ConstantesSeguridad.UsuarioAdministrador 
                && password == ConstantesSeguridad.PasswordAdministrador;
        }
    }
}
