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
        List<ComisionServicioDTO> listaComisionesEliminar;
        List<ComisionServicioDTO> listaComisionesAgregar;
        DateTime? fechaHasta;
        int i;

        public long AgenteId { get; set; }

        public _00016_ABM_ComisionServicio()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _comisionServicio = new ComisionServicio();
            listaComisionesEliminar = new List<ComisionServicioDTO>();
            listaComisionesAgregar = new List<ComisionServicioDTO>();
            listaComisiones = new List<ComisionServicioDTO>();
        }
        public _00016_ABM_ComisionServicio(string titulo) : this()
        {
            this.Text = titulo;
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgvGrilla);

            this.dgvGrilla.Columns["Descripcion"].Visible = true;
            this.dgvGrilla.Columns["Descripcion"].HeaderText = "Descripción";
            this.dgvGrilla.Columns["Descripcion"].Width = 111;
            this.dgvGrilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["Descripcion"].DisplayIndex = 1;

            this.dgvGrilla.Columns["FechaDesdeStr"].Visible = true;
            this.dgvGrilla.Columns["FechaDesdeStr"].HeaderText = "Desde";
            this.dgvGrilla.Columns["FechaDesdeStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["FechaDesdeStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["FechaHastaStr"].Visible = true;
            this.dgvGrilla.Columns["FechaHastaStr"].HeaderText = "Hasta";
            this.dgvGrilla.Columns["FechaHastaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["FechaHastaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["HoraInicioStr"].Visible = true;
            this.dgvGrilla.Columns["HoraInicioStr"].HeaderText = "Entrada";
            this.dgvGrilla.Columns["HoraInicioStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["HoraInicioStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["HoraFinStr"].Visible = true;
            this.dgvGrilla.Columns["HoraFinStr"].HeaderText = "Salida";
            this.dgvGrilla.Columns["HoraFinStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvGrilla.Columns["HoraFinStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["JornadaCompletaStr"].Visible = true;
            this.dgvGrilla.Columns["JornadaCompletaStr"].HeaderText = "Jornada Completa";
            this.dgvGrilla.Columns["JornadaCompletaStr"].Width = 111;
            this.dgvGrilla.Columns["JornadaCompletaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvGrilla.Columns["Observaciones"].Visible = true;
            this.dgvGrilla.Columns["Observaciones"].HeaderText = "Observaciones";
            this.dgvGrilla.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvGrilla.Columns["Observaciones"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Actualizar()
        {
            this.dgvGrilla.DataSource = listaComisiones.Concat(listaComisionesAgregar).ToList();
            FormatearGrilla(this.dgvGrilla);
        }

        private void Eliminar(List<ComisionServicioDTO> lista)
        {
            foreach (var comision in lista)
            {
                _comisionServicio.Eliminar(comision.Id);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _00016_ABM_ComisionServicio_Load(object sender, EventArgs e)
        {
            var agente = _agenteServicio.ObtenerPorId(AgenteId);
            this.lblApyNom.Text = string.Format("{0}, {1}", agente.Apellido, agente.Nombre);
            this.lblDNI.Text = string.Format("{0:##0,000,000}", Int32.Parse(agente.DNI));
            this.lblLegajo.Text = string.Format("{0:###,000}", Int32.Parse(agente.Legajo));
                        
            listaComisiones = _comisionServicio.ObtenerPorFiltro(AgenteId).ToList();
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Enabled) fechaHasta = dtpFechaHasta.Value;
            else fechaHasta = null;

            if (txtDescripcion.Text.Trim().Length == 0) MessageBox.Show("La descripción no debe estar vacía");
            else if (dtpHoraInicio.Value.ToShortTimeString() == dtpHoraFin.Value.ToShortTimeString()) {
                MessageBox.Show("La hora de entrada y salida es la misma");
            }
            else
            {
                if (_comisionServicio.VerificarNoEsteRepetidoMemoria(listaComisiones.Concat(listaComisionesAgregar).ToList(), this.dtpFechaDesde.Value, fechaHasta, chkJornadaCompleta.Checked, dtpHoraInicio.Value.TimeOfDay, dtpHoraFin.Value.TimeOfDay))
                {
                    var _nuevaComision = new ComisionServicioDTO()
                    {
                        AgenteId = this.AgenteId,
                        FechaDesde = this.dtpFechaDesde.Value,
                        FechaHasta = chkFechaHasta.Checked ? fechaHasta : null,
                        Observaciones = this.txtObservaciones.Text,
                        JornadaCompleta = this.chkJornadaCompleta.Checked,
                        HoraFin = this.dtpHoraFin.Value.TimeOfDay,
                        HoraInicio = this.dtpHoraInicio.Value.TimeOfDay,
                        Descripcion = this.txtDescripcion.Text,
                    };
                    listaComisionesAgregar.Add(_nuevaComision);
                    Actualizar();
                }
                else
                {
                    MessageBox.Show("Se repite");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvGrilla.RowCount > 0)
            {
                listaComisionesEliminar.Add((ComisionServicioDTO)this.dgvGrilla.SelectedRows[0].DataBoundItem);

                if (listaComisionesAgregar.Contains((ComisionServicioDTO)this.dgvGrilla.SelectedRows[0].DataBoundItem))
                {
                    listaComisionesAgregar.Remove((ComisionServicioDTO)this.dgvGrilla.SelectedRows[0].DataBoundItem);
                }
                else
                {
                    listaComisiones.Remove((ComisionServicioDTO)this.dgvGrilla.SelectedRows[0].DataBoundItem);
                }

                Actualizar();
            }
            else
            {
                listaComisionesEliminar = new List<ComisionServicioDTO>();
                listaComisionesAgregar = new List<ComisionServicioDTO>();
                listaComisiones = new List<ComisionServicioDTO>();
            }
        }

        private void chkFechaHasta_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked) dtpFechaHasta.Enabled = true;
            else dtpFechaHasta.Enabled = false;
        }

        private void dtpHoraInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpHoraFin.Value.TimeOfDay < dtpHoraInicio.Value.TimeOfDay) dtpHoraFin.Value = dtpHoraInicio.Value;
        }

        private void dtpHoraFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpHoraFin.Value.TimeOfDay < dtpHoraInicio.Value.TimeOfDay) dtpHoraInicio.Value = dtpHoraFin.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaHasta.Value < dtpFechaDesde.Value) dtpFechaDesde.Value = dtpFechaHasta.Value;
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaHasta.Value < dtpFechaDesde.Value) dtpFechaHasta.Value = dtpFechaDesde.Value;
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvGrilla.RowCount > 0)
            {
                i = e.RowIndex;

            }
            else
            {
                i = -1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _comisionServicio.Insertar(listaComisionesAgregar);

            if (listaComisionesEliminar.Count() > 0) Eliminar(listaComisionesEliminar);
            this.Close();
        }
    }
}
