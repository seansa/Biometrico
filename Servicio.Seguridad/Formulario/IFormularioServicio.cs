using Servicio.Seguridad.Formulario.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.Formulario
{
    public interface IFormularioServicio
    {
        void Insertar(List<FormularioDTO> listaFormularios);

        void Eliminar(List<long> formulariosIds);

        AccesoDatos.Formulario ObtenerPorNombre(string nombreFormularioCompleto);

        IEnumerable<AccesoDatos.Formulario> ObtenerTodo();

        IEnumerable<FormularioDTO> ObtenerPorFiltro(List<Assembly> listaAssemblys, string cadenaBuscar);

        bool VerificarSiSeCargaronFormularios();
    }
}
