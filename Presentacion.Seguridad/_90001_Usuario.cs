using PresentacionBase;
using Servicio.Seguridad.AccesoControles;
using Servicio.Seguridad.Usuario;
using Servicio.Seguridad.Usuario.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Seguridad
{
    public partial class _90001_Usuario : PresentacionBase.FormularioBase
    {
        private readonly IServicioUsuario _usuarioServicio;

        public _90001_Usuario()
        {
            InitializeComponent();

            _usuarioServicio = new ServicioUsuario();

            this.txtBuscar.Enter += Control_Enter;
            this.txtBuscar.Leave += Control_Leave;

            this.btnGrabar.Image = Imagenes.BotonEjecutar;
            this.btnSalir.Image = Imagenes.BotonSalir;
            this.imgBuscar.Image = Imagenes.BotonBuscar;
            this.btnBloquearUsuario.Image = Imagenes.BotonUsuario;
            this.btnResetearUsuario.Image = Imagenes.BotonResetearPassword;

            this.menu.BackColor = Colores.ColorMenuAccesoRapido;

            this.WindowState = FormWindowState.Maximized;

            AccesoControlesServicio.TieneAcceso(Identidad.NombreUsuario, this);
        }

        public _90001_Usuario(string tituloFormulario, string tituloGrilla)
            :this()
        {
            this.Text = tituloFormulario;
            this.lblTitulo.Text = tituloGrilla;
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

        private void _90001_Usuario_Load(object sender, EventArgs e)
        {
            Actualizar(string.Empty);
        }

        private void Actualizar(string cadenaBuscar)
        {
            this.dgvGrilla.DataSource = _usuarioServicio
                .ObtenerPorFiltro(cadenaBuscar);

            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Item"].Visible = true;
            dgv.Columns["Item"].Width = 60;
            dgv.Columns["Item"].HeaderText = "Item";
            dgv.Columns["Item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Item"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Legajo"].Visible = true;
            dgv.Columns["Legajo"].Width = 100;
            dgv.Columns["Legajo"].HeaderText = "Legajo";
            dgv.Columns["Legajo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Legajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Usuario"].Visible = true;
            dgv.Columns["Usuario"].Width = 100;
            dgv.Columns["Usuario"].HeaderText = "Usuario";
            dgv.Columns["Usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Usuario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["EstaBloqueadoStr"].Visible = true;
            dgv.Columns["EstaBloqueadoStr"].Width = 100;
            dgv.Columns["EstaBloqueadoStr"].HeaderText = "Bloqueado";
            dgv.Columns["EstaBloqueadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EstaBloqueadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = (List<UsuarioDTO>)this.dgvGrilla.DataSource;

                if (resultado.Any(x => x.Item))
                {
                    if (_usuarioServicio.CrearUsuarios(resultado.ToList()))
                    {
                        Mensaje.Mostrar("Los Usuarios se crearon correctamente", TipoMensaje.Aviso);
                        Actualizar(this.txtBuscar.Text);
                    }                    
                }
                else
                {
                    Mensaje.Mostrar("No hay agentes seleccionados", TipoMensaje.Aviso);
                }
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al crear los Usuarios",TipoMensaje.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Actualizar(this.txtBuscar.Text);
        }

        private void btnMarcaNoAsignados_Click(object sender, EventArgs e)
        {
            Activar(true);
        }

        private void Activar(bool estado)
        {
            if (this.dgvGrilla.RowCount > 0)
            {
                for (int i = 0; i < this.dgvGrilla.RowCount; i++)
                {
                    this.dgvGrilla["Item", i].Value = estado;

                }
            }
        }

        private void btnDesmarcarNoAsignado_Click(object sender, EventArgs e)
        {
            Activar(false);
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvGrilla.RowCount > 0)
            {
                this.dgvGrilla.EndEdit();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                Actualizar(this.txtBuscar.Text);
                e.Handled = true;
            }
        }
        
        private void BloquearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                var _listaUsuarios = (List<UsuarioDTO>)this.dgvGrilla.DataSource;

                _usuarioServicio.BloquearUsuario(_listaUsuarios);
                Actualizar(this.txtBuscar.Text);
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al bloquear / desbloquear", TipoMensaje.Error);
            }

        }

        private void btnResetearUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                var _listaUsuarios = (List<UsuarioDTO>)this.dgvGrilla.DataSource;

                _usuarioServicio.ResetearPassword(_listaUsuarios);
                Actualizar(this.txtBuscar.Text);
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al resetear el password", TipoMensaje.Error);
            }
        }
    }
}
