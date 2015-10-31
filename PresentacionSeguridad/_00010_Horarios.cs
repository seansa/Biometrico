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
    public partial class _00010_Horarios : FormularioBase
    {

        IAgenteServicio _agenteServicio;
        IHorarioServicio _horarioServicio;
        public long IdAgente { get; set; }
        public _00010_Horarios()
        {
            InitializeComponent();
            _agenteServicio = new AgenteServicio();
            _horarioServicio = new HorarioServicio();


        }
        public _00010_Horarios(string Titulo):this()
        {
            this.lblTitle.Text = Titulo;
            lblTitulo.Font = NuevaFuente(RecursosCompartidos.OpenSans_Light, (long)20);
        }

        private void _00010_Horarios_Load(object sender, EventArgs e)
        {
            //var agente = _agenteServicio.ObtenerPorId(ayuda.idmio);
            var agente = _agenteServicio.ObtenerPorId(IdAgente);
            this.txtApyNom.Text = agente.Apellido + " " + agente.Nombre;
            this.txtLegajo.Text = agente.Legajo.ToString();
            this.txtDni.Text = agente.DNI.ToString();
            ActualizarGrilla();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var fhorarios = new PresentacionRecursoHumano._00011_ABM_Horario();
            fhorarios.IdAgente = this.IdAgente;
            fhorarios.ShowDialog();
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            this.dgvGrilla.DataSource = _horarioServicio.ObtenerHorariosPorId(IdAgente).ToList();
            FormatearGrilla(this.dgvGrilla);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            this.dgvGrilla.Columns["FechaDesdeStr"].Visible = true;
            this.dgvGrilla.Columns["FechaHastaStr"].Visible = true;
            this.dgvGrilla.Columns["HoraEntradaStr"].Visible = true;
            this.dgvGrilla.Columns["HoraSalidaStr"].Visible = true;
            this.dgvGrilla.Columns["HoraSalidaParcialStr"].Visible = true;
            this.dgvGrilla.Columns["HoraEntradaParcialStr"].Visible = true;
            this.dgvGrilla.Columns["LunesStr"].Visible = true;
            this.dgvGrilla.Columns["MartesStr"].Visible = true;
            this.dgvGrilla.Columns["MiercolesStr"].Visible = true;
            this.dgvGrilla.Columns["JuevesStr"].Visible = true;
            this.dgvGrilla.Columns["ViernesStr"].Visible = true;
            this.dgvGrilla.Columns["SabadoStr"].Visible = true;
            this.dgvGrilla.Columns["DomingoStr"].Visible = true;

            this.dgvGrilla.Columns["FechaDesdeStr"].HeaderText = "Fecha Inicio";
            this.dgvGrilla.Columns["FechaHastaStr"].HeaderText = "Fecha Fin";
            this.dgvGrilla.Columns["HoraEntradaStr"].HeaderText = "Hora Inicio";
            this.dgvGrilla.Columns["HoraSalidaStr"].HeaderText = "Hora Fin";
            this.dgvGrilla.Columns["HoraSalidaParcialStr"].HeaderText = "Hora Salida Parcial";
            this.dgvGrilla.Columns["HoraEntradaParcialStr"].HeaderText = "Hora Entrada Parcial";
            this.dgvGrilla.Columns["LunesStr"].HeaderText = "Lunes";
            this.dgvGrilla.Columns["MartesStr"].HeaderText = "Martes";
            this.dgvGrilla.Columns["MiercolesStr"].HeaderText = "Miercoles";
            this.dgvGrilla.Columns["JuevesStr"].HeaderText = "Jueves";
            this.dgvGrilla.Columns["ViernesStr"].HeaderText = "Viernes";
            this.dgvGrilla.Columns["SabadoStr"].HeaderText= "Sabado";
            this.dgvGrilla.Columns["DomingoStr"].HeaderText = "Domingo";

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
