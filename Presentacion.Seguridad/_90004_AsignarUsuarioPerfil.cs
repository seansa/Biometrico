using Servicio.Seguridad.Perfil;
using Servicio.Seguridad.PerfilUsuario;
using Servicio.Seguridad.PerfilUsuario.DTOs;
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
    public partial class _90004_AsignarUsuarioPerfil : PresentacionBase.FormularioBase
    {
        private readonly IPerfilUsuarioServicio _perfilUsuarioServicio;
        private readonly IServicioPerfil _perfilServicio;

        public _90004_AsignarUsuarioPerfil()
        {
            InitializeComponent();

            _perfilUsuarioServicio = new PerfilUsuarioServicio();
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

        private void _90004_AsignarUsuarioPerfil_Load(object sender, EventArgs e)
        {
            if (this.cmbPerfil.Items.Count > 0)
            {
                ActualizarNoAsignados(string.Empty);
                ActualizarAsignados(string.Empty);
            }
            else
            {
                this.dgvGrillaAsignados.DataSource = new List<PerfilUsuarioDTO>();
                this.dgvGrillaNoAsignados.DataSource = new List<PerfilUsuarioDTO>();
            }
        }
        
        private void ActualizarNoAsignados(string cadenaBuscar)
        {
            var resultado = _perfilUsuarioServicio.ObtenerUsuariosNoAsignados(Convert.ToInt32(this.cmbPerfil.SelectedValue), cadenaBuscar);

            this.dgvGrillaNoAsignados.DataSource = resultado.ToList();

            FormatearGrilla(this.dgvGrillaNoAsignados);
        }

        private void ActualizarAsignados(string cadenaBuscar)
        {
            var resultado = _perfilUsuarioServicio.ObtenerUsuariosAsignados(Convert.ToInt32(this.cmbPerfil.SelectedValue), cadenaBuscar);
            
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
            dgv.Columns["UsuarioId"].Visible = false;

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
            dgv.Columns["ApyNom"].HeaderText = "Apellido  y Nombre";
            dgv.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Dni"].Visible = true;
            dgv.Columns["Dni"].HeaderText = "Documento";
            dgv.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Dni"].Width = 120;

            dgv.Columns["NombreUsuario"].Visible = true;
            dgv.Columns["NombreUsuario"].HeaderText = "Usuario";
            dgv.Columns["NombreUsuario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["NombreUsuario"].Width = 150;

            dgv.Columns["EstaBloqueado"].Visible = true;
            dgv.Columns["EstaBloqueado"].HeaderText = "Bloqueado";
            dgv.Columns["EstaBloqueado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EstaBloqueado"].Width = 80;
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
                var usuariosNoAsignados = (List<PerfilUsuarioDTO>)this.dgvGrillaNoAsignados.DataSource;
                _perfilUsuarioServicio.AsignarUsuarios(usuariosNoAsignados
                    .Where(x=>x.Item)
                    .Select(x => x.UsuarioId).ToList(),
                    Convert.ToInt64(this.cmbPerfil.SelectedValue));

                var usuariosAsignados = (List<PerfilUsuarioDTO>)this.dgvGrillaAsignados.DataSource;
                _perfilUsuarioServicio.QuitarUsuarios(usuariosAsignados
                    .Where(x => x.Item)
                    .Select(x => x.UsuarioId).ToList(),
                    Convert.ToInt64(this.cmbPerfil.SelectedValue));

                ActualizarAsignados(string.Empty);
                ActualizarNoAsignados(string.Empty);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrión un error al Asignar o Quitar Usuarios", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
