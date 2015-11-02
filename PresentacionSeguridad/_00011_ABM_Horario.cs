using PresentacionBase;
using PresentacionBase.Clases;
using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Horario;
using Servicio.RecursoHumano.Horario.DTOs;
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
    public partial class _00011_ABM_Horario : FormularioBase
    {
        IAgenteServicio _agenteServicio;
        IHorarioServicio _horarioServicio;
        List<DetalleHorarioDTO> listaHorarios;
        List<DetalleHorarioDTO> listaTemporal;
        TimeSpan? _horaEntradaParcial;
        TimeSpan? _horaSalidaParcial;
        public long IdAgente { get; set; }
        public _00011_ABM_Horario()
        {

            InitializeComponent();
            _horarioServicio = new HorarioServicio();
            _agenteServicio = new AgenteServicio();
            listaHorarios = new List<DetalleHorarioDTO>();
            listaTemporal = new List<DetalleHorarioDTO>();
            _horaEntradaParcial = new TimeSpan?();
            _horaSalidaParcial = new TimeSpan?();
        }

        private void _00011_ABM_Horario_Load(object sender, EventArgs e)
        {
            var agente = _agenteServicio.ObtenerPorId(IdAgente);
            this.txtApyNom.Text = agente.Apellido + " " + agente.Nombre;
            this.txtLegajo.Text = agente.Legajo.ToString();
            this.txtDni.Text = agente.DNI.ToString();
            ResetearHorayFecha();
            
           

        }

        private void ResetearHorayFecha()
        {
            //this.dtpFechaHasta.Enabled = false;
            this.dtpFechaHasta.Value = dtpFechaHasta.MaxDate;
            this.dtpFechaHasta.MinDate = dtpFechaDesde.Value;
            
            

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            var listaDias = new bool[7];
            listaDias[0] = chkLunes.Checked;
            listaDias[1] = chkMartes.Checked;
            listaDias[2] = chkMiercoles.Checked;
            listaDias[3] = chkJueves.Checked;
            listaDias[4] = chkViernes.Checked;
            listaDias[5] = chkSabado.Checked;
            listaDias[6] = chkDomingo.Checked;

            //listaHorarios = _horarioServicio.AgregarDetalleHorario(listaHorarios, IdAgente, dtpFechaDesde.Value, dtpFechaHasta.Value, dtpHoraEntrada.Value.TimeOfDay, dtpHoraEntradaParcial.Value.TimeOfDay, dtpHoraSalidaParcial.Value.TimeOfDay, dtpHoraSalida.Value.TimeOfDay, chkLunes.Checked, chkMartes.Checked, chkMiercoles.Checked, chkJueves.Checked, chkViernes.Checked, chkSabado.Checked, chkDomingo.Checked).ToList();
            if (!chkDomingo.Checked && !chkLunes.Checked && !chkMartes.Checked && !chkMiercoles.Checked && !chkJueves.Checked && !chkViernes.Checked && !chkSabado.Checked) MessageBox.Show("Debe tildar un dia de la semana al menos.");
            else
            {
                _horaSalidaParcial = this.dtpHoraSalidaParcial.Value.TimeOfDay;
                _horaEntradaParcial = this.dtpHoraEntradaParcial.Value.TimeOfDay;
                if (_horarioServicio.VerificarExiste(listaTemporal, dtpFechaDesde.Value, dtpFechaHasta.Value, dtpHoraEntrada.Value.TimeOfDay, dtpHoraSalidaParcial.Value.TimeOfDay, dtpHoraEntradaParcial.Value.TimeOfDay, dtpHoraSalida.Value.TimeOfDay, listaDias))
                {
                    listaTemporal = _horarioServicio.AgregarDetalleHorario(listaHorarios, IdAgente, dtpFechaDesde.Value, dtpFechaHasta.Value, dtpHoraEntrada.Value.TimeOfDay, _horaSalidaParcial, _horaEntradaParcial, dtpHoraSalida.Value.TimeOfDay, chkLunes.Checked, chkMartes.Checked, chkMiercoles.Checked, chkJueves.Checked, chkViernes.Checked, chkSabado.Checked, chkDomingo.Checked).ToList();
                }
                else MessageBox.Show("El Agente ya tiene asignado horarios en el/los dias ingresados.");
                this.dgvgrilla.DataSource = listaTemporal.ToList();
                FormatearGrilla(this.dgvgrilla);
            }
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            this.dgvgrilla.Columns["FechaDesdeStr"].Visible = true;
            this.dgvgrilla.Columns["FechaHastaStr"].Visible = true;
            this.dgvgrilla.Columns["HoraEntradaStr"].Visible = true;
            this.dgvgrilla.Columns["HoraSalidaStr"].Visible = true;
            this.dgvgrilla.Columns["HoraSalidaParcialStr"].Visible = true;
            this.dgvgrilla.Columns["HoraEntradaParcialStr"].Visible = true;
            this.dgvgrilla.Columns["LunesStr"].Visible = true;
            this.dgvgrilla.Columns["MartesStr"].Visible = true;
            this.dgvgrilla.Columns["MiercolesStr"].Visible = true;
            this.dgvgrilla.Columns["JuevesStr"].Visible = true;
            this.dgvgrilla.Columns["ViernesStr"].Visible = true;
            this.dgvgrilla.Columns["SabadoStr"].Visible = true;
            this.dgvgrilla.Columns["DomingoStr"].Visible = true;

            this.dgvgrilla.Columns["FechaDesdeStr"].HeaderText = "Fecha Inicio";
            this.dgvgrilla.Columns["FechaHastaStr"].HeaderText = "Fecha Fin";
            this.dgvgrilla.Columns["HoraEntradaStr"].HeaderText = "Hora Inicio";
            this.dgvgrilla.Columns["HoraSalidaStr"].HeaderText = "Hora Fin";
            this.dgvgrilla.Columns["HoraSalidaParcialStr"].HeaderText = "Hora Salida Parcial";
            this.dgvgrilla.Columns["HoraEntradaParcialStr"].HeaderText = "Hora Entrada Parcial";
            this.dgvgrilla.Columns["LunesStr"].HeaderText = "Lunes";
            this.dgvgrilla.Columns["MartesStr"].HeaderText = "Martes";
            this.dgvgrilla.Columns["MiercolesStr"].HeaderText = "Miercoles";
            this.dgvgrilla.Columns["JuevesStr"].HeaderText = "Jueves";
            this.dgvgrilla.Columns["ViernesStr"].HeaderText = "Viernes";
            this.dgvgrilla.Columns["SabadoStr"].HeaderText = "Sabado";
            this.dgvgrilla.Columns["DomingoStr"].HeaderText = "Domingo";


        }
        private void dpHorarioEntrada_ValueChanged(object sender, EventArgs e)
        {
            
            //dtpHoraSalida.MinDate = dtpHoraEntrada.Value;
            if (dtpHoraSalida.Value < dtpHoraEntrada.Value) dtpHoraEntrada.Value = dtpHoraSalida.Value;
            dtpHoraSalidaParcial.MinDate = dtpHoraEntrada.Value;
            dtpHoraSalida.MinDate = dtpHoraEntrada.Value;         
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<DetalleHorarioDTO> listadeHorarios = listaHorarios;
           
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (this.dgvgrilla.RowCount>0)
            {

                listaHorarios.RemoveAt(this.dgvgrilla.CurrentRow.Index);
                this.dgvgrilla.DataSource = listaHorarios.ToList();

            }
        }

        private void dtpHoraSalida_ValueChanged(object sender, EventArgs e)
        {
            dtpHoraEntrada.MaxDate = dtpHoraSalida.Value;
            if (dtpHoraEntrada.Value > dtpHoraSalida.Value) dtpHoraEntrada.Value = dtpHoraSalida.Value;
            dtpHoraEntradaParcial.MaxDate = dtpHoraSalida.Value;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHorariosParciales.Checked)
            {

                this.dtpHoraEntradaParcial.Enabled = true;
                this.dtpHoraSalidaParcial.Enabled = true;

                //this.dtpHoraSalida.Value = dtpHoraEntrada.Value;
                //this.dtpHoraEntradaParcial.Value = dtpHoraEntrada.Value;
                //this.dtpHoraSalidaParcial.MinDate = this.dtpHoraEntrada.Value;
                //this.dtpHoraSalidaParcial.MaxDate = this.dtpHoraSalida.Value;
                //this.dtpHoraEntradaParcial.MinDate = this.dtpHoraEntrada.Value;
                //this.dtpHoraEntradaParcial.MaxDate = this.dtpHoraSalida.Value;
                this._horaEntradaParcial = (TimeSpan?)this.dtpHoraEntradaParcial.Value.TimeOfDay;
                this._horaSalidaParcial = (TimeSpan?)this.dtpHoraSalidaParcial.Value.TimeOfDay;

                //_horaEntradaParcial = (TimeSpan?)this.dtpHoraEntradaParcial.Value.TimeOfDay;
            }
            else
            {
                _horaEntradaParcial = null;
                _horaSalidaParcial = null;
                this.dtpHoraSalidaParcial.Enabled = false;
                this.dtpHoraEntradaParcial.Enabled = false;
            }


        }

        //private void checkBox3_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chkHoraSalidaParcial.Checked)
        //    {
                
        //        this.dtpHoraSalidaParcial.MinDate = this.dtpHoraEntrada.Value;
        //        this.dtpHoraSalidaParcial.MaxDate = this.dtpHoraSalida.Value;
        //        _horaSalidaParcial = (TimeSpan?)this.dtpHoraSalidaParcial.Value.TimeOfDay;
        //    }



        //}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _horarioServicio.AsignarHorarios(listaHorarios, IdAgente);
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.chkLunes.Checked = true;
            this.chkMartes.Checked = true;
            this.chkMiercoles.Checked = true;
            this.chkJueves.Checked = true;
            this.chkViernes.Checked = true;
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaHasta.MinDate = dtpFechaDesde.Value;
            if (dtpFechaHasta.Value < dtpFechaDesde.Value) dtpFechaHasta.Value = dtpFechaDesde.Value;
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaDesde.MaxDate = dtpFechaHasta.Value;
            if (dtpFechaDesde.Value > dtpFechaHasta.Value) dtpFechaDesde.Value = dtpFechaHasta.Value;
        }

        private void dtpHoraEntradaParcial_ValueChanged(object sender, EventArgs e)
        {
            
            this.dtpHoraEntradaParcial.MinDate = this.dtpHoraEntrada.Value;
            this.dtpHoraEntradaParcial.MaxDate = this.dtpHoraSalida.Value;
            if (dtpHoraEntradaParcial.Value < dtpHoraSalidaParcial.Value) dtpHoraEntradaParcial.Value = dtpHoraSalida.Value;
        }

        private void dtpHoraSalidaParcial_ValueChanged(object sender, EventArgs e)
        {
            
            this.dtpHoraSalidaParcial.MinDate = this.dtpHoraEntrada.Value;
            this.dtpHoraSalidaParcial.MaxDate = this.dtpHoraSalida.Value;
            if (dtpHoraSalidaParcial.Value > dtpHoraEntradaParcial.Value) dtpHoraSalidaParcial.Value = dtpHoraEntrada.Value;



        }

        private void btnSalir_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFechaHasta.Checked)
            {
                this.dtpFechaHasta.Enabled = true;
                this.dtpFechaHasta.Value = dtpFechaHasta.MinDate;
            }
            else 
            {
                this.dtpFechaHasta.Enabled = false;   
                this.dtpFechaHasta.Value = dtpFechaHasta.MaxDate;
            }
        }
    }
}
