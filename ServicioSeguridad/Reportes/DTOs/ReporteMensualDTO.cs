using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Reportes.DTOs
{
    public class ReporteMensualDTO
    {
        public int numero { get; set; }
        public long AgenteId { get; set; }
        private string _legajo;
        public string Legajo
        {
            get { return _legajo.PadLeft(3, '0'); }
            set { _legajo = value; }
        }

        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string ApyNom { get { return string.Format("{0}, {1}", Apellido, Nombre); } }
        public bool TieneNovedades {
            get {
                return Novedades.Count() > 0 ? true : false;
            }
        }
        public bool TieneComisiones
        {
            get
            {
                return Comisiones.Count() > 0 ? true : false;
            }
        }
        public bool TieneLactancias
        {
            get
            {
                return Lactancias.Count() > 0 ? true : false;
            }
        }
        public List<NovedadAgente.DTOs.NovedadAgenteDTO> Novedades { get; set; }
        public List<ComisionServicio.DTOs.ComisionServicioDTO> Comisiones { get; set; }
        public List<Lactancia.DTOs.LactanciaDTO> Lactancias { get; set; }
        public DateTime Fecha { get; set; }
        public string Mes { get { return Fecha.Month.ToString(); } }
        public string Año { get { return Fecha.Year.ToString(); } }
        public string FechaStr {
            get
            {
                return Fecha.Date.ToShortDateString();
            }
        }
    }
}
