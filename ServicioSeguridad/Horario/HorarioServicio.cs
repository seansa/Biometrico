using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Servicio.RecursoHumano.Horario.DTOs;
using System.Globalization;

namespace Servicio.RecursoHumano.Horario
{
    public class HorarioServicio : IHorarioServicio
    {
        
      

        public IEnumerable<DetalleHorarioDTO> AgregarDetalleHorario(List<DetalleHorarioDTO> listahorarios, long id, DateTime fechadesde, DateTime fechahasta, TimeSpan? horaentrada, TimeSpan? horasalidaparcial, TimeSpan? horaentradaparcial, TimeSpan? horasalida, bool lunes, bool martes, bool miercoles, bool jueves, bool viernes, bool sabado, bool domingo)
        {
            var nuevoHorario = new DetalleHorarioDTO();
            nuevoHorario.AgenteId = id;
            nuevoHorario.FechaDesde = fechadesde;
            nuevoHorario.FechaHasta = fechahasta;
            nuevoHorario.HoraEntrada = horaentrada;
            nuevoHorario.HoraSalidaParcial = horasalidaparcial;
            nuevoHorario.HoraEntradaParcial = horaentradaparcial;
            nuevoHorario.HoraSalida = horasalida;
            nuevoHorario.Lunes = lunes;
            nuevoHorario.Martes = martes;
            nuevoHorario.Miercoles = miercoles;
            nuevoHorario.Jueves = jueves;
            nuevoHorario.Viernes = viernes;
            nuevoHorario.Sabado = sabado;
            nuevoHorario.Domingo = domingo;
            listahorarios.Add(nuevoHorario);
            return listahorarios;
        }

        public void AsignarHorarios(List<DetalleHorarioDTO> listahorarios, long agenteId)
        {
            using (var _contexto = new AccesoDatos.ModeloBometricoContainer())
            {
                try
                {
                    var _agente = _contexto.Agentes.Find(agenteId);
                    var fechadeactualizacion = DateTime.Now;

                    foreach (var horario in listahorarios)
                    {
                        //var _horario = _contexto.Agentes.Find(agenteId);
                        var _nuevoHorario = new AccesoDatos.Horario();
                        _nuevoHorario.AgenteId = horario.AgenteId;
                        _nuevoHorario.FechaDesde = horario.FechaDesde;
                        _nuevoHorario.FechaHasta = horario.FechaHasta;
                        _nuevoHorario.HoraEntrada = horario.HoraEntrada;
                        _nuevoHorario.HoraEntradaParcial = horario.HoraEntradaParcial;
                        _nuevoHorario.HoraSalidaParcial = horario.HoraSalidaParcial;
                        _nuevoHorario.HoraSalida = horario.HoraSalida;

                        _nuevoHorario.Lunes = horario.Lunes;
                        _nuevoHorario.Martes = horario.Martes;
                        _nuevoHorario.Miercoles = horario.Miercoles;
                        _nuevoHorario.Jueves = horario.Jueves;
                        _nuevoHorario.Viernes = horario.Viernes;
                        _nuevoHorario.Sabado = horario.Sabado;
                        _nuevoHorario.Domingo = horario.Domingo;
                        _nuevoHorario.FechaActualizacion = fechadeactualizacion;

                        _agente.Horarios.Add(_nuevoHorario);
                        
                    }
                    _contexto.SaveChanges();


                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<DetalleHorarioDTO> ObtenerHorariosPorId(long idpasado)
        {
            using (var _context = new AccesoDatos.ModeloBometricoContainer())
            {
                var resultado = _context.Agentes
                    .Find(idpasado)
                    .Horarios
                    .Select(x => new DetalleHorarioDTO()
                    {
                        AgenteId = x.AgenteId,
                        FechaDesde = x.FechaDesde,
                        FechaHasta = x.FechaHasta,
                        HoraEntrada = x.HoraEntrada,
                        HoraSalidaParcial = x.HoraSalidaParcial,
                        HoraEntradaParcial = x.HoraEntradaParcial,
                        HoraSalida = x.HoraSalida,

                        Lunes = x.Lunes,
                        Martes = x.Martes,
                        Miercoles = x.Miercoles,
                        Jueves = x.Jueves,
                        Viernes = x.Viernes,
                        Sabado = x.Sabado,
                        Domingo = x.Domingo,

                    }).ToList();




                return resultado;
            }
        }

        public string VerificarDiasDelRango(DateTime inicio, DateTime fin, int dias)
        {
            DateTime _diaAux = inicio;
            do
            {
                if ((int)_diaAux.DayOfWeek==dias)
                {
                    return _diaAux.ToString("dddd", new CultureInfo("es-ES"));
                }
                _diaAux = _diaAux.AddDays(1);
            } while (_diaAux.Date<=fin.Date);
            return "NO";
        }

        public bool VerificarExiste(List<DetalleHorarioDTO> lista, DateTime fechadesde, DateTime fechahasta, TimeSpan? horaentrada, TimeSpan? horasalidaparcial, TimeSpan? horaentradaparcial, TimeSpan? horasalida, bool[] listaDias)
        {
            try
            {

                foreach (var item in lista)
                {
                    var arrayDias = new bool[7];
                    arrayDias[0] = item.Lunes;
                    arrayDias[1] = item.Martes;
                    arrayDias[2] = item.Miercoles;
                    arrayDias[3] = item.Jueves;
                    arrayDias[4] = item.Viernes;
                    arrayDias[5] = item.Sabado;
                    arrayDias[6] = item.Domingo;

                    if ((((fechadesde >= item.FechaDesde && fechadesde <= item.FechaHasta) || (fechahasta >= item.FechaDesde && fechahasta <= item.FechaHasta)) || (fechadesde < item.FechaDesde && fechahasta > item.FechaHasta)) && lista != null)

                    {
                        for (var i = 0; i < arrayDias.Length; i++)
                        {

                            if ((listaDias[i]) && (listaDias[i] == arrayDias[i])) return false;

                        }


                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
