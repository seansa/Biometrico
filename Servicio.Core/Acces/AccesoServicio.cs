﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Servicio.Core.Acceso.DTOs;

namespace Servicio.Core.Acces
{
    public class AccesoServicio : IAccesoServicio
    {
        public void Insertar(long agenteId, DateTime fechaHora, TipoAcceso tipoAcceso, string nroReloj, TimeSpan? hora)
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    var _acceso = new AccesoDatos.Acceso();
                    _acceso.AgenteId = agenteId;
                    _acceso.FechaHora = fechaHora;
                    _acceso.TipoAcceso = tipoAcceso;
                    _acceso.NroReloj = nroReloj;
                    _acceso.Hora = hora;
                    _context.Accesos.Add(_acceso);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<AccesoDTO> ObtenerPorId(long IdAgente)
        {
            using (var _context = new AccesoDatos.ModeloBometricoContainer())
            {
                var resultado = _context.Agentes
                    .Find(IdAgente)
                    .Accesos
                    .Select(acceso => new AccesoDTO()
                    {
                        AgenteId = acceso.AgenteId,
                        FechaHora = acceso.FechaHora,
                        Hora = acceso.Hora,
                        TipoAcceso = acceso.TipoAcceso.ToString(),
                        NumeroReloj = acceso.NroReloj,
                    }).ToList();

                return resultado;
            }
        }

        public bool VerificarNoEsteRegistrado(long agenteId, DateTime fechaHora, TipoAcceso tipoAcceso, string nroReloj)
        {
            try
            {
                using (var _context=new ModeloBometricoContainer())
                {
                    return _context.Accesos.Any(x => x.AgenteId == agenteId && x.FechaHora.ToShortDateString() == fechaHora.ToShortDateString() && x.TipoAcceso == tipoAcceso && x.NroReloj == nroReloj);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool HayAccesos()
        {
            try
            {
                using (var _context = new ModeloBometricoContainer())
                {
                    return _context.Accesos.Any();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool VerificarTipoAccesoCorrecto(long agenteId, DateTime fechaHora, TipoAcceso tipoAcceso, string nroReloj)
        {
            throw new NotImplementedException();
        }
    }
}
