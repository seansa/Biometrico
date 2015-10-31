using AccesoDatos;
using Servicio.Seguridad.Perfil.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Seguridad.Perfil
{
    public class ServicioPerfil : IServicioPerfil
    {
        private readonly ModeloBometricoContainer contexto;

        public ServicioPerfil()
        {
            contexto = new ModeloBometricoContainer();
        }

        public void Eliminar(AccesoDatos.Perfil entidadEliminar)
        {
            contexto.Perfiles.Remove(entidadEliminar);
            contexto.SaveChanges();
        }

        public void Eliminar(long id)
        {
            var entidad = contexto.Perfiles.Find(id);
            Eliminar(entidad);
        }

        public void Insertar(AccesoDatos.Perfil entidadNueva)
        {
            contexto.Perfiles.Add(entidadNueva);
            contexto.SaveChanges();
        }

        public void Modificar(AccesoDatos.Perfil entidadModificar)
        {
            contexto.SaveChanges();
        }

        public IEnumerable<PerfilDTO> ObtenerPorFiltro(string cadenaBuscar)
        {
            int codigo = -1;
            int.TryParse(cadenaBuscar, out codigo);

            var resultado = contexto.Perfiles
                .AsNoTracking()
                .Where(x => x.Descripcion.Contains(cadenaBuscar))
                .OrderBy(x => x.Descripcion)
                .Select(x => new PerfilDTO
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    CantidadUsuarios = x.Usuarios.Count()
                })
                .ToList();

            return resultado;
        }

        public AccesoDatos.Perfil ObtenerPorId(long id)
        {
            return contexto.Perfiles.Find(id);
        }
        
        public IEnumerable<PerfilDTO> ObtenerTodo()
        {
            return contexto.Perfiles
                .AsNoTracking()
                .OrderBy(x => x.Descripcion)
                .Select(x => new PerfilDTO
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    CantidadUsuarios = x.Usuarios.Count()
                })
                .ToList();
        }

        public bool VerificarSiExiste(long? id, string descripcion)
        {
            if (id.HasValue)
            {
                return contexto.Perfiles.AsNoTracking()
                    .Any(x => x.Id != id.Value
                    && x.Descripcion == descripcion);
            }
            else
            {
                return contexto.Perfiles.AsNoTracking()
                    .Any(x => x.Descripcion == descripcion);
            }
        }
    }
}
