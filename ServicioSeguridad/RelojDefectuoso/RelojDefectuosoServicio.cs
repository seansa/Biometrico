using Servicio.RecursoHumano.RelojDefectuoso.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.RecursoHumano.RelojDefectuoso
{
    public class RelojDefectuosoServicio:IRelojDefectuoso
    {
        public IEnumerable<RelojDefectuosoDTO> ObtenerListadodeRelojDefectuoso(DateTime fechareloj, bool jornadacompleta, TimeSpan horadesde, TimeSpan horahasta)
        {
            try
            {
                using (var contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    List<RelojDefectuosoDTO> listafinal = new List<RelojDefectuosoDTO>();
                    var diaDefectuoso = fechareloj.ToString("dddd").ToUpper();

                    foreach (var agente in contexto.Agentes)
                    {
                        var listahorarios = agente.Horarios.Where(x => fechareloj.Date >= x.FechaDesde.Date && (fechareloj.Date <= x.FechaHasta || x.FechaHasta == null)).OrderByDescending(x => x.FechaActualizacion.Date);



                        var ultimohorario = listahorarios.FirstOrDefault();

                        if (ultimohorario != null)
                        {
                            var listaultimohorario = listahorarios.Where(x => x.FechaActualizacion.Date == ultimohorario.FechaActualizacion.Date);


                            if (diaDefectuoso == "LUNES")
                            {
                                var horarioaplicado = listaultimohorario.FirstOrDefault(x => x.Lunes);

                                ValidarReloj(horarioaplicado, horadesde, horahasta, jornadacompleta, agente, listafinal);

                            }
                            else if (diaDefectuoso == "MARTES")
                            {
                                var horarioaplicado = listaultimohorario.FirstOrDefault(x => x.Martes);
                                ValidarReloj(horarioaplicado, horadesde, horahasta, jornadacompleta, agente, listafinal);

                            }
                            else if (diaDefectuoso == "MIÉRCOLES")
                            {
                                var horarioaplicado = listaultimohorario.FirstOrDefault(x => x.Miercoles);
                                ValidarReloj(horarioaplicado, horadesde, horahasta, jornadacompleta, agente, listafinal);

                            }
                            else if (diaDefectuoso == "JUEVES")
                            {
                                var horarioaplicado = listaultimohorario.FirstOrDefault(x => x.Jueves);
                                ValidarReloj(horarioaplicado, horadesde, horahasta, jornadacompleta, agente, listafinal);

                            }
                            else if (diaDefectuoso == "VIERNES")
                            {
                                var horarioaplicado = listaultimohorario.FirstOrDefault(x => x.Viernes);
                                ValidarReloj(horarioaplicado, horadesde, horahasta, jornadacompleta, agente, listafinal);

                            }
                            else if (diaDefectuoso == "SÁBADO")
                            {
                                var horarioaplicado = listaultimohorario.FirstOrDefault(x => x.Sabado);
                                ValidarReloj(horarioaplicado, horadesde, horahasta, jornadacompleta, agente, listafinal);

                            }
                            else if (diaDefectuoso == "DOMINGO")
                            {
                                var horarioaplicado = listaultimohorario.FirstOrDefault(x => x.Domingo);
                                ValidarReloj(horarioaplicado, horadesde, horahasta, jornadacompleta, agente, listafinal);

                            }

                        }
                    }
                    return listafinal.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GuardarRelojDefectuoso(DateTime fechareloj, TimeSpan horadesde, TimeSpan horahasta, bool jornadacompleta)
        {
            try
            {
                using (var contexto = new AccesoDatos.ModeloBometricoContainer())
                {
                    var reloj = new AccesoDatos.RelojDefectuoso();
                    reloj.Fecha = fechareloj;
                    if (jornadacompleta) reloj.JornadaCompleta = true;
                    else
                    {
                        reloj.HoraDesde = horadesde;
                        reloj.HoraHasta = horahasta;
                    }

                    contexto.RelojDefectuosos.Add(reloj);
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ValidarReloj(AccesoDatos.Horario horarioaplicado, TimeSpan horadesde, TimeSpan horahasta, bool jornadacompleta, AccesoDatos.Agente agente, List<RelojDefectuosoDTO> listafinal)
        {
            if (horarioaplicado != null)
            {
                if (jornadacompleta)
                {
                    var _afectado = new RelojDefectuosoDTO();
                    _afectado.IdAgente = agente.Id;
                    _afectado.IdHorario = horarioaplicado.Id;
                    _afectado.Nombre = agente.Nombre;
                    _afectado.RelojDefectuosoEntrada = false;
                    _afectado.RelojDefectuosoEntradaParcial = false;
                    _afectado.RelojDefectuosoSalidaParcial = false;
                    _afectado.RelojDefectuosoSalida = false;
                    _afectado.JornadaCompleta = true;

                    listafinal.Add(_afectado);
                }
                else  //ver las horas
                {
                    //veo si esta fuera del horario de rotura
                    if (!(horarioaplicado.HoraSalida < horadesde || horarioaplicado.HoraEntrada > horahasta))
                    {
                        var _afectado = new RelojDefectuosoDTO();
                        _afectado.IdAgente = agente.Id;
                        _afectado.IdHorario = horarioaplicado.Id;
                        _afectado.Nombre = agente.Nombre;
                        //veo si esta totalmente dentro del horario de rotura
                        if (horarioaplicado.HoraEntrada >= horadesde && horarioaplicado.HoraSalida <= horahasta)
                        {
                            _afectado.RelojDefectuosoEntrada = true;
                            _afectado.RelojDefectuosoEntradaParcial = true;
                            _afectado.RelojDefectuosoSalidaParcial = true;
                            _afectado.RelojDefectuosoSalida = true;
                            _afectado.JornadaCompleta = false;
                            listafinal.Add(_afectado);
                            //horario salida dentro del horario roto
                        }
                        else if (horarioaplicado.HoraSalida >= horadesde && horarioaplicado.HoraSalida <= horahasta)
                        {
                            _afectado.RelojDefectuosoEntrada = false;
                            _afectado.RelojDefectuosoEntradaParcial = false;
                            _afectado.RelojDefectuosoSalidaParcial = false;
                            _afectado.RelojDefectuosoSalida = true;
                            _afectado.JornadaCompleta = false;
                            listafinal.Add(_afectado);
                            //horario de entrada dentro del horario roto
                        }
                        else if (horarioaplicado.HoraEntrada >= horadesde && horarioaplicado.HoraEntrada <= horahasta)
                        {
                            _afectado.RelojDefectuosoEntrada = true;
                            _afectado.RelojDefectuosoEntradaParcial = false;
                            _afectado.RelojDefectuosoSalidaParcial = false;
                            _afectado.RelojDefectuosoSalida = false;
                            _afectado.JornadaCompleta = false;
                            listafinal.Add(_afectado);
                        }

                    }
                }


            }
        }


    }
}

