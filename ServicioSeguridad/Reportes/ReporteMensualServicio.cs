using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;

namespace Servicio.RecursoHumano.Reportes
{
    public class ReporteMensualServicio : IReporteMensualServicio
    {
        private List<Tuple<string, int>> _listaMesesYAños;

        public ReporteMensualServicio()
        {
            _listaMesesYAños = ListaMesesYAños();
        }

        private DateTime FechaPrimerAcceso()
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    var _primerAcceso = _context.Accesos.First();
                    if (_primerAcceso == null) throw new Exception("No hay accesos");
                    return _primerAcceso.FechaHora;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<Tuple<string, int>> ListaMesesYAños()
        {
            DateTime fechaInicio = FechaPrimerAcceso();
            DateTime fechaFin = DateTime.Today;
            DateTime iterador;
            DateTime limite;
            List<Tuple<string, int>> lista = new List<Tuple<string, int>>();
            var dateTimeFormat = new CultureInfo("es-Ar").DateTimeFormat;

            if (fechaInicio.Date == fechaFin.Date)
            {
                lista.Add(Tuple.Create(dateTimeFormat.GetMonthName(fechaInicio.Month), fechaInicio.Year));
                return lista;
            }
            else
            {
                iterador = new DateTime(fechaInicio.Year, fechaInicio.Month, 1);
                limite = fechaFin;

                while (iterador <= limite)
                {
                    lista.Add(Tuple.Create(dateTimeFormat.GetMonthName(iterador.Month), iterador.Year));
                    iterador = iterador.AddMonths(1);
                }

                return lista;
            }  
        }

        public List<string> ListaMeses()
        {
            var lista = new List<string>();

            foreach (var tupla in _listaMesesYAños)
            {
                lista.Add(tupla.Item1);
            }

            return lista;
        }

        public List<int> ListaAños()
        {
            var lista = new List<int>();

            foreach (var tupla in _listaMesesYAños)
            {
                lista.Add(tupla.Item2);
            }

            return lista;
        }
    }
}
