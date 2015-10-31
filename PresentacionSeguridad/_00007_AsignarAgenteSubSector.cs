using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio.RecursoHumano.AgenteSubSector;
using Servicio.RecursoHumano.AgenteSubSector.DTOs;
using Servicio.RecursoHumano.Sector;
using Servicio.RecursoHumano.SubSector;

namespace PresentacionRecursoHumano
{
    public partial class _00007_AsignarAgenteSubSector : PresentacionBase.FormularioBase
    {
        private readonly IAgenteSubSectorServicio _agenteSubSectorServicio;
        private readonly ISubSectorServicio _subSectorServicio;
        private readonly ISectorServicio _sectorServicio;

        public _00007_AsignarAgenteSubSector()
        {
            InitializeComponent();

            _agenteSubSectorServicio = new AgenteSubSectorServicio();

            _subSectorServicio = new SubSectorServicio();

            _sectorServicio = new SectorServicio();

            this.WindowState = FormWindowState.Maximized;

            this.imgBuscarNoAsignados.Image = PresentacionBase.Imagenes.BotonBuscar;
            this.imgBuscarAsignados.Image = PresentacionBase.Imagenes.BotonBuscar;

            this.txtBuscarAsignados.Enter += Control_Enter;
            this.txtBuscarNoAsignado.Enter += Control_Enter;

            this.txtBuscarAsignados.Leave += Control_Leave;
            this.txtBuscarNoAsignado.Leave += Control_Leave;

            this.btnActualizar.Image = PresentacionBase.Imagenes.BotonActualizar;
            this.btnEjecutar.Image = PresentacionBase.Imagenes.BotonEjecutar;
            this.btnSalir.Image = PresentacionBase.Imagenes.BotonSalir;

            PoblarComboBox(this.cmbSector, _sectorServicio.ObtenerTodo(), "Descripcion");

            if (this.cmbSector.Items.Count > 0)
            {
                PoblarComboBox(this.cmbSubSector,
                    _subSectorServicio.ObtenerTodo(Convert.ToInt64(this.cmbSector.SelectedValue)),
                    "Descripcion");
            }
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _00007_AsignarAgenteSubSector_Load(object sender, EventArgs e)
        {
            if (this.cmbSubSector.Items.Count > 0)
            {
                ActualizarNoAsignados(string.Empty);
                ActualizarAsignados(string.Empty);
            }
            else
            {
                this.dgvGrillaAsignados.DataSource = new List<AgenteSubSectorDTO>();
                this.dgvGrillaNoAsignados.DataSource = new List<AgenteSubSectorDTO>();
            }
        }

        private void ActualizarNoAsignados(string cadenaBuscar)
        {
            var resultado = _agenteSubSectorServicio.ObtenerAgentesNoAsignados(Convert.ToInt32(this.cmbSubSector.SelectedValue), cadenaBuscar);

            this.dgvGrillaNoAsignados.DataSource = resultado.ToList();

            FormatearGrilla(this.dgvGrillaNoAsignados);
        }

        private void ActualizarAsignados(string cadenaBuscar)
        {
            var resultado = _agenteSubSectorServicio.ObtenerAgentesAsignados(Convert.ToInt32(this.cmbSubSector.SelectedValue), cadenaBuscar);

            this.dgvGrillaAsignados.DataSource = resultado;

            FormatearGrilla(this.dgvGrillaAsignados);
        }

        private void Activar(DataGridView dgv, bool estado)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv["Item", i].Value = estado;
            }
        }
        
        public override void FormatearGrilla(DataGridView dgv)
        {
            dgv.Columns["AgenteId"].Visible = false;

            dgv.Columns["Item"].Visible = true;
            dgv.Columns["Item"].HeaderText = "Item";
            dgv.Columns["Item"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Item"].Width = 60;

            dgv.Columns["Legajo"].Visible = true;
            dgv.Columns["Legajo"].HeaderText = "Legajo";
            dgv.Columns["Legajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Legajo"].Width = 100;

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Dni"].Visible = true;
            dgv.Columns["Dni"].HeaderText = "DNI";
            dgv.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Dni"].Width = 100;
        }

        private void btnBuscarNoAsignado_Click(object sender, EventArgs e)
        {
            ActualizarNoAsignados(this.txtBuscarNoAsignado.Text);
        }

        private void txtBuscarNoAsignado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                ActualizarNoAsignados(this.txtBuscarNoAsignado.Text);
                e.Handled = true;
            }
        }

        private void btnBuscarAsignados_Click(object sender, EventArgs e)
        {
            ActualizarAsignados(this.txtBuscarAsignados.Text);
        }

        private void txtBuscarAsignados_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                ActualizarAsignados(this.txtBuscarAsignados.Text);
                e.Handled = true;
            }
        }

        private void btnMarcarAsignados_Click(object sender, EventArgs e)
        {
            Activar(this.dgvGrillaAsignados, true);
        }

        private void btnDesmarcarAsignados_Click(object sender, EventArgs e)
        {
            Activar(this.dgvGrillaAsignados, false);
        }

        private void btnMarcaNoAsignados_Click(object sender, EventArgs e)
        {
            Activar(this.dgvGrillaNoAsignados, true);
        }

        private void btnDesmarcarNoAsignado_Click(object sender, EventArgs e)
        {
            Activar(this.dgvGrillaNoAsignados, false);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarAsignados(string.Empty);
            ActualizarNoAsignados(string.Empty);
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                var AgentesNoAsignados = (List<AgenteSubSectorDTO>)this.dgvGrillaNoAsignados.DataSource;
                _agenteSubSectorServicio.AsignarAgentes(AgentesNoAsignados
                    .Where(x => x.Item)
                    .Select(x => x.AgenteId).ToList(),
                    Convert.ToInt64(this.cmbSubSector.SelectedValue));

                var AgentesAsignados = (List<AgenteSubSectorDTO>)this.dgvGrillaAsignados.DataSource;
                _agenteSubSectorServicio.QuitarAgentes(AgentesAsignados
                    .Where(x => x.Item)
                    .Select(x => x.AgenteId).ToList(),
                    Convert.ToInt64(this.cmbSubSector.SelectedValue));

                ActualizarAsignados(string.Empty);
                ActualizarNoAsignados(string.Empty);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrión un error al Asignar o Quitar Agentes", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGrillaAsignados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvGrillaAsignados.RowCount > 0)
            {
                this.dgvGrillaAsignados.EndEdit();
            }
        }

        private void dgvGrillaNoAsignados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvGrillaNoAsignados.RowCount > 0)
            {
                this.dgvGrillaNoAsignados.EndEdit();
            }
        }

        private void txtBuscarNoAsignado_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = PresentacionBase.Colores.ColorControlConFoco;
        }

        private void txtBuscarNoAsignado_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = PresentacionBase.Colores.ColorControlSinFoco;
        }

        private void cmbSector_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbSubSector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbSubSector.Items.Count > 0)
            {
                ActualizarNoAsignados(string.Empty);
                ActualizarAsignados(string.Empty);
            }
            else
            {
                this.dgvGrillaAsignados.DataSource = new List<AgenteSubSectorDTO>();
                this.dgvGrillaNoAsignados.DataSource = new List<AgenteSubSectorDTO>();
            }
        }

        private void cmbSector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbSector.Items.Count > 0)
            {
                PoblarComboBox(this.cmbSubSector, _subSectorServicio.ObtenerTodo(Convert.ToInt64(this.cmbSector.SelectedValue)), "Descripcion");
            }
        }

        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
