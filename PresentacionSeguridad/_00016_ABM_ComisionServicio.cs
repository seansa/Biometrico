using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.ComisionServicio;
using Servicio.RecursoHumano.ComisionServicio.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00016_ABM_ComisionServicio : PresentacionBase.FormularioBase
    {
        AgenteServicio _agenteServicio;
        IComisionServicio _comisionServicio;
        List<ComisionServicioDTO> listaComisiones;
        List<ComisionServicioDTO> listaTemporal;

        public long AgenteId { get; set; }

        public _00016_ABM_ComisionServicio()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _comisionServicio = new ComisionServicio();
            listaComisiones = new List<ComisionServicioDTO>();
            listaTemporal = new List<ComisionServicioDTO>();
        }
        public _00016_ABM_ComisionServicio(string titulo) : this()
        {
            this.Text = titulo;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _00016_ABM_ComisionServicio_Load(object sender, EventArgs e)
        {
            var agente = _agenteServicio.ObtenerPorId(AgenteId);
            this.lblApyNom.Text = agente.Apellido + " " + agente.Nombre;
            this.lblLegajo.Text = agente.Legajo.ToString();
            this.lblDNI.Text = agente.DNI.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (_comisionServicio.VerificarNoEsteRepetidoMemoria(listaTemporal, this.dtpFechaDesde.Value, this.dtpFechaHasta.Value))
            {

                var _nuevaComision = new ComisionServicioDTO()
                {
                    AgenteId = this.AgenteId,
                    FechaDesde = this.dtpFechaDesde.Value,
                    FechaHasta = this.dtpFechaHasta.Value,
                    Observaciones = this.txtObservaciones.Text,

                };
                listaTemporal.Add(_nuevaComision);
            }
            else
            {
                MessageBox.Show("Se Repite");
            }
            this.dgvGrilla.DataSource = listaTemporal.ToList();
        }
    }
}
