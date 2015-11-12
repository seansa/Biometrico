using Servicio.RecursoHumano.RelojDefectuoso.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.RelojDefectuoso
{
    public interface IRelojDefectuoso
    {
        IEnumerable<RelojDefectuosoDTO> ObtenerListadodeRelojDefectuoso(DateTime fechareloj, bool jornadacompleta, TimeSpan horadesde, TimeSpan horahasta);
        void GuardarRelojDefectuoso(DateTime fechareloj, TimeSpan horadesde, TimeSpan horahasta, bool jornadacompleta);

    }
}
