using Servicio.RecursoHumano.Lactancia.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Lactancia
{
    public interface ILactanciaServicio
    {

        void Insertar(List<LactanciaDTO> lista);
        void Eliminar(long id);
        IEnumerable<Lactancia.DTOs.LactanciaDTO> ObtenerTodo();
        AccesoDatos.Lactancia ObtenerPorId(long id);
        IEnumerable<Lactancia.DTOs.LactanciaDTO> ObtenerPorFiltro(long agenteId);
        IEnumerable<Lactancia.DTOs.LactanciaDTO> ObtenerPorFiltro(long agenteId, DateTime fechaDesde, DateTime fechaHasta);
        bool VerificarNoEsteRepetidoMemoria(List<LactanciaDTO> lista, DateTime fechaDesde, DateTime fechaHasta, bool[] arrayDias);
        bool VerificarAlgunDiaCargado(bool[] arrayDias);
        string ComprobarDiaExisteEnRango(DateTime inicio, DateTime fin, int dia);
    }
}
