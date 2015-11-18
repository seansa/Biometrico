using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Lactancia;
using Servicio.RecursoHumano.Lactancia.DTOs;
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
    public partial class _00014_ABM_Lactancia : PresentacionBase.FormularioBase
    {
        public long AgenteId { get; set; }
        private IAgenteServicio _agenteServicio;
        private ILactanciaServicio _lactanciaServicio;
        private List<LactanciaDTO> _listaLactancia;
        private LactanciaDTO _lactanciaSeleccionada;
        private int _indice;

        public _00014_ABM_Lactancia()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _lactanciaServicio = new LactanciaServicio();
            _listaLactancia = new List<LactanciaDTO>();
            _lactanciaSeleccionada = new LactanciaDTO();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _00014_ABM_Lactancia_Load(object sender, EventArgs e)
        {
            var _agente = _agenteServicio.ObtenerPorId(AgenteId);
            this.txtApyNom.Text = _agente.Apellido + ", " + _agente.Nombre;
            this.txtLegajo.Text = _agente.Legajo;
            this.txtDni.Text = _agente.DNI;
            HabilitarCheckBoxDias();
            Actualizar();

        }
        private void Actualizar()
        {
            this.dgvLactancia.DataSource = _listaLactancia.ToList();
            FormatearGrilla(this.dgvLactancia);
            
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            this.dgvLactancia.Columns["FechaDesdeStr"].Visible = true;
            this.dgvLactancia.Columns["FechaHastaStr"].Visible = true;
            this.dgvLactancia.Columns["HoraInicio"].Visible = true;
            this.dgvLactancia.Columns["LunesStr"].Visible = true;
            this.dgvLactancia.Columns["MartesStr"].Visible = true;
            this.dgvLactancia.Columns["MiercolesStr"].Visible = true;
            this.dgvLactancia.Columns["JuevesStr"].Visible = true;
            this.dgvLactancia.Columns["ViernesStr"].Visible = true;
            this.dgvLactancia.Columns["SabadoStr"].Visible = true;
            this.dgvLactancia.Columns["DomingoStr"].Visible = true;
            this.dgvLactancia.Columns["FechaActualizacionStr"].Visible = true;
            this.dgvLactancia.Columns["FechaDesdeStr"].HeaderText = "Fecha Desde";
            this.dgvLactancia.Columns["FechaHastaStr"].HeaderText = "Fecha Hasta";
            this.dgvLactancia.Columns["HoraInicio"].HeaderText = "Hora Inicio";
            this.dgvLactancia.Columns["LunesStr"].HeaderText = "Lunes";
            this.dgvLactancia.Columns["MartesStr"].HeaderText = "Martes";
            this.dgvLactancia.Columns["MiercolesStr"].HeaderText = "Miercoles";
            this.dgvLactancia.Columns["JuevesStr"].HeaderText = "Jueves";
            this.dgvLactancia.Columns["ViernesStr"].HeaderText = "Viernes";
            this.dgvLactancia.Columns["SabadoStr"].HeaderText = "Sabado";
            this.dgvLactancia.Columns["DomingoStr"].HeaderText = "Domingo";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var arrayDias = new bool[7];

            arrayDias[0] = this.chkLunes.Checked;
            arrayDias[1] = this.chkMartes.Checked;
            arrayDias[2] = this.chkMiercoles.Checked;
            arrayDias[3] = this.chkJueves.Checked;
            arrayDias[4] = this.chkViernes.Checked;
            arrayDias[5] = this.chkSabado.Checked;
            arrayDias[6] = this.chkDomingo.Checked;
            if (_lactanciaServicio.VerificarAlgunDiaCargado(arrayDias))
            {
                if (_lactanciaServicio.VerificarNoEsteRepetidoMemoria(_listaLactancia, this.dtpFechaDesde.Value, this.dtpFechaHasta.Value, arrayDias))
                {

                    var _nuevaLactancia = new LactanciaDTO()
                    {
                        AgenteId = AgenteId,
                        FechaDesde = this.dtpFechaDesde.Value,
                        FechaHasta = this.dtpFechaHasta.Value,
                        HoraInicio = this.chkHoraInicio.Checked,
                        Lunes = this.chkLunes.Checked,
                        Martes = this.chkMartes.Checked,
                        Miercoles = this.chkMiercoles.Checked,
                        Jueves = this.chkJueves.Checked,
                        Viernes = this.chkViernes.Checked,
                        Sabado = this.chkSabado.Checked,
                        Domingo = this.chkDomingo.Checked
                    };
                    _listaLactancia.Add(_nuevaLactancia);
                }
                else
                {
                    MessageBox.Show("El Agente ya tiene asignada lactancia en el/los dias especificados");
                }
            }
            else
            {
                MessageBox.Show("NO Hay dias Seleccionados");
            }
            LimpiarControles(this.pnlDias);
            LimpiarControles(this.pnlFechas);
            Actualizar();
        }
        public override void LimpiarControles(object obj)
        {
            base.LimpiarControles(obj);
        }

        private void btnMarcarSemana_Click(object sender, EventArgs e)
        {
            if (this.chkLunes.Enabled)
            {
                this.chkLunes.Checked = true; 
            }
            if (this.chkMartes.Enabled)
            {
                this.chkMartes.Checked = true; 
            }
            if (this.chkMiercoles.Enabled)
            {
                this.chkMiercoles.Checked = true;
            }
            if (this.chkJueves.Enabled)
            {

                this.chkJueves.Checked = true;
            }
            if (this.chkViernes.Enabled)
            {

                this.chkViernes.Checked = true; 
            }
           // this.dgvLactancia.Select();

        }

        private void btnDesmarcar_Click(object sender, EventArgs e)
        {
            this.chkLunes.Checked = false;
            this.chkMartes.Checked = false;
            this.chkMiercoles.Checked = false;
            this.chkJueves.Checked = false;
            this.chkViernes.Checked = false;
            this.chkSabado.Checked = false;
            this.chkDomingo.Checked = false;
            //this.dgvLactancia.Select();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvLactancia.RowCount > 0)
            //if(this.dgvLactancia.CurrentRow.Index <= 0)
            {
                // _listaLactancia.Remove((LactanciaDTO)this.dgvLactancia.CurrentRow.DataBoundItem);
                _listaLactancia.Remove((LactanciaDTO)this.dgvLactancia.Rows[_indice].DataBoundItem);
            }
            Actualizar();
        }

        private void dgvLactancia_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvLactancia.RowCount>0)
            {
                _indice = e.RowIndex;

            }
            else
            {
                _indice = -1;
            }
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dtpFechaHasta.Value.Date, this.dtpFechaDesde.Value.Date) < 0)
            {
                this.dtpFechaHasta.Value = DateTime.Now;
                MessageBox.Show("La fecha Hasta no puede ser anterior a la fecha Desde");

            }
            HabilitarCheckBoxDias();
            //this.dgvLactancia.Select();
        }

        private void HabilitarCheckBoxDias()
        {
            DeshabilitarCheckBoxDias();
            for (int i = 0; i < 7; i++)
            {
                foreach (var chk in this.pnlDias.Controls)
                {

                    if (_lactanciaServicio.ComprobarDiaExisteEnRango(this.dtpFechaDesde.Value, this.dtpFechaHasta.Value, i) == ((CheckBox)chk).Text.ToLower())
                    {
                        ((CheckBox)chk).Enabled = true;
                    }
                }
            }
        }
        private void DeshabilitarCheckBoxDias()
        {
            foreach (var chk in this.pnlDias.Controls)
            {
                ((CheckBox)chk).Enabled = false;
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dtpFechaHasta.Value.Date, this.dtpFechaDesde.Value.Date) < 0)
            {
                this.dtpFechaDesde.Value = DateTime.Now;
                MessageBox.Show("La fecha Hasta no puede ser anterior a la fecha Desde");

            }
            HabilitarCheckBoxDias();
            //this.dgvLactancia.Select();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _lactanciaServicio.Insertar(_listaLactancia);
            this.Close();
        }
    }
}
