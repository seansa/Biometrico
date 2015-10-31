using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.LogIn
{
    public interface ILogInServicio
    {
        bool VerificarIngreso(string nombreUsuario, string password);
        bool VerificarIngresoAdministrador(string nombreUsuario, string password);
    }
}
