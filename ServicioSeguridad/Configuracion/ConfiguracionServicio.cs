using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.Configuracion
{
    public class ConfiguracionServicio:IConfiguracionServicio
    {
        public void GuardarConfiguracion(TimeSpan entrada, TimeSpan salida, int lactancia, int minutostarde, int minutosausente)
        {
            try
            {
                using (var contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    var _confi = new AccesoDatos.Configuracion();

                    _confi.HoraEntradaPorDefecto = entrada;
                    _confi.HoraSalidaPorDefecto = salida;
                    _confi.MinutosLactancia = lactancia;
                    _confi.MinutosToleranciaLlegadaTarde = minutostarde;
                    _confi.MinutosToleranciaAusente = minutosausente;
                    //_confi.EstaAplicado = false;
                    contexto.Configuraciones.Add(_confi);
                    contexto.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int MinutosToleranciaAusente {
            get {
                try
                {
                    using (var _context = new AccesoDatos.ModeloBometricoContainer())
                    {

                        return _context.Configuraciones.Select(config => config.MinutosToleranciaAusente).Last();

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static int MinutosToleranciaLlegadaTarde
        {
            get
            {
                try
                {
                    using (var _context = new AccesoDatos.ModeloBometricoContainer())
                    {

                        return _context.Configuraciones.Select(config => config.MinutosToleranciaLlegadaTarde).Last();

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool HayRegistros()
        {
            try
            {
                using (var contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    return contexto.Configuraciones.Any();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
              

        public AccesoDatos.Configuracion ObtenerUltimaConfiguracion()
        {
            try
            {
                using (var contexto = new AccesoDatos.ModeloBometricoContainer())
                {

                    return contexto.Configuraciones.OrderByDescending(x => x.Id).FirstOrDefault();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
