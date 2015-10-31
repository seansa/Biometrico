using Servicio.Seguridad.Perfil;
using Servicio.Seguridad.PerfilControles;
using Servicio.Seguridad.PerfilControles.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Seguridad
{
    public partial class _90006_AsignarControlPerfil : PresentacionBase.FormularioBase
    {
        private readonly IPerfilControlServicio _perfilControlServicio;
        private readonly IServicioPerfil _perfilServicio;

        public _90006_AsignarControlPerfil()
        {
            InitializeComponent();

            _perfilControlServicio = new PerfilControlServicio();
            _perfilServicio = new ServicioPerfil();

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

            PoblarComboBox(this.cmbPerfil, _perfilServicio.ObtenerTodo(), "Descripcion");
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

        private void _90006_AsignarControlPerfil_Load(object sender, EventArgs e)
        {
            if (this.cmbPerfil.Items.Count > 0)
            {
                ActualizarNoAsignados(string.Empty);
                ActualizarAsignados(string.Empty);
            }
            else
            {
                this.dgvGrillaAsignados.DataSource = new List<PerfilControlDTO>();
                this.dgvGrillaNoAsignados.DataSource = new List<PerfilControlDTO>();
            }
        }

        private void ActualizarNoAsignados(string cadenaBuscar)
        {
            var resultado = _perfilControlServicio.ObtenerControlesNoAsignados(Convert.ToInt32(this.cmbPerfil.SelectedValue), cadenaBuscar);

            this.dgvGrillaNoAsignados.DataSource = resultado.ToList();

            FormatearGrilla(this.dgvGrillaNoAsignados);
        }

        private void ActualizarAsignados(string cadenaBuscar)
        {
            var resultado = _perfilControlServicio.ObtenerControlesAsignados(Convert.ToInt32(this.cmbPerfil.SelectedValue), cadenaBuscar);

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

        private void btnNuevoPerfil_Click(object sender, EventArgs e)
        {
            var formulario = new _90003_ABM_Perfil();
            formulario.EntidadId = null;
            formulario.TipoOperacion = PresentacionBase.TipoOperacion.Insertar;
            formulario.ShowDialog();

            if (formulario.RealizoAlgunaOperacion)
            {
                PoblarComboBox(this.cmbPerfil, _perfilServicio.ObtenerTodo(), "Descripcion");
                ActualizarAsignados(string.Empty);
                ActualizarNoAsignados(string.Empty);
            }
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            dgv.Columns["ControlId"].Visible = false;

            dgv.Columns["Item"].Visible = true;
            dgv.Columns["Item"].HeaderText = "Item";
            dgv.Columns["Item"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Item"].Width = 60;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].HeaderText = "Control";
            dgv.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Formulario"].Visible = true;
            dgv.Columns["Formulario"].HeaderText = "Formulario";
            dgv.Columns["Formulario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Formulario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                var ControlsNoAsignados = (List<PerfilControlDTO>)this.dgvGrillaNoAsignados.DataSource;
                _perfilControlServicio.AsignarControles(ControlsNoAsignados
                    .Where(x => x.Item)
                    .Select(x => x.ControlId).ToList(),
                    Convert.ToInt64(this.cmbPerfil.SelectedValue));

                var ControlsAsignados = (List<PerfilControlDTO>)this.dgvGrillaAsignados.DataSource;
                _perfilControlServicio.QuitarControles(ControlsAsignados
                    .Where(x => x.Item)
                    .Select(x => x.ControlId).ToList(),
                    Convert.ToInt64(this.cmbPerfil.SelectedValue));

                ActualizarAsignados(string.Empty);
                ActualizarNoAsignados(string.Empty);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrión un error al Asignar o Quitar Controls", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPerfil_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbPerfil.Items.Count > 0)
            {
                ActualizarAsignados(string.Empty);
                ActualizarNoAsignados(string.Empty);
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
    }
}
